using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_assessment_task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();
            string name;
            int rollNumber;
            float cgpa;
            int semFee;
            int matricMarks;
            string hometown;
            bool isHostelite;
            //----------
            float f;
            float e;
            while (true)
            {
                int choice = 0;
                Console.WriteLine(" <<< MENU >>> ");
                Console.WriteLine("1. Register a Student");
                Console.WriteLine("2. Calculate Aggregate");
                Console.WriteLine("3. Scholarship Status");
                Console.WriteLine("4. Display Information");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your Choice: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if(choice==1)
                    {
                        //collecting information
                        Console.Write("Enter Student's name: ");
                        name = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Enter Roll Number: ");
                        rollNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Write("Enter CGPA: ");
                        cgpa = float.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Write("Enter Semester Fee: ");
                        semFee = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Write("Enter Matric Marks: ");
                        matricMarks = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Write("Enter FSC Marks: ");
                        f = float.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Write("Enter ECAT marks: ");
                        e = float.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Write("Enter hometown: ");
                        hometown = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Hostelite (True/False): ");
                        isHostelite = bool.Parse(Console.ReadLine());
                        Console.WriteLine("-----------------------------");
                        //create object
                        Student s = new Student(name, rollNumber, cgpa, semFee, matricMarks, f, e, hometown, isHostelite);
                        //add object to the list
                        studentList.Add(s);
                    }
                    if (choice == 2)
                    {
                        foreach (Student s in studentList)
                        {
                            Console.WriteLine(" <<< AGGREGATE >>>");
                            s.calculateMerit();
                        }
                    }
                    else if (choice == 3)
                    {
                        foreach (Student s in studentList)
                        {
                            if (s.isEligibleforScholarship() == true)
                            {
                                Console.WriteLine(" Student is eligible for scholarship");
                            }
                            else if (s.isEligibleforScholarship() == false)
                            {
                                Console.WriteLine(" Student is NOT eligible for scholarship");
                            }
                        }
                    }
                    else if (choice == 4)
                    {
                        foreach (Student s in studentList)
                        {
                            s.display();
                        }
                    }
                    else if (choice == 5)
                    {
                        Console.WriteLine("Exiting");
                        return;
                    }
                }
            }
        }
    }
}
