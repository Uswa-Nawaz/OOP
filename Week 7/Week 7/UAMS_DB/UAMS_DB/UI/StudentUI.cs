using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_DB.BL;
using UAMS_DB.DL;

namespace UAMS_DB.UI
{
    internal class StudentUI
    {
        // Takes input to create a new Student object
        public static Student takeInputForStudent()
        {
            List<DegreeProgram> preferences = new List<DegreeProgram>();
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Student Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Student FSc Marks: ");
            double fscMarks = double.Parse(Console.ReadLine());
            Console.Write("Enter Student Ecat Marks: ");
            double ecatMarks = double.Parse(Console.ReadLine());

            Console.WriteLine("Available Degree Programs");
            DegreeProgramUI.viewDegreePrograms();

            Console.Write("Enter how many preferences to Enter: ");
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count; x++)
            {
                string degName = Console.ReadLine();
                bool flag = false;
                foreach (DegreeProgram dp in DegreeProgramDL.getProgramList())
                {
                    if (degName == dp.getDegreename() && !(preferences.Contains(dp)))
                    {
                        preferences.Add(dp);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Enter Valid Degree Program Name");
                    x--;
                }
            }
            Student s = new Student(name, age, fscMarks, ecatMarks, preferences);
            return s;
        }

        // Calculates and displays the total fees for all admitted students
        public static void calculateFeeForAll()
        {
            foreach (Student s in StudentDL.getStudentList())
            {
                if (s.getregDegree() != null)
                {
                    Console.WriteLine(s.getname() + " has " + s.calculateFee() + " fees");
                }
            }
        }

        // Displays admission results for all students
        public static void printStudents()
        {
            foreach (Student s in StudentDL.getStudentList())
            {
                if (s.getregDegree() != null)
                {
                    Console.WriteLine(s.getname() + " got Admission in " + s.getregDegree().getDegreename());
                }
                else
                {
                    Console.WriteLine(s.getname() + " did not get Admission");
                }
            }
        }

        // Displays students registered in a specific degree program
        public static void viewStudentInDegree(string degName)
        {
            // Define the headers with fixed widths
            // Name: 15 spaces, FSC: 10, Ecat: 10, Age: 5
            Console.WriteLine("{0, -15} {1, -10} {2, -10} {3, -5}", "Name", "FSC", "Ecat", "Age");
            Console.WriteLine("--------------------------------------------");

            foreach (Student s in StudentDL.getStudentList())
            {
                if (s.getregDegree() != null)
                {
                    if (degName == s.getregDegree().getDegreename())
                    {
                        // Use the same width numbers here so the data lines up with the headers
                        Console.WriteLine("{0, -15} {1, -10} {2, -10} {3, -5}",
                                       s.getname(), s.getfscmarks(), s.getecatmarks(), s.getage());
                    }
                }
            }
        }

        // Displays all students who successfully secured admission
        public static void viewRegisteredStudents()
        {
            // Define headers: Name(15), FSC(10), Ecat(10), Age(5)
            Console.WriteLine("{0, -15} {1, -10} {2, -10} {3, -5}", "Name", "FSC", "Ecat", "Age");
            Console.WriteLine("--------------------------------------------");

            foreach (Student s in StudentDL.getStudentList())
            {
                // Only print if the student actually has a degree assigned
                if (s.getregDegree() != null)
                {
                    // Data alignment matches the header alignment above
                    Console.WriteLine("{0, -15} {1, -10} {2, -10} {3, -5}",
                                       s.getname(), s.getfscmarks(), s.getecatmarks(), s.getage());
                }
            }
        }
    }
}
