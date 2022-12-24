using System;

namespace Lab8
{
    public class Vector
    {
        public double x, y, z;

        public Vector(double x, double y, double z, bool isVectorNeededToBeNormalized = false)
        {
            double normalization = isVectorNeededToBeNormalized
                ? Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2))
                : 1;
            this.x = x / normalization;
            this.y = y / normalization;
            this.z = z / normalization;
        }

        public Vector(Point3D p, bool isVectorNeededToBeNormalized = false) : this(p.Xf, p.Yf, p.Zf, isVectorNeededToBeNormalized)
        {
        
        }
        
        public Vector(Point3D start, Point3D end, bool isVectorNeededToBeNormalized = false) : this (end.Xf - start.Xf, end.Yf - start.Yf,end.Zf - start.Zf,isVectorNeededToBeNormalized){}

        public Vector normalize()
        {
            double normalization = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
            x = x / normalization;
            y = y / normalization;
            z = z / normalization;
            return this;
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
        
        public static Vector MultiplyVectors(Vector firstVector,Vector secondVector) 
        {
            double resX = firstVector.y * secondVector.z - firstVector.z * firstVector.y;
            double resY = firstVector.z * secondVector.x - firstVector.x * secondVector.z;
            double resZ = firstVector.x * secondVector.y - firstVector.y * secondVector.x;
            
            return new Vector(resX, resY, resZ);
        }

        public static double GetCos(Vector v1, Vector v2)
        {
            double scalar = v1.Xf * v2.Xf + v1.Yf * v2.Yf + v1.Zf * v2.Zf;
            double lengthv1 = Math.Sqrt(v1.Xf * v1.Xf + v1.Yf * v1.Yf + v1.Zf * v1.Zf);
            double lengthv2 = Math.Sqrt(v2.Xf * v2.Xf + v2.Yf * v2.Yf + v2.Zf * v2.Zf);
            double res = scalar / lengthv1 / lengthv2;
            return res;

        }
    }
    
}