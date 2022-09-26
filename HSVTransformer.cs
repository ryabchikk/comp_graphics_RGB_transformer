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
    class HSVTransformer
    {
        PictureBox pb_source;
        PictureBox pb_hsv;

        private bool was_initialized;
        
        public HSVTransformer(PictureBox source,PictureBox hsv)
        {
            pb_source = source;
            pb_hsv = hsv;
            was_initialized = false;
        }

        private Color GetColorFromHSV(double H, double S, double V)
        {
            return Color.White;
        }

        public void Tranform(double H,double S,double V)
        {
         

            if (!was_initialized) {
                was_initialized = true;
                pb_hsv.Image = (Image)pb_source.Image.Clone();
            }

            Bitmap bitmap_hsv = (Bitmap)pb_hsv.Image;

            using (var fastBitmap = new FastBitmap.FastBitmap(bitmap_hsv))
            {
                for (var x = 0; x < fastBitmap.Width; x++) 
                { 
                     for (var y = 0; y < fastBitmap.Height; y++)
                    {
                        var color = fastBitmap[x, y];
                        fastBitmap[x, y] = GetColorFromHSV(H,S,V);
                    }
                }
                   
            }

            Graphics graphics = pb_hsv.CreateGraphics();
            graphics.DrawImage(bitmap_hsv, 0, 0);
        }
    }
}
