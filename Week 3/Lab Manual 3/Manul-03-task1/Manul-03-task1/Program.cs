using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manul_03_task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClockType empty_time = new ClockType();
            Console.Write("Empty time: ");
            empty_time.printTime();

            ClockType hour_time = new ClockType(8);
            Console.Write("Hour time: ");
            hour_time.printTime();

            ClockType minute_time = new ClockType(8, 10);
            Console.Write("Minute time: ");
            minute_time.printTime();

            ClockType full_time = new ClockType(8, 10, 10);
            Console.Write("Full time: ");
            full_time.printTime();

            full_time.incrementSeconds();
            Console.Write("Full time (Increment Second): ");
            full_time.printTime();

            full_time.incrementHours();
            Console.Write("Full time (Increment hours): ");
            full_time.printTime();

            full_time.incrementMinutes();
            Console.Write("Full time (Increment Mintues): ");
            full_time.printTime();

            // With manual timings
            bool flag = full_time.isEqual(9, 11, 11);
            Console.WriteLine("Flag: " + flag);

            // With object timings
            ClockType cmp = new ClockType(10, 12, 1);
            flag = full_time.isEqual(cmp);
            Console.WriteLine("Object Flag: " + flag);

            Console.WriteLine("Elapsed time in seconds: " + full_time.elapsedTime());
            Console.WriteLine("Remaining time in seconds: " + full_time.remainingTime());

            int diffSeconds = full_time.difference(cmp);
            Console.WriteLine("Difference in seconds: " + diffSeconds);
        }
    }
}
