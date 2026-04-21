using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01.BL
{
    internal class MyPoint
    {
        //instances
        private int x;
        private int y;

        //default constructor
        public MyPoint()
        {
            this.x = 0;
            this.y = 0;
        }

        //parameterized constructor
        public MyPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //getter
        //for x
        public int getX()
        {
            return x;
        }
        //for y
        public int getY()
        {
            return y;
        }

        //setter
        public void setXY(int x, int y)
        {
            this.x = x;
            this.y=y;
        }

        //--------Distance logic Methods---------
        //Distance with cords
        //calculate the distance from this point to a specific point 
        public double distancewithcord(int x2, int y2) //specific point passed as parameter
        {
            //(x2-x1)^2 
            double horizontaldistance = Math.Pow(x2 - this.x, 2);
            //(y2-y1)^2
            double verticaldistance=Math.Pow(y2-this.y,2);
            //underoot[(x2-x1)^2+(y2-y1)^2]
            return Math.Sqrt(horizontaldistance + verticaldistance);
        }

        //Distance with object
        //calculate the distance from this mypoint object to another my point object
        public double distancewithobject(MyPoint otherpoint)
        {
            //distance formula:-  underoot[(x2-x1)^2+(y2-y1)^2]

            //(x2-x1)^2
            double horizontaldistance=Math.Pow(otherpoint.getX() - this.x, 2);
            //(y2-y1)^2
            double verticaldistance=Math.Pow(otherpoint.getY() - this.y, 2);
            //underoot[(x2-x1)^2+(y2-y1)^2]
            return Math.Sqrt(horizontaldistance + verticaldistance);
        }

        //Distace from zero
        //calculate the distance from my point to zero
        public double distancewithzero()
        {
            //(0-x1)^2
            double horizontaldistance = Math.Pow(this.x, 2);
            //(0-y1)^2
            double verticaldistance = Math.Pow(this.y, 2);
            //underoot[(0-x1)^2+(0-y1)^2]
            return Math.Sqrt(horizontaldistance + verticaldistance);
        }
    
    }
}
