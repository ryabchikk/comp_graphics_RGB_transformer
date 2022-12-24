using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Lab8
{
    // Объёмная фигура, которая состоит из граней
    public class Figure
    {
        List<Face3D> faces;
        private const int objScaleFactor = 10;
        private Color figureColor;
        

        public Figure()
        {
            Random rnd = new Random();
            figureColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            faces = new List<Face3D>();
        }

        public Figure AddFace(Face3D face)
        {
            faces.Add(face);
            return this;
        }

        public List<Face3D> Faces
        {
            get => faces;
        }
        public Color GetColor
        {
            get => figureColor;
        }

        // Преобразует все точки в фигуре по заданной функции
        public void TransformPoints(Func<Vertex, Vertex> f)
        {
            foreach (var face in Faces)
            {
                face.TransformPoints(f);
            }
        }

        // Считывает модель формата .obj и выгружает его
        public static Figure ReadFigure(string fileName)
        {
            Figure res = new Figure();
            
            List<Point3D> vertices = new List<Point3D>();
            List<TexturePoint> textureVertices = new List<TexturePoint>();
            List<Vector> normales = new List<Vector>();
            
            var lines = File.ReadAllLines(fileName);
            
            foreach (var line in lines)
            {
                
                string[] data = line.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
                
                if (data.Count() == 0) {
                    continue;
                }
                
                if (data[0] == "v") {
                    vertices.Add(new Point3D(double.Parse(data[1], CultureInfo.InvariantCulture.NumberFormat) * objScaleFactor,
                        double.Parse(data[2], CultureInfo.InvariantCulture.NumberFormat) * objScaleFactor, double.Parse(data[3], CultureInfo.InvariantCulture.NumberFormat) * objScaleFactor));
                }

                if (data[0] == "vt") {
                    textureVertices.Add(new TexturePoint(double.Parse(data[1], CultureInfo.InvariantCulture.NumberFormat), double.Parse(data[2], CultureInfo.InvariantCulture.NumberFormat)));
                }

                if (data[0] == "vn") {
                    normales.Add(new Vector(double.Parse(data[1], CultureInfo.InvariantCulture.NumberFormat), double.Parse(data[2], CultureInfo.InvariantCulture.NumberFormat), double.Parse(data[3], CultureInfo.InvariantCulture.NumberFormat)));
                }

                if (data[0] == "f") {
                    var face = new Face3D();
                    for (int i = 1; i < data.Length; i++)
                    {
                        var stringVertex = data[i].Split('/');
                        if (stringVertex.Count() < 3)
                        {
                            break;
                        }
                        face.AddVertex(new Vertex(vertices[int.Parse(stringVertex[0]) - 1],
                            normales[int.Parse(stringVertex[2]) - 1], textureVertices[int.Parse(stringVertex[1]) - 1]));
                    }
                    
                    res.AddFace(face);
                }
            }

            return res;
        }
    }
}