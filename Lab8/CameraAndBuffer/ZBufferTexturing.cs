using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Lab8
{
    using FastBitmap;
    class ZBufferTexturing
    {
        // Интерполяция точек
        public static List<int> Interpolate(int x1, int y1, int x2, int y2)
        {
            List<int> res = new List<int>();
            if (x1 == x2)
            {
                res.Add(y2);
            }

            double y = y1;
            for (int i = x1; i <= x2; i++)
            {
                res.Add((int) y);
                y += (y2 - y1) * 1.0f / (x2 - x1);;
            }

            return res;
        }

        //интерполяция освещенности
        public static List<TexturePoint> InterpolateTexture(int x1, TexturePoint t1, int x2, TexturePoint t2)
        {
            List<TexturePoint> res = new List<TexturePoint>();
            if (x1 == x2)
            {
                res.Add(t1);
            }

            TexturePoint step = (t2 - t1) / (x2 - x1); //с таким шагом будем получать новые значения
            TexturePoint y = t1;
            for (int i = x1; i <= x2; i++)
            {
                res.Add(y);
                y += step;
            }

            return res;
        }

        //растеризация треугольника
        public static List<Vertex> Raster(List<Vertex> points)
        {
            List<Vertex> res = new List<Vertex>();
            //отсортировать точки по неубыванию ординаты
            points.Sort((p1, p2) => p1.Y.CompareTo(p2.Y));
            
            // "рабочие точки"
            // изначально они находятся в верхней точке
            var wpoints = points.Select((p) => (x:  p.X, y:  p.Y, z:  p.Z, uv: p.texturePoint)).ToList();
            var xy01 = Interpolate(wpoints[0].y, wpoints[0].x, wpoints[1].y, wpoints[1].x);
            var xy12 = Interpolate(wpoints[1].y, wpoints[1].x, wpoints[2].y, wpoints[2].x);
            var xy02 = Interpolate(wpoints[0].y, wpoints[0].x, wpoints[2].y, wpoints[2].x);
            var yz01 = Interpolate(wpoints[0].y, wpoints[0].z, wpoints[1].y, wpoints[1].z);
            var yz12 = Interpolate(wpoints[1].y, wpoints[1].z, wpoints[2].y, wpoints[2].z);
            var yz02 = Interpolate(wpoints[0].y, wpoints[0].z, wpoints[2].y, wpoints[2].z);
            
            xy01.RemoveAt(xy01.Count() - 1);
            
            var xy = xy01.Concat(xy12).ToList();
            
            yz01.RemoveAt(yz01.Count() - 1);
            
            var yz = yz01.Concat(yz12).ToList();
            
            //когда растеризуем, треугольник делим надвое и ищем координаты, чтобы разделить треугольник на 2
            int center = xy.Count() / 2;
            
            List<int> lx, rx, lz, rz; //для приращений по координатам
            List<TexturePoint> lefttexture, righttexture; //для приращений по интенсивности цвета
            
            lefttexture = new List<TexturePoint>();
            righttexture = new List<TexturePoint>();
            
            if (xy02[center] < xy[center]) {
                lx = xy02;
                lz = yz02;
                rx = xy;
                rz = yz;
            }
            else {
                lx = xy;
                lz = yz;
                rx = xy02;
                rz = yz02;
            }

            var lighting01 = InterpolateTexture(wpoints[0].y, wpoints[0].uv, wpoints[1].y, wpoints[1].uv);
            var lighting12 = InterpolateTexture(wpoints[1].y, wpoints[1].uv, wpoints[2].y, wpoints[2].uv);
            var lighting02 = InterpolateTexture(wpoints[0].y, wpoints[0].uv, wpoints[2].y, wpoints[2].uv);
            
            lighting01.RemoveAt(lighting01.Count() - 1); //убрать точку, чтобы не было повтора
            
            var lighting = lighting01.Concat(lighting12).ToList();
            
            if (xy02[center] < xy[center]) {
                lefttexture = lighting02;
                righttexture = lighting;
            }
            else {
                lefttexture = lighting;
                righttexture = lighting02;
            }

            int y0 = wpoints[0].y;
            int y2 = wpoints[2].y;
            
            for (int i = 0; i <= y2 - y0; i++)
            {
                int leftx = lx[i];
                int rightx = rx[i];

                List<int> zcurr = Interpolate(leftx, lz[i], rightx, rz[i]);
                List<TexturePoint> texture_current = InterpolateTexture(leftx, lefttexture[i], rightx, righttexture[i]);
                
                for (int j = leftx; j < rightx; j++)
                {
                    res.Add(new Vertex(j, y0 + i, zcurr[j - leftx], texture_current[j - leftx]));
                }
            }

            return res;
        }

        //разбиение на треугольники
        public static List<List<Vertex>> Triangulate(List<Vertex> points)
        {
            //если всего 3 точки, то это уже трекгольник
            List<List<Vertex>> res = new List<List<Vertex>>();
            
            if (points.Count == 3) {
                res = new List<List<Vertex>> {points};
            }

            for (int i = 2; i < points.Count(); i++)
            {
                res.Add(new List<Vertex> {points[0], points[i - 1], points[i]}); //points[0]
            }

            return res;
        }

        public static List<List<Vertex>> RasterFigure(Figure figure, Camera camera, bool mode)
        {
            List<List<Vertex>> res = new List<List<Vertex>>();
            
            foreach (var polygon in figure.Faces)
            {
                List<Vertex> currentface = new List<Vertex>();
                List<Vertex> points = new List<Vertex>();
                
                //добавим все вершины
                for (int i = 0; i < polygon.Vertices.Count(); i++)
                {
                    points.Add(polygon.Vertices[i]);
                }

                List<List<Vertex>> triangles = Triangulate(points);
                
                foreach (var triangle in triangles)
                {
                    var planeTriangle = ProjectionToPlane(triangle, camera);
                    currentface.AddRange(Raster(planeTriangle));

                }

                res.Add(currentface);
            }

            return res;
        }

        // Проецирование точек на экран с учетом камеры и вида проекции
        public static List<Vertex> ProjectionToPlane(List<Vertex> points, Camera camera)
        {
            List<Vertex> res = new List<Vertex>();

            foreach (var p in points)
            {
                var current = p.ConvertPointTo2D(camera);
                
                if (current.Item1 != null) {
                    var tocamv = camera.ToCameraView(p);

                    Vertex newpoint = new Vertex(current.Item1.Value.X, current.Item1.Value.Y, tocamv.Zf, p.texturePoint);
                    
                    res.Add(newpoint);
                }
            }

            return res;
        }

        // Перевод координат точки согласно матрице
        public static Point3D TransformPoint(Point3D p, Matrix matrix)
        {
            var matrfrompoint = new Matrix(4, 1).Fill(p.Xf, p.Yf, p.Zf, 1);

            var matrPoint = matrix * matrfrompoint;

            Point3D newPoint = new Point3D(matrPoint[0, 0], matrPoint[1, 0], matrPoint[2, 0]);
            
            return newPoint;
        }

        public static Bitmap Zbuffer(int width, int height, List<Figure> scene, Camera camera, LightSource light, List<Color> colors, bool mode, string filename)
        {
            if (mode == true)
            {
                foreach (var shape in scene)
                {
                    Lighting.CalculateLambert(shape, light);
                }
            }

            Bitmap canvas = new Bitmap(width, height);
            
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    canvas.SetPixel(i, j, Color.White);
                }
                
            }

            double[,] zbuffer = new double[width, height];
            
            for (int i = 0; i < width; i++) 
            { 
                for (int j = 0; j < height; j++)
                {
                    zbuffer[i, j] = double.MaxValue;
                }
            }


            List<List<List<Vertex>>> rasterscene = new List<List<List<Vertex>>>();
            for (int i = 0; i < scene.Count(); i++)
            {
                rasterscene.Add(RasterFigure(scene[i], camera, mode));
            }

            Bitmap bitmap = new Bitmap(filename);
            FastBitmap texture = new FastBitmap(bitmap);
            
            int withmiddle = width / 2;
            int heightmiddle = height / 2;
            int index = 0;
            
            for (int i = 0; i < rasterscene.Count(); i++)
            {
                Color color1 = scene[i].GetColor;
                for (int j = 0; j < rasterscene[i].Count(); j++)
                {
                    List<Vertex> current = rasterscene[i][j];

                    var cntV = current.Where(x => x.texturePoint.V < 0);
                    
                    foreach (Vertex p in current)
                    {
                        int x = (p.X);

                        int y = (p.Y);

                        double u = p.texturePoint.U;
                        double v = p.texturePoint.V;

                        if (x < width && y < height && y > 0 && x > 0) {
                            if (p.Zf < zbuffer[x, y]) {
                                zbuffer[x, y] = p.Zf;
                                
                                if (mode == false) {
                                    var color = texture.GetPixel(new Point((int) (u * (texture.Width - 1)), (int) (v * (texture.Height - 1))));
                                    
                                    canvas.SetPixel(x, y, color);
                                }
                                else {
                                    canvas.SetPixel(x, y, Color.FromArgb((int) (p.lightness * color1.R), (int) (p.lightness * color1.G),(int) (p.lightness * color1.B)));
                                }
                            }
                        }
                    }

                    index++;
                }
            }

            return canvas;
        }
    }
}