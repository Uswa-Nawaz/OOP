using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_03.BL;
using Challenge_03.DL;
using Challenge_03.UI;

namespace Challenge_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            while (option != 8)
            {
                option = MenuUI.Menu();
                MenuUI.clearScreen();

                if (option == 1) // Add Student
                {
                    // Check if any degree programs exist before adding a student
                    if (DegreeProgramDL.getProgramList().Count > 0)
                    {
                        Student s = StudentUI.takeInputForStudent();
                        StudentDL.addIntoStudentList(s);
                    }
                    else
                    {
                        Console.WriteLine("No degree programs available. Please add a degree first.");
                    }
                }
                else if (option == 2) // Add Degree Program
                {
                    DegreeProgram d = DegreeProgramUI.takeInputForDegree();
                    DegreeProgramDL.addIntoDegreeList(d);
                }
                else if (option == 3) // Generate Merit
                {
                    List<Student> sortedStudentList = StudentDL.sortStudentsByMerit();
                    StudentDL.giveAdmission(sortedStudentList);
                    StudentUI.printStudents();
                }
                else if (option == 4) // View Registered Students
                {
                    StudentUI.viewRegisteredStudents();
                }
                else if (option == 5) // View Students of a Specific Program
                {
                    Console.Write("Enter Degree Name: ");
                    string degName = Console.ReadLine();
                    StudentUI.viewStudentInDegree(degName);
                }
                else if (option == 6) // Register Subjects for a Specific Student
                {
                    Console.Write("Enter the Student Name: ");
                    string name = Console.ReadLine();
                    Student s = StudentDL.StudentPresent(name);

                    if (s != null)
                    {
                        SubjectUI.viewSubjects(s);
                        SubjectUI.registerSubjects(s);
                    }
                    else
                    {
                        Console.WriteLine("Student not found or not admitted to a degree.");
                    }
                }
                else if (option == 7) // Calculate Fees
                {
                    StudentUI.calculateFeeForAll();
                }

                if (option != 8)
                {
                    MenuUI.clearScreen();
                }
            }
        }
    }
}
