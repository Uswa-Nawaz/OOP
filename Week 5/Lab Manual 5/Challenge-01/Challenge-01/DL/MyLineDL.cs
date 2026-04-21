using Challenge_01.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01.DL
{
    internal class MyLineDL
    {
        private static MyLine line;

        //get line
        public static MyLine getline()
        {
            return line;
        }
        //set line
        public static void setline(MyLine l)
        {
           line= l;
        }
    }
}
