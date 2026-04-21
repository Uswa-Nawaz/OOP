using Challenge_03.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Challenge_03.DL
{
    internal class StudentDL
    {
        private static List<Student> studentList = new List<Student>();

        public static void addIntoStudentList(Student s)
        {
            studentList.Add(s);
        }

        public static Student StudentPresent(string name)
        {
            foreach (Student s in studentList)
            {
                // Using your getter getname() and getregDegree()
                if (name == s.getname() && s.getregDegree() != null)
                {
                    return s;
                }
            }
            return null;
        }

        public static List<Student> sortStudentsByMerit()
        {
            foreach (Student s in studentList)
            {
                s.calculatemerit();
            }

            // Sorting the list using LINQ based on the merit value
            return studentList.OrderByDescending(o => o.getmerit()).ToList();
        }

        public static void giveAdmission(List<Student> sortedStudentList)
        {
            foreach (Student s in sortedStudentList)
            {
                foreach (DegreeProgram d in s.getpreferences())
                {
                    // Using getters for seats and checking if already registered
                    if (d.getseats() > 0 && s.getregDegree() == null)
                    {
                        s.setregDegree(d);
                        d.setseats(d.getseats() - 1);
                        break;
                    }
                }
            }
        }
        public static List<Student> getStudentList()
        {
            return studentList;
        }
    }
}
