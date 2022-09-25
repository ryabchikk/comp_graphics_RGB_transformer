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
            g.Clear(Color.White);
            float max = histPoints.Max();
            if (max > 0)

                for (int i = 0; i < histPoints.Length; i++)
                {
                    float h = rect.Height * histPoints[i] / max;
                    g.FillRectangle(b, i * rect.Width / (float)histPoints.Length, rect.Height - h + rect.Y, rect.Width / (float)histPoints.Length, h);
                }
        }


    }
}
