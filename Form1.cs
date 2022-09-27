using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using  FastBitmap;

namespace Lab2
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        PictureBox pb2;
        HSVTransformer hsvTransformer;
        public Form1()
        {
            InitializeComponent();
            pb2 = this.PB_SOURCE;
            pb2.Image = Image.FromFile(@"../../cat.png");

            bitmap = new Bitmap(pb2.Image,pb2.Width,pb2.Height);
            hsvTransformer = new HSVTransformer(PB_SOURCE, PB_HSV);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar2.Value = 50;
            trackBar3.Value = 50;
            hsvTransformer.Tranform(GetH(), GetS(), GetV());
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.ShowDialog();
        }

        private double GetH()
        {
            var H = this.trackBar1.Value;
            return H;
        }

        private double GetS()
        {
            var S = this.trackBar2.Value;
            return S / 100.0;
        }

        private double GetV()
        {
            var V = this.trackBar3.Value;
            return  V / 100.0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
            hsvTransformer.Tranform(GetH(), GetS(), GetV());
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            hsvTransformer.Tranform(GetH(), GetS(), GetV());
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            hsvTransformer.Tranform(GetH(), GetS(), GetV());
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            hsvTransformer.Tranform(GetH(), GetS(), GetV());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 fm3 = new Form3();
            fm3.ShowDialog();
        }

    }
}
