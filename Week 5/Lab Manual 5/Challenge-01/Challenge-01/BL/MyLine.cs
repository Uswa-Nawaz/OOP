using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01.BL
{
    internal class MyLine
    {
        //composition
        private MyPoint begin;
        private MyPoint end;

        //constructor
        public MyLine(MyPoint begin, MyPoint end)
        {
            this.begin= begin;
            this.end= end;
        }

        //getter
        //gets begin
        public MyPoint getbegin()
        {
            return begin;
        }
        //gets end
        public MyPoint getend()
        {
            return end;
        }

        //setter
        //sets begin
        public void setbegin(MyPoint begin)
        {
            this.begin = begin;
        }
        //set end
        public void setend(MyPoint end)
        {
            this.end = end;
        }

        //get length
        public double getlength()
        {
            return begin.distancewithobject(end);
        }

        //getgradient
        //calculate the slope of the line
        public double getgradient()
        {
            double num=end.getY()-begin.getY();
            double den=end.getX()-begin.getX();
            return num/den;
        }
    }
}
