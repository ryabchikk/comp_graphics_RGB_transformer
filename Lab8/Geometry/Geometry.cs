using System;
using System.Collections.Generic;

namespace Lab8
{
    public delegate void ActionRef<T>(ref T item);

    class Geometry
    {
        // Переводит угол из градусов в радианы
        public static double DegreesToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        // Косинус из угла в градусах
        public static double Cos(double angle)
        {
            return Math.Cos(DegreesToRadians(angle));
        }

        // Синус из угла в градусах
        public static double Sin(double angle)
        {
            return Math.Sin(DegreesToRadians(angle));
        }

        // Перевод точки в другую точку
        public static Point3D TransformPoint(Point3D p, Matrix matrix)

        {
            var matrfrompoint = new Matrix(4, 1).Fill(p.X, p.Y, p.Z, 1);

            var matrPoint = matrix * matrfrompoint;
            Point3D newPoint = new Point3D(matrPoint[0, 0], matrPoint[1, 0], matrPoint[2, 0]);
            return newPoint;
        }

        // Перевод всех точек для тела вращения в другие точки
        public static List<Point3D> TransformPointsRotationFig(Matrix matrix, List<Point3D> allpoints)
        {
            List<Point3D> clone = allpoints;
            List<Point3D> res = new List<Point3D>();
            foreach (var p in clone)
            {
                Point3D newp = TransformPoint(p, matrix);
                res.Add(newp);
            }

            return res;
        }

        // Поворот образующей для фигуры вращения
        public static List<Point3D> RotatePoint(List<Point3D> general, AxisType axis, double angle)
        {
            List<Point3D> res;
            double mysin = Math.Sin(DegreesToRadians(angle));
            double mycos = Math.Cos(DegreesToRadians(angle));
            Matrix rotation = new Matrix(0, 0);

            switch (axis)
            {
                case AxisType.X:
                    rotation = new Matrix(4, 4).Fill(1, 0, 0, 0, 0, mycos, -mysin, 0, 0, mysin, mycos, 0, 0, 0, 0, 1);
                    break;
                case AxisType.Y:
                    rotation = new Matrix(4, 4).Fill(mycos, 0, mysin, 0, 0, 1, 0, 0, -mysin, 0, mycos, 0, 0, 0, 0, 1);
                    break;
                case AxisType.Z:
                    rotation = new Matrix(4, 4).Fill(mycos, -mysin, 0, 0, mysin, mycos, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
                    break;
            }

            res = TransformPointsRotationFig(rotation, general);

            return res;
        }

    }
}