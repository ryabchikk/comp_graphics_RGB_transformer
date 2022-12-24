namespace Lab8
{
    // Тип координатной прямой (для поворотов)
    public enum AxisType{X,Y,Z};

    public class AffineTransformations
    {
        // Сдвинуть фигуру на заданные расстояния
        public static Figure MoveFigure(Figure figure, double dx, double dy, double dz)
        {
            Matrix shift = new Matrix(4, 4).Fill(1, 0, 0, dx, 0, 1, 0, dy, 0, 0, 1, dz, 0, 0, 0, 1);
            figure.TransformPoints((Vertex p) =>
            {
                var res = shift * new Matrix(4, 1).Fill(p.Xf, p.Yf, p.Zf, 1);
                return new Vertex(new Point3D(res[0, 0], res[1, 0], res[2, 0]),p.normVector,p.texturePoint);
            });
            return figure;
        }

        // Растянуть фигуру на заданные коэффициенты
        public static Figure ScaleFigure(Figure shape, double cx, double cy, double cz)
        {
            Matrix scale = new Matrix(4, 4).Fill(cx, 0, 0, 0, 0, cy, 0, 0, 0, 0, cz, 0, 0, 0, 0, 1);
            shape.TransformPoints((Vertex p) =>
            {
                var res = scale * new Matrix(4, 1).Fill(p.Xf, p.Yf, p.Zf, 1);
                return new Vertex(new Point3D(res[0, 0], res[1, 0], res[2, 0]),p.normVector,p.texturePoint);
            });
            return shape;
        }

        // Повернуть фигуру на заданный угол вокруг заданной оси
        public static Figure RotateFigure(Figure figure, AxisType type, double angle)
        {
            Matrix rotation = new Matrix(0, 0);

            switch (type)
            {
                case AxisType.X:
                    rotation = new Matrix(4, 4).Fill(1, 0, 0, 0, 0, Geometry.Cos(angle), -Geometry.Sin(angle), 0, 0,
                        Geometry.Sin(angle), Geometry.Cos(angle), 0, 0, 0, 0, 1);
                    break;
                case AxisType.Y:
                    rotation = new Matrix(4, 4).Fill(Geometry.Cos(angle), 0, Geometry.Sin(angle), 0, 0, 1, 0, 0,
                        -Geometry.Sin(angle), 0, Geometry.Cos(angle), 0, 0, 0, 0, 1);
                    break;
                case AxisType.Z:
                    rotation = new Matrix(4, 4).Fill(Geometry.Cos(angle), -Geometry.Sin(angle), 0, 0,
                        Geometry.Sin(angle), Geometry.Cos(angle), 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
                    break;
            }

            figure.TransformPoints((Vertex p) =>
            {
                var res = rotation * new Matrix(4, 1).Fill(p.Xf, p.Yf, p.Zf, 1);
                return new Vertex(new Point3D(res[0, 0], res[1, 0], res[2, 0]),p.normVector,p.texturePoint);
            });
            return figure;
        }

        public static void RotateVectors(ref Vector vector1, ref Vector vector2, double angle, Vector axis)
        {
            axis.normalize();
            
            double l = axis.x;
            double m = axis.y;
            double n = axis.z;
            double anglesin = Geometry.Sin(angle);
            double anglecos = Geometry.Cos(angle);
            
            Matrix rotation = new Matrix(4, 4).Fill(l * l + anglecos * (1 - l * l),
                l * (1 - anglecos) * m - n * anglesin, l * (1 - anglecos) * n + m * anglesin, 0,
                l * (1 - anglecos) * m + n * anglesin, m * m + anglecos * (1 - m * m),
                m * (1 - anglecos) * n - l * anglesin, 0,
                l * (1 - anglecos) * n - m * anglesin, m * (1 - anglecos) * n + l * anglesin,
                n * n + anglecos * (1 - n * n), 0,
                0, 0, 0, 1);

            var res = rotation * new Matrix(4, 1).Fill(vector1.x, vector1.y, vector1.z, 1);
            
            vector1 = new Vector(res[0, 0], res[1, 0], res[2, 0], true);
            res = rotation * new Matrix(4, 1).Fill(vector2.x, vector2.y, vector2.z, 1);
            vector2 = new Vector(res[0, 0], res[1, 0], res[2, 0], true);
        }
    }
}