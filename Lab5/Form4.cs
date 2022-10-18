using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form4 : Form
    {
        private Graphics g;
        private Bitmap bmp;
        private bool IsAdding;
        private bool IsRemoving;
        private bool IsMoving;
        List<Point> ControlPoints;
        private int CircleRadius = 3;

        private int MovingPoint;
        public Form4()
        {
            InitializeComponent();
           
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            ControlPoints = new List<Point>();
            pictureBox1.Image = bmp;

            MovingPoint = -1;
            g = Graphics.FromImage(pictureBox1.Image);
            //  g.ScaleTransform(1.0F, -1.0F);
            //  g.TranslateTransform(0.0F, -pb.Height);

            g.Clear(Color.White);
           
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            IsAdding = true;
            IsRemoving = false;
            IsMoving = false;
        }

        private void DetermineAction(Point userPoint)
        {
            if (IsAdding)
            {
                AddPoint(userPoint);
            }
            if (IsRemoving)
            {
                RemovePoint(userPoint);
            }
            if (IsMoving)
            {
                MovingPoint = GetPointIndex(userPoint);
            }  
        }

        private void AddPoint(Point point)
        {
            g.DrawEllipse(Pens.Blue, point.X, point.Y, CircleRadius, CircleRadius);
            g.FillEllipse(Brushes.Blue, point.X, point.Y, CircleRadius, CircleRadius);
            ControlPoints.Add(point);
            pictureBox1.Invalidate();
        }

        private void MakeBesierSplines()
        {
            List<Point> points = new List<Point>() { new Point(), new Point() , new Point() , new Point() };
            Point middle = new Point(0,0);
            int ind = 0;
            for(int i = 0; i < ControlPoints.Count; i++)
            {
                if(ind == 2 && i < ControlPoints.Count - 2)
                {
                    middle.X = (ControlPoints[i].X + ControlPoints[i + 1].X) / 2;
                    middle.Y = (ControlPoints[i].Y + ControlPoints[i + 1].Y) / 2;
                }
                // 0 1 2 middle ; draw; middle 4 5 6;draw;
                if( ind == 3)
                {
                    if (!middle.IsEmpty)
                    {
                        points[ind] = middle;
                        MakeBesierCurve(points);
                        points[0] = middle;
                        ind = 1;
                        middle = Point.Empty;
                    }
                    else
                    {   
                        points[ind] = ControlPoints[i];
                        MakeBesierCurve(points);
                        ind = 0;
                    }
                }

                points[ind++] = ControlPoints[i];
              
            }

            if(ind > 0)
            {
                for (int i = ind; i < 4; i++)
                    points[i] = ControlPoints[ControlPoints.Count - 1];
                MakeBesierCurve(points);
            }
           
        }

        private void MakeBesierCurve(List<Point> points)
        {
            double xt = 0.0f, yt = 0.0f;
            
            
            for (double t = 0.0; t <= 1.0; t += 0.0001)
            {
                xt = Math.Pow(1 - t, 3) * points[0].X + 3 * t * Math.Pow(1 - t, 2) * points[1].X + 3 * Math.Pow(t, 2) * (1 - t) * points[2].X
                     + Math.Pow(t, 3) * points[3].X;
                yt = Math.Pow(1 - t, 3) * points[0].Y + 3 * t * Math.Pow(1 - t, 2) * points[1].Y + 3 * Math.Pow(t, 2) * (1 - t) * points[2].Y
                    + Math.Pow(t, 3) * points[3].Y;
                g.FillRectangle(Brushes.Red, (int)xt, (int)yt,1,1);
                
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            DetermineAction(e.Location);

        }

        private void Redraw()
        {
            g.Clear(Color.White);
          for(int i = 0; i < ControlPoints.Count; i++)
          {
                g.DrawEllipse(Pens.Blue, ControlPoints[i].X, ControlPoints[i].Y, CircleRadius, CircleRadius);
                g.FillEllipse(Brushes.Blue, ControlPoints[i].X, ControlPoints[i].Y, CircleRadius, CircleRadius);
          }
           
            pictureBox1.Invalidate();
            if (ControlPoints.Count > 3)
                MakeBesierSplines();
        }
         
        void RemovePoint(Point userPoint)
        {
            int point = GetPointIndex(userPoint);
            if (point>-1)
            {
                ControlPoints.RemoveAt(point);
                Redraw();
               
            }
            
        }

        private bool IsInCircle(Point center,Point userPoint)
        {
            return Math.Pow(center.X - userPoint.X, 2) + Math.Pow(center.Y - userPoint.Y, 2) <= CircleRadius * CircleRadius;
        }

        private int GetPointIndex(Point userPoint)
        {
            for(int i = 0; i < ControlPoints.Count; i++)
            {
                if (IsInCircle(ControlPoints[i], userPoint))
                    return i;
            }
            return -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (ControlPoints.Count > 3)
            {
                Redraw();
                MakeBesierSplines();
                pictureBox1.Invalidate();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            IsRemoving = true;
            IsAdding = false;
            IsMoving = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            MovePoint(e.Location);
        }

        private void MovePoint(Point newLocation)
        {
            if (IsMoving && MovingPoint != -1)
                ControlPoints[MovingPoint] = newLocation;
            Redraw();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            IsRemoving = false;
            IsAdding = false;
            IsMoving = true;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            MovingPoint = -1;
        }
    }
}
