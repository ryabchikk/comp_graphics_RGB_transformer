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
    public class GrayTransformer
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
        
        Bitmap bitmap_YUV;
        Bitmap bitmap_HDTV;
        Bitmap RES;
        
        public void TransformToYUV()
        {
            Bitmap bitmap = (Bitmap)pb_source.Image;
            Bitmap bitmap_yuv = new Bitmap(bitmap.Width, bitmap.Height);

            using (var fastBitmap = new FastBitmap.FastBitmap(bitmap))
            using (var fastBitmap_yuv = new FastBitmap.FastBitmap(bitmap_yuv))
            {
                for (var x = 0; x < fastBitmap.Width; x++)
                    for (var y = 0; y < fastBitmap.Height; y++)
                    {
                        var color = fastBitmap[x, y];
                        double Y = 0.29 * color.R + 0.59 * color.G + 0.11 * color.B;
                        fastBitmap_yuv[x, y] = Color.FromArgb((int)Y, (int)Y, (int)Y);
                    }
            }

            graphics = pb_yuv.CreateGraphics();
            graphics.DrawImage(bitmap_yuv, 0, 0);
            bitmap_YUV = bitmap_yuv;

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
                        double Y = 0.21 * color.R + 0.72 * color.G + 0.07 * color.B;
                        fastBitmap_hdtv[x, y] = Color.FromArgb((int)Y, (int)Y, (int)Y);
                    }
                
            }

            graphics = pb_hdtv.CreateGraphics();
            graphics.DrawImage(bitmap_hdtv, 0, 0);
            bitmap_HDTV = bitmap_hdtv;
        }

        public void CalcDifference()
        {
            if ((bitmap_YUV != null) && (bitmap_HDTV != null) && (bitmap_YUV != bitmap_HDTV))
            {
                Bitmap res = new Bitmap(bitmap_YUV.Width, bitmap_YUV.Height);
                for (int i = 0; i < bitmap_YUV.Width; i++)
                {
                    for (int i1 = 0; i1 < bitmap_YUV.Height; i1++)
                    {
                        int diff = Math.Abs(bitmap_YUV.GetPixel(i, i1).R - bitmap_HDTV.GetPixel(i, i1).R);
                        res.SetPixel(i, i1, Color.FromArgb(diff, diff, diff));
                    }
                }

                graphics = pb_diff.CreateGraphics();
                graphics.DrawImage(res, 0, 0);
                RES = res;

            }
        }


        public Bitmap first() {
            Bitmap bitmap = (Bitmap)pb_source.Image;
            Bitmap bitmap_yuv = new Bitmap(bitmap.Width, bitmap.Height);

            using (var fastBitmap = new FastBitmap.FastBitmap(bitmap))
            using (var fastBitmap_yuv = new FastBitmap.FastBitmap(bitmap_yuv))
            {
                for (var x = 0; x < fastBitmap.Width; x++)
                    for (var y = 0; y < fastBitmap.Height; y++)
                    {
                        var color = fastBitmap[x, y];
                        double Y = 0.29 * color.R + 0.59 * color.G + 0.11 * color.B;
                        fastBitmap_yuv[x, y] = Color.FromArgb((int)Y, (int)Y, (int)Y);
                    }
            }
            bitmap_YUV = bitmap_yuv;
            return bitmap_YUV; }
        public Bitmap second() {
            Bitmap bitmap = (Bitmap)pb_source.Image;
            Bitmap bitmap_hdtv = new Bitmap(bitmap.Width, bitmap.Height);

            using (var fastBitmap = new FastBitmap.FastBitmap(bitmap))
            using (var fastBitmap_hdtv = new FastBitmap.FastBitmap(bitmap_hdtv))
            {
                for (var x = 0; x < fastBitmap.Width; x++)
                    for (var y = 0; y < fastBitmap.Height; y++)
                    {
                        var color = fastBitmap[x, y];
                        double Y = 0.21 * color.R + 0.72 * color.G + 0.07 * color.B;
                        fastBitmap_hdtv[x, y] = Color.FromArgb((int)Y, (int)Y, (int)Y);
                    }

            }

            bitmap_HDTV = bitmap_hdtv;
            return bitmap_HDTV; }
        
    }
}
