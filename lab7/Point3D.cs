using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class Point3D
    {
       
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        private Transform transform;

        public static PointF WorldCenter = new PointF(250,250);

        public static string projection = "isometric";

        public Point3D(float X,float Y,float Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            transform = new Transform();
        }

        public void ApplyTransformation(Transform t)
        {
            transform *= t;
        }

        // [1,4] * [4,4] => [1,4]
        private double[] GetTransformedCoordinates(Transform t)
        {
            double[] coords = { X, Y, Z, 1 };
            double[] res = new double[4];
            for (int i = 0; i < 4; i++)
            {   

                for(int j = 0;j < 4; j++)
                {
                    res[i] += coords[i] * t.Matrix[j, i];
                }
            }

            return res;
        }

        public Point3D GetTransformedCoordinates()
        {
            var t = GetTransformedCoordinates(transform);
            return new Point3D((float)t[0], (float)t[1], (float)t[2]);
        }

        public void Draw(Graphics g)
        {
            var res = ConvertTo2D();
            g.DrawEllipse(new Pen(Color.Black, 2), (float)res[0], (float)res[1], 2, 2);
        }
        
        private double Scale(double x)
        {
            return (x + 300) / 2 * WorldCenter.X;
          
        }
        
        private double[] ConvertToIsometric(double[] t)
        {
            var t1 = Transform.IsometricProjection() * new Transform(new double[,] { { t[0] }, { t[1] }, { t[2] } });
            var t2 = new Transform(new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } }) * t1;
            return new double[] {WorldCenter.X+ t2.Matrix[0,0],WorldCenter.Y+ t2.Matrix[1,0]
            };
        }


        private double[] ConvertToPerspective(double[] t)
        {
            //  var t2 = new Transform(new double[,] { { t[0] }, { t[1] }, { t[2] } , { 1 } }) * new Transform(new double[,] { { 1, 0, 0 , 0 }, { 0, 1, 0,0 }, { 0, 0, 0,0.001 },{ 0,0,0,1} }) * (1/(0.0001*t[2]));
            var t2 = new Transform(new double[,] { { t[0], t[1], t[2], 1 } }) * Transform.PerspectiveProjection(2);
            return new double[] {WorldCenter.X  + t2.Matrix[0,0],WorldCenter.Y  + t2.Matrix[0,1]};
        }


        public double[] ConvertTo2D()
        {
           // this.ApplyTransformation(Transform.RotateY(10));
            double [] t = GetTransformedCoordinates(transform);
            switch (Point3D.projection)
            {
                case "isometric": return ConvertToIsometric(t);
                case "perspective" : return ConvertToPerspective(t);
            }

            return ConvertToIsometric(t);
        }

    }
}
