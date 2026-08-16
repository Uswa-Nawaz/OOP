using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS_DB.BL;

namespace UAMS_DB.DL
{
    internal class StudentDL
    {
        //static list of all the students
        private static List<Student> studentList = new List<Student>();

        //static method to add student to the list
        public static void addIntoStudentList(Student s)
        {
            studentList.Add(s);
        }

        //methos to get the student list
        public static List<Student> getStudentList()
        {
            return studentList;
        }

        //method to find if student is in the list
        public static Student StudentPresent(string name)
        {
            foreach (Student s in studentList)
            {
                if (name == s.getname() && s.getregDegree() != null)
                {
                    return s;
                }
            }
            return null;
        }

        //method that returns the list of student sorted by their merits
        public static List<Student> sortStudentsByMerit()
        {
            foreach (Student s in studentList)
            {
                s.calculatemerit();
            }

            // Sorting the list using LINQ, based on the merit value
            return studentList.OrderByDescending(o => o.getmerit()).ToList();
        }

        //method to give the admission to the student
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
    }
}
