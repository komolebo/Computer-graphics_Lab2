using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Bezier
{
    class MyModifier
    {
        private int x_size, x_center;
        private int y_size, y_center;
        private short MODE = 0; // 1 - rotate;    2 - zoom;   3 - move;

        private const int rotate_lines_len = 40;
        private const int zoom_lines_half_len = 20;
        private const int zoom_lines_offset = 10;

        private const int move_lines_offset = 10;
        private const int point_size = 3;

        private const int circle_radius = 150;
        private Bitmap bitmap;
        private Label dataX, dataY;

        public MyModifier(Label data_x, Label data_y, int _x_zize, int _y_size)
        {
            dataX = data_x;
            dataY = data_y;

            x_size = _x_zize;
            y_size = _y_size;

            x_center = (int)(x_size * .5);
            y_center = (int)(y_size * .5);
        }
        public void setMode(short mode)
        {
            MODE = mode;
        }
        public short getMode()
        {
            return MODE;
        }
        public void setBitmap(Bitmap bmp)
        {
            bitmap = bmp;
        }


        private Point point_pointer_vector(Point curr_pos, int R)
        {
            double alpha = get_alpha(curr_pos);

            int xf = x_center + (int)(R * Math.Cos(alpha));
            int yf = y_center + (int)(R * Math.Sin(alpha));
            return new Point(xf, yf);
        }
        public double get_alpha(Point curr_pos)
        {
            int x = curr_pos.X;
            int y = curr_pos.Y;

            double alpha = Math.Atan((y - y_center) / (double)(x - x_center));
            if (x < x_center && y < y_center)
                alpha = Math.PI + alpha;
            else
                if (x < x_center && y_center < y)
                    alpha = -(Math.PI - alpha);
            return alpha;
        }
        public void draw_initial_rotate(Point coords)
        {
            Pen rotate_pen = new Pen(Color.Navy, 5);
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawLine(rotate_pen, 0, y_center, rotate_lines_len, y_center);
            g.DrawLine(rotate_pen, x_size - 1 - rotate_lines_len, y_center, x_size - 1, y_center);
            g.DrawLine(rotate_pen, x_center, 0, x_center, rotate_lines_len);
            g.DrawLine(rotate_pen, x_center, y_size - 1 - rotate_lines_len, x_center, y_size - 1);

            g.DrawLine(rotate_pen, point_pointer_vector(coords, (int)(circle_radius * .5)), point_pointer_vector(coords, circle_radius));
        }
        public void Rotate(Point coords, List<Point> points, List<Point> fixed_points)
        {
            double angle = get_alpha(coords);

            for (int i = 0; i < fixed_points.Count; i++)
            {
                int dx = fixed_points[i].X - x_center;
                int dy = fixed_points[i].Y - y_center;

                points[i] = (new Point((int)(x_center + dx * Math.Cos(angle) - dy * Math.Sin(angle)),
                    (int)(y_center + dx * Math.Sin(angle) + dy * Math.Cos(angle))));
            }
            dataX.Text = "Rad:  " + Convert.ToString(angle);
            dataY.Text = "Grad: " + Convert.ToString(angle / (double)Math.PI * 180);
        }
        private double x_zoom_now(double x_zoom, Point cursor_location)
        {
            return x_zoom - x_zoom * (x_size - cursor_location.X) / (double)x_size;
        }
        private double y_zoom_now(double y_zoom, Point cursor_location)
        {
            return y_zoom - y_zoom * (453 - (cursor_location.Y)) / (double)453;
        }
        public double max_y_zoom(List<Point> points)
        {
            int max_coordinate = points[0].Y;
            int min_coordinate = points[0].Y;

            for (int i = 1; i < points.Count; i++)
            {
                if (points[i].Y < min_coordinate)
                    min_coordinate = points[i].Y;
                if (points[i].Y > max_coordinate)
                    max_coordinate = points[i].Y;
            }

            double y = Math.Max(max_coordinate, y_size - min_coordinate);
            return (y_size * .5 - 3) / (double)(y - y_size * .5);
        }
        public double max_x_zoom(List<Point> points)
        {
            int max_coordinate = points[0].X;
            int min_coordinate = points[0].X;

            for (int i = 1; i < points.Count; i++)
            {
                if (points[i].X < min_coordinate)
                    min_coordinate = points[i].X;
                if (max_coordinate < points[i].X)
                    max_coordinate = points[i].X;
            }

            double x = Math.Max(max_coordinate, x_size - min_coordinate);
            return (x_center - 3) / (double)(x - x_center);
        }
        public void Zoom(double x_zoom, double y_zoom, Point mouse_position, List<Point> fixed_points, List<Point> points)
        {
            double mx = x_zoom_now(x_zoom, mouse_position);
            double my = y_zoom_now(y_zoom, mouse_position);

            for (int i = 0; i < fixed_points.Count; i++)
            {
                int x = (int)((fixed_points[i].X - x_center) * mx + x_center);
                int y = (int)((fixed_points[i].Y - y_center) * my + y_center);
                points[i] = new Point(x, y);
            }

            draw_zoom_lines(mouse_position);
            dataX.Text = "X-zoom: " + Convert.ToString(mx);
            dataY.Text = "Y-zoom: " + Convert.ToString(my);
        }
        public void Move(MouseEventArgs mouse_events, Point move_center, List<Point> points_from_center, List<Point> points)
        {
            int dx = mouse_events.X - move_center.X;
            int dy = mouse_events.Y - move_center.Y;

            bool let_X = true;
            bool let_Y = true;
            for (int i = 0; i < points_from_center.Count; i++)
            {
                int x = points_from_center[i].X + mouse_events.X;
                int y = points_from_center[i].Y + mouse_events.Y;

                if (x < point_size || x_size - point_size <= x)
                    let_X = false;
                if (y < point_size || y_size - point_size <= y)
                    let_Y = false;
            }

            for (int i = 0; i < points.Count; i++)
            {

                int x = points[i].X;
                int y = points[i].Y;
                if (let_X)
                    x = points_from_center[i].X + mouse_events.X;
                if (let_Y)
                    y = points_from_center[i].Y + mouse_events.Y;

                points[i] = new Point(x, y);
            }

            draw_move_lines(points);

            dataX.Text = "X: " + Convert.ToString(dx);
            dataY.Text = "Y: " + Convert.ToString(dy);
        }
        private void draw_zoom_lines(Point cursor_location)
        {
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawLine(new Pen(Color.Navy, 5), zoom_lines_offset, cursor_location.Y - zoom_lines_half_len, zoom_lines_offset, cursor_location.Y + zoom_lines_half_len);
            g.DrawLine(new Pen(Color.Navy, 5), cursor_location.X - zoom_lines_half_len, y_size - zoom_lines_offset, cursor_location.X + zoom_lines_half_len, y_size - zoom_lines_offset);
        }
        public void draw_move_lines(List<Point> points)
        {
            Graphics g = Graphics.FromImage(bitmap);
            Pen move_pen = new Pen(Color.Navy, 5);

            g.DrawLine(move_pen, move_lines_offset, min_coordinate_Y(points), move_lines_offset, max_coordinate_Y(points));
            g.DrawLine(move_pen, min_coordinate_X(points), y_size - zoom_lines_offset, max_coordinate_X(points), y_size - zoom_lines_offset);
        }

        public int min_coordinate_X(List<Point> points)
        {
            int min_coordinate_x = points[0].X;
            for (int i = 1; i < points.Count; i++)
                if (points[i].X < min_coordinate_x)
                    min_coordinate_x = points[i].X;
            return min_coordinate_x;
        }

        public int max_coordinate_X(List<Point> points)
        {
            int max_coordinate_x = points[0].X;
            for (int i = 1; i < points.Count; i++)
                if (max_coordinate_x < points[i].X)
                    max_coordinate_x = points[i].X;
            return max_coordinate_x;
        }

        public int min_coordinate_Y(List<Point> points)
        {
            int min_coordinate_y = points[0].Y;
            for (int i = 1; i < points.Count; i++)
                if (points[i].Y < min_coordinate_y)
                    min_coordinate_y = points[i].Y;
            return min_coordinate_y;
        }

        public int max_coordinate_Y(List<Point> points)
        {
            int max_coordinate_y = points[0].Y;
            for (int i = 1; i < points.Count; i++)
                if (max_coordinate_y < points[i].Y)
                    max_coordinate_y = points[i].Y;
            return max_coordinate_y;
        }
    }
}
