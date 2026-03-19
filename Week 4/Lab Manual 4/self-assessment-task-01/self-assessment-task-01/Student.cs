using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_assessment_task_01
{
    internal class Student
    {
        public string name;
        public int rollNumber;
        public float cgpa;
        public int semFee;
        public int matricMarks;
        // ----------------
        //calculated will be here in these three
        public float fscMarks;
        public float ecatMarks;
        //------------------
        public string hometown;
        public bool isHostelite;
        public bool isTakingScholarship;
        float agg;

        //parameterized constructor to set values
        public Student(string name, int rollNumber, float cgpa, int semFee, int matricMarks, float f, float e, string hometown, bool isHostelite)
        {
            this.name = name;
            this.rollNumber = rollNumber;
            this.cgpa = cgpa;
            this.semFee = semFee;
            this.matricMarks = matricMarks;
            this.hometown = hometown;
            this.isHostelite = isHostelite;
            this.fscMarks = f;
            this.ecatMarks = e;
        }
        //method that will calculate the aggregate
        public float calculateMerit()
        {
            float fpercentage = (fscMarks / 1200) * 60;
            float epercentage= (ecatMarks / 400) * 40;
            agg = fpercentage + epercentage;
            Console.WriteLine("Aggregate : "+agg);
            return agg;
        }
        //method to check eligibility for scholarship
        public bool isEligibleforScholarship()
        {
            if (agg >= 80)
            {
                return true;
            }
            return false;
        }

        //method to display all information
        public void display()
        {
            Console.WriteLine(" <<< STUDENT INFO >>>");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Roll Number: " + rollNumber);
            Console.WriteLine("CGPA: " + cgpa);
            Console.WriteLine("Semester Fee: " + semFee);
            Console.WriteLine("Matric Marks: " + matricMarks);
            Console.WriteLine("FSC Marks: " + fscMarks);
            Console.WriteLine("ECAT Marks: " + ecatMarks);
            Console.WriteLine("HomeTown: " + hometown);
            Console.WriteLine("Accommodation Status: " + isHostelite);
            Console.WriteLine("Scholarship Status: " + isTakingScholarship);
            Console.WriteLine("----------------------------------------");
        }
    }
}
