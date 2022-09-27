using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form3 : Form
    {
        GrayTransformer grayTransformer;
        public Form3()
        {
            InitializeComponent();

            Form1 fm1 = new Form1();
            grayTransformer = new GrayTransformer(fm1.PB_SOURCE, PB_YUV, PB_HDTV, PB_DIFF);

            
        }
        public void GenHistogram(Bitmap source1, int chartt)
        {
            Dictionary<int, int> pixelintensities = new Dictionary<int, int>();

            for (int i = 0; i < 256; i++)
            {
                pixelintensities.Add(i, 0);
            }

            for (int i = 0; i < source1.Width; i++)
            {
                for (int i1 = 0; i1 < source1.Height; i1++)
                {
                    int x = source1.GetPixel(i, i1).B;
                    pixelintensities[x] += 1;
                }
            }
            
            List<int> c = new List<int>();

            for (int i = 1; i < 257; i++) c.Add(i);

            if (chartt == 1)
                this.chart1.Series["Series1"].Points.DataBindXY(c, pixelintensities.Values);
            else
                this.chart2.Series["Series1"].Points.DataBindXY(c, pixelintensities.Values);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grayTransformer.TransformToYUV();
            grayTransformer.TransformToHDTV();
            grayTransformer.CalcDifference();            
            Bitmap bitmap_YUV = grayTransformer.first();
            Bitmap bitmap_HDTV = grayTransformer.second();
            GenHistogram(bitmap_YUV, 1);
            GenHistogram(bitmap_HDTV, 2);
        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }
    }
}
