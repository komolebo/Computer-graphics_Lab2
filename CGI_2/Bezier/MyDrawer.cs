using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Bezier
{
    class MyDrawer
    {
        private Color colorLine = Color.LightGreen, colorPoint = Color.Red;
        private int x_size, y_size;
        public Bitmap bitmap;

        private PictureBox display;
        public List<Point> points = new List<Point>();
        public MyDrawer(Bitmap bmp, PictureBox pBox, int _x_size, int _y_size)
        {
            display = pBox;
            bitmap = bmp;
            x_size = _x_size;
            y_size = _y_size;
        }
        public void reloadBitmap()
        {
            bitmap = new Bitmap(x_size, y_size);
            display.Image = bitmap;
        }
        private double getFact(double x)
        {
            return (x == 0) ? 1 : x * getFact(x - 1);
        }
        private double getB_i(int i, int n, double t) 
        {
            return getFact(n) / (double)(getFact(i) * getFact(n - i)) * Math.Pow(1 - t, n - i) * Math.Pow(t, i);
        }

        public void draw_curve()
        {
            if (points.Count >= 2)
                for (double t = 0; t <= 1; t += 0.0001)
                {
                    double x = 0;
                    double y = 0;
                    for (int i = 0; i < points.Count; i++)
                    {
                        double b_i = getB_i(i, points.Count - 1, t);
                        x += b_i * points[i].X;
                        y += b_i * points[i].Y;
                    }

                    bitmap.SetPixel((int)x, (int)y, colorLine);
                }
            display.Image = bitmap;
        }
        public void draw_point(Point point, int size)
        {
            if (point.X + size > x_size || point.Y + size > y_size || point.X - size < 0 || point.Y - size < 0)
                return;

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    bitmap.SetPixel(point.X + i, point.Y + j, colorPoint);
                    bitmap.SetPixel(point.X - i, point.Y - j, colorPoint);
                    bitmap.SetPixel(point.X + i, point.Y - j, colorPoint);
                    bitmap.SetPixel(point.X - i, point.Y + j, colorPoint);
                }
            display.Image = bitmap;
        }
        public void draw_points()
        {
            for (int i = 0; i < points.Count; i++)
                draw_point(points[i], 3);
        }

    }
}
