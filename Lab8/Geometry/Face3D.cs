using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{

    // Грань, которая состоит из конечного числа отрезков
    public class Face3D
    {
        Vector normVector;
        List<Vertex> vertices;
        
        public bool isFacial = true;

        public Face3D()
        {
            vertices = new List<Vertex>();
            normVector = new Vector(0, 0, 0);
        }

        public Face3D AddVertex(Vertex newPoint)
        {
            vertices.Add(newPoint);
            return this;
        }
        
        public List<Vertex> Vertices
        {
            get => vertices;
        }

        public Vector NormVector
        {
            get
            {
                Vector vect1 = new Vector(vertices.First(),vertices[1]);
                Vector vect2 = new Vector(vertices.First(),vertices.Last());
                
                normVector = Vector.MultiplyVectors(vect2, vect1);
                
                return normVector;
            }
        }

        public void TransformPoints(Func<Vertex,Vertex> f)
        {
            vertices = vertices.Select(f).ToList();
        }

        // Получение центра тяжести грани
        public Point3D GetCenter()
        {
            double x = 0, y = 0, z = 0;
            foreach (var point in vertices)
            {
                x += point.Xf;
                y += point.Yf;
                z += point.Zf;
            }

            return new Point3D(x / vertices.Count, y / vertices.Count, z / vertices.Count);
        }
    }
}