using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace Lab3
{
    public partial class Form3 : Form
    {
        Point[] points = new Point[3];
        int CounterSetPoint;
        Bitmap bmp;
        PictureBox pbox;
        private void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private void ArrangePoints()
        {

            if (points[1].Y < points[0].Y) {
                Swap(ref points[1], ref points[0]);
            }
            if (points[2].Y < points[0].Y) {
                Swap(ref points[2], ref points[0]);
            }
            if (points[1].Y > points[2].Y) {
                Swap(ref points[1], ref points[2]);
            }
        }
        private void CalculateIncrements(ref double dx13,ref double dx12,ref double dx23)
        {
            if (points[2].Y != points[0].Y) {
                dx13 = points[2].X - points[0].X;
                dx13 /= points[2].Y - points[0].Y;
            }
            else {
                dx13 = 0;
            }

            if (points[1].Y != points[0].Y) {
                dx12 = points[1].X - points[0].X;
                dx12 /= points[1].Y -points[0].Y;
            }
            else {
                dx12 = 0;
            }

            if (points[2].Y != points[1].Y) {
                dx23 = points[2].X - points[1].X;
                dx23 /= points[2].Y - points[1].Y;
            }
            else {
                dx23 = 0;
            }
        }
        public static Color LerpRGB(Color a, Color b, float t)
        {
            Color colorRes = Color.FromArgb(Math.Abs((int)(a.A + (b.A - a.A) * t) % 256), Math.Abs((int)(a.R + (b.R - a.R) * t) % 256), Math.Abs((int)(a.G + (b.G - a.G) * t)%256), Math.Abs((int)(a.B + (b.B - a.B) * t) % 256));
            return colorRes;
        }
        private void CutTheTriangle(PaintEventArgs e)
        {
            double incrementForX13 = 0;
            double incrementForX12 = 0;
            double incrementForX23 = 0;
            double currentX1 = points[0].X;
            double currentX2 = currentX1;
            
            ArrangePoints();
            CalculateIncrements(ref incrementForX13, ref incrementForX12, ref incrementForX23);

            double _dx13 = incrementForX13;
            if (incrementForX13 > incrementForX12)
            {
                Swap(ref incrementForX13, ref incrementForX12);
            }
            float t = 0.3f;
            for (int i = points[0].Y; i < points[1].Y; i++)
            {
                
                for (int j = (int)currentX1; j <= (int)currentX2; j++)
                {
                    
                    Graphics g = e.Graphics;
                    Color red1 = ((Bitmap)pictureBox1.Image).GetPixel(1, 1);
                    Color red = LerpRGB(Color.Red,Color.Black , t);
                    SolidBrush myBrush = new SolidBrush(red);
                    g.FillRectangle(myBrush, j, i, 1, 1);
                    t += 0.00005f;
                }
                currentX1 += incrementForX13;
                currentX2 += incrementForX12;
            }
            if (points[0].Y == points[1].Y)
            {
                currentX1 = points[0].X;
                currentX2 = points[1].X;
            }
            if (_dx13 < incrementForX23)
            {
                Swap(ref _dx13, ref incrementForX23);
            }
            for (int i = points[1].Y; i <= points[2].Y; i++)
            {
                for (int j = (int)currentX1; j <= (int)currentX2; j++)
                {
                    Graphics g = e.Graphics;
                    Color red = LerpRGB(Color.Red, Color.Black, t);
                    SolidBrush myBrush = new SolidBrush(red);
                    g.FillRectangle(myBrush, j, i, 1, 1);
                    t += 0.00005f;
                }
                currentX1 += _dx13;
                currentX2 += incrementForX23;
            }
        }
        public void DrawPathGradentWthoutGraphicsPath(PaintEventArgs e)
        {
            // Construct a path gradient brush based on an array of points.
            PointF[] ptsF = { points[0], points[1], points[2] };

            PathGradientBrush pBrush = new PathGradientBrush(ptsF);

            // An array of five points was used to construct the path gradient
            // brush. Set the color of each point in that array.
            Color[] colors = {
       Color.FromArgb(255, 255, 0, 0),  // (0, 0) red
       Color.FromArgb(255, 0, 255, 0),  // (160, 0) green
       Color.FromArgb(255, 0, 0, 255) };  // (80, 150) blue

            pBrush.SurroundColors = colors;

            // Set the center color to white.
            //pBrush.CenterColor = Color.White;

            // Use the path gradient brush to fill a rectangle.
            e.Graphics.FillRectangle(pBrush, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
        }
        public Form3()
        {
            InitializeComponent();
            CounterSetPoint = 0;
            pbox = this.pictureBox1;
            bmp = new Bitmap(pbox.Width, pbox.Height);
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (CounterSetPoint > 2) { 
                CounterSetPoint = 0;
                pictureBox1.Invalidate();
            }
            points[CounterSetPoint] = new Point(e.X, e.Y);
            CounterSetPoint++;
            
           Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
            if (CounterSetPoint > 2) {
                e.Graphics.Clear(Color.White);
                e.Graphics.DrawPolygon(new Pen(Color.Black), points);
                var g = pictureBox1.CreateGraphics();
                CutTheTriangle(e);
                
            }
            
        }
    }
}
