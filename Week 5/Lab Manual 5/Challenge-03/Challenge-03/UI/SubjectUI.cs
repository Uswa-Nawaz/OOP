using Challenge_03.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_03.UI
{
    internal class SubjectUI
    {
        // Method to take input for a subject from the console
        public static Subject takeInputForSubject()
        {
            Console.Write("Enter Subject Code: ");
            string code = Console.ReadLine();
            Console.Write("Enter Subject Type: ");
            string type = Console.ReadLine();
            Console.Write("Enter Subject Credit Hours: ");
            int creditHours = int.Parse(Console.ReadLine());
            Console.Write("Enter Subject Fees: ");
            int subjectFees = int.Parse(Console.ReadLine());

            Subject sub = new Subject(code, type, creditHours, subjectFees);
            return sub;
        }

        // Method to view subjects registered in a student's degree program
        public static void viewSubjects(Student s)
        {
            if (s.getregDegree() != null)
            {
                Console.WriteLine("Sub Code\tSub Type");
                // Accessing the list of subjects within the degree program
                foreach (Subject sub in s.getregDegree().getSubjects())
                {
                    Console.WriteLine(sub.getcode() + "\t\t" + sub.getType());
                }
            }
        }

        // Method to register specific subjects for a student
        public static void registerSubjects(Student s)
        {
            Console.Write("Enter how many subjects you want to register: ");
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count; x++)
            {
                Console.Write("Enter the subject code: ");
                string code = Console.ReadLine();
                bool Flag = false;

                // Loop through available subjects in the assigned degree
                foreach (Subject sub in s.getregDegree().getSubjects())
                {
                    if (code == sub.getcode() && !(s.getregsubject().Contains(sub)))
                    {
                        if (s.regStudentSubject(sub))
                        {
                            Flag = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("A student cannot have more than 9 CH");
                            Flag = true;
                            break;
                        }
                    }
                }

                if (Flag == false)
                {
                    Console.WriteLine("Enter Valid Course");
                    x--; // Decrement index to allow re-entry for this count
                }
            }
        }
    }
}
