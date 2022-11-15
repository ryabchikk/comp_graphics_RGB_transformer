using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class Line3D
    {
        public Point3D P1 { get; set; }
        public Point3D P2 { get; set; }
        public Line3D(Point3D p1,Point3D p2)
        {
            P1 = p1;
            P2 = p2;
           
        }

        public void ApplyTransformation(Transform t)
        {
            P1.ApplyTransformation(t);
            P2.ApplyTransformation(t);
        }

        public void Draw(Graphics g)
        {
            P1.Draw(g);
            P2.Draw(g);
            var p1Res = P1.ConvertTo2D();
            var p2Res = P2.ConvertTo2D();
            g.DrawLine(Pens.Black, (float)p1Res[0], (float)p1Res[1], (float)p2Res[0], (float)p2Res[1]);
          
        }

        public void Draw(Graphics g, Pen p)
        {
            P1.Draw(g);
            P2.Draw(g);
            var p1Res = P1.ConvertTo2D();
            var p2Res = P2.ConvertTo2D();
            g.DrawLine(p, (float)p1Res[0], (float)p1Res[1], (float)p2Res[0], (float)p2Res[1]);
            
        }

    }
}
