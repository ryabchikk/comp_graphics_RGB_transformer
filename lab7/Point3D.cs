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

        public static PointF WorldCenter = new PointF(200,200);

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

        public void Draw(Graphics g)
        {
            var res = ConvertTo2D();
            g.DrawEllipse(new Pen(Color.Black, 2), (float)res[0], (float)res[1], 2, 2);
        }

        public double[] ConvertTo2D()
        {
            double [] t = GetTransformedCoordinates(transform);
            var  t1 = Transform.IsometricProjection()*new Transform(new double[,] { { t[0] },{ t[1]},{ t[2]} });
            var t2 = new Transform(new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } }) * t1;
            return new double[] {WorldCenter.X+ t2.Matrix[0,0],WorldCenter.Y+ t2.Matrix[1,0]
            };
        }

    }
}
