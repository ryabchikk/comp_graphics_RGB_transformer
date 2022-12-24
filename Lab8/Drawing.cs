using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lab8
{
    using FastBitmap;
    public partial class Form1
    {
        Pen whitePen = new Pen(Color.White, 3);
        Pen highlightPen = new Pen(Color.DarkRed, 3);
        
        FastBitmap fbitmap;

        // Рисует фигуры на канвасе, выделяя цветом выбранную фигуру
        void DrawFigure(Figure shape, Pen pen)
        {
            foreach (var face in shape.Faces)
            {
                DrawFace(face, pen);
            }
        }

        // Рисует заданную границу грани заданным цветом
        void DrawFace(Face3D face, Pen pen)
        {
            for (var i = 0; i < face.Vertices.Count; i++)
            {
                DrawLine(face.Vertices[i],face.Vertices[(i+1) % face.Vertices.Count], pen);
            }
            
            // TODO: Здесь можно включить отображение нормалей грани
            //var norm = face.NormVector;
            //DrawLine(face.GetCenter(), new Point3D((int)(face.GetCenter().Xf + norm.x * 50), (int)(face.GetCenter().Yf + norm.y * 50), (int)(face.GetCenter().Zf + norm.z * 50)), new Pen(Color.GreenYellow));
        }

        // Рисует линию, переводя её координаты из 3D в 2D
        void DrawLine(Point3D start, Point3D end, Pen pen)
        {
            var pf1 = start.ConvertPointTo2D(camera).Item1;
            var pf2 = end.ConvertPointTo2D(camera).Item1;
            if(pf1.HasValue && pf2.HasValue)
            {
                AdditionalAlgorithms.DrawVuLine(ref fbitmap, new Point((int)pf1.Value.X, (int)(pf1.Value.Y)), new Point((int)pf2.Value.X, (int)(pf2.Value.Y)), pen.Color);
            }
        }


        // Перерисовывает всю сцену
        void RedrawScene()
        {
            var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            fbitmap = new FastBitmap(bitmap);
            
            for (int i = 0; i < sceneShapes.Count; i++)
            {
                if(i == listBox1.SelectedIndex) {
                    DrawFigure(sceneShapes[i], highlightPen);
                    continue;
                }
                DrawFigure(sceneShapes[i], whitePen);
            }
            
            DrawLine(camera.cameraPosition, new Point3D(camera.cameraPosition.Xf + camera.cameraDirection.x * 50, camera.cameraPosition.Yf + camera.cameraDirection.y * 50, camera.cameraPosition.Zf + camera.cameraDirection.z * 50), new Pen(Color.CadetBlue));
            DrawLine(camera.cameraPosition, new Point3D(camera.cameraPosition.Xf + camera.cameraRight.x * 50, camera.cameraPosition.Yf + camera.cameraRight.y * 50, camera.cameraPosition.Zf + camera.cameraRight.z * 50), new Pen(Color.DarkOrange));
            DrawLine(camera.cameraPosition, new Point3D(camera.cameraPosition.Xf + camera.cameraUp.x * 50, camera.cameraPosition.Yf + camera.cameraUp.y * 50, camera.cameraPosition.Zf + camera.cameraUp.z * 50), new Pen(Color.Violet));

            List<Point3D> lig = Lab8.Zbuffer.ProjectionToPlane(new List<Point3D> { lightSource.Position }, camera);

            fbitmap.Dispose();
            String text = "x:";
            text += lightSource.Position.Xf.ToString();
           
            text += "y:";
            text += lightSource.Position.Yf.ToString();
            
            text += "z:";
            text += lightSource.Position.Zf.ToString();
            
            pictureBox1.Image = bitmap;
        }
        
        // Генерирует множество цветов
        List<Color> GenerateColors()
        {
            List<Color> res = new List<Color>();
           Random r;
            r= new Random();
            for (int i = 0; i < 50; ++i)
               res.Add(Color.FromArgb(r.Next(0, 255), r.Next(0, 100), r.Next(10, 255)));
            return res;
        }
    }
}
