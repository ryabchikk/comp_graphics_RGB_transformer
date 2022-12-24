using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Lab8
{
    class Zbuffer
    {
        // Интерполяция точек
        public static List<int> Interpolate(int x1, int y1, int x2, int y2)
        {
            List<int> res = new List<int>();
            
            if (x1 == x2) {
                res.Add(y2);
            }

            double y = y1;

            for (int i = x1; i <= x2; i++)
            {
                res.Add((int) y);

                y += (y2 - y1) * 1.0f / (x2 - x1);
            }

            return res;
        }

        //интерполяция освещенности
        public static List<double> InterpolateIntense(int x1, double i1, int x2, double i2)
        {
            List<double> res = new List<double>();
            
            if (x1 == x2) {
                res.Add(i1);
            }

            double y = i1;

            for (int i = x1; i <= x2; i++)
            {
                res.Add(y);
                y += (i2 - i1) / (x2 - x1);;
            }

            return res;
        }

        //растеризация треугольника
        public static List<Point3D> Raster(List<Point3D> points,bool mode)
        {
            List<Point3D> res = new List<Point3D>();
            
            //отсортировать точки по неубыванию ординаты
            points.Sort((p1, p2) => p1.Y.CompareTo(p2.Y));
            
            // "рабочие точки"
            // изначально они находятся в верхней точке
            var wpoints = points.Select((p) => (x: (int) p.X, y: (int) p.Y, z: (int) p.Z,intense: p.light)).ToList();
            var xy01 = Interpolate(wpoints[0].y, wpoints[0].x, wpoints[1].y, wpoints[1].x);
            var xy12 = Interpolate(wpoints[1].y, wpoints[1].x, wpoints[2].y, wpoints[2].x);
            var xy02 = Interpolate(wpoints[0].y, wpoints[0].x, wpoints[2].y, wpoints[2].x);
            var yz01 = Interpolate(wpoints[0].y, wpoints[0].z, wpoints[1].y, wpoints[1].z);
            var yz12 = Interpolate(wpoints[1].y, wpoints[1].z, wpoints[2].y, wpoints[2].z);
            var yz02 = Interpolate(wpoints[0].y, wpoints[0].z, wpoints[2].y, wpoints[2].z);
            xy01.RemoveAt(xy01.Count() - 1); //убрать точку, чтобы не было повтора
            var xy = xy01.Concat(xy12).ToList();
            yz01.RemoveAt(yz01.Count() - 1);
            var yz = yz01.Concat(yz12).ToList();
            
            //когда растеризуем, треугольник делим надвое
            //ищем координаты, чтобы разделить треугольник на 2
            int center = xy.Count() / 2;
            
            List<int> lx, rx, lz, rz; //для приращений по координатам
            List<double> leftintense, rightintense;//для приращений по интенсивности цвета
            
            leftintense = new List<double>();
            rightintense = new List<double>();
            
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

            if (mode)
            {
                var lighting01 = InterpolateIntense(wpoints[0].y, wpoints[0].intense, wpoints[1].y, wpoints[1].intense);
                var lighting12 = InterpolateIntense(wpoints[1].y, wpoints[1].intense, wpoints[2].y, wpoints[2].intense);
                var lighting02 = InterpolateIntense(wpoints[0].y, wpoints[0].intense, wpoints[2].y, wpoints[2].intense);
                
                lighting01.RemoveAt(lighting01.Count() - 1); //убрать точку, чтобы не было повтора
                
                var lighting = lighting01.Concat(lighting12).ToList();
                
                if (xy02[center] < xy[center])
                {
                    leftintense = lighting02;
                    rightintense = lighting;
                   
                }
                else
                {
                    leftintense = lighting;
                    rightintense = lighting02;
                }

                //когда растеризуем, треугольник делим надвое
                //ищем координаты, чтобы разделить треугольник на 2

            }
          
            int y0 = wpoints[0].y;
            int y2 = wpoints[2].y;
            
            for (int i = 0; i <= y2 - y0; i++)
            {
                int leftx = lx[i];
                int rightx = rx[i];
                List<int> zcurr = Interpolate(leftx, lz[i], rightx, rz[i]);
                if (mode)//если освещаем, то интерполируем освещенность, которую мы получили в вершинах
                {
                    List<double> intense_current = InterpolateIntense(leftx, leftintense[i], rightx, rightintense[i]);
                    for (int j = leftx; j < rightx; j++)
                    {
                        res.Add(new Point3D(j, y0 + i, zcurr[j - leftx], intense_current[j - leftx]));
                    }
                }
                else
                {
                    for (int j = leftx; j < rightx; j++)
                    {
                        res.Add(new Point3D(j, y0 + i, zcurr[j - leftx]));
                    }
                }
            }

            return res;
        }

        //разбиение на треугольники
        public static List<List<Point3D>> Triangulate(List<Point3D> points)
        {
            List<List<Point3D>> res = new List<List<Point3D>>();
            if (points.Count == 3)
            {
                res = new List<List<Point3D>> {points};
            }

            for (int i = 2; i < points.Count(); i++)
            {
                res.Add(new List<Point3D> {points[0], points[i - 1], points[i]}); //points[0]
            }

            return res;
        }

        //растеризовать фигуру
        public static List<List<Point3D>> RasterFigure(Figure figure, Camera camera,bool mode)
        {
            List<List<Point3D>> res = new List<List<Point3D>>();
            foreach (var polygon in figure.Faces) //каждая грань-это многоугольник, который надо растеризовать
            {
                
                List<Point3D> currentface = new List<Point3D>();
                List<Point3D> points = new List<Point3D>();
                
                //добавим все вершины
                for (int i = 0; i < polygon.Vertices.Count(); i++)
                {
                    points.Add(polygon.Vertices[i]);
                }

                List<List<Point3D>> triangles = Triangulate(points); //разбили все грани на треугольники
                
                foreach (var triangle in triangles)
                {
                    currentface.AddRange(Raster(ProjectionToPlane(triangle, camera),mode));
                }

                res.Add(currentface);
            }

            return res;
        }

        // Проецирование точек на экран с учетом камеры и вида проекции
        public static List<Point3D> ProjectionToPlane(List<Point3D> points, Camera camera)
        {
            List<Point3D> res = new List<Point3D>();
            foreach (var p in points)
            {
                var current = p.ConvertPointTo2D(camera);
                if (current.Item1 != null)
                {
                    Point3D newpoint = new Point3D(current.Item1.Value.X, current.Item1.Value.Y, current.Item2,p.lightness);
                    res.Add(newpoint);
                }
            }

            return res;
        }

        // Алгоритм Z буфера
        public static Bitmap Zbuff(int width, int height, List<Figure> scene, Camera camera, LightSource light, List<Color> colors,bool mode)
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
               for (int j = 0; j < height; j++)
                    canvas.SetPixel(i, j, Color.Black);
            
            double[,] zbuffer = new double[width, height];
            
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    zbuffer[i, j] = double.MaxValue;
            
            List<List<List<Point3D>>> rasterscene = new List<List<List<Point3D>>>();
            
            for (int i = 0; i < scene.Count(); i++)
            {
                rasterscene.Add(RasterFigure(scene[i], camera,mode)); //растеризовали все фигуры
            }

            int index = 0;

            for (int i = 0; i < rasterscene.Count(); i++)
            {
                Color color1 = scene[i].GetColor;
                for (int j = 0; j < rasterscene[i].Count(); j++)
                {
                    List<Point3D> current = rasterscene[i][j];
                    foreach (Point3D p in current)
                    {
                        int x = (p.X);
                        int y = (p.Y);

                        if (x < width && y < height && y > 0 && x > 0) {
                            
                            if (p.Zf < zbuffer[x, y]) {
                                zbuffer[x, y] = p.Zf;
                                if (mode == false) {
                                    canvas.SetPixel(x, y, colors[index % colors.Count()]);
                                }
                                else {
                                    canvas.SetPixel(x, y, Color.FromArgb((int)(p.lightness * color1.R), (int)(p.lightness * color1.G), (int)(p.lightness * color1.B)));
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