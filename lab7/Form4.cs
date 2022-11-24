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
        Func<float, float, float> function;
        public Form4()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.DarkGray);
            comboBox1.Items.Add("x*x + y*y");
            comboBox1.Items.Add("x + y");
            comboBox1.Items.Add("x*x + y*y");
            Point3D.projection = "perspective";

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void DrawAxis()
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

        Tuple<int,int,int,int,int> GetUserInput()
        {
            if (!int.TryParse(textBox1.Text, out int x0))
            {
                MessageBox.Show("Incorrect x0", "Some title",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!int.TryParse(textBox3.Text, out int x1))
            {
                MessageBox.Show("Incorrect x1", "Some title",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!int.TryParse(textBox2.Text, out int y0))
            {
                MessageBox.Show("Incorrect y0", "Some title",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!int.TryParse(textBox4.Text, out int y1))
            {
                MessageBox.Show("Incorrect y1", "Some title",
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!int.TryParse(textBox5.Text, out int step))
            {
                if (step == 0)
                    MessageBox.Show("Incorrect step", "Some title",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return new Tuple<int, int, int, int,int>(x0, x1, y0, y1, step);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DrawAxis();
            
            if(function != null)
            {
                var input = GetUserInput();
                float stepX = (input.Item2 - input.Item1) * 1.0f / input.Item5;
                float stepY = (input.Item4 - input.Item3) * 1.0f / input.Item5;
                DrawSurface(input.Item1, input.Item2, input.Item3, input.Item4,stepX, stepY);
            }
            
         /*   
            Point3D p = new Point3D(0, 0, -30);
          //  Point3D p1 = new Point3D(10, -50, 0);
           // Point3D p2 = new Point3D(0, 0, 300);
            p.Draw(g);
            //p1.Draw(g);
            //p2.Draw(g);
           */ 
            pictureBox1.Invalidate();
        }

        private float SimpleSquareFunction(float x, float y)
        {
            return x * x + y * y;
        }

        private float SimpleFunction(float x, float y)
        {
            return x + y ;
        }

        Func<float, float, float> GetSelectedFunc(string func)
        {
            switch (func)
            {
                case "x*x + y*y": return SimpleSquareFunction;
                case "x+y": return SimpleFunction;
            }

            return SimpleSquareFunction;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFunc = comboBox1.SelectedItem.ToString();
            function = GetSelectedFunc(selectedFunc);
        }

        private void DrawSurface(int x0,int x1,int y0,int y1,float stepX,float stepY)
        {
            Surface3D surface = new Surface3D();
            for(float x = x0;x < x1; x += stepX)
            {
                for (float y = y0; y < y1; y += stepY)
                {
                    var f = new Face3D();
                    f.AddLine(new Line3D(new Point3D(x, -y, function(x, y)), new Point3D(x + stepX, -y, function(x + stepX, y))));
                    f.AddLine(new Line3D(new Point3D(x + stepX, -y, function(x + stepX, y)), new Point3D(x + stepX, -y - stepY, function(x + stepX, y + stepY))));
                    f.AddLine(new Line3D(new Point3D(x + stepX, -y - stepY, function(x + stepX, y + stepY)), new Point3D(x, y+stepY, function(x, y+stepY))));
                    f.AddLine(new Line3D(new Point3D(x , -y - stepY, function(x, y + stepY)), new Point3D(x, y, function(x, y ))));
                    surface.AddFace(f);
                }
            }
            surface.Draw(g);
        }

        void Clear()
        {  
            g.Clear(Color.DarkGray);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
            pictureBox1.Invalidate();
            DrawAxis();
        }
    }
}
