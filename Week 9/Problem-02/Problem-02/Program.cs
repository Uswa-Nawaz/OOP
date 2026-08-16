using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_02
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Student s1 = new Student("Ali", "Lahore", "CS", 2, 50000);
            Student s2 = new Student("Sara", "Karachi", "SE", 3, 55000);

            Staff st1 = new Staff("Dr. Ahmed", "Lahore", "CS Dept", 120000);
            Staff st2 = new Staff("Ms. Hina", "Islamabad", "Math Dept", 95000);

            Console.WriteLine(s1.ToString());
            Console.WriteLine(s2.ToString());
            Console.WriteLine(st1.ToString());
            Console.WriteLine(st2.ToString());
        }
    }
}
