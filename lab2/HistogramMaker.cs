using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastBitmap;
using System.Drawing;
using System.Windows.Forms;


namespace Lab2
{
    class HistogramMaker
    {
        PictureBox pb_source;
        public HistogramMaker(PictureBox source)
        {
            pb_source = source;
        }

        private static int[] GetHist(int length, Bitmap bitmap, Func<Color, byte> func)
        {
            var hist = new int[length];
            bitmap.ForEach(color => hist[func(color)]++);
            return hist;
        }

        public void DrawHistogram(Graphics g, Rectangle rect, Brush b, Func<Color, byte> func)
        {
            Bitmap bitmap = new Bitmap(pb_source.Image,rect.Width,rect.Height);
            var histPoints = GetHist(256,bitmap ,func);
            g.Clear(Color.Black);
            float max = histPoints.Max();
            if (max > 0)

                for (int i = 0; i < histPoints.Length; i++)
                {
                    float h = rect.Height * histPoints[i] / max;
                    g.FillRectangle(b, i * rect.Width / (float)histPoints.Length, rect.Height - h + rect.Y, rect.Width / (float)histPoints.Length, h);
                }
        }

        public void GetEachChannel(PictureBox pb_r, PictureBox pb_g, PictureBox pb_b)
        {
            DrawChannel(pb_r, color => Color.FromArgb(color.A, color.R, 0,0));
            DrawChannel(pb_b, color => Color.FromArgb(color.A, 0, 0, color.B));
            DrawChannel(pb_g, color => Color.FromArgb(color.A, 0, color.G, 0));
        }


        private void DrawChannel(PictureBox target,Func<Color,Color> transformer)
        {
            Bitmap bitmap_source = (Bitmap)pb_source.Image;
            Bitmap bitmap_target = new Bitmap(bitmap_source.Width, bitmap_source.Height);

            using (var fstbmp = new FastBitmap.FastBitmap(bitmap_target))
            using (var fastBitmap = new FastBitmap.FastBitmap(bitmap_source))
            {
                for (var x = 0; x < fastBitmap.Width; x++)
                {
                    for (var y = 0; y < fastBitmap.Height; y++)
                    {
                        fstbmp[x, y] = transformer(fastBitmap[x, y]); 
                    }
                }

            }

            Graphics graphics = target.CreateGraphics();
            graphics.DrawImage(bitmap_target, 0, 0);
        }

    }
}
