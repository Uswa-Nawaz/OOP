using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_02_Task4
{
    internal class Student
    {
        public string name;
        public int matric;
        public int inter;
        public int ecat;
        public double agg;

        // Default constructor to initialize the value
        public Student()
        {
            name = null;
            matric = 0;
            inter = 0;
            ecat = 0;
            agg = 0.0;
        }
        // Methos to input Data 
        public void inputData(int count)
        {
            Console.WriteLine($"Enter student {count + 1} name: ");
            this.name = Console.ReadLine();
            Console.WriteLine($"Enter student's Matric marks: ");
            this.matric = int.Parse(Console.ReadLine());
            Console.WriteLine($"Enter student's Inter marks: ");
            this.inter = int.Parse(Console.ReadLine());
            Console.WriteLine($"Enter student's Ecat marks: ");
            this.ecat = int.Parse(Console.ReadLine());
    }

        // Method to calculate aggregate
        public double aggregate()
        {
            double m, i, e;
            m = (matric / 1100.0) * 100;
            i = (inter / 1200.0) * 100;
            e = (ecat / 400.0) * 100;
            agg = (m * 0.10) + (i * 0.40) + (e * 0.50);
            return agg;
        }
    }
}
