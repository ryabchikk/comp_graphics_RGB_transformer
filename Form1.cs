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
        Graphics graphics;
        PictureBox pb;
        PictureBox pb2;
        GrayTransformer grayTransformer;
        HistogramMaker histMaker;
        HSVTransformer hsvTransformer;
        public Form1()
        {
            InitializeComponent();
            pb = this.PB_HIST_1;
            pb2 = this.PB_SOURCE;

            pb2.Image = Image.FromFile(@"../../cat.png");
            bitmap = new Bitmap(pb2.Image,pb2.Width,pb2.Height);

            graphics = pb.CreateGraphics();
            graphics.DrawImage(bitmap,0,0);

            grayTransformer = new GrayTransformer(PB_SOURCE,PB_YUV,PB_HDTV,PB_DIFF);
            histMaker = new HistogramMaker(PB_SOURCE);
            hsvTransformer = new HSVTransformer(PB_SOURCE, PB_YUV);
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
     

        private void button2_Click(object sender, EventArgs e)
        {
            grayTransformer.TransformToYUV();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            grayTransformer.TransformToHDTV();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = PB_HIST_1.CreateGraphics();
            histMaker.DrawHistogram(g, new Rectangle(0, 0, PB_HIST_1.Width, PB_HIST_1.Height),Brushes.Red,x => x.R);

             g = PB_HIST_2.CreateGraphics();
            histMaker.DrawHistogram(g, new Rectangle(0, 0, PB_HIST_2.Width, PB_HIST_2.Height), Brushes.Green, x => x.G);

             g = PB_HIST_3.CreateGraphics();
            histMaker.DrawHistogram(g, new Rectangle(0, 0, PB_HIST_3.Width, PB_HIST_3.Height), Brushes.Blue, x => x.B);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            grayTransformer.CalcDifference();
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
    }
}
