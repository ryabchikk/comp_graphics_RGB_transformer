using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class Face3D
    {
        private List<Line3D> lst;
        public Face3D()
        {
            lst = new List<Line3D>();
        }

        public Face3D(params Line3D[] args)
        {   
            if(args != null)
            lst = new List<Line3D>(args);
            else
                lst = new List<Line3D>();
        }

        public void AddLine(Line3D l)
        {
            lst.Add(l);
        }

        public void Draw(Graphics g)
        {
            foreach(var x in lst)
            {
                x.Draw(g);
            }
        }

        public void ApplyTransformation(Transform t)
        {
            foreach (var x in lst)
            {
                x.ApplyTransformation(t);
            }
        }

    }
}
