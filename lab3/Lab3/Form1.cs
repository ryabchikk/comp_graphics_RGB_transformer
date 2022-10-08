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
        TextureBrush textureBrush;
        HashSet<Point> filledPoints = new HashSet<Point>();
        Color borderColor = Color.FromArgb(255, 0, 0, 0);
        Point mouseCoord;

        Point? prev;
        bool DrawButtonIsPressed;
        bool FillColorButtonIsPressed;
        bool FillTextureButtonIsPressed;
        bool FillBorderIsPressed;
        Color AreaBorder { get; set; }
        public Form1()
        {
            InitializeComponent();

            pbox = this.pictureBox__t_1;

            bmp = new Bitmap(pbox.Width, pbox.Height);

            pictureBox__t_1.Image = bmp;

             g =  Graphics.FromImage(pictureBox__t_1.Image);
            //g = pictureBox__t_1.CreateGraphics();
            AreaBorder = Color.FromArgb(255, 0, 0, 0);
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


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prev = e.Location;
            mouseCoord = e.Location;
            if (FillColorButtonIsPressed)
            {

                RecursiveFill(e.Location, Color.Red, new ConstantColor(Color.Red));
               // RecursiveFill(new Point(151,154), Color.Red, new ConstantColor(Color.Red));
                pictureBox__t_1.Invalidate();
            }

            if (FillTextureButtonIsPressed)
            {
                textureFill2(e.Location);
            }

            if (FillBorderIsPressed)
            {
                pictureBox__t_1.Invalidate();
                selectBorder(Color.Red);
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

                g.DrawLine(new Pen(Color.FromArgb(255, 0, 0, 0),1), prev.Value, e.Location);
                prev = e.Location;
                pictureBox__t_1.Invalidate();
                // pbox.Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            prev = null;
            mouseCoord = e.Location;
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

     
        private void loadFillImage()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter =
                "Image Files(*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Image img = Image.FromFile(openDialog.FileName);
                    textureBrush = new TextureBrush(img);
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Color getColorAt(Point point)
        {
            if (pictureBox__t_1.ClientRectangle.Contains(point))
                return ((Bitmap)pictureBox__t_1.Image).GetPixel(point.X, point.Y);
            else
                return Color.FromArgb(255, 0, 0, 0);
        }

        private void DrawHorizontalLineTexture(int x1, int x2, int y)
        {
            g.FillRectangle(textureBrush, x1, y, Math.Abs(x2 - x1) + 1, 1);
            for (int i = x1; i <= x2; ++i)
                filledPoints.Add(new Point(i, y));
        }

        private void textureFill2(Point p)
        {
            Color curr = getColorAt(p);
            Point leftPoint = p;
            Point rightPoint = p;
            if (!filledPoints.Contains(p) && pictureBox__t_1.ClientRectangle.Contains(p) && curr != borderColor)
            {
                pictureBox__t_1.Invalidate();

                while (curr != borderColor && pictureBox__t_1.ClientRectangle.Contains(leftPoint))
                {
                    leftPoint.X -= 1;
                    curr = getColorAt(leftPoint);
                }

                leftPoint.X += 1;
                
                curr = getColorAt(p);

                while (curr != borderColor && pictureBox__t_1.ClientRectangle.Contains(rightPoint))
                {
                    rightPoint.X += 1;
                    curr = getColorAt(rightPoint);
                }
                rightPoint.X -= 1;
                
                
                DrawHorizontalLineTexture(leftPoint.X, rightPoint.X, leftPoint.Y);
                
                for (int i = leftPoint.X; i <= rightPoint.X; ++i)
                {
                    Point upPoint = new Point(i, p.Y + 1);
                    Color upC = getColorAt(upPoint);
                    if (!filledPoints.Contains(upPoint) && upC.ToArgb() != borderColor.ToArgb() && pictureBox__t_1.ClientRectangle.Contains(upPoint))
                        textureFill2(upPoint);
                }
                
                
                for (int i = leftPoint.X; i < rightPoint.X; ++i)
                {
                    Point downPoint = new Point(i, p.Y - 1);
                    Color downC = getColorAt(downPoint);
                    if (!filledPoints.Contains(downPoint) && downC.ToArgb() != borderColor.ToArgb() && pictureBox__t_1.ClientRectangle.Contains(downPoint))
                        textureFill2(downPoint);
                }
                return;
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            loadFillImage();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DrawButtonIsPressed = false;
            FillColorButtonIsPressed = false;
            FillTextureButtonIsPressed = !FillTextureButtonIsPressed;
            FillBorderIsPressed = false;
            
        }

        // найти точку, принадлежащую границе
        private Point findStartPoint()
        {
            int x = mouseCoord.X;
            int y = mouseCoord.Y;

            Color bgColor = bmp.GetPixel(mouseCoord.X, mouseCoord.Y);
            Color currColor = bgColor;
            while (x < bmp.Width - 2 && currColor.ToArgb() == bgColor.ToArgb())
            {
                x++;
                currColor = bmp.GetPixel(x, y);
            }

            return new Point(x, y);
        }
        private void selectBorder(Color c)
        {
            List<Point> pixels = new List<Point>();
            Point curr = findStartPoint();
            Point start = curr;
            pixels.Add(start);
            Color borderColor = bmp.GetPixel(curr.X, curr.Y);

            Point next = new Point();
            int currDir = 6;
            int nextDir = -1;
            int moveTo = 0;
            // определяем направление движения
            do
            {
                // двигаемся в выбранном направлении
                moveTo = (currDir - 2 + 8) % 8;
                int mt = moveTo;
                do
                {
                    next = curr;
                    switch (moveTo)
                    {
                        case 0: next.X++; nextDir = 0; break;
                        case 1: next.X++; next.Y--; nextDir = 1; break;
                        case 2: next.Y--; nextDir = 2; break;
                        case 3: next.X--; next.Y--; nextDir = 3; break;
                        case 4: next.X--; nextDir = 4; break;
                        case 5: next.X--; next.Y++; nextDir = 5; break;
                        case 6: next.Y++; nextDir = 6; break;
                        case 7: next.X++; next.Y++; nextDir = 7; break;
                    }

                    if (next == start )
                        break;

                    if (bmp.GetPixel(next.X, next.Y) == borderColor)
                    {
                        pixels.Add(next);
                        curr = next;
                        currDir = nextDir;
                        break;
                    }
                    moveTo = (moveTo + 1) % 8;
                } while (moveTo != mt);
            } while (next != start);

            // меняем цвет грацицы
            foreach (var p in pixels)
                bmp.SetPixel(p.X, p.Y, c);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DrawButtonIsPressed = false;
            FillColorButtonIsPressed = false;
            FillTextureButtonIsPressed = false;
            FillBorderIsPressed = !FillBorderIsPressed;
        }

        private void pictureBox__t_1_Click(object sender, EventArgs e)
        {

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
