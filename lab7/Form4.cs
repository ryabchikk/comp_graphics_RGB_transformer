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
        Surface3D surface;
        public Form4()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.DarkGray);
            comboBox1.Items.Add("x*x + y*y");
            comboBox1.Items.Add("x*y");

            comboBox2.Items.Add("perspective");
            comboBox2.Items.Add("isometric");

            Point3D.projection = "perspective";
            surface = new Surface3D();
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


            var pX = new Line3D(a, b);
            var pC = new Line3D(a, c);
            var pZ = new Line3D(a, d);
            pX.Draw(g, Pens.Green);
            pC.Draw(g, Pens.Yellow);
            pZ.Draw(g, Pens.Red);



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
            ReDraw();
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
            return x * y ;
        }

        Func<float, float, float> GetSelectedFunc(string func)
        {
            switch (func)
            {
                case "x*x + y*y": return SimpleSquareFunction;
                case "x*y": return SimpleFunction;
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
            surface = new Surface3D();
            pictureBox1.Invalidate();
            DrawAxis();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Point3D.projection = comboBox2.SelectedItem.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private Transform GetMoveParams()
        {
            return Transform.Translate((double)numericUpDown1.Value, (double)numericUpDown2.Value, (double)numericUpDown3.Value);
        }

        private Transform GetRotateParams()
        {
            var t1 = (double)numericUpDown4.Value / 180 * Math.PI;
            var t2 = (double)numericUpDown5.Value / 180 * Math.PI;
            var t3 = (double)numericUpDown6.Value / 180 * Math.PI;

            return Transform.RotateX(t1) * Transform.RotateY(t2) * Transform.RotateZ(t3);
        }

        private Transform GetScaleParams()
        {
            return Transform.Scale((double)numericUpDown7.Value, (double)numericUpDown8.Value, (double)numericUpDown9.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReDraw();
            surface.ApplyTransformation(GetScaleParams());
            surface.ApplyTransformation(GetMoveParams());
            surface.ApplyTransformation(GetRotateParams());
            surface.Draw(g);
            pictureBox1.Invalidate();
        }

        private void ReDraw()
        {
            g.Clear(Color.DarkGray);
            DrawAxis();
            pictureBox1.Invalidate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
