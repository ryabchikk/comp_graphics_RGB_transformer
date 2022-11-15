using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab7
{
    class Octahedron : Primitive
	{
		private List<Point3D> points = new List<Point3D>();

		private List<Line3D> verges = new List<Line3D>();

		public List<Point3D> Points { get { return points; } }
		public List<Line3D> Verges { get { return verges; } }




		public Octahedron(float size)
		{
			points = new List<Point3D>();
			verges = new List<Line3D>();


			points.Add(new Point3D(-size / 2, 0, 0));
			points.Add(new Point3D(0, -size / 2, 0));
			points.Add(new Point3D(0, 0, -size / 2));
			points.Add(new Point3D(size / 2, 0, 0));
			points.Add(new Point3D(0, size / 2, 0));
			points.Add(new Point3D(0, 0, size / 2));

			verges.Add(new Line3D(points[0], points[2]));
			verges.Add(new Line3D(points[2], points[4]));
			verges.Add(new Line3D(points[0], points[4]));

			verges.Add(new Line3D(points[2], points[4]));
			verges.Add(new Line3D(points[4], points[3]));
			verges.Add(new Line3D(points[2], points[3]));

			verges.Add(new Line3D(points[4], points[5]));
			verges.Add(new Line3D(points[5], points[3]));
			verges.Add(new Line3D(points[4], points[3]));

			verges.Add(new Line3D(points[0], points[5]));
			verges.Add(new Line3D(points[5], points[4]));
			verges.Add(new Line3D(points[0], points[4]));

			verges.Add(new Line3D(points[0], points[5]));
			verges.Add(new Line3D(points[5], points[1]));
			verges.Add(new Line3D(points[0], points[1]));

			verges.Add(new Line3D(points[5], points[3]));
			verges.Add(new Line3D(points[3], points[1]));
			verges.Add(new Line3D(points[5], points[1]));

			verges.Add(new Line3D(points[0], points[2]));
			verges.Add(new Line3D(points[2], points[1]));
			verges.Add(new Line3D(points[0], points[1]));

			verges.Add(new Line3D(points[2], points[1]));
			Verges.Add(new Line3D(points[1], points[3]));
			Verges.Add(new Line3D(points[2], points[3]));

			//Verges.Add(new Verge(new Point3D[] { points[2], points[4], points[3] }));
			//Verges.Add(new Verge(new Point3D[] { points[4], points[5], points[3] }));
			//Verges.Add(new Verge(new Point3D[] { points[0], points[5], points[4] }));
			//Verges.Add(new Verge(new Point3D[] { points[0], points[5], points[1] }));
			//Verges.Add(new Verge(new Point3D[] { points[5], points[3], points[1] }));
			//Verges.Add(new Verge(new Point3D[] { points[0], points[2], points[1] }));
			//Verges.Add(new Verge(new Point3D[] { points[2], points[1], points[3] }));
		}

		public void Apply(Transform t)
		{
			foreach (var point in Verges)
				point.ApplyTransformation(t);
		}

		public void Draw(Graphics g, Transform projection, int width, int height)
		{
			if (Points.Count != 6) return;

			foreach (var Verge in Verges)
				Verge.Draw(g);
		}
	}
}
