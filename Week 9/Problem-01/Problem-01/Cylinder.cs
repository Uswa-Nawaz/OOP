using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_01
{
    internal class Cylinder : Circle
    {
        private double height;

        public Cylinder()
        {
            height = 1.0;
        }

        public Cylinder(double radius)
        {
            this.radius = radius;
            this.height = 1.0;
        }

        public Cylinder(double radius, double height)
        {
            this.radius = radius;
            this.height = height;
        }

        public Cylinder(double radius, double height, string color)
        {
            this.radius = radius;
            this.height = height;
            this.color = color;
        }

        public double GetHeight()
        {
            return height;
        }

        public void SetHeight(double height)
        {
            this.height = height;
        }

        public double GetVolume()
        {
            return GetArea() * height;
        }
    }
}
