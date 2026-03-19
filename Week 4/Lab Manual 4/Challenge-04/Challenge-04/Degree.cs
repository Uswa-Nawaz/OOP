using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Challenge_04
{
    internal class Degree
    {
        public string title; // name of the degree program
        public float duration; // duration in years
        public int seats;  // available seats for admission

        public List<Subject> subjects;

        // parameterized constructor to set degree info
        public Degree(string title, float duration, int seats)
        {
            this.title = title;
            this.duration = duration;
            this.seats = seats;
            subjects = new List<Subject>();
        }
        // returns the total credit hours
        public int calculateCreditHours()
        {
            int total = 0;
            foreach (Subject subject in subjects)
            {
                total = total + subject.CRH;

            }
            return total;

        }
        // checks if a subject already exists in the degree by subject code
        public bool isSubjectExists(Subject sub)
        {
            foreach (Subject subject in subjects)
            {
                if (subject.SubjCode == sub.SubjCode)
                {
                    return true;
                }
            }
            return false;

        }
        // adds a subject if total credit hours won't exceed 20
        public bool AddSubject(Subject s)
        {
            int creditHours = calculateCreditHours();
            if (creditHours + s.CRH <= 20)
            {
                subjects.Add(s);
                return true;
            }
            return false;

        }
    }
}
