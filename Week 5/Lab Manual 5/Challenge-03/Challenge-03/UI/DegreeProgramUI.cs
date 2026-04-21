using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_03.BL;
using Challenge_03.DL;

namespace Challenge_03.UI
{
    internal class DegreeProgramUI
    {
        // Method to take input for a new degree program and its subjects
        public static DegreeProgram takeInputForDegree()
        {
            Console.Write("Enter Degree Name: ");
            string degreeName = Console.ReadLine();
            Console.Write("Enter Degree Duration: ");
            float degreeDuration = float.Parse(Console.ReadLine());
            Console.Write("Enter Seats for Degree: ");
            int seats = int.Parse(Console.ReadLine());

            // Create the degree object using constructor
            DegreeProgram degProg = new DegreeProgram(degreeName, degreeDuration, seats);

            Console.Write("Enter How many Subjects to Enter: ");
            int count = int.Parse(Console.ReadLine());

            for (int x = 0; x < count; x++)
            {
                // Call SubjectUI to get the subject details
                Subject s = SubjectUI.takeInputForSubject();

                // Attempt to add the subject to the degree program
                if (degProg.addSubject(s))
                {
                    // If successfully added, check if it's already in the global Subject list
                    if (!(SubjectDL.getSubjectList().Contains(s)))
                    {
                        SubjectDL.addSubjectIntoList(s);
                    }
                    Console.WriteLine("Subject Added");
                }
                else
                {
                    Console.WriteLine("Subject Not Added");
                    Console.WriteLine("20 credit hour limit exceeded");
                    x--; // Allow the user to try adding a different subject
                }
            }
            return degProg;
        }

        // Method to display all available degree programs
        public static void viewDegreePrograms()
        {
            // Accessing the static list through the DL getter
            foreach (DegreeProgram dp in DegreeProgramDL.getProgramList())
            {
                // Using the Degreename() getter from BL class
                Console.WriteLine(dp.Degreename());
            }
        }
    }
}
