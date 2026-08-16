using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle_and_Cylinder
{
    internal class Cylinder : Circle
    {
        private double height;

        public Cylinder() : base()
        {
            height = 1.0;
        }

        public Cylinder(double radius) : base (radius)
        {
            height = 1.0; 
            // radius is handled by parent class (base keyword)
        }

        public Cylinder(double radius,double height) : base (radius)
        {
            this.height = height;
            // radius is handled by parent class (base keyword)
        }

        public Cylinder(double radius,double height,string color) : base (radius,color)
        {
            this.height= height;
            // radius and color are handled by parent class (base keyword)
        }

        public double getHeight()
        {
            return height; 
        }

        public void setHeight(double height)
        {
            this.height = height;
        }

        public double getVolume() 
        {
            //Volume = (π × radius²) × height
            //Volume = area × height


            double volume = getArea() * height;
            return volume;

        }


    }
}
