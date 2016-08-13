using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bezier
{
    public partial class MainForm : Form
    {
        private MyDrawer myDrawer;
        private MyModifier myModifier;

        private List<Point> fixed_points = new List<Point>();
        private List<Point> points_from_center = new List<Point>();

        private Point move_center;

        double x_zoom, y_zoom;

        public MainForm()
        {
            InitializeComponent();

            int x_size = pbox.Size.Width;
            int x_center = (int)(x_size * .5);

            int y_size = pbox.Size.Height;
            int y_center = (int)(y_size * .5);

            myDrawer = new MyDrawer(new Bitmap(x_size, y_size), pbox, x_size, y_size);
            myModifier = new MyModifier(dataX, dataY, x_size, y_size);
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            myDrawer.reloadBitmap();
            myDrawer.draw_points();
            myDrawer.draw_curve();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                myDrawer.bitmap.Save(saveFileDialog.FileName);
        }

        private void pbox_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_events = (MouseEventArgs)e;
            Point coords = new Point(mouse_events.X, mouse_events.Y);

            if(myModifier.getMode() == 0)
            {
                myDrawer.draw_point(coords, 3);                
                myDrawer.points.Add(coords);
                if (myDrawer.points.Count >= 2)
                {
                    bDraw.BackgroundImage = Image.FromFile("icons/run1.png");
                    bRotate.Enabled = bZoom.Enabled = bMove.Enabled = true;
                    bRotate.ForeColor = bZoom.ForeColor = bMove.ForeColor = Color.LimeGreen;
                }
                return;
            }
            if (myModifier.getMode() != 0)
                myModifier.setMode(0);

            myDrawer.reloadBitmap();
            myDrawer.draw_points();
            myDrawer.draw_curve();

            dataX.Text = dataY.Text = "";
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            myDrawer.points.Clear();
            myDrawer.reloadBitmap();

            bDraw.BackgroundImage = Image.FromFile("icons/run0.png");
            bRotate.Enabled = bZoom.Enabled = bMove.Enabled = false;
            bRotate.ForeColor = bZoom.ForeColor = bMove.ForeColor = Color.Gray;

            myModifier.setMode(0);

            dataX.Text = dataY.Text = "";
        }

        private void bRotate_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_events = (MouseEventArgs)e;
            Point coords = new Point(mouse_events.X, mouse_events.Y);
            myModifier.setMode(1);

            fixed_points = new List<Point>(myDrawer.points);

            myDrawer.reloadBitmap();
            myModifier.setBitmap(myDrawer.bitmap);
            myModifier.draw_initial_rotate(coords);
            myDrawer.draw_points();

            pbox.Image = myDrawer.bitmap;
        }

        private void pbox_MouseMove(object sender, MouseEventArgs e)
        {
            MouseEventArgs mouse_events = (MouseEventArgs)e;

            if (myModifier.getMode() == 0) return;

            if (myModifier.getMode() == 1) // Rotate
            {
                myDrawer.reloadBitmap();
                myModifier.setBitmap(myDrawer.bitmap);

                myModifier.Rotate(new Point(mouse_events.X, mouse_events.Y), myDrawer.points, fixed_points);
                myModifier.draw_initial_rotate(new Point(mouse_events.X, mouse_events.Y));
            }
            else
                if (myModifier.getMode() == 2)  // Zoom
                {
                    myDrawer.reloadBitmap();
                    myModifier.setBitmap(myDrawer.bitmap);
                    myModifier.Zoom(x_zoom, y_zoom, new Point(mouse_events.X, mouse_events.Y), fixed_points, myDrawer.points);
                    
                }
                else
                    if (myModifier.getMode() == 3)  // Move
                    {
                        myDrawer.reloadBitmap();

                        myModifier.setBitmap(myDrawer.bitmap);
                        myModifier.Move(mouse_events, move_center, points_from_center, myDrawer.points);
                    }
            myDrawer.draw_points();
            pbox.Image = myDrawer.bitmap;
        }

        private void bZoom_Click(object sender, EventArgs e)
        {
            myModifier.setMode(2);
            fixed_points = new List<Point>(myDrawer.points);

            x_zoom = myModifier.max_x_zoom(fixed_points);
            y_zoom = myModifier.max_y_zoom(fixed_points);
        }


        private void bMove_Click(object sender, EventArgs e)
        {
            myModifier.setMode(3);
            move_center = calculate_center_figure(myDrawer.points);

            points_from_center = new List<Point>();
            for (int i = 0; i < myDrawer.points.Count; i++)
                points_from_center.Add(new Point(myDrawer.points[i].X - move_center.X, myDrawer.points[i].Y - move_center.Y));

            myModifier.setBitmap(myDrawer.bitmap);
            myModifier.draw_move_lines(myDrawer.points);
            myDrawer.draw_points();
        }

        private Point calculate_center_figure(List<Point> points)
        {
            int center_X = 0;
            int center_Y = 0;
            for (int i = 0; i < points.Count; i++)
            {
                center_X += points[i].X;
                center_Y += points[i].Y;
            }
            return new Point(center_X / points.Count, center_Y / points.Count);
        }
        private async void DONTtouchIT(object sender, EventArgs e)
        {

        }
    }
}

