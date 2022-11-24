using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class Surface3D
    {
        private List<Face3D> lst;

        public Surface3D(List<Face3D> lst)
        {
            this.lst = lst;
        }


        public Surface3D()
        {
            this.lst = new List<Face3D>();
        }


        public void AddFace(Face3D f)
        {
            lst.Add(f);
        }

        public void ApplyTransformation(Transform t)
        {
            foreach (var x in lst)
            {
                x.ApplyTransformation(t);
            }
        }

        public void Draw(Graphics g)
        {
            foreach (var x in lst)
            {
                x.Draw(g);
            }
        }

    }
}
