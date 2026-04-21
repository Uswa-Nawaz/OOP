using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Challenge_03.BL;

namespace Challenge_03.DL
{
    internal class SubjectDL
    {
        // Static list to store all subjects 
        private static List<Subject> subjectList = new List<Subject>();

        // Method to add a subject object into the static list
        public static void addSubjectIntoList(Subject s)
        {
            subjectList.Add(s);
        }
        // Method to search a subject in the list based on its type
        public static Subject isSubjectExists(string type)
        {
            foreach (Subject s in subjectList)
            {
                if (s.getType() == type)
                {
                    return s;
                }
            }
            return null;
        }

        // Getter for the subject list 
        public static List<Subject> getSubjectList()
        {
            return subjectList;
        }
    }
}
