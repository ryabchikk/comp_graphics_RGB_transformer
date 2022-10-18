using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form3 : Form
    {
        private Graphics graphics;
        Random rand = new Random();
        LinkedList<Point> llist;
        List<Point> points;
        public Form3()
        {
            InitializeComponent();
            points = new List<Point>();
            pictureBox1.Image = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            graphics.Clear(Color.White);
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void Redraw()
        {
            graphics.Clear(Color.White);
            var SelectedPoint = getSelectedPoint();
            foreach (var Point in points)
            {
                if (Point == SelectedPoint)
                {
                    graphics.FillRectangle(Brushes.Red, Point.X - 3, Point.Y - 3, 6, 6);
                }
                else
                {
                    graphics.FillRectangle(Brushes.Black, Point.X - 3, Point.Y - 3, 6, 6);
                }
            }
            pictureBox1.Invalidate();
        }

        private Point getSelectedPoint()
        {
            if (treeView1.SelectedNode == null) return Point.Empty;
            var p = treeView1.SelectedNode.Tag;
            return (Point)p;
        }


        private void midpoint(LinkedList<Point> vector, LinkedListNode<Point> hl, LinkedListNode<Point> hr, double r, int iter)
        {
            if (iter == 0)
                return;
            Math.Pow((hr.Value.X - hl.Value.X), 2);
            var len = Math.Sqrt(Math.Pow((hr.Value.X - hl.Value.X), 2) + Math.Pow((hr.Value.Y - hl.Value.Y), 2));

            var h = (hl.Value.Y + hr.Value.Y) / 2;
            
            var randPart = rand.Next((int)(-r * len), (int)(+r * len));
            while(h + randPart > pictureBox1.Image.Height)
            {
                randPart = rand.Next((int)(-r * len), (int)(+r * len));
            }
            int neg = rand.Next(10, 25) * iter;
            h = (h + randPart) < 0 ? h + neg : (h + randPart);
            var np = new Point((hr.Value.X - hl.Value.X) / 2 + hl.Value.X, h);
            llist.AddAfter(hl, np);

            graphics.Clear(Color.White);
            var p = llist.First;
            while (p.Next != null)
            {
                Pen pen = new Pen(Color.Black);
                pen.Width = 2;
                graphics.DrawLine(pen, p.Value.X, p.Value.Y, p.Next.Value.X, p.Next.Value.Y);
                p = p.Next;
            }
            pictureBox1.Invalidate();
            //pb.Refresh();
            Thread.Sleep(50);

            //выполняем алгоритм для получившихся половин
            midpoint(vector, hl, hl.Next, r, iter - 1);
            midpoint(vector, hr.Previous, hr, r, iter - 1);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Redraw();
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Delete != e.KeyCode && Keys.Back != e.KeyCode) return;
            var S = getSelectedPoint();
            if (S.IsEmpty) return;
            points.Remove(S);

            treeView1.SelectedNode.Remove();
            Redraw();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs args = (MouseEventArgs)e;
            Point p = args.Location;

            TreeNode node = treeView1.Nodes.Add("Точка");
            node.Tag = p;
            points.Add(p);
            Redraw();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point start = getSelectedPoint();
            llist = new LinkedList<Point>();
            var end = new Point(start.X + (int)numericUpDown2.Value, start.Y);
            graphics.FillRectangle(Brushes.Black, end.X - 3, end.Y - 3, 6, 6);
            pictureBox1.Refresh();
            Thread.Sleep(50);

            llist.AddFirst(start);
            llist.AddLast(end);

            graphics.Clear(Color.White);
            Pen pen = new Pen(Color.Black);
            pen.Width = 2;
            graphics.DrawLine(pen, start.X, start.Y, end.X, end.Y);
            pictureBox1.Refresh();
            Thread.Sleep(50);

            var hl = llist.First; //левая точка
            var hr = hl.Next; //правая точка

            midpoint(llist, hl, hr, (double)numericUpDown1.Value, (int)numericUpDown3.Value);
            pictureBox1.Refresh();
        }
    }
}
