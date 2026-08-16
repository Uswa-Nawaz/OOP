using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Object 1: default constructor
            Cylinder c1 = new Cylinder();
            c1.SetHeight(5.0);
            Console.WriteLine("Cylinder 1 Volume: " + c1.GetVolume());

            // Object 2: parameterized constructor
            Cylinder c2 = new Cylinder(3.0, 7.0);
            Console.WriteLine("Cylinder 2 Volume: " + c2.GetVolume());

            // Object 3: parameterized constructor
            Cylinder c3 = new Cylinder(4.0, 10.0, "blue");
            Console.WriteLine("Cylinder 3 Volume: " + c3.GetVolume());
        }
    }
}
