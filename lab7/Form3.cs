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
    public partial class Form3 : Form
    {
        private Bitmap perspective_bmp;
        enum AxisType { X, Y, Z }

        private AxisType selectType;
        private Primitive a;
        private RotationShape rotObj;
        List<Point3D> points = new List<Point3D>();
        int CounterSetPoint;
       
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
        private void GetAxisXYZ()
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                case "X":
                    {
                        selectType = AxisType.X;
                        break;
                    }
                case "Y":
                    {
                        selectType = AxisType.Y;
                        break;
                    }
                case "Z":
                    {
                        selectType = AxisType.Z;
                        break;
                    }
                default:
                    {
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
        public Form3()
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
           
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Text files(*.txt) | *.txt | All files(*.*) | *.* ";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string info = "";
                    info += a.ToString() + "\r\n" + "\r\n";
                    
                    
                    int num = 1;
                    foreach (Line3D v in a.Verges)
                    {
                            var p1 = v.P1.GetTransformedCoordinates();
                            var p2 = v.P2.GetTransformedCoordinates();
                            info += p1.X + " " + p1.Y + " " + p1.Z + " " + p2.X + " " + p2.Y + " " + p2.Z;
                            info += "\r\n";
                        
                        if (num != a.Verges.Count)
                            info += "\r\n";
                        ++num;
                    }

                    System.IO.File.WriteAllText(saveDialog.FileName, info);
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно сохранить файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadDialog = new OpenFileDialog();
            loadDialog.Filter = "Object Files(Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (loadDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Clear();
                    List<Point3D> points = new List<Point3D>();
                    List<Line3D> lines = new List<Line3D>();

                    string str = System.IO.File.ReadAllText(loadDialog.FileName).Replace("\r\n", "!");
                    string[] info = str.Split('!');

                    string type_of_primitive = info[0];

                    int cur_string = 2;
                    while (cur_string < info.Length && info[cur_string] != "")
                    {
                        string[] coordinates = info[cur_string].Split(' ');

                        float x = float.Parse(coordinates[0]);
                        float y = float.Parse(coordinates[1]);
                        float z = float.Parse(coordinates[2]);
                        float x2 = float.Parse(coordinates[3]);
                        float y2 = float.Parse(coordinates[4]);
                        float z2 = float.Parse(coordinates[5]);
                        points.Add(new Point3D(x, y, z));
                        points.Add(new Point3D(x2, y2, z2));
                        cur_string += 2;
                    }

                    DrawAxis();

                    for (int i = 0; i < (points.Count()-2); i+=2)
                    {
                        lines.Add(new Line3D(points[i], points[i + 1]));
                    }

                    for (int i = 0; i < (lines.Count()); i++)
                    {
                        lines[i].Draw(g, Pens.Black);
                        PerspectiveBox.Invalidate();
                    }

                    cur_string++;

                    PerspectiveBox.Invalidate();

                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        class RotationShape : Surface3D
        {
            List<Point3D> formingline;
            Line3D axiz;
            int Divisions;
            List<Point3D> allpoints;
            List<Line3D> edges;//ребра
            public RotationShape()
            {
                allpoints = new List<Point3D>();
                edges = new List<Line3D>();
            }
            public List<Line3D> Edges { get => edges; }
            public Surface3D addEdge(Line3D edge)
            {
                edges.Add(edge);
                return this;
            }
            public RotationShape(IEnumerable<Point3D> points) : this()
            {
                this.allpoints.AddRange(points);
            }
            public RotationShape(Line3D ax, int Div, IEnumerable<Point3D> line) : this()
            {
                this.axiz = ax;
                this.Divisions = Div;
                this.formingline.AddRange(line);
            }
            public RotationShape addPoints(IEnumerable<Point3D> points)
            {
                this.allpoints.AddRange(points);
                return this;
            }

            public List<Point3D> Points { get => allpoints; }
        }
        public static double degreesToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        private List<Point3D> transformPointsRotationFig(Transform matrix, List<Point3D> allpoints)
        {
            List<Point3D> clone = allpoints;
            List<Point3D> res = new List<Point3D>();
            foreach (var p in clone)
            {
                Point3D newp = new Point3D(p.X, p.Y, p.Z);
                newp.ApplyTransformation(matrix);
                //Point3D newp = transformPoint(p, matrix);
                res.Add(newp);
            }
            return res;
        }
        private List<Point3D> RotatePoint(List<Point3D> general, AxisType axis, double angle)
        {
            List<Point3D> res;
            double mysin = Math.Sin(degreesToRadians(angle));
            double mycos = Math.Cos(degreesToRadians(angle));
            Transform rotation = new Transform();

            switch (axis)
            {
                case AxisType.X:
                    rotation = new Transform(new double[,] { { 1, 0, 0, 0 }, { 0, mycos, -mysin, 0 }, { 0, mysin, mycos, 0 }, { 0, 0, 0, 1 } });
                    break;
                case AxisType.Y:
                    rotation = new Transform(new double[,] { { mycos, 0, mysin, 0 }, { 0, 1, 0, 0 }, { -mysin, 0, mycos, 0 }, { 0, 0, 0, 1 } });
                    break;
                case AxisType.Z:
                    rotation = new Transform(new double[,] { { mycos, -mysin, 0, 0 }, { mysin, mycos, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } });
                    break;
            }

            res = transformPointsRotationFig(rotation, general);

            return res;
        }
        private RotationShape getRotationShape(List<Point3D> general, int divisions, AxisType axis)
        {
            RotationShape res = new RotationShape();
            List<Point3D> genline = general;
            int GeneralCount = genline.Count();

            //Line axis;
            double angle = (360.0 / divisions);//угол

            res.addPoints(genline);//добавили образующую

            for (int i = 1; i < divisions; i++)//количество разбиений
            {
                res.addPoints(RotatePoint(genline, axis, angle * i));
            }

            //Фигура вращения задаётся тремя параметрами: образующей(набор точек), осью вращения и количеством разбиений
            //зададим ребра и грани
            for (int i = 0; i < divisions; i++)
            {
                for (int j = 0; j < GeneralCount; j++)
                {
                    int index = i * GeneralCount + j;//индекс точки
                    if (index < divisions * GeneralCount)
                    {

                        int e = (index + GeneralCount) % res.Points.Count;

                        if ((index + 1) % GeneralCount == 0)
                        {
                            res.addEdge(new Line3D(res.Points[index], res.Points[e]));
                        }
                        else
                        {

                            res.addEdge(new Line3D(res.Points[index], res.Points[index + 1]));
                            res.addEdge(new Line3D(res.Points[index], res.Points[e]));
                            int e1 = (index + 1 + GeneralCount) % res.Points.Count;

                            //добавим грань
                            Face3D face = new Face3D(new Line3D(res.Points[index], res.Points[index + 1]),
                                                     new Line3D(res.Points[index + 1], res.Points[e1]),
                                                     new Line3D(res.Points[e1], res.Points[e]),
                                                     new Line3D(res.Points[e], res.Points[index]));

                            res.AddFace(face);
                        }
                    }

                }
            }

            return res;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Clear();
            DrawAxis();
            GetAxisXYZ();
            rotObj = getRotationShape(points, (int)numericUpDown17.Value, selectType);
            rotObj.Draw(g);
            PerspectiveBox.Invalidate();
        }

        private void PerspectiveBox_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void AddPoint_Click(object sender, EventArgs e)
        {
            Point3D point = new Point3D((float)numericUpDown14.Value, (float)numericUpDown15.Value, (float)numericUpDown16.Value);
            points.Add(point);
            point.Draw(g);
            PerspectiveBox.Invalidate();
        }
    }
}

