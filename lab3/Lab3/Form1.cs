using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{

    interface IColorable
    {
         Color GetColor();
    }


    public partial class Form1 : Form
    {


        Bitmap bmp;
        PictureBox pbox;
        Graphics g;

        Point? prev;
        bool DrawButtonIsPressed;
        bool FillColorButtonIsPressed;
        Color AreaBorder { get; set; }
        public Form1()
        {
            InitializeComponent();

            pbox = this.pictureBox__t_1;

            bmp = new Bitmap(pbox.Width, pbox.Height);

            pictureBox__t_1.Image = bmp;

             g =  Graphics.FromImage(pictureBox__t_1.Image);
            //g = pictureBox__t_1.CreateGraphics();
            AreaBorder = Color.Black;
            g.Clear(Color.Silver);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form frm1 = new Form2();
            //frm1.ShowDialog();
            FillColorButtonIsPressed = false;
            DrawButtonIsPressed = !DrawButtonIsPressed;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DoAction(Point? p)
        {
            if (FillColorButtonIsPressed)
            {
                RecursiveFill(prev.Value, bmp.GetPixel(prev.Value.X, prev.Value.Y), new ConstantColor(Color.Red));
                return;
            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prev = e.Location;
            if (FillColorButtonIsPressed)
            {

                RecursiveFill(e.Location, Color.Red, new ConstantColor(Color.Red));
               // RecursiveFill(new Point(151,154), Color.Red, new ConstantColor(Color.Red));
                pictureBox__t_1.Invalidate();
            }
            else
            {
                pictureBox1_MouseMove(sender, e);
               
               //  g.DrawLine(Pens.Black, 150, 150, 153, 150);
                // g.DrawLine(Pens.Black, 153, 150, 153, 158);
                 //g.DrawLine(Pens.Black, 153, 158, 150, 158);
                // g.DrawLine(Pens.Black, 150, 158, 150, 150);
                pictureBox__t_1.Invalidate();
            }
              //  pictureBox1_MouseMove(sender, e);
        }

        private bool CanDraw(Point? p, bool flg) => p != null && flg;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (CanDraw(prev, DrawButtonIsPressed))
            {

                g.DrawLine(new Pen(Color.Black,1), prev.Value, e.Location);
                prev = e.Location;
                pictureBox__t_1.Invalidate();
                // pbox.Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            prev = null;
          
        }

        private bool IsWindowBorder(Point p)
        {
            return (p.X <= 0) || (p.X >= bmp.Width) || (p.Y <= 0) || (p.Y >= bmp.Height); 
        }

        private bool IsBorder(Point p)
        {
            return IsWindowBorder(p) || IsColoredBorder(p);
        }

        private bool IsColored(Color areaColor, Color current)
        {
            return areaColor.ToArgb() == current.ToArgb();
        }

        private bool IsColoredBorder(Point p)
        {
            Color c = ((Bitmap)(pictureBox__t_1.Image)).GetPixel(p.X, p.Y);
            return c.ToArgb() == AreaBorder.ToArgb();
        }

        private void RecursiveFill(Point start,Color area,IColorable getter)
        {
         
            if (IsBorder(start) || IsColored(area, ((Bitmap)(pictureBox__t_1.Image)).GetPixel(start.X, start.Y)))
                return;

                
                Point left_border = new Point(start.X, start.Y);
                while (!IsBorder(left_border)) {
                    Brush brush1 = new SolidBrush(getter.GetColor());
                    g.FillRectangle(brush1, left_border.X, left_border.Y, 1, 1);
                    brush1.Dispose();
                    left_border = new Point(left_border.X - 1, start.Y);
                }
                
                Point right_border = new Point(start.X + 1, start.Y);

            while (!IsBorder(right_border))
            {
                Brush brush2 = new SolidBrush(getter.GetColor());
                g.FillRectangle(brush2, right_border.X, right_border.Y, 1, 1);
                brush2.Dispose();
                right_border = new Point(right_border.X + 1, start.Y);
            }
            
            for (int i = left_border.X+1; i < right_border.X; i++)
            {
                pictureBox__t_1.Invalidate();
                RecursiveFill(new Point(i, start.Y + 1), area, getter);
             
             
            }
            
           
            
            for (int i = left_border.X+1 ; i < right_border.X; i++)
            {
                 pictureBox__t_1.Invalidate();
                RecursiveFill(new Point(i, start.Y - 1), area, getter);
                
            }
            
           
        }


        private void Clear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Silver);
            pictureBox__t_1.Invalidate();
        }
        


        private void button4_Click(object sender, EventArgs e)
        {
            DrawButtonIsPressed = false;
            FillColorButtonIsPressed = !FillColorButtonIsPressed;
        }
    }

    class ConstantColor : IColorable
    {
        private Color color;
        
        public ConstantColor(Color c)
        {
            color = c;
        }

        public Color GetColor()
        {   
            return color;
        }
    }
}
