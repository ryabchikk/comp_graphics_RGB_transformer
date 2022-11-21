using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab7
{
    class Tetrahedron : Primitive
    {
        // первые три точки - основание тетраэдра, четвертая точка - его вершина
        private List<Point3D> points = new List<Point3D>();

        private List<Line3D> verges = new List<Line3D>();

        public List<Point3D> Points { get { return points; } }
        public List<Line3D> Verges { get { return verges; } }

        public Point3D Center
        {
            get
            {
                Point3D p = new Point3D(0, 0, 0);
                for (int i = 0; i < 4; i++)
                {
                    p.X += Points[i].X;
                    p.Y += Points[i].Y;
                    p.Z += Points[i].Z;
                }
                p.X /= 4;
                p.Y /= 4;
                p.Z /= 4;
                return p;
            }
        }

        public Tetrahedron(float size)
        {
            float h = (float)Math.Sqrt(2.0 / 3.0) * size;
            points = new List<Point3D>();

            points.Add(new Point3D(-size / 2, 0, h / 3));
            points.Add(new Point3D(0, 0, -h * 2 / 3));
            points.Add(new Point3D(size / 2, 0, h / 3));
            points.Add(new Point3D(0, -h, 0));

            // Основание тетраэдра
            //Verges.Add(new Line3D(Point3D[] { points[0], points[1], points[2] }));
            Verges.Add(new Line3D(Points[0], Points[1]));
            Verges.Add(new Line3D(Points[1], Points[2]));
            Verges.Add(new Line3D(Points[0], Points[2]));

            // Левая грань
            //Verges.Add(new Line3D(new Point3D[] { points[1], points[3], points[0] }));
            Verges.Add(new Line3D(Points[1], Points[3]));
            Verges.Add(new Line3D(Points[3], Points[0]));
            Verges.Add(new Line3D(Points[1], Points[0]));

            // Правая грань
            //Verges.Add(new Line3D(new Point3D[] { points[2], points[3], points[1] }));
            Verges.Add(new Line3D(Points[2], Points[3]));
            Verges.Add(new Line3D(Points[3], Points[1]));
            Verges.Add(new Line3D(Points[2], Points[1]));

            // Передняя грань
            //Verges.Add(new Line3D(new Point3D[] { points[0], points[3], points[2] }));
            Verges.Add(new Line3D(Points[0], Points[3]));
            Verges.Add(new Line3D(Points[3], Points[2]));
            Verges.Add(new Line3D(Points[0], Points[2]));
        }

        public void Apply(Transform t)
        {
            foreach (var point in Points)
                point.ApplyTransformation(t);
        }

        public void Draw(Graphics g, Transform projection, int width, int height)
        {
            foreach (var Verge in Verges)
                Verge.Draw(g);
        }
    }
}
