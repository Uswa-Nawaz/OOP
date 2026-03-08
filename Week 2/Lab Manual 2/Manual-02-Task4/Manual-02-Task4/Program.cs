using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Manual_02_Task4
{
    internal class Program
    {
        //function that finds top student
        public static double topStudent(Student[] allStudents, int count)
        {
            double topmarks = 0;
            for (int i = 0; i < count; i++)
            {
                if (allStudents[i].agg > topmarks)
                {
                    topmarks = allStudents[i].aggregate();
                }
            }
            Console.WriteLine($"Aggregate: {topmarks}");
            return topmarks;
        }
        //Function that shows all students
        public static void showAllStudents(Student[] allStudents, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Student number: {i+1} ");
                Console.WriteLine(allStudents[i].name);
                Console.WriteLine(allStudents[i].matric);
                Console.WriteLine(allStudents[i].inter);
                Console.WriteLine(allStudents[i].ecat);
                Console.WriteLine(allStudents[i].agg);
                Console.WriteLine("-----------------------");
            }
        }

        static void Main(string[] args)
        {
            // array of objects here
            Student[] allStudents = new Student[100];
            int count = 0;
            while (true)
            {
                int choice = 0;
                Console.WriteLine(" << PICK YOUR OPTION >> ");
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. Calculate Aggregate");
                Console.WriteLine("3. Top Student");
                Console.WriteLine("4. Show All Students");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice 1-5: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice == 1)
                    {
                        Student s1= new Student(); 
                        s1.inputData(count);       
                        allStudents[count] = s1;   
                        count++;
                        Console.WriteLine("Student added successfully! Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (choice == 2)
                    {
                        for (int x = 0; x < count; x++)
                        {
                            double result = allStudents[x].aggregate();
                            Console.WriteLine($"Aggregate: {result}");
                        }
                    }
                    else if (choice == 3)
                    {
                        topStudent(allStudents, count);
                    }
                    else if (choice == 4)
                    {
                        showAllStudents(allStudents, count);
                    }
                    else if (choice == 5)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("ERROR: Enter a valid number between 1-5");
                    }
                }
                else
                {
                    Console.WriteLine("[ERROR]: Enter valid type of data");
                }
            }

        }
    }
}
