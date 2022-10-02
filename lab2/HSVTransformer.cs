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
        private double CalculateValue(double max,double degreeV) 
        {
            double result = max;
            result *= 200 * degreeV;
            result /= 100;
            return result;
        }

        private double CalculateSaturation(double max,double min, double degreeS) 
        {
            double saturation = 0;
            
            if(max!=0) {
                saturation = 1 - (min / max);
            }
            
            saturation *= 200 * degreeS;
            
            if (saturation >= 100) {
                saturation = 100;
            }
            
            saturation /= 100;

            return saturation;
        }
        
        private void CheckColor(ref double color) 
        {
            if (color > 255) {
                color = 255;
            }
            if (color< 0) {
                color = 0;
            }
        }
        private Color GetColorFromHSV(double degreeH, double degreeS, double degreeV,Color pixel)
        {
            double R, G, B, S, V = 0;
            double C, X, Y, Z = 0;
            double H = 1;
            double max, min = 0;

            R = (double)pixel.R/100;
            G = (double)pixel.G/100;
            B = (double)pixel.B/100;
            
            max = Math.Max(R, Math.Max(G, B));
            min = Math.Min(R, Math.Min(G, B));
            
            V = CalculateValue(max, degreeV);
            S = CalculateSaturation(max, min, degreeS);
            H *= degreeH;

            if (S == 0) { 
                R = G = B = V;
            } 
            else {
                
                H = H / 60;
                int i = (int)H;
                C = H - i;
                X = V * (1.0 - S);
                Y = V * (1 - S * C);
                Z = V * (1 - S * (1 - C));
                
                switch (i)
                {
                    case 0: R = V; G = Z; B = X; break;
                    case 1: R = Y; G = V; B = X; break;
                    case 2: R = X; G = V; B = Z; break;
                    case 3: R = X; G = Y; B = V; break;
                    case 4: R = Z; G = X; B = V; break;
                    case 5: R = V; G = X; B = Y; break;
                }

            }

            R *= 100; 
            G *= 100; 
            B *= 100;
            
            CheckColor(ref R);
            CheckColor(ref G);
            CheckColor(ref B);
            return Color.FromArgb(255, (int)R, (int)G, (int)B);

        }

        public void Tranform(double H,double S,double V)
        {
            
            if (!was_initialized) {
                was_initialized = true;
                pb_hsv.Image = (Image)pb_source.Image.Clone();
            }
            
            pb_hsv.Image.Dispose();
            pb_hsv.Image = (Image)pb_source.Image.Clone();
            
            Bitmap bitmap_hsv = (Bitmap)pb_hsv.Image;

            using (var fastBitmap = new FastBitmap.FastBitmap(bitmap_hsv))
            {
                for (var x = 0; x < fastBitmap.Width; x++) 
                { 
                     for (var y = 0; y < fastBitmap.Height; y++)
                     {
                        var color = fastBitmap[x, y];
                        fastBitmap[x, y] = GetColorFromHSV(H, S, V,color );
                        
                     }
                }
                   
            }
            
            Graphics graphics = pb_hsv.CreateGraphics();
            graphics.DrawImage(bitmap_hsv, 0, 0);
        }
    }
}
