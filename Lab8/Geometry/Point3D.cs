using System;
using System.Drawing;

namespace Lab8
{
    // Точка в пространстве
    public class Point3D
    {
        double x, y, z;
        public double lightness;//для интенсивности освещения
        public static PointF worldCenter;
        static Size screenSize;
        static double zScreenNear, zScreenFar, fov;

        static Matrix centralMatrix = new Matrix(4, 4).Fill(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, k, 0, 0, 0, 1);
        static Matrix perspectiveProjectionMatrix;
        const double k = 0.001f;

        public Point3D(int x, int y, int z,double light=1.0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.lightness = light;
        }

        public Point3D(Point3D point) : this(point.x,point.y,point.z,point.lightness) { }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Point3D objAsPart = obj as Point3D;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals(Point3D other)
        {
            if (other == null) return false;
            return (this.X.Equals(other.X) && this.Y.Equals(other.Y) && this.Z.Equals(other.Z));
        }

        public static void setProjection(Size screenSize, double zScreenNear, double zScreenFar, double fov)
        {
            Point3D.screenSize = screenSize;
            Point3D.zScreenNear = zScreenNear;
            Point3D.zScreenFar = zScreenFar;
            Point3D.fov = fov;

            perspectiveProjectionMatrix = new Matrix(4, 4).Fill(
                screenSize.Height / (Math.Tan(Geometry.DegreesToRadians(fov / 2)) * screenSize.Width), 0, 0, 0, 0,
                1.0 / Math.Tan(Geometry.DegreesToRadians(fov / 2)), 0, 0, 0, 0,
                -(zScreenFar + zScreenNear) / (zScreenFar - zScreenNear),
                -2 * (zScreenFar * zScreenNear) / (zScreenFar - zScreenNear), 0, 0, -1, 0);
        }

        public Point3D(double x, double y, double z,double light=1.0)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.lightness = light;
        }

        public int X
        {
            get => (int) Math.Round(x);
            set => x = value;
        }

        public int Y
        {
            get => (int) Math.Round(y);
            set => y = value;
        }

        public int Z
        {
            get => (int) Math.Round(z);
            set => z = value;
        }

        public double Xf
        {
            get => x;
            set => x = value;
        }

        public double Yf
        {
            get => y;
            set => y = value;
        }

        public double Zf
        {
            get => z;
            set => z = value;
        }
        
        public double light
        {
            get => lightness;
                
            set => lightness = value;
        }
        
        private double ClampDouble(double value, double min, double max)
        {
            if (min <= value && value <= max)
            {
                return value;
            }
            else if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }
            else
            {
                return double.NaN;
            }
        }
        
        // Перевод точки из 3D в 2D
        public PointF ConvertPointTo2D()
        {
            Matrix res = new Matrix(1, 4).Fill(Xf, Yf, Zf, 1) * centralMatrix * (1 / (k * Zf + 1));
            return new PointF(worldCenter.X + (float) res[0, 0], worldCenter.Y + (float) res[0, 1]);
        }

        public Tuple<PointF?, double> ConvertPointTo2D(Camera cam)
        {
            var viewCoord = cam.ToCameraView(this);


                if (viewCoord.Zf < 0) {
                    return Tuple.Create<PointF?, double>(null, (float) viewCoord.Zf);
                }

                Matrix res = new Matrix(1, 4).Fill(viewCoord.Xf, viewCoord.Yf, viewCoord.Zf, 1) * perspectiveProjectionMatrix;
                
                if (res[0, 3] == 0) {
                    return Tuple.Create<PointF?, double>(null, (float) viewCoord.Zf);
                }

                res *= 1.0 / res[0, 3];
                res[0, 0] = ClampDouble(res[0, 0], -1, 1);
                res[0, 1] = ClampDouble(res[0, 1], -1, 1);

                if (res[0, 2] < 0) {
                    return Tuple.Create<PointF?, double>(null, (float) viewCoord.Zf);
                }

                return Tuple.Create<PointF?, double>(
                    new PointF(worldCenter.X + (float) res[0, 0] * worldCenter.X,
                        worldCenter.Y + (float) res[0, 1] * worldCenter.Y), (float) viewCoord.Zf);
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }
    }
}