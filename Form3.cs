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

        private void button1_Click(object sender, EventArgs e)
        {
            grayTransformer.TransformToYUV();
            grayTransformer.TransformToHDTV();
            grayTransformer.CalcDifference();
        }
    }
}
