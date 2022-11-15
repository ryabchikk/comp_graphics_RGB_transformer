using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form4 : Form
    {

        Graphics g;
        
        public Form4()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.DarkGray);
            
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void DrawAxis(Graphics g)
        {
            List<Line3D> p = new List<Line3D>();
         

            Point3D a = new Point3D(0, 0, 0);
            Point3D b = new Point3D(150, 0, 0);
            Point3D c = new Point3D(0, -150, 0);
            Point3D d = new Point3D(0, 0, 150);


            var p1 = new Line3D(a, b);
            var p2 = new Line3D(a, c);
            var p3 = new Line3D(a, d);
            p1.Draw(g, Pens.Green);
            p2.Draw(g, Pens.Yellow);
            p3.Draw(g, Pens.Red);

            /*
            foreach (var x in p1)
            {
                x.Draw(g);
            }
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DrawAxis(g);
            pictureBox1.Invalidate();
        }
    }
}
