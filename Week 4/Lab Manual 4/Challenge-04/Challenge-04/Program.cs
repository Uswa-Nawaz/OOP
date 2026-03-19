using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> StudentList = new List<Student>();
            List<Student> SelectedStudentList = new List<Student>();
            List<Degree> programList = new List<Degree>();

            int Option = 0;
            do
            {


                Console.WriteLine("************************************************************");
                Console.WriteLine("                             UAMS                           ");
                Console.WriteLine("************************************************************");
                Console.WriteLine("1.Add Student");
                Console.WriteLine("2.Add Degree Program");
                Console.WriteLine("3.Add Subjects to Degree Program");
                Console.WriteLine("4.Generate Merit List");
                Console.WriteLine("5.View Registered Students");
                Console.WriteLine("6.View Students of a Specific Program");
                Console.WriteLine("7.Register Subjects for a Specific Students");
                Console.WriteLine("8.Calculate Fee for all Registered Students");
                Console.WriteLine("9.Exit");
                Console.WriteLine("");
                Console.Write("Enter Option: ");

                Option = int.Parse(Console.ReadLine());
                if (Option == 1)
                {
                    // can only add student if at least one degree program exists
                    if (programList.Count > 0)
                    {
                        Student s = takeInputForStudent(programList);
                        StudentList.Add(s);
                    }
                    else
                    {
                        Console.WriteLine("No Degree Programs available. Add a program first!");
                    }

                }

                else if (Option == 2)
                {
                    // add a new degree program to the list
                    Degree d = takeInputForDegree();
                    programList.Add(d);
                }
                else if (Option == 3)
                {
                    // find the degree by title and add a subject to it
                    Console.Write("Enter Degree Title to add subject: ");
                    string title = Console.ReadLine();

                    Degree selectedDegree = null;
                    foreach (Degree d in programList)
                    {
                        if (d.title == title)
                        {
                            selectedDegree = d;
                            break;
                        }
                    }

                    if (selectedDegree != null)
                    {
                        AddSubjectToDegree(selectedDegree);
                    }
                    else
                    {
                        Console.WriteLine("Degree not found!");
                    }
                }
                else if (Option == 4)
                {
                    // generate merit list and assign degrees to students
                    GenMeritList(StudentList, programList);
                }

                else if (Option == 5)
                {
                    // display all admitted students
                    viewRegisteredStudents(StudentList);
                }

                else if (Option == 6)
                {
                    // display students of a specific degree program
                    SpecificProgramStudents(StudentList);
                }

                else if (Option == 7)
                {
                    // register subjects for a specific student
                    StudentRegSub(StudentList);
                }

                else if (Option == 8)
                {
                    // calculate and display fee for all admitted students
                    CalculateFeesForAll(StudentList);
                }

                if (Option != 9)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }


            } while (Option != 8);

        }

        static Student takeInputForStudent(List<Degree> programList)          //for option 1 add student
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Student Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter FSC Marks: ");
            float FSC = float.Parse(Console.ReadLine());

            Console.Write("Enter ECAT Marks: ");
            float ECAT = float.Parse(Console.ReadLine());

            Student stu = new Student(name, age, FSC, ECAT);

            // show available degree programs for student to pick preferences
            Console.WriteLine("Available Degree Programs:");
            foreach (Degree d in programList)
            {
                Console.WriteLine(d.title);
                Console.WriteLine(d.duration);
            }

            Console.Write("How many preferences: ");
            int pref = int.Parse(Console.ReadLine());
            // collect degree preferences from the student
            for (int i = 0; i < pref; i++)
            {
                Console.Write("Enter Preference ", (i + 1), ": ");
                string chooseDegree = Console.ReadLine();

                foreach (Degree d in programList)
                {
                    if (d.title == chooseDegree)
                    {
                        stu.prefrences.Add(d);
                    }
                }
            }

            return stu;
        }

        static Degree takeInputForDegree()     //for option 2 add degree programms
        {
            Console.Write("Enter Degree Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Degree Duration: ");
            int duration = int.Parse(Console.ReadLine());

            Console.Write("Enter Seats: ");
            int seats = int.Parse(Console.ReadLine());

            Degree deg = new Degree(title, duration, seats);
            // add initial subjects to the degree during creation
            Console.Write("Enter how many subjects you want to enter: ");
            int subjects = int.Parse(Console.ReadLine());

            for (int i = 0; i < subjects; i++)
            {
                Console.Write("Enter subject code: ");
                string code = Console.ReadLine();

                Console.Write("Enter Subject type: ");
                string type = Console.ReadLine();

                Console.Write("Enter subject credit hours: ");
                int CreditHours = int.Parse(Console.ReadLine());

                Console.Write("Enter subject fees: ");
                float fees = float.Parse(Console.ReadLine());

                Subject s = new Subject(code, CreditHours, type, fees);
                deg.AddSubject(s);
            }
            return deg;
        }
        static void AddSubjectToDegree(Degree deg)     //for option 3 add subjects to degree
        {
            Console.Write("Enter subject code: ");
            string code = Console.ReadLine();

            Console.Write("Enter Subject type: ");
            string type = Console.ReadLine();

            Console.Write("Enter subject credit hours: ");
            int CreditHours = int.Parse(Console.ReadLine());

            Console.Write("Enter subject fees: ");
            float fees = float.Parse(Console.ReadLine());

            Subject s = new Subject(code, CreditHours, type, fees);
            deg.AddSubject(s);
        }
        static void GenMeritList(List<Student> StudentList, List<Degree> programList)
        {
            foreach (Student student in StudentList)
            {
                student.CalculateMerit();
            }

            for (int i = 0; i < StudentList.Count - 1; i++)       //finding the highest merit
            {
                for (int j = 0; j < StudentList.Count - 1 - i; j++)
                {
                    if (StudentList[j].merit < StudentList[j + 1].merit)
                    {
                        Student temp = StudentList[j];
                        StudentList[j] = StudentList[j + 1];
                        StudentList[j + 1] = temp;
                    }
                }
            }

            foreach (Student student in StudentList)
            {
                foreach (Degree deg in student.prefrences)
                {
                    if (deg.seats > 0)
                    {
                        deg.seats--;
                        student.RegDegree = deg;
                        break;
                    }
                }
            }

            foreach (Student student in StudentList)
            {
                if (student.RegDegree != null)
                {
                    Console.WriteLine($"{student.Name} got Admission in {student.RegDegree.title}");
                }
                else
                {
                    Console.WriteLine($"{student.Name} did not get Admission");
                }
            }
        }

        static void viewRegisteredStudents(List<Student> studentList)       //option 4 for generating merit list
        {
            Console.WriteLine("Name        Age");
            foreach (Student student in studentList)
            {
                if (student.RegDegree != null)
                {
                    Console.WriteLine($"{student.Name}        {student.age}");
                }
            }
        }

        static void SpecificProgramStudents(List<Student> studentList)       //option 5
        {
            Console.Write("Enter the name of degree program: ");
            string dgr = Console.ReadLine();
            Console.WriteLine("Name        Age");
            foreach (Student student in studentList)
            {
                if (student.RegDegree != null && student.RegDegree.title == dgr)
                {
                    Console.WriteLine($"{student.Name}        {student.age}");
                }
            }
        }

        static void StudentRegSub(List<Student> studentList)        //option 6
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            Student s = StudentPresent(studentList, name);     //checking if student exists or admitted

            if (s != null)   //Student regeistered sub for degree
            {
                Console.WriteLine("SubCode\tType\tCredit Hours\tFees");
                foreach (Subject sub in s.RegDegree.subjects)
                {
                    Console.WriteLine($"{sub.SubjCode}\t{sub.SubjType}\t{sub.CRH}\t{sub.SubjFee}");
                }

                Console.Write("Enter Subject Code to Register: ");
                string code = Console.ReadLine();

                Subject selectedSubject = null;
                foreach (Subject sub in s.RegDegree.subjects)        //finding user input code from subject
                {
                    if (sub.SubjCode == code)
                    {
                        selectedSubject = sub;
                        break;
                    }
                }

                if (selectedSubject != null)
                {

                    bool success = s.StdRegSubj(selectedSubject);

                    if (success)
                    {
                        Console.WriteLine("Subject Registered Successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Registration Failed. 9 Credit Hour limit exceeded.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Subject Code!");
                }
            }
            else
            {
                Console.WriteLine("Student not found or not admitted to any program.");
            }
        }

        static Student StudentPresent(List<Student> studentList, string name)        // option 6 helper function
        {
            foreach (Student student in studentList)
            {
                if (student.Name == name && student.RegDegree != null)
                {
                    return student;
                }

            }
            return null;
        }

        static void CalculateFeesForAll(List<Student> studentList)       //option 7
        {
            foreach (Student s in studentList)
            {
                if (s.RegDegree != null)
                {
                    float totalFee = s.CalculateFee();
                    Console.WriteLine($"{s.Name} has {totalFee} fees");
                }
            }
        }
    }
}
