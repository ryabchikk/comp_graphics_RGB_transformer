namespace Lab8
{
    public class Vertex : Point3D
    {
        public TexturePoint texturePoint;
        public Vector normVector;
        
        public Vertex(double x, double y, double z, TexturePoint texturePoint) : base(x, y, z,0) 
        {
            this.texturePoint = texturePoint;
        }

        public Vertex(Point3D p, Vector normVector, TexturePoint texturePoint) : base(p)
        {
            this.normVector = normVector;
            this.texturePoint = texturePoint;
         
        }
    }
}