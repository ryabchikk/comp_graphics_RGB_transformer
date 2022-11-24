using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab6
{
    interface IPrimitive
    {
        void Draw(Graphics g, Transform projection, int width, int height);

        void Apply(Transform t);

        XYZPoint Center { get; }
    }
}
