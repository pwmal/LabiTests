using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MathTaskClassLibrary;

namespace MathTaskClassLibraryTests
{
    [TestClass]
    public class GeometryTests
    {
        [TestMethod]
        public void RectangleArea_3and5_15returned()
        {
            int a = 3;
            int b = 5;
            int expected = 15;

            Geometry g = new Geometry();
            int actual = g.RectangleArea(a, b);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CylinderVolume_4and5_251_2returned()
        {
            double r = 4;
            double h = 5;
            double expected = 3.14 * r * r * h;

            Geometry g = new Geometry();
            double actual = g.CylinderVolume(r, h);

            Assert.AreEqual(expected, actual);
        }
    }
}
