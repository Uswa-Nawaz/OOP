using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manul_03_task1
{
    internal class ClockType
    {
        public int hours;
        public int minutes;
        public int seconds;

        // Default Constructor
        public ClockType()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
        }

        // Parameterized Constructors
        public ClockType(int h)
        {
            hours = h;
        }

        public ClockType(int h, int m)
        {
            hours = h;
            minutes = m;
        }
        public ClockType(int h, int m, int s)
        {
            hours = h;
            minutes = m;
            seconds = s;
        }
        public void incrementSeconds() 
        {
            seconds++;
        }
        public void incrementMinutes() 
        {
            minutes++; 
        }
        public void incrementHours() 
        {
            hours++;
        }
        public void printTime()
        {
            //  Format hr:min:sec
            Console.WriteLine($"{hours}:{minutes}:{seconds}");
        }
        // isEqual with Manual Timings
        public bool isEqual(int h, int m, int s)
        {
            if(hours == h && minutes == m && seconds == s)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // isEqual with Object Timings
        public bool isEqual(ClockType temp)
        {
            if(hours == temp.hours && minutes == temp.minutes && seconds == temp.seconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Challenge a: Elapsed time in seconds
        public int elapsedTime()
        {
            int totalSeconds;
            int h_sec = hours * 3600;      // Convert hours to seconds
            int m_sec = minutes * 60;      // Convert minutes to seconds

            totalSeconds = h_sec + m_sec + seconds;
            return totalSeconds;
        }

        // Challenge b: Remaining time in seconds
        public int remainingTime()
        {
            int totalDaySeconds = 86400;   // Total seconds in 24 hours
            int elapsed = elapsedTime();  
            int remaining;

            remaining = totalDaySeconds - elapsed;
            return remaining;
        }

        // Challenge c: Difference between two clocks
        public int difference(ClockType other)
        {
            int time1 = elapsedTime();      
            int time2 = other.elapsedTime();
            int diff;

            if (time1 > time2)
            {
                diff = time1 - time2;
            }
            else
            {
                diff = time2 - time1;
            }
            return diff;
        }
    }
}
