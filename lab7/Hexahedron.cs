using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab7
{
	class Hexahedron : Primitive
	{

		private List<Point3D> points = new List<Point3D>();

		private List<Line3D> verges = new List<Line3D>();

		public List<Point3D> Points { get { return points; } }
		public List<Line3D> Verges { get { return verges; } }

		public Point3D Center
		{
			get
			{
				Point3D p = new Point3D(0, 0, 0);
				for (int i = 0; i < 8; i++)
				{
					p.X += Points[i].X;
					p.Y += Points[i].Y;
					p.Z += Points[i].Z;
				}
				p.X /= 8;
				p.Y /= 8;
				p.Z /= 8;
				return p;
			}
		}

		public Hexahedron(float size)
		{
			points = new List<Point3D>();

			Points.Add(new Point3D(-size / 2, -size / 2, -size / 2));
			Points.Add(new Point3D(-size / 2, -size / 2, size / 2));
			Points.Add(new Point3D(-size / 2, size / 2, -size / 2));
			Points.Add(new Point3D(size / 2, -size / 2, -size / 2));
			Points.Add(new Point3D(-size / 2, size / 2, size / 2));
			Points.Add(new Point3D(size / 2, -size / 2, size / 2));
			Points.Add(new Point3D(size / 2, size / 2, -size / 2));
			Points.Add(new Point3D(size / 2, size / 2, size / 2));


			//Verges.Add(new Verge(new Point3D[] { points[0], points[1], points[5], points[3] }));
			Verges.Add(new Line3D(Points[0], Points[1]));
			Verges.Add(new Line3D(Points[0], Points[5]));
			Verges.Add(new Line3D(Points[0], Points[3]));
			Verges.Add(new Line3D(Points[1], Points[5]));
			Verges.Add(new Line3D(Points[1], Points[3]));
			Verges.Add(new Line3D(Points[5], Points[3]));

			//Verges.Add(new Verge(new Point3D[] { points[2], points[6], points[3], points[0] }));
			Verges.Add(new Line3D(Points[2], Points[6]));
			Verges.Add(new Line3D(Points[2], Points[3]));
			Verges.Add(new Line3D(Points[2], Points[0]));
			Verges.Add(new Line3D(Points[6], Points[3]));
			Verges.Add(new Line3D(Points[6], Points[0]));
			Verges.Add(new Line3D(Points[3], Points[0]));

			//Verges.Add(new Verge(new Point3D[] { points[4], points[1], points[0], points[2] }));
			Verges.Add(new Line3D(Points[4], Points[1]));
			Verges.Add(new Line3D(Points[4], Points[0]));
			Verges.Add(new Line3D(Points[4], Points[2]));
			Verges.Add(new Line3D(Points[1], Points[0]));
			Verges.Add(new Line3D(Points[1], Points[2]));
			Verges.Add(new Line3D(Points[0], Points[2]));

			//Verges.Add(new Verge(new Point3D[] { points[7], points[5], points[3], points[6] }));
			Verges.Add(new Line3D(Points[7], Points[5]));
			Verges.Add(new Line3D(Points[7], Points[3]));
			Verges.Add(new Line3D(Points[7], Points[6]));
			Verges.Add(new Line3D(Points[5], Points[3]));
			Verges.Add(new Line3D(Points[5], Points[6]));
			Verges.Add(new Line3D(Points[3], Points[6]));

			//Verges.Add(new Verge(new Point3D[] { points[2], points[4], points[7], points[6] }));
			Verges.Add(new Line3D(Points[2], Points[4]));
			Verges.Add(new Line3D(Points[2], Points[7]));
			Verges.Add(new Line3D(Points[2], Points[6]));
			Verges.Add(new Line3D(Points[4], Points[7]));
			Verges.Add(new Line3D(Points[4], Points[6]));
			Verges.Add(new Line3D(Points[7], Points[6]));

			//Verges.Add(new Verge(new Point3D[] { points[4], points[1], points[5], points[7] }));
			Verges.Add(new Line3D(Points[4], Points[1]));
			Verges.Add(new Line3D(Points[4], Points[5]));
			Verges.Add(new Line3D(Points[4], Points[7]));
			Verges.Add(new Line3D(Points[1], Points[5]));
			Verges.Add(new Line3D(Points[1], Points[7]));
			Verges.Add(new Line3D(Points[5], Points[7]));
		}

		public void Apply(Transform t)
		{
			foreach (var point in Points)
				point.ApplyTransformation(t);
		}

		public void Draw(Graphics g, Transform projection, int width, int height)
		{
			if (Points.Count != 8) return;

			foreach (var Verge in Verges)
				Verge.Draw(g);
		}

		public int Count_Verges()
		{
			return 36;
		}
	}
}
