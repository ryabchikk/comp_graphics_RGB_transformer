using System.Collections.Generic;
using System.Drawing;

namespace lab7
{
    interface Primitive
    {
        List<Point3D> Points { get; }

        List<Line3D> Verges { get; }

        void Draw(Graphics g, Transform projection, int width, int height);

        void Apply(Transform t);

        string ToString();

        int Count_Verges();
    }
}
