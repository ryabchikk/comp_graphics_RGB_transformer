using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    class AffineTransformator
    {
       
       
        private Graphics g;
        private Bitmap bmp;
        private PictureBox pb;
        public AffineTransformator(PictureBox _Pb, Graphics _g, Bitmap _bmp)
        {
          
            g = _g;
            bmp = _bmp;
            pb = _Pb;
        }
       
        public void Scale(int x,int y,Point p)
        {

        }

        public void Move(int x,int y)
        {

        }

        public void Rotate(int angle, Point p)
        {

        }

    }
}
