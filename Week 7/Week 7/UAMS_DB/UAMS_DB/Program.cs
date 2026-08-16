using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_DB.BL;
using UAMS_DB.DL;
using UAMS_DB.UI;

namespace UAMS_DB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SubjectDL.loadSubjectsFromDB();

            int option = 0;
            while (option != 8)
            {
                option = MenuUI.Menu();
                MenuUI.clearScreen();

                // Add Student
                if (option == 1)
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

                //Add degree program
                else if (option == 2) 
                {
                    DegreeProgram d = DegreeProgramUI.takeInputForDegree();
                    DegreeProgramDL.addIntoDegreeList(d);
                }

                //gemerate merit
                else if (option == 3)
                {
                    List<Student> sortedStudentList = StudentDL.sortStudentsByMerit();
                    StudentDL.giveAdmission(sortedStudentList);
                    StudentUI.printStudents();
                }

                //view registered student
                else if (option == 4)
                {
                    StudentUI.viewRegisteredStudents();
                }

                //View Students of a Specific Program
                else if (option == 5)
                {
                    Console.Write("Enter Degree Name: ");
                    string degName = Console.ReadLine();
                    StudentUI.viewStudentInDegree(degName);
                }

                //Register Subjects for a Specific Student
                else if (option == 6)
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

                //Calculate Fees for all Registered Students
                else if (option == 7)
                {
                    StudentUI.calculateFeeForAll();
                }

                //Exit
                if (option != 8)
                {
                    MenuUI.clearScreen();
                }
            }
        }
    }
}
