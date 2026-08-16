using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******** Car Rental System ********");

            Console.WriteLine("1. BMW");
            Console.WriteLine("2. GLI");
            Console.WriteLine("3. Audi");

            int choice;
            while (true)
            {
                Console.WriteLine("Enter your choice:");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid choice(1-3)!!");
                }
            }

            if (choice == 1)    //BMW
            {
                Console.WriteLine("------BMW------");

                Console.Write("Enter the car model: ");
                string model = Console.ReadLine();

                Console.Write("Enter the color of car: ");
                string color = Console.ReadLine();

                double price;
                while(true)
                {
                    Console.WriteLine("Enter car price: ");
                    if(double.TryParse(Console.ReadLine(),out price))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter valid price!!");
                    }
                }

                BMW b = new BMW(15.0,model,color,price);

                double km;
                while (true)
                {
                    Console.Write("Enter km driven: ");
                    if (double.TryParse(Console.ReadLine(), out km))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter valid km!!\n");
                    }
                }

                b.calculateFuel(km);

                //--------Displaying
                Console.WriteLine($"Fuel consumed: {b.calculateFuel(km)} liters");
                Console.WriteLine(b.toString());

            }

            else if (choice == 2) //GLI
            {
                Console.WriteLine("------GLI------");

                Console.Write("Enter the car model: ");
                string model = Console.ReadLine();

                Console.Write("Enter the color of car: ");
                string color = Console.ReadLine();

                double price;
                while (true)
                {
                    Console.WriteLine("Enter car price: ");
                    if (double.TryParse(Console.ReadLine(), out price))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter valid price!!");
                    }
                }

                GLI g = new GLI(10.0, model, color, price);

                double km;
                while (true)
                {
                    Console.Write("Enter km driven: ");
                    if (double.TryParse(Console.ReadLine(), out km))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter valid km!!\n");
                    }
                }

                g.calculateFuel(km);

                //--------Displaying
                Console.WriteLine($"Fuel consumed: {g.calculateFuel(km)} liters");
                Console.WriteLine(g.toString());
            }

            else if (choice == 3)    //Audi
            {
                Console.WriteLine("------Audi------");

                Console.Write("Enter the car model: ");
                string model = Console.ReadLine();

                Console.Write("Enter the color of car: ");
                string color = Console.ReadLine();

                double price;
                while (true)
                {
                    Console.WriteLine("Enter car price: ");
                    if (double.TryParse(Console.ReadLine(), out price))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter valid price!!");
                    }
                }

                Audi a = new Audi(20.0, model, color, price);

                double km;
                while (true)
                {
                    Console.Write("Enter km driven: ");
                    if (double.TryParse(Console.ReadLine(), out km))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter valid km!!\n");
                    }
                }

                a.calculateFuel(km);

                //--------Displaying
                Console.WriteLine($"Fuel consumed: {a.calculateFuel(km)} liters");
                Console.WriteLine(a.toString());
            }
            else
            {
                Console.WriteLine("Enter a valid choice(1-3)");
            }
        }
    }
}
