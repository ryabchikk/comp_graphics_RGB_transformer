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
    class GrayTransformer
    {
        PictureBox pb_source;
        PictureBox pb_yuv;
        PictureBox pb_hdtv;
        PictureBox pb_diff;
        Graphics graphics;
        public GrayTransformer(PictureBox source, PictureBox yuv, PictureBox hdtv, PictureBox diff)
        {
            pb_source = source;
            pb_yuv = yuv;
            pb_hdtv = hdtv;
            pb_diff = diff;
        }

        public void TransformToYUV()
        {
            Bitmap bitmap = (Bitmap)pb_source.Image;
            Bitmap bitmap_yuv = new Bitmap(bitmap.Width,bitmap.Height);

            using (var fastBitmap = new FastBitmap.FastBitmap(bitmap))
            using (var fastBitmap_yuv = new FastBitmap.FastBitmap(bitmap_yuv))
            {
                for (var x = 0; x < fastBitmap.Width; x++)
                    for (var y = 0; y < fastBitmap.Height; y++)
                    {
                        var color = fastBitmap[x, y];
                        double Y =0.299* color.R  +0.587* color.G +0.114*color.B;
                        fastBitmap_yuv[x, y] = Color.FromArgb((int)Y,(int)Y,(int)Y);
                    }
            }

            graphics = pb_yuv.CreateGraphics();
            graphics.DrawImage(bitmap_yuv, 0, 0);

        }

        public void TransformToHDTV()
        {
            Bitmap bitmap = (Bitmap)pb_source.Image;
            Bitmap bitmap_hdtv = new Bitmap(bitmap.Width, bitmap.Height);

            using (var fastBitmap = new FastBitmap.FastBitmap(bitmap))
            using (var fastBitmap_hdtv = new FastBitmap.FastBitmap(bitmap_hdtv))
            {
                for (var x = 0; x < fastBitmap.Width; x++)
                    for (var y = 0; y < fastBitmap.Height; y++)
                    {
                        var color = fastBitmap[x, y];
                        double Y = 0.2126 * color.R + 0.7152 * color.G + 0.0722 * color.B;
                        fastBitmap_hdtv[x, y] = Color.FromArgb((int)Y, (int)Y, (int)Y);
                    }

            }

            graphics = pb_hdtv.CreateGraphics();
            graphics.DrawImage(bitmap_hdtv, 0, 0);

        }

        public void CalcDifference()
        {

        }

    }
}
