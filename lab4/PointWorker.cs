using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    class PointWorker
    {
        private Graphics g;
        private Bitmap bmp;
        private PictureBox pb;

        public PointWorker(PictureBox _Pb, Graphics _g, Bitmap _bmp)
        {

            g = _g;
            bmp = _bmp;
            pb = _Pb;
        }

        public void FindIntersection()
        {

        }

        public bool IsInPolygon()
        {
            return false;
        }

        public void GetPointLocation(List<Point> Line)
        {
           
        }

    }
}
