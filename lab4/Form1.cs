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
        List<Segment> segments = new List<Segment>();
        List<Point> polygon = new List<Point>();
        Point startPoint, endPoint, minPolygonCoord, maxPolygonCoord;
        Point pointLocation;
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

            g.Clear(Color.White);
            LineRadioButton.Checked = true;
            startPoint = Point.Empty;
            endPoint = Point.Empty;
            pointLocation = new Point(0, 0);
            GroupBox GB1 = groupBox1; 
            GB1.Controls.Add(DotRadioButton);
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
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            g.ScaleTransform(1.0F, -1.0F);
            g.TranslateTransform(0.0F, -pb.Height);
            segments.Clear();
            polygon.Clear();
            pointLocation = Point.Empty;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
            
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsDrawing())
            {
                startPoint = e.Location;

                if (PolygonRadioButton.Checked && polygon.Count == 0)
                {
                    minPolygonCoord = e.Location;
                    maxPolygonCoord = e.Location;
                    polygon.Add(startPoint);
                }
            }
            else
                p = e.Location;
           
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (LineRadioButton.Checked && IsDrawing())
            {
                endPoint = e.Location;
            }
            else if (PolygonRadioButton.Checked && IsDrawing())
            {
                endPoint = e.Location;
            }
            pictureBox1.Invalidate();
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (LineRadioButton.Checked && IsDrawing())
            {
                if (endPoint == Point.Empty)
                    return;
                segments.Add(new Segment(startPoint, endPoint));
                startPoint = Point.Empty;
                endPoint = Point.Empty;

            }
            else if (PolygonRadioButton.Checked && IsDrawing())
            {
                if (endPoint == Point.Empty)
                    return;
                polygon.Add(endPoint);
                if (endPoint.X < minPolygonCoord.X)
                    minPolygonCoord.X = endPoint.X;
                if (endPoint.Y < minPolygonCoord.Y)
                    minPolygonCoord.Y = endPoint.Y;
                if (endPoint.X > maxPolygonCoord.X)
                    maxPolygonCoord.X = endPoint.X;
                if (endPoint.Y > maxPolygonCoord.Y)
                    maxPolygonCoord.Y = endPoint.Y;

                startPoint = endPoint;
                endPoint = Point.Empty;
            }

            else if (DotRadioButton.Checked)
            {
                pointLocation = e.Location;
            }
            pictureBox1.Invalidate();
        }

        private bool IsDrawing() => DotRadioButton.Checked || LineRadioButton.Checked || PolygonRadioButton.Checked;

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        { 
            
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            if (segments.Count > 0)
            {
                foreach (Segment seg in segments)
                    g.DrawLine(Pens.Red, seg.leftP, seg.rightP);
            }

            if (polygon.Count > 1)
            {
                for (int i = 0; i < polygon.Count - 1; ++i)
                {
                    g.DrawLine(Pens.Red, polygon[i], polygon[i + 1]);
                }
                g.DrawLine(Pens.Red, polygon[0], polygon[polygon.Count - 1]);
                pictureBox1.Invalidate();

            }
            //пока тянешь ребро
            if (startPoint != Point.Empty && endPoint != Point.Empty)
                g.DrawLine(Pens.Red, startPoint, endPoint);
            //точка
            g.DrawEllipse(Pens.Blue, pointLocation.X - 1, pointLocation.Y - 1, 3, 3);
            g.FillEllipse(Brushes.Blue, pointLocation.X - 1, pointLocation.Y - 1, 3, 3);

            pictureBox1.Invalidate();
            //подключить обновление состояний Антона
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
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

            */
            /*
           //тест точки пересечения
            Point p1 = new Point(30, 50);
            Point p2 = new Point(30, 400);

            Point p3 = new Point(20, 250);
            Point p4 = new Point(120, 40);

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
            /*
            List<Point> lst = new List<Point>();
            Point p1 = new Point(30, 50);
            Point p2 = new Point(330, 300);
            Point p3 = new Point(350, 200);
            Point p4 = new Point(400, 400);
            g.DrawLine(Pens.Black, p1, p2);
            g.DrawLine(Pens.Black, p2, p3);
            g.DrawLine(Pens.Black, p3, p4);
            g.DrawLine(Pens.Black, p1, p4);

            lst.Add(p1);
            lst.Add(p2);
            lst.Add(p3);
            lst.Add(p4);

            g.FillEllipse(Brushes.Black, 370, 330, 3, 3);
            pw.FindIntersection((p1, p4), (new Point(371, 330), new Point(571, 330)));
            pb.Invalidate();
          //  label2.Text = "Принадлежит полигону:" + (pw.IsInPolygon(new Point(370, 330), lst) ? "Da" : "Net");
             */

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }

    class Segment
    {
        public Point leftP, rightP;

        public Segment() { leftP = new Point(); rightP = new Point(); }

        public Segment(Point l, Point r) { leftP = l; rightP = r; }
    }
}
