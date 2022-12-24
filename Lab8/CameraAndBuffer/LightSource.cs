namespace Lab8
{
    public class LightSource
    {
        Point3D position;

        public LightSource(Point3D position)
        {
            this.position = position;
        }

        public Point3D Position => position;

        public void Move(double shiftX = 0, double shiftY = 0, double shiftZ = 0)
        {
            position.Xf += shiftX;
            position.Yf += shiftY;
            position.Zf += shiftZ;
        }
    }
}