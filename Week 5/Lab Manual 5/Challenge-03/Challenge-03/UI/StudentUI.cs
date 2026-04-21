using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_03.BL;
using Challenge_03.DL;

namespace Challenge_03.UI
{
    internal class StudentUI
    {
        // Displays admission results for all students
        public static void printStudents()
        {
            foreach (Student s in StudentDL.getStudentList())
            {
                if (s.getregDegree() != null)
                {
                    Console.WriteLine(s.getname() + " got Admission in " + s.getregDegree().Degreename());
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
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (Student s in StudentDL.getStudentList())
            {
                if (s.getregDegree() != null)
                {
                    if (degName == s.getregDegree().Degreename())
                    {
                        Console.WriteLine(s.getname() + "\t" + s.getfscmarks() + "\t" + s.getecatmarks() + "\t" + s.getage());
                    }
                }
            }
        }

        // Displays all students who successfully secured admission
        public static void viewRegisteredStudents()
        {
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (Student s in StudentDL.getStudentList())
            {
                if (s.getregDegree() != null)
                {
                    Console.WriteLine(s.getname() + "\t" + s.getfscmarks() + "\t" + s.getecatmarks() + "\t" + s.getage());
                }
            }
        }

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
                    if (degName == dp.Degreename() && !(preferences.Contains(dp)))
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
    }
}
