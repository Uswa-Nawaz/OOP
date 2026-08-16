using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_DB.BL;
using UAMS_DB.DL;
namespace UAMS_DB.UI
{
    internal class SubjectUI
    {
        // Method to take input for a subject info
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
                // -15 for subj Code, -15 for subj Type
                Console.WriteLine($"{"Sub Code",-15} {"Sub Type",-15}");
                Console.WriteLine("------------------------------");

                foreach (Subject sub in s.getregDegree().getSubjects())
                {
                    Console.WriteLine($"{sub.getcode(),-15} {sub.getType(),-15}");
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
