using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person_Student_Staff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------Student Data----------");
            Console.Write("Enter the name of student: ");
            string name = Console.ReadLine();

            Console.Write("Enter the address of student: ");
            string address = Console.ReadLine();

            Console.Write("Enter the program in which student is enrolled: ");
            string program = Console.ReadLine();

            int year;
            while (true)
            {
                Console.Write("Enter program year: ");
                if (int .TryParse(Console.ReadLine(), out year))
                {
                    break;
                }
                else 
                {
                    Console.WriteLine("Enter a valid integer!!\n");
                }
            }

            double fee;
            while (true)
            {
                Console.Write("Enter the total fee: ");
                if (double.TryParse(Console.ReadLine(), out fee))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid fee!!\n");
                }
            }

            Student std = new Student(name, address,program,year,fee);

            Console.WriteLine("-------------Staff data Data------------");

            Console.Write("Enter the name of staff member: ");
            name = Console.ReadLine();

            Console.Write("Enter the address of staff member: ");
            address = Console.ReadLine();

            Console.Write("Enter the shool of staff member: ");
            string school = Console.ReadLine();

            double pay;
            while (true)
            {
                Console.Write("Enter the total pay of staff member: ");
                if (double.TryParse(Console.ReadLine(), out pay))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid pay!!\n");
                }
            }

            Staff s = new Staff(name, address,school, pay);

            Console.WriteLine("-------------DISPLAYING STUDENT DATA------------");

            // Console.WriteLine($"Name: {std.getName()}");
            // Console.WriteLine($"Address: {std.getAddress()}");
            Console.WriteLine($"{std.toString()}");
            Console.WriteLine($"Program: {std.getProgram()}");
            Console.WriteLine($"Year: {std.getYear()}");
            Console.WriteLine($"Fee: {std.getFee()}");



            Console.WriteLine("-------------DISPLAYING STAFF DATA------------");

            // Console.WriteLine($"Name: {std.getName()}");
            // Console.WriteLine($"Address: {std.getAddress()}");
            Console.WriteLine($"{std.toString()}");
            Console.WriteLine($"School: {s.getSchool()}");
            Console.WriteLine($"Year: {s.getPay()}");
        }
    }
}
