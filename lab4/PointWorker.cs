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
            pointPerEdge = l2;
            intersectionPoint = l;
            PolygonPoint = l1;
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
        
        private PointF GetIntersectionPoint((Point f, Point s) first, (Point f, Point s) second)
        {
            //second - cd ; first = ab
            Point dc = GetVector(second); 
            Point ba = GetVector(first);  
            Point n = new Point(-dc.Y, dc.X); 
        
            int div = GetScalarMult(n, ba); 
            if (div != 0)
            {
                Point ac = new Point(first.f.X - second.f.X, first.f.Y - second.f.Y);

                float t = -1*GetScalarMult(n, ac) * 1.0f / div; 
                Point k = new Point(-ba.Y, ba.X);

                float u = -1*GetScalarMult(k, ac) * 1.0f / div;

                if (u>=0 && u< 1 && t >= 0 && t <= 1)
                {
                    PointF intersection = new PointF(((first.s.X - first.f.X) * t + first.f.X), (t * (first.s.Y - first.f.Y) + first.f.Y));
                    return intersection;
                }
            }
            



            return PointF.Empty;
        } 

        public void FindIntersection((Point f,Point s) first, (Point f, Point s) second)
        {
            PointF intersection = GetIntersectionPoint(first, second);
            if (!intersection.IsEmpty)
            {
                g.FillEllipse(Brushes.Red, intersection.X, intersection.Y,5 , 5);
                intersectionPoint.Text = "Точка пересечения: " + intersection.X + ", " + intersection.Y;
                pb.Invalidate();
            }
            else
                intersectionPoint.Text = "Точка пересечения: не существует";
        }

        public void PrintPointIsInPolygon(Point userPoint, List<Point> Polygon)
        {
            PolygonPoint.Text = "fuuck";
            //PolygonPoint.Text = "Принадлежит полигону:" + (IsInPolygon(userPoint, Polygon) ? "Da" : "Net");
        }

        public bool IsInPolygon(Point userPoint,List<Point> Polygon)
        {   
            if(Polygon.Count < 3)
              return false;
            Point inf = new Point(pb.Width,userPoint.Y);
            int count = 0;
            
            for(int i=0;i<Polygon.Count-1;i++)
            {

                PointF intersection = GetIntersectionPoint((Polygon[i], Polygon[i + 1]), (userPoint, inf));
                if (!intersection.IsEmpty)
                {
                    if (AreColinear(Polygon[i], userPoint, Polygon[i + 1]))
                        return LiesOnLine((Polygon[i], Polygon[i + 1]), userPoint);
                    count++;
                }

            }

            PointF intersect = GetIntersectionPoint((Polygon[Polygon.Count - 1], Polygon[0]), (userPoint, inf));
            if (!intersect.IsEmpty)
            {
                if (AreColinear(Polygon[Polygon.Count - 1], userPoint, Polygon[0]))
                    return LiesOnLine((Polygon[Polygon.Count - 1], Polygon[0]), userPoint);
                count++;
            }

            return count % 2 != 0;
        }

        private bool LiesOnLine((Point f,Point s) Line,Point p)
        {
            return (p.X <= Math.Max(Line.f.X, Line.s.X)) && (p.X >= Math.Min(Line.f.X, Line.s.X)
                && (p.Y >= Math.Min(Line.s.Y, Line.f.Y)) && (p.Y <= Math.Max(Line.s.Y, Line.f.Y))); 
        }

        private bool AreColinear(Point p,Point p1,Point p2)
        {
            return p.X * (p1.Y - p2.Y) + p1.X * (p.Y - p2.Y) + p2.X * (p.Y - p1.Y) == 0;
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
