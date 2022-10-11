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
        List<Segment> segments = new List<Segment>();
        List<Point> polygon = new List<Point>();
        Point startPoint, endPoint, minPolygonCoord, maxPolygonCoord;
        Point pointLocation;
        Point p;
        PointWorker pw;
        Point up;
        Point down;
        public Form1()
        {
            InitializeComponent();
            RadioButton[] primitivesRadioButtons = new RadioButton[3] { DotRadioButton, LineRadioButton, PolygonRadioButton };

            pb = pictureBox1;
            bmp = new Bitmap(pb.Width, pb.Height);

            pictureBox1.Image = bmp;

            g = Graphics.FromImage(pictureBox1.Image);
            g.ScaleTransform(1.0F, -1.0F);
            g.TranslateTransform(0.0F, -pb.Height);
            
            drawer = new PrimitiveDrawer(pb,g,bmp, primitivesRadioButtons);
            pw = new PointWorker(pb, g, bmp, label1, label2,label3);
           

            g.Clear(Color.White);
            LineRadioButton.Checked = true;
            startPoint = Point.Empty;
            endPoint = Point.Empty;
            pointLocation = new Point(0, 0);
            GroupBox GB1 = groupBox1; 
            GB1.Controls.Add(DotRadioButton);
            groupBox1.Invalidate();
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
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            g.ScaleTransform(1.0F, -1.0F);
            g.TranslateTransform(0.0F, -pb.Height);
            segments.Clear();
            polygon.Clear();
            pointLocation = Point.Empty;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
            
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsDrawing())
            {
                startPoint = e.Location;

                if (PolygonRadioButton.Checked && polygon.Count == 0)
                {
                    minPolygonCoord = e.Location;
                    maxPolygonCoord = e.Location;
                    polygon.Add(startPoint);
                }
            }
            else
                p = e.Location;
           
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (LineRadioButton.Checked && IsDrawing())
            {
                endPoint = e.Location;
            }
            else if (PolygonRadioButton.Checked && IsDrawing())
            {
                endPoint = e.Location;
            }
            pictureBox1.Invalidate();
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (LineRadioButton.Checked && IsDrawing())
            {
                if (endPoint == Point.Empty)
                    return;
                segments.Add(new Segment(startPoint, endPoint));
                up = startPoint;
                down = endPoint;
                startPoint = Point.Empty;
                endPoint = Point.Empty;

            }
            else if (PolygonRadioButton.Checked && IsDrawing())
            {
                if (endPoint == Point.Empty)
                    return;
                polygon.Add(endPoint);
                if (endPoint.X < minPolygonCoord.X)
                    minPolygonCoord.X = endPoint.X;
                if (endPoint.Y < minPolygonCoord.Y)
                    minPolygonCoord.Y = endPoint.Y;
                if (endPoint.X > maxPolygonCoord.X)
                    maxPolygonCoord.X = endPoint.X;
                if (endPoint.Y > maxPolygonCoord.Y)
                    maxPolygonCoord.Y = endPoint.Y;


                up = startPoint;
                down = endPoint;
                startPoint = endPoint;
                endPoint = Point.Empty;
            }

            else if (DotRadioButton.Checked)
            {
                pointLocation = e.Location;
                up = e.Location;
            }
            pictureBox1.Invalidate();
        }

        private bool IsDrawing() => DotRadioButton.Checked || LineRadioButton.Checked || PolygonRadioButton.Checked;

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        { 
            
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            if (segments.Count > 0)
            {
                foreach (Segment seg in segments)
                    g.DrawLine(Pens.Red, seg.leftP, seg.rightP);
            }

            if (polygon.Count > 1)
            {
                for (int i = 0; i < polygon.Count - 1; ++i)
                {
                    g.DrawLine(Pens.Red, polygon[i], polygon[i + 1]);
                }
                g.DrawLine(Pens.Red, polygon[0], polygon[polygon.Count - 1]);
                pictureBox1.Invalidate();

            }
            //пока тянешь ребро
            if (startPoint != Point.Empty && endPoint != Point.Empty)
                g.DrawLine(Pens.Red, startPoint, endPoint);
            //точка
            g.DrawEllipse(Pens.Blue, pointLocation.X - 1, pointLocation.Y - 1, 3, 3);
            g.FillEllipse(Brushes.Blue, pointLocation.X - 1, pointLocation.Y - 1, 3, 3);

            pictureBox1.Invalidate();
            //подключить обновление состояний Антона
            if (!pointLocation.IsEmpty && !up.IsEmpty && !down.IsEmpty)
            {
                pw.PrintPointLocation((down, up),pointLocation);
            }
            
            if(segments.Count >= 2)
            {
                pw.FindIntersection(segments[segments.Count - 2].GetPoints(), segments[segments.Count - 1].GetPoints());
            }

            if(!pointLocation.IsEmpty && polygon.Count > 2)
            {
                pw.PrintPointIsInPolygon(pointLocation,polygon);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {


            if (MoveRadioButton.Checked)
            {
                int x = (int)numX.Value;
                int y = (int)numY.Value;
                Back_coord(x, y);
                pictureBox1.Invalidate();
            }

            if (ScalingRadioButton.Checked)
            {
                double x = (double)numX.Value / 100;
                double y = (double)numY.Value / 100;
                //матрица сжатия/растяжения
                Matrix M = new Matrix(3, 3);
                M[0, 2] = 0;
                M[1, 2] = 0;
                M[2, 2] = 1;
                M[0, 0] = x;
                M[1, 1] = y;
                M[0, 1] = 0;
                M[1, 0] = 0;
                M[2, 0] = 0;
                M[2, 1] = 0;

                //точка, относительно которой масштабировать
                PointF translationPoint;

                //вокруг точки
                if (checkBox1.Checked)
                {
                    if (pointLocation == Point.Empty)
                        return;
                    translationPoint = pointLocation;
                }
                //вокруг центра
                else
                    translationPoint = new PointF((minPolygonCoord.X + maxPolygonCoord.X) / 2, (minPolygonCoord.Y + maxPolygonCoord.Y) / 2);

                for (int i = 0; i < polygon.Count; ++i)
                {
                    //перенос в начало координат
                    Back_coord(-1 * translationPoint.X, -1 * translationPoint.Y);
                    //масштабирование
                    Matrix vec = new Matrix(1, 3);
                    vec[0, 0] = polygon[i].X;
                    vec[0, 1] = polygon[i].Y;
                    vec[0, 2] = 1;
                    vec *= M;
                    polygon[i] = new Point((int)vec[0, 0], (int)vec[0, 1]);
                    //перенос обратно
                    Back_coord(translationPoint.X, translationPoint.Y);
                }
            }

            if (RotateRadioButton.Checked)
            {
                double angle = (double)Angle.Value;
                //матрица сжатия/растяжения
                Matrix M = new Matrix(3, 3);
                M[0, 2] = 0;
                M[1, 2] = 0;
                M[2, 2] = 1;
                M[0, 0] = Math.Cos(angle * Math.PI / 180);
                M[0, 1] = Math.Sin(angle * Math.PI / 180);
                M[1, 0] = -Math.Sin(angle * Math.PI / 180);
                M[1, 1] = Math.Cos(angle * Math.PI / 180);
                M[2, 0] = 0;
                M[2, 1] = 0;

                for (int i = 0; i < polygon.Count; ++i)
                {
                    //точка, относительно которой масштабировать
                    PointF translationPoint;

                    //вокруг заданной точки
                    if (checkBox1.Checked)
                    {
                        if (pointLocation == Point.Empty)
                            return;
                        translationPoint = pointLocation;
                    }
                    //вокруг центра
                    else
                        translationPoint = new PointF((minPolygonCoord.X + maxPolygonCoord.X) / 2, (minPolygonCoord.Y + maxPolygonCoord.Y) / 2);


                    //перенос в начало координат
                    Back_coord(-1 * translationPoint.X, -1 * translationPoint.Y);
                    //масштабирование
                    Matrix vec = new Matrix(1, 3);
                    vec[0, 0] = polygon[i].X;
                    vec[0, 1] = polygon[i].Y;
                    vec[0, 2] = 1;
                    vec *= M;
                    polygon[i] = new Point((int)vec[0, 0], (int)vec[0, 1]);
                    //перенос обратно
                    Back_coord(translationPoint.X, translationPoint.Y);

                    pictureBox1.Invalidate();

                }


            }

            /*
           //тест точки пересечения
            Point p1 = new Point(30, 50);
            Point p2 = new Point(30, 400);

            Point p3 = new Point(20, 250);
            Point p4 = new Point(120, 40);

            g.DrawLine(Pens.Black, p1, p2);
            g.DrawLine(Pens.Black, p3, p4);

            pw.FindIntersection((p3, p4), (p2, p1));

            pb.Invalidate();
             */            

            /* 
             * тест расположение точки
            Point p1 = new Point(30, 50);
            Point p2 = new Point(330, 300);
            Point p3 = new Point(350, 200);
            g.DrawLine(Pens.Black, p1, p2);
            g.FillEllipse(Brushes.Black, p3.X, p3.Y, 3, 3);
            pw.PrintPointLocation((p1, p2), p3);
            pb.Invalidate();
            */
            /*
            List<Point> lst = new List<Point>();
            Point p1 = new Point(30, 50);
            Point p2 = new Point(330, 300);
            Point p3 = new Point(350, 200);
            Point p4 = new Point(400, 400);
            g.DrawLine(Pens.Black, p1, p2);
            g.DrawLine(Pens.Black, p2, p3);
            g.DrawLine(Pens.Black, p3, p4);
            g.DrawLine(Pens.Black, p1, p4);

            lst.Add(p1);
            lst.Add(p2);
            lst.Add(p3);
            lst.Add(p4);

            g.FillEllipse(Brushes.Black, 370, 330, 3, 3);
            pw.FindIntersection((p1, p4), (new Point(371, 330), new Point(571, 330)));
            pb.Invalidate();
          //  label2.Text = "Принадлежит полигону:" + (pw.IsInPolygon(new Point(370, 330), lst) ? "Da" : "Net");
             */

        }

        private void Back_coord(double dx, double dy)
        {
            //матрица переноса
            Matrix M = new Matrix(3, 3);
            M[0, 2] = 0;
            M[1, 2] = 0;
            M[2, 2] = 1;
            M[0, 0] = 1;
            M[0, 1] = 0;
            M[1, 0] = 0;
            M[1, 1] = 1;
            M[2, 0] = dx;
            M[2, 1] = dy;
            if (LineRadioButton.Checked)
            {
                for (int i = 0; i < segments.Count; ++i)
                {
                    Matrix vec = new Matrix(1, 3);
                    vec[0, 0] = segments[i].leftP.X;
                    vec[0, 1] = segments[i].leftP.Y;
                    vec[0, 2] = 1;
                    vec *= M;
                    Point leftP = new Point((int)vec[0, 0], (int)vec[0, 1]);
                    vec[0, 0] = segments[i].rightP.X;
                    vec[0, 1] = segments[i].rightP.Y;
                    vec[0, 2] = 1;
                    vec *= M;
                    Point rightP = new Point((int)vec[0, 0], (int)vec[0, 1]);
                    segments[i] = new Segment(leftP, rightP);
                }
            }
            else if (PolygonRadioButton.Checked)
            {
                for (int i = 0; i < polygon.Count; ++i)
                {
                    Matrix vec = new Matrix(1, 3);
                    vec[0, 0] = polygon[i].X;
                    vec[0, 1] = polygon[i].Y;
                    vec[0, 2] = 1;
                    vec *= M;
                    polygon[i] = new Point((int)vec[0, 0], (int)vec[0, 1]);
                }
            }
        }

        private void DotRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        int find_where_the_point_is(PointF p, Point A, Point B)
        {
            return (int)((p.X - A.X) * (B.Y - A.Y) - (p.Y - A.Y) * (B.X - A.X));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }

    class Segment
    {
        public Point leftP, rightP;

        public Segment() { leftP = new Point(); rightP = new Point(); }

        public Segment(Point l, Point r) { leftP = l; rightP = r; }

        public (Point,Point) GetPoints()
        {
            return (leftP, rightP);
        }
    }

    class Matrix
    {
        private double[,] data;

        private int m;
        public int M { get => this.m; }

        private int n;
        public int N { get => this.n; }

        public Matrix(int m, int n)
        {
            this.m = m;
            this.n = n;
            this.data = new double[m, n];
        }
        public void ProcessFunctionOverData(Action<int, int> func)
        {
            for (var i = 0; i < this.M; i++)
            {
                for (var j = 0; j < this.N; j++)
                {
                    func(i, j);
                }
            }
        }

        public double this[int x, int y]
        {
            get
            {
                return this.data[x, y];
            }
            set
            {
                this.data[x, y] = value;
            }
        }

        public static Matrix operator *(Matrix matrix, double value)
        {
            var result = new Matrix(matrix.M, matrix.N);
            result.ProcessFunctionOverData((i, j) =>
                result[i, j] = matrix[i, j] * value);
            return result;
        }

        public static Matrix operator *(Matrix matrix, Matrix matrix2)
        {
            if (matrix.N != matrix2.M)
            {
                throw new ArgumentException("matrixes can not be multiplied");
            }
            var result = new Matrix(matrix.M, matrix2.N);
            result.ProcessFunctionOverData((i, j) => {
                for (var k = 0; k < matrix.N; k++)
                {
                    result[i, j] += matrix[i, k] * matrix2[k, j];
                }
            });
            return result;
        }
    }
}
