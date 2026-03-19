using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_04
{
    internal class Student
    {
        public string Name;
        public int age;
        public float FSCMarks;
        public float ECATMarks;
        public double merit;

        public List<Degree> prefrences;
        public List<Subject> RegSubj;

        public Degree RegDegree;

        // parameterized constructor to set student info
        public Student(string Name, int age, float FSCMarks, float ECATMarks)
        {
            this.Name = Name;
            this.age = age;
            this.FSCMarks = FSCMarks;
            this.ECATMarks = ECATMarks;
            this.merit = 0;
            this.RegDegree = null;

            prefrences = new List<Degree>();
            RegSubj = new List<Subject>();
        }
        // 30% FSC + 70% ECAT
        public void CalculateMerit()
        {
            merit = (FSCMarks * 0.30) + (ECATMarks * 0.70);
        }

        public int GetCreditHours()
        {

            int total = 0;
            foreach (Subject subject in RegSubj)
            {
                total = total + subject.CRH;

            }
            return total;

        }
        // returns total fee of all registered subjects
        public float CalculateFee()
        {
            float total = 0;
            foreach (Subject subject in RegSubj)
            {
                total = total + subject.SubjFee;

            }
            return total;

        }
        // registers a subject if it exists in the degree and credit hours don't exceed 9
        public bool StdRegSubj(Subject s)
        {
            int StdCH = GetCreditHours();

            if (RegDegree != null && RegDegree.isSubjectExists(s) && StdCH + s.CRH <= 9)
            {
                RegSubj.Add(s);
                return true;
            }
            return false;
        }
    }
}
