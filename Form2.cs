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
   
    public partial class Form2 : Form
    {
        HistogramMaker histMaker;
        public Form2()
        {
            InitializeComponent();
            Form1 fm1 = new Form1();
            histMaker = new HistogramMaker(fm1.PB_SOURCE);

           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = PB_HIST_1.CreateGraphics();
            histMaker.DrawHistogram(g, new Rectangle(0, 0, PB_HIST_1.Width, PB_HIST_1.Height), Brushes.Red, x => x.R);
            g = PB_HIST_2.CreateGraphics();
            histMaker.DrawHistogram(g, new Rectangle(0, 0, PB_HIST_2.Width, PB_HIST_2.Height), Brushes.Green, x => x.G);

             g = PB_HIST_3.CreateGraphics();
             histMaker.DrawHistogram(g, new Rectangle(0, 0, PB_HIST_3.Width, PB_HIST_3.Height), Brushes.Blue, x => x.B);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            histMaker.GetEachChannel(PB_IMG_R, PB_IMG_G, PB_IMG_B);
        }
    }
}
