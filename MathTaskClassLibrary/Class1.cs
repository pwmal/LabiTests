using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTaskClassLibrary
{
    public class Geometry
    {
        public int RectangleArea(int a, int b)
        {
            return a * b;
        }
        public double CylinderVolume(double r, double h)
        {
            return (3.14*r*r*h);
        }

    }
}
