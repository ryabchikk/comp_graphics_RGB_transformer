using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    using FastBitmap;
    public partial class Form1 : Form
    {
        BindingList<Figure> sceneShapes;
        List<Figure> scene;
        Camera camera;
        LightSource lightSource;
        List<Color> colorrange;
        
        bool is_lighting;
        string textureFileName = "";

        public Form1()
        {
            sceneShapes = new BindingList<Figure>();
            colorrange = GenerateColors();
            //colorrange = new List<Color> { Color.Red, Color.Blue, Color.Green };
            scene = new List<Figure>();
            
            InitializeComponent();
            
            listBox1.DataSource = sceneShapes;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            camera = new Camera();
            lightSource = new LightSource(new Point3D(100, 100, 100));
            lightSource = new LightSource(new Point3D(100, 100, 100));

            // А здесь задаём точку начала координат
            Point3D.worldCenter = new PointF(pictureBox1.Width / 2, pictureBox1.Height / 2);
            Point3D.setProjection(pictureBox1.Size, 1, 100, 45);
        }
        
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Figure s = Figure.ReadFigure(openFileDialog1.FileName);
                sceneShapes.Add(s);
                scene.Add(s);
                RedrawScene();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            sceneShapes.Remove((Figure)listBox1.SelectedValue);
            RedrawScene();
        }        
        
        private void Zbuffer_Click(object sender, EventArgs e)
        {
            is_lighting = false;
            
            List<Figure> l = sceneShapes.ToList();
            Bitmap bmp = Lab8.Zbuffer.Zbuff(pictureBox1.Width, pictureBox1.Height, l, camera, lightSource, colorrange, is_lighting);
            
            pictureBox1.Image = bmp;
            pictureBox1.Invalidate();
        }
        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RedrawScene();
        }
       
        private void ScaleButton_Click(object sender, EventArgs e)
        {
            sceneShapes[listBox1.SelectedIndex] = AffineTransformations.ScaleFigure(sceneShapes[listBox1.SelectedIndex],
            double.Parse(textScaleX.Text, CultureInfo.InvariantCulture.NumberFormat), double.Parse(textScaleY.Text, CultureInfo.InvariantCulture.NumberFormat), double.Parse(textScaleZ.Text, CultureInfo.InvariantCulture.NumberFormat));
        }

        private void TranslateButton_Click(object sender, EventArgs e)
        {
            sceneShapes[listBox1.SelectedIndex] = AffineTransformations.MoveFigure(sceneShapes[listBox1.SelectedIndex],
            int.Parse(textTranslateX.Text), int.Parse(textTranslateY.Text), int.Parse(textTranslateZ.Text));
        }

        private void LoadTextureButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                textureFileName = openFileDialog2.FileName;
            }
        }
        private void TextureObjectButton_Click(object sender, EventArgs e)
        {
            List<Figure> l = sceneShapes.ToList();
            Bitmap bmp = ZBufferTexturing.Zbuffer(pictureBox1.Width, pictureBox1.Height, l, camera, lightSource, colorrange, false, textureFileName);
            pictureBox1.Image = bmp;
            pictureBox1.Invalidate();
        }

        private void LightButton_Click(object sender, EventArgs e)
        {
            is_lighting = true;
            List<Figure> l = sceneShapes.ToList();
            Bitmap bmp = Lab8.Zbuffer.Zbuff(pictureBox1.Width, pictureBox1.Height, l, camera, lightSource, colorrange, is_lighting);
            pictureBox1.Image = bmp;
            pictureBox1.Invalidate();
            is_lighting = false;
        }


        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'w':
                    camera.Move(forwardbackward: 5);
                    break;
                case 'a':
                    camera.Move(leftright: 5);
                    break;
                case 's':
                    camera.Move(forwardbackward: -5);
                    break;
                case 'd':
                    camera.Move(leftright: -5);
                    break;
                case 'q':
                    camera.Move(updown: 5);
                    break;
                case 'e':
                    camera.Move(updown: -5);
                    break;
                case 'i':
                    camera.ChangeView(shiftY: 2);
                    break;
                case 'j':
                    camera.ChangeView(shiftX: -2);
                    break;
                case 'k':
                    camera.ChangeView(shiftY: -2);
                    break;
                case 'l':
                    camera.ChangeView(shiftX: 2);
                    break;
                case 'g':
                    lightSource.Move(shiftY: 5);
                    break;
                case 'b':
                    lightSource.Move(shiftY: -5);
                    break;
                case 'v':
                    lightSource.Move(shiftX: -5);
                    break;
                case 'n':
                    lightSource.Move(shiftX: 5);
                    break;
                case 'f':
                    lightSource.Move(shiftZ: -5);
                    break;
                case 'h':
                    lightSource.Move(shiftZ: 5);
                    break;
                default: return;
            }

            RedrawScene();
            e.Handled = true;
        }


    }
}
