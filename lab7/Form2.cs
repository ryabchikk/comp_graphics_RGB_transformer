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
    public partial class Form2 : Form
    {
        private Bitmap perspective_bmp;

        private Primitive a;

        Graphics g;

        //Рисует координатные оси 
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

        private void GetPrimitive()
        {
            switch (PrimitiveComboBox.SelectedItem.ToString())
            {
                case "Тетраэдр":
                    {
                        a = new Tetrahedron(160);
                        break;
                    }
                case "Гексаэдр":
                    {
                       a = new Hexahedron(160);
                        break;
                    }
                case "Октаэдр":
                    {
                        a = new Octahedron(160);
                        break;
                    }
                case "Икосаэдр":
                    {
                        //cur_primitive = new Icosahedron(0.5);
                        break;
                    }
                case "Додекаэдр":
                    {
                        //cur_primitive = new Dodecahedron(0.5);
                        break;
                    }
                default:
                    {
                        Octahedron a = new Octahedron(160);
                        break;
                    }
            }
        }

        private void Clear()
        {
            perspective_bmp = new Bitmap(PerspectiveBox.Width, PerspectiveBox.Height);
            g = Graphics.FromImage(perspective_bmp);
            PerspectiveBox.Image = perspective_bmp;
        }
        public Form2()
        {
            InitializeComponent();

            //Создаем Bitmap и Graphics для PictureBox
            perspective_bmp = new Bitmap(PerspectiveBox.Width, PerspectiveBox.Height);
            g = Graphics.FromImage(perspective_bmp);
            PerspectiveBox.Image = perspective_bmp;

            //Инициализируем ComboBox для отображения проекций
            PerspectiveComboBox.SelectedItem = PerspectiveComboBox.Items[1];
            PrimitiveComboBox.SelectedItem = PrimitiveComboBox.Items[2];
            ReflectionComboBox.SelectedItem = ReflectionComboBox.Items[0];

            GetPrimitive();
            DrawAxis();
        }

        private void ApplyPerspective_Click(object sender, EventArgs e)
        {
            perspective_bmp = new Bitmap(PerspectiveBox.Width, PerspectiveBox.Height);
            g = Graphics.FromImage(perspective_bmp);
            PerspectiveBox.Image = perspective_bmp;
            DrawAxis();
        }


        private void ApplyPrimitive_Click(object sender, EventArgs e)
        {
            Clear();
            GetPrimitive();
            a.Draw(g,null,0,0);
            DrawAxis();
            PerspectiveBox.Invalidate();
        }

        //Смещение
        private void Translate()
        {
            double X = (double)numericUpDown1.Value;
            double Y = (double)numericUpDown2.Value;
            double Z = (double)numericUpDown3.Value;
            a.Apply(Transform.Translate(X, Y, Z));
        }

        //Поворот
        private void Rotate()
        {
            double X = (double)numericUpDown4.Value / 180 * Math.PI;
            double Y = (double)numericUpDown5.Value / 180 * Math.PI;
            double Z = (double)numericUpDown6.Value / 180 * Math.PI;
            a.Apply(Transform.RotateX(X) * Transform.RotateY(Y) * Transform.RotateZ(Z));
        }

        //Масштаб
        private void Scale()
        {
            double X = (double)numericUpDown7.Value;
            double Y = (double)numericUpDown8.Value;
            double Z = (double)numericUpDown9.Value;
            a.Apply(Transform.Scale(X, Y, Z));

        }

        //Отражение
        private void Reflect()
        {
            switch (ReflectionComboBox.SelectedItem.ToString())
            {
                case "Отражение по X":
                    {
                        a.Apply(Transform.ReflectX());
                        break;
                    }
                case "Отражение по Y":
                    {
                        a.Apply(Transform.ReflectY());
                        break;
                    }
                case "Отражение по Z":
                    {
                        a.Apply(Transform.ReflectZ());
                        break;
                    }
                default:
                    {
                        a.Apply(Transform.ReflectX());
                        break;
                    }
            }
        }

        //Масштабирование относительно центра
        private void ScaleCenter()
        {
            double C = (double)numericUpDown10.Value;
            a.Apply(Transform.Scale(C, C, C));
        }

        private void RotateCenter()
        {
            double X = (double)numericUpDown11.Value / 180 * Math.PI;
            double Y = (double)numericUpDown12.Value / 180 * Math.PI;
            double Z = (double)numericUpDown13.Value / 180 * Math.PI;
            a.Apply(Transform.RotateX(X) * Transform.RotateY(Y) * Transform.RotateZ(Z));
        }

        private void RotateLine()
        {
            float X1 = (float)numericUpDown14.Value;
            float Y1 = (float)numericUpDown15.Value;
            float Z1 = (float)numericUpDown16.Value;

            float X2 = (float)numericUpDown17.Value;
            float Y2 = (float)numericUpDown18.Value;
            float Z2 = (float)numericUpDown19.Value;

            Line3D l = new Line3D(new Point3D(X1, Y1, Z1), new Point3D(X2, Y2, Z2));

            double ang = (double)numericUpDown20.Value / 180 * Math.PI;

            //a.Apply(Transform.RotateLine(l, ang));
        }

        private void ApplyAffin_Click(object sender, EventArgs e)
        {
            Clear();
            Translate();
            Rotate();
            Scale();
            a.Draw(g, null, 0, 0);
            DrawAxis();
            PerspectiveBox.Invalidate();
        }

        private void ApplyReflection_Click(object sender, EventArgs e)
        {
            Clear();
            Reflect();
            a.Draw(g, null, 0, 0);
            DrawAxis();
            PerspectiveBox.Invalidate();
        }

        private void ApplyScaleCenter_Click(object sender, EventArgs e)
        {
            Clear();
            ScaleCenter();
            a.Draw(g, null, 0, 0);
            DrawAxis();
            PerspectiveBox.Invalidate();
        }

        private void ApplyRotationCenter_Click(object sender, EventArgs e)
        {
            Clear();
            RotateCenter();
            a.Draw(g, null, 0, 0);
            DrawAxis();
            PerspectiveBox.Invalidate();
        }

        private void ApplyLineRotation_Click(object sender, EventArgs e)
        {
            Clear();
            RotateLine();
            a.Draw(g, null, 0, 0);
            DrawAxis();
            PerspectiveBox.Invalidate();
        }

        private void PerspectiveBox_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
