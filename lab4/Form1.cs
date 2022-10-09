using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form1 : Form
    {
        PictureBox pb;
        private PrimitiveDrawer drawer;
        private Graphics g;
        private Bitmap bmp;
        private AffineTransformator affine;
        Point p;
        PointWorker pw;
        public Form1()
        {
            InitializeComponent();
            RadioButton[] primitivesRadioButtons = new RadioButton[3] { DotRadioButton, LineRadioButton, PolygonRadioButton };

            pb = pictureBox1;
            bmp = new Bitmap(pb.Width, pb.Height);

            pictureBox1.Image = bmp;

            g = Graphics.FromImage(pictureBox1.Image);
            g.ScaleTransform(1.0F, -1.0F);
            g.TranslateTransform(0.0F, -pb.Height);

            drawer = new PrimitiveDrawer(pb,g,bmp, primitivesRadioButtons);
            pw = new PointWorker(pb, g, bmp, label1, label2,label3);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

     
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsDrawing())
            {
                drawer.Draw(e.Location);
            }
            else
                p = e.Location;
           
        }

        private bool IsDrawing() => DotRadioButton.Checked || LineRadioButton.Checked || PolygonRadioButton.Checked;

        private void button2_Click(object sender, EventArgs e)
        {
            
            int x = string.IsNullOrEmpty(textBox1.Text) ? 0 : int.Parse(textBox1.Text);
            int y = string.IsNullOrEmpty(textBox2.Text) ? 0 : int.Parse(textBox2.Text);

            if (MoveRadioButton.Checked)
            {
                affine.Move(x, y);
                return;
            }

            if (ScalingRadioButton.Checked)
            {
               
                if (checkBox1.Checked)
                {
                    affine.Scale(x, y,p);
                    return;
                } else
                    affine.Scale(x, y, Point.Empty);
            }

            if (RotateRadioButton.Checked)
            {
               int angle = string.IsNullOrEmpty(textBox3.Text) ? 0 : int.Parse(textBox3.Text);
                if (checkBox1.Checked)
                {
                    affine.Rotate(angle, p);
                    return;
                }
                else
                    affine.Rotate(angle,Point.Empty);

            }
            

            /* тест точки пересечения
            Point p1 = new Point(30, 50);
            Point p2 = new Point(30, 400);

            Point p3 = new Point(20, 250);
            Point p4 = new Point(20, 40);

            g.DrawLine(Pens.Black, p1, p2);
            g.DrawLine(Pens.Black, p3, p4);

            pw.FindIntersection((p3, p4), (p2, p1));

            pb.Invalidate();
            */
            
            /* 
             * тест расположение точки
            Point p1 = new Point(30, 50);
            Point p2 = new Point(330, 300);
            Point p3 = new Point(350, 200);
            g.DrawLine(Pens.Black, p1, p2);
            g.FillEllipse(Brushes.Black, p3.X, p3.Y, 3, 3);
            pw.PrintPointLocation((p1, p2), p3);
            pb.Invalidate();
            */

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
