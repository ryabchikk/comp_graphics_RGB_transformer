using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    class PointWorker
    {
        private Graphics g;
        private Bitmap bmp;
        private PictureBox pb;
        Label pointPerEdge;
        Label intersectionPoint;
        Label PolygonPoint;

        public PointWorker(PictureBox _Pb, Graphics _g, Bitmap _bmp,Label l,Label l1,Label l2)
        {

            g = _g;
            bmp = _bmp;
            pb = _Pb;
            pointPerEdge = l;
            intersectionPoint = l1;
            PolygonPoint = l2;
        }

        private Point GetVector((Point f, Point s) line)
        {
            return new Point(line.s.X - line.f.X, line.s.Y - line.f.Y);
        }

        private int GetScalarMult (Point f,Point s)
        {
            return f.X * s.X + f.Y * s.Y;
        }

        private Point NumberMult(int t, Point v)
        {
            return new Point(t * v.X, t * v.Y);
        }

        public void FindIntersection((Point f,Point s) first, (Point f, Point s) second)
        {
            Point dc = GetVector(second);
            Point ba = GetVector(first);
            Point n = new Point(-dc.Y, dc.X);
            int div = GetScalarMult(n, ba);
            if (div != 0)
            {
                Point ac = new Point(first.f.X - second.f.X, first.f.Y - second.f.Y);

                double t =  -1 * GetScalarMult(n, ac)*1.0/div;
                
                Point intersection = new Point((int)((first.s.X - first.f.X)*t + first.f.X), (int)(t*(first.s.Y - first.f.Y) + first.f.Y));
                g.FillEllipse(Brushes.Red, intersection.X, intersection.Y,5 , 5);
                intersectionPoint.Text = "Точка пересечения: " + intersection.X + ", " + intersection.Y;
                pb.Invalidate();
            }
            else
                intersectionPoint.Text = "Точка пересечения: не существует";
        }

        public bool IsInPolygon()
        {
            return false;
        }

        public void PrintPointLocation((Point s,Point f) Line,Point userPoint)
        {
            int line_temp_x = Line.f.X - Line.s.X;
            int line_temp_Y = Line.f.Y - Line.s.Y;

            int user_temp_x = userPoint.X - Line.s.X;
            int user_temp_y = userPoint.Y - Line.s.Y;

            int sin = user_temp_y * line_temp_x - user_temp_x * line_temp_Y;
            if(sin  > 0)
                pointPerEdge.Text = "Положение точки: " + "Слева";
            else if (sin < 0)
                pointPerEdge.Text = "Положение точки: " + "Справа";
            else
                pointPerEdge.Text = "Положение точки: " + "На ребре";
        }

    }
}
