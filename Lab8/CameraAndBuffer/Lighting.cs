using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab8
{
    //для реализации освещения по модели Ламберта 
    class Lighting
    {
        
        //Вычислить цвет в каждой вершине по модели Ламберта (рассеянную часть).
        //Закрасить грань, интерполируя цвет между цветами вершин(билинейная интерполяция).
        //Добавить возможность применения аффинных преобразований к объекту.
        public static  double GetLightness(Vertex v, LightSource light)
        {
            var normV = v.normVector;
            var rayToVertex = new Vector(v.Xf - light.Position.Xf, v.Yf - light.Position.Yf, v.Zf - light.Position.Zf);

            double cos =Math.Max( Vector.GetCos(normV, rayToVertex),0.0);
            return cos;
        }
        
        public static double GetIntense(double lightness)
        {
            return (lightness+1) /2;
        }
        
        public static Vector NormalVertex(List<Face3D> faces, Figure s)
        {
            Vector res=new Vector(0,0,0);
            foreach (var face in faces)
            {
                res.Xf += face.NormVector.Xf;
                res.Yf += face.NormVector.Yf;
                res.Zf += face.NormVector.Zf;
            }
            res.Xf = res.Xf / faces.Count();
            res.Yf = res.Yf / faces.Count();
            res.Zf = res.Zf / faces.Count();
            return res;
        }
        
        // Для каждой вершины считает освещенность по методу Ламберта, пересчитывает нормали(что-то у нас с obj нормалями не то)
        public static void CalculateLambert(Figure s,Lab8.LightSource light)
        {
            Dictionary<Vertex, Vector> normales = new Dictionary<Vertex, Vector>();
            for (int i = 0; i < s.Faces.Count; i++)
            {
                Face3D f = s.Faces[i];
                foreach (var vert in f.Vertices)
                {
                    List<Face3D> faces = s.Faces.Where(x => x.Vertices.Contains(vert)).ToList();
                    vert.normVector = NormalVertex(faces, s);
                }
            }

            foreach (var f in s.Faces)
            {

                foreach (var vert in f.Vertices)
                {
                    double lamb = GetLightness(vert, light);
                    double intense = GetIntense(lamb);
                    vert.lightness = intense;
                }
            }
        }
    }

}