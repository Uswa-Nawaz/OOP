using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle_and_Cylinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("-----------Default values-------------\n");
            Cylinder cd = new Cylinder(); // uses all defaults
            Console.WriteLine($"Radius: {cd.getRadius()}");
            Console.WriteLine($"Color: {cd.getColor()}");
            Console.WriteLine($"Height: {cd.getHeight()}");
            Console.WriteLine("");

            Console.Write("-----------Use Input values-------------\n");
            double radius;
             
            while (true)
            {
                Console.Write("Enter Radius: ");
                if (double.TryParse(Console.ReadLine(), out radius))
                {
                    break;
                }
                else
                {
                    Console.Write("Enter valid decimal number!!");
                }

            }

            double height;

            while (true)
            {
                Console.Write("Enter height: ");
                if (double.TryParse(Console.ReadLine(), out height))
                {
                    break;
                }
                else
                {
                    Console.Write("Enter valid decimal number!!");
                }

            }


            Console.Write("Enter Color: ");
            string color = Console.ReadLine();

            Cylinder c = new Cylinder(radius, height, color);

            Console.WriteLine($"Radius: {c.getRadius()}");
            Console.WriteLine($"Color: {c.getColor()}");
            Console.WriteLine($"Height: {c.getHeight()}");
            Console.WriteLine($"Area: {c.getArea()}");
            Console.WriteLine($"Volume: {c.getVolume()}");
            Console.WriteLine(c.toString());

        }
    }
}
