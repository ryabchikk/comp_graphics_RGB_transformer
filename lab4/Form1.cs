using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form1 : Form
    {
        PictureBox pb;
        private PrimitiveDrawer drawer;
        private Graphics g;
        private Bitmap bmp;
        private AffineTransformator affine;
        Point p;
        
        public Form1()
        {
            InitializeComponent();
            RadioButton[] primitivesRadioButtons = new RadioButton[3] { DotRadioButton, LineRadioButton, PolygonRadioButton };

            pb = pictureBox1;
            bmp = new Bitmap(pb.Width, pb.Height);

            pictureBox1.Image = bmp;

            g = Graphics.FromImage(pictureBox1.Image);

            drawer = new PrimitiveDrawer(pb,g,bmp, primitivesRadioButtons);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

     
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsDrawing())
            {
                drawer.Draw(e.Location);
            }
            else
                p = e.Location;
           
        }

        private bool IsDrawing() => DotRadioButton.Checked || LineRadioButton.Checked || PolygonRadioButton.Checked;

        private void button2_Click(object sender, EventArgs e)
        {

            int x = string.IsNullOrEmpty(textBox1.Text) ? 0 : int.Parse(textBox1.Text);
            int y = string.IsNullOrEmpty(textBox2.Text) ? 0 : int.Parse(textBox2.Text);

            if (MoveRadioButton.Checked)
            {
                affine.Move(x, y);
                return;
            }

            if (ScalingRadioButton.Checked)
            {
               
                if (checkBox1.Checked)
                {
                    affine.Scale(x, y,p);
                    return;
                } else
                    affine.Scale(x, y, Point.Empty);
            }

            if (RotateRadioButton.Checked)
            {
               int angle = string.IsNullOrEmpty(textBox3.Text) ? 0 : int.Parse(textBox3.Text);
                if (checkBox1.Checked)
                {
                    affine.Rotate(angle, p);
                    return;
                }
                else
                    affine.Rotate(angle,Point.Empty);

            }

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
