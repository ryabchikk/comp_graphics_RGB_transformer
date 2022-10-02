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
    public partial class Form2 : Form
    {
        Bitmap bmp;
        PictureBox pbox;
        Graphics g;

        Point start;
        Point end;

        private bool IsStartSet;
        public Form2()
        {
            InitializeComponent();
            pbox = this.pictureBox1;

            bmp = new Bitmap(pbox.Width, pbox.Height);
            //pbox.Image = bmp;

            pbox.Image = bmp ;


            IsStartSet = false;
            g = pbox.CreateGraphics();
            g.ScaleTransform(1.0F, -1.0F);
            g.TranslateTransform(0.0F, -pbox.Height);
        }

        private void ClearPoints()
        {
            IsStartSet = false;
            start = new Point(0, 0);
            end = new Point(0, 0);
        }

        private void SetPoints(Point p)
        {
            if (!IsStartSet)
            {
                start = new Point(p.X,pbox.Height - p.Y);
                IsStartSet = true;
            }
            else
                end = new Point(p.X, pbox.Height - p.Y);
        }

        private bool IsReadyToDraw() => !end.IsEmpty;

        private int GetUserChoice()
        {
            if (radioButton1.Checked)
                return 1;
            return 2;
        }

        private void SelectAlgo(int user_choice)
        {
            switch (user_choice){
                case 1: {   BresenhamDraw(); break; }
                default: { WooDraw();break; }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point point = me.Location;
            SetPoints(point);
            if (IsReadyToDraw())
            {
                SelectAlgo(GetUserChoice());
                ClearPoints();
            }
                
        }

        private void BresenhamDraw()
        {
            if(Math.Abs(start.Y - end.Y) < Math.Abs(start.X - end.X))
            {
                if(start.X > end.X)
                {
                    PlotLineX(end, start);
                }
                else
                {
                    PlotLineX(start, end);
                }
            }
            else
            {
                if(start.Y > end.Y)
                {
                    PlotLineY(end, start);
                }
                else 
                {
                    PlotLineY(start, end);
                }
                    
            }
        }


        private void WooDraw()
        {
            if (Math.Abs(start.Y - end.Y) < Math.Abs(start.X - end.X))
            {
                if (start.X > end.X)
                {
                    PlotLineWooX(end, start);
                }
                else
                {
                    PlotLineWooX(start, end);
                }
            }
            else
            {
                if (start.Y > end.Y)
                {
                    PlotLineWooY(end, start);
                }
                else
                {
                    PlotLineWooY(start, end);
                }

            }
        }



        private void PlotLineX(Point start,Point end)
        {
            int delta_x = end.X - start.X;
            int delta_y = end.Y - start.Y;
            int yi = delta_y > 0 ? 1: -1;
            delta_y = Math.Abs(delta_y);

           
            int delta = 2 * delta_y - delta_x;
            int y = start.Y;

           

            for(int x = start.X;x <= end.X; x++)
            {
                g.FillRectangle(Brushes.Black, x, y,1,1);
                if (delta > 0)
                {
                    y += yi;
                    delta += 2 * (delta_y - delta_x);
                }
                else
                    delta += 2 * delta_y;
            }
        }

        private void PlotLineY(Point start, Point end)
        {
            int delta_x = end.X - start.X;
            int delta_y = end.Y - start.Y;
            int xi = delta_x > 0 ? 1 : -1;
            delta_x = Math.Abs(delta_x);


            int delta = 2 * delta_x - delta_y;
            int x = start.X;



            for (int y = start.Y; y <= end.Y; y++)
            {
                g.FillRectangle(Brushes.Black, x, y, 1, 1);
                if (delta > 0)
                {
                    x += xi;
                    delta += 2 * (delta_x - delta_y);
                }
                else
                    delta += 2 * delta_x;
            }
        }


        private void PlotLineWooX(Point start, Point end)
        {
            float delta_x = end.X - start.X;
            float delta_y = end.Y - start.Y;
            float gradient = delta_y / delta_x;
           
            
            float y = start.Y + gradient;
           

            for (int x = start.X+1; x < end.X; x++)
            {

                using(var btmp = new Bitmap(1, 1))
                {
                    btmp.SetPixel(0, 0, Color.FromArgb((int)(1 - (y - (int)y)), 0, 0, 0));
                    g.DrawImage(btmp,x,(int)y);
                }

                using (var btmp = new Bitmap(1, 1))
                {
                    btmp.SetPixel(0, 0, Color.FromArgb((int)(y - (int)y), 0, 0, 0));
                    g.DrawImage(btmp, x, (int)y + 1);
                }
              
                y += gradient;
            }

        }


        private void PlotLineWooY(Point start, Point end)
        {
            float delta_x = end.X - start.X;
            float delta_y = end.Y - start.Y;
           
            float gradient = delta_x / delta_y;
            float x = start.X + gradient;
            for (int y = start.Y+1; y < end.Y; y++)
            {
                var btmp = new Bitmap(1, 1);
                
                    btmp.SetPixel(0, 0, Color.FromArgb((int)(1 - (x - (int)x)), 0, 0, 0));
                    g.DrawImage(btmp, (int)x, y);
                

                var btmp1 = new Bitmap(1, 1);
                
                    btmp1.SetPixel(0, 0, Color.FromArgb((int)(x - (int)x), 0, 0, 0));
                    g.DrawImage(btmp1, (int)x+1,y);
                
                x += gradient;
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearPoints();
            g.Clear(Color.Silver);
        }
    }
}
