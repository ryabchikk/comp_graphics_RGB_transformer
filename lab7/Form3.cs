using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace lab7
{
    public partial class Form3 : Form
    {
        enum AxisType
        {
            X,
            Y,
            Z
        }
        public Form3()
        {
            InitializeComponent();
        }
        class RotationShape : Face3D
        {
            List<Point3D> formingline;
            Line3D axiz;
            int Divisions;
            List<Point3D> allpoints;
            List<Line3D> edges;//ребра
            public RotationShape()
            {
                allpoints = new List<Point3D>();
                edges = new List<Line3D>();
            }
            public List<Line3D> Edges { get => edges; }
            public Face3D addEdge(Line3D edge)
            {
                edges.Add(edge);
                return this;
            }
            public Face3D addEdges(IEnumerable<Line3D> ed)
            {
                this.edges.AddRange(ed);
                return this;
            }

            public RotationShape(IEnumerable<Point3D> points) : this()
            {
                this.allpoints.AddRange(points);
            }
            public RotationShape(Line3D ax, int Div, IEnumerable<Point3D> line) : this()
            {
                this.axiz = ax;
                this.Divisions = Div;
                this.formingline.AddRange(line);
            }

            public RotationShape addPoint(Point3D p)
            {
                allpoints.Add(p);
                return this;
            }
            public RotationShape addPoints(IEnumerable<Point3D> points)
            {
                this.allpoints.AddRange(points);
                return this;
            }

            public List<Point3D> Points { get => allpoints; }
        }
        public static double degreesToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private List<Point3D> transformPointsRotationFig(Transform matrix, List<Point3D> allpoints)
        {
            List<Point3D> clone = allpoints;
            List<Point3D> res = new List<Point3D>();
            foreach (var p in clone)
            {
                Point3D newp= new Point3D(p.X,p.Y,p.Z);
                newp.ApplyTransformation(matrix);
                //Point3D newp = transformPoint(p, matrix);
                res.Add(newp);
            }
            return res;
        }
        private List<Point3D> RotatePoint(List<Point3D> general, AxisType axis, double angle)
        {
            List<Point3D> res;
            double mysin = Math.Sin(degreesToRadians(angle));
            double mycos = Math.Cos(degreesToRadians(angle));
            Transform rotation = new Transform();

            switch (axis)
            {
                case AxisType.X:
                    rotation = new Transform(new double[,] { { 1, 0, 0, 0 }, { 0, mycos, -mysin, 0 }, { 0, mysin, mycos, 0 }, { 0, 0, 0, 1 } });
                    //rotation = new Matrix(4, 4).fill(1, 0, 0, 0, 0, mycos, -mysin, 0, 0, mysin, mycos, 0, 0, 0, 0, 1);
                    break;
                case AxisType.Y:
                    rotation = new Transform(new double[,] { { mycos, 0, mysin, 0 }, { 0, 1, 0, 0 }, { -mysin, 0, mycos, 0 }, { 0, 0, 0, 1 } });
                    //rotation = new Matrix(4, 4).fill(mycos, 0, mysin, 0, 0, 1, 0, 0, -mysin, 0, mycos, 0, 0, 0, 0, 1);
                    break;
                case AxisType.Z:
                    rotation = new Transform(new double[,] { { mycos, -mysin, 0, 0 }, { mysin, mycos, 0, 0 }, { 0, 0, 1, 0 },{ 0, 0, 0, 1 }});
                    //rotation = new Matrix(4, 4).fill(mycos, -mysin, 0, 0, mysin, mycos, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
                    break;
            }

            res = transformPointsRotationFig(rotation, general);

            return res;
        }
        private RotationShape getRotationShape(List<Point3D> general, int divisions, AxisType axis)
        {
            RotationShape res = new RotationShape();
            List<Point3D> genline = general;
            int GeneralCount = genline.Count();
            //Line axis;
            int Count = divisions;
            double angle = (360.0 / Count);//угол 
            List<Line3D> edges;//ребра

            res.addPoints(genline);//добавили образующую
            for (int i = 1; i < divisions; i++)//количество разбиений
            {
                res.addPoints(RotatePoint(genline, axis, angle * i));
            }
            //

            //Фигура вращения задаётся тремя параметрами: образующей(набор точек), осью вращения и количеством разбиений
            //зададим ребра и грани
            for (int i = 0; i < divisions; i++)
            {
                for (int j = 0; j < GeneralCount; j++)
                {
                    int index = i * GeneralCount + j;//индекс точки
                    if (index < divisions * GeneralCount)
                    {
                        int e = (index + GeneralCount) % res.Points.Count;
                        if ((index + 1) % GeneralCount == 0)
                        {

                            // res.addFace(new Face().addEdge(new Line( res.Points[current], res.Points[e])));
                            res.addEdge(new Line3D(res.Points[index], res.Points[e]));
                        }
                        else
                        {
                            res.addEdge(new Line3D(res.Points[index], res.Points[index + 1]));
                            res.addEdge(new Line3D(res.Points[index], res.Points[e]));
                            int e1 = (index + 1 + GeneralCount) % res.Points.Count;
                            //добавим грань
                            res.addFace(new Face().addEdge(new Line(res.Points[index], res.Points[index + 1])).addEdge(new Line(res.Points[index + 1], res.Points[e1])).addEdge(new Line(res.Points[e1], res.Points[e])).addEdge(new Line(res.Points[e], res.Points[index])));
                        }
                    }

                }


            }

            return res;
        }
    }
}
