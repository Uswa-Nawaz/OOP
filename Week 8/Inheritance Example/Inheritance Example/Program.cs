using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************DAY SCHOLOR*****************");
            DayScholar std = new DayScholar();

            // Using setter functions instead of direct access
            std.setName("Ahmad");
            std.setSession("2024-2028");
            std.setSubjects(5);
            std.SetBusNo(1);
            std.SetPickUpDistance(10);
             
            int tuitionFee = std.getFee();
            int transportFee = std.getBusFee();
             
            Console.WriteLine(std.getName() + " is Allocated Bus " + std.GetBusNo());
            Console.WriteLine("Total Fee: " + (tuitionFee + transportFee));


            Console.WriteLine("\n-------------------------------------------------------\n");

            Console.WriteLine("*************HOSTELUTE*****************");

            Hostelite host = new Hostelite();

            // Using setter functions
            host.setName("Ahmad");
            host.setSession("2024-2028");
            host.setSubjects(6);
            host.SetHostelName("Jinnah Hall");
            host.SetRoomNo(12);
            host.SetMonthlyRent(5000);

            // Calculating fees
            tuitionFee = host.getFee();
            int hostelFee = host.GetHostelFee();

            // Using getter functions for the output
            Console.WriteLine(std.getName() + " is Allocated Room " + host.GetRoomNo() + " in " + host.GetHostelName());
            Console.WriteLine("Total Semester Fee: " + (tuitionFee + hostelFee));
        }
    }
}
