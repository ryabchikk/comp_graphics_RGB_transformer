using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class Transform
    {
        private double[,] matrix = new double[4, 4];

        public double[,] Matrix { get { return matrix; } }

        public Transform()
        {
            matrix = Identity().matrix;
        }

        public Transform(double[,] matrix)
        {
            this.matrix = matrix;
        }

        public static Transform RotateX(double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Transform(
                new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, cos, -sin, 0 },
                    { 0, sin, cos, 0 },
                    { 0, 0, 0, 1 }
                });
        }

        public static Transform RotateY(double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Transform(
                new double[,]
                {
                    { cos, 0, sin, 0 },
                    { 0, 1, 0, 0 },
                    { -sin, 0, cos, 0 },
                    { 0, 0, 0, 1 }
                });
        }

        public static Transform RotateZ(double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Transform(
                new double[,]
                {
                    { cos, -sin, 0, 0 },
                    { sin, cos, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                });
        }

       

        public static Transform Scale(double fx, double fy, double fz)
        {
            return new Transform(
                new double[,] {
                    { fx, 0, 0, 0 },
                    { 0, fy, 0, 0 },
                    { 0, 0, fz, 0 },
                    { 0, 0, 0, 1 }
                });
        }

        public static Transform Translate(double dx, double dy, double dz)
        {
            return new Transform(
                new double[,]
                {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { dx, dy, dz, 1 },
                });
        }

        public static Transform Identity()
        {
            return new Transform(
                new double[,] {
                    { 1, 0, 0, 0 },
                    { 0, 1, 0, 0 },
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 }
                });
        }


        public static Transform ReflectX()
        {
            return Scale(-1, 1, 1);
        }

        public static Transform ReflectY()
        {
            return Scale(1, -1, 1);
        }

        public static Transform ReflectZ()
        {
            return Scale(1, 1, -1);
        }

        public static Transform OrthographicXYProjection()
        {
            return Identity();
        }

        public static Transform OrthographicXZProjection()
        {
            return Identity() * RotateX(-Math.PI / 2);
        }

        public static Transform OrthographicYZProjection()
        {
            return Identity() * RotateY(Math.PI / 2);
        }

        public static Transform IsometricProjection()
        {
            double[,] matr =  new double[,] {
                    { Math.Sqrt(3), 0,  -Math.Sqrt(3) },
                    { 1, 2, 1 },
                    { Math.Sqrt(2), -Math.Sqrt(2), Math.Sqrt(2) }
                };
            /*
            double[,] matr1 = new double[,] {
                    { 1, 0, 0 },
                    { 0, 1, 0 },
                    { 0, 0, 0 }
                };
            */
            return new Transform(matr) * (1/Math.Sqrt(6));
        }

        public static Transform PerspectiveProjection(double distance = 1.0)
        {
            return new Transform(
                new double[,] {
                    { 1, 0, 0, 0 },
                    { 0, 1 , 0, 0 },
                    { 0, 0, 0, distance },
                    { 0, 0, 0, 1 }
                });
        }

        public static Transform operator *(Transform t1, Transform t2)
        {
            double[,] matrix = new double[t1.matrix.GetLength(0), t2.matrix.GetLength(1)];
            for (int i = 0; i < t1.matrix.GetLength(0); ++i)
                for (int j = 0; j < t2.matrix.GetLength(1); ++j)
                {
                    matrix[i, j] = 0;
                    for (int k = 0; k < t1.matrix.GetLength(1); ++k)
                        matrix[i, j] += t1.matrix[i, k] * t2.matrix[k, j];
                }
            return new Transform(matrix);
        }

        public static Transform operator *(Transform t1, double alpha)
        {
            double[,] matrix = new double[t1.matrix.GetLength(0), t1.matrix.GetLength(1)];
            for (int i = 0; i < t1.matrix.GetLength(0); ++i)
                for (int j = 0; j < t1.matrix.GetLength(1); ++j)
                {
                        matrix[i, j] = t1.matrix[i, j] * alpha;
                }
            return new Transform(matrix);
        }

    }
}
