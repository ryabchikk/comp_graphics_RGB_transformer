using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    class PrimitiveDrawer
    {
        private RadioButton[] radioButtons;
        private Graphics g;
        private Bitmap bmp;
        private PictureBox pb;
        public PrimitiveDrawer(PictureBox _Pb,Graphics _g,Bitmap _bmp,RadioButton[] arr)
        {
            radioButtons = arr;
            g = _g;
            bmp = _bmp;
            pb = _Pb;
        }

        public void Draw(Point p)
        {
            int ind = GetCheckedButton();
            switch (ind)
            {
                case 1: {DrawPoint(p); break; }
                case 2: { DrawLine(p);break; }
                case 3: { DrawPolygon(p); break; }

            }
        }

        private void DrawPoint(Point p)
        {

        }

        private void DrawLine(Point p)
        {

        }

        private void DrawPolygon(Point p)
        {

        }

        private int GetCheckedButton()
        {
            return radioButtons.Select((x, i) => new { x, V = i +1 }).Where(x => x.x.Checked).Select(x => x.V).LastOrDefault();
        }

    }
}
