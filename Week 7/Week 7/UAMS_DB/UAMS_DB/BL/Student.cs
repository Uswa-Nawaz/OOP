using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS_DB.BL
{
    internal class Student
    {
        //instances
        private string name;
        private int age;
        private double fscmarks;
        private double ecatmarks;
        private double merit; //to find out

        private List<DegreeProgram> preferences;
        private List<Subject> regsubject;

        private DegreeProgram regDegree;

        //constructor
        public Student(string name, int age, double fscmarks, double ecatmarks, List<DegreeProgram> preferences)
        {
            setname(name);
            setage(age);
            setfscmarks(fscmarks);
            setecatmarks(ecatmarks);
            this.preferences = preferences;
            regsubject = new List<Subject>();
        }

        //getters
        //for name
        public string getname()
        {
            return name;
        }
        //for age
        public int getage()
        {
            return age;
        }
        //for fsc marks
        public double getfscmarks()
        {
            return fscmarks;
        }
        //for ecatmarks
        public double getecatmarks()
        {
            return ecatmarks;
        }
        //for merit
        public double getmerit()
        {
            return merit;
        }
        //for the list of subjects registered by the student
        public List<Subject> getregsubject()
        {
            return regsubject;
        }
        //for the one final degree program that is registered
        public DegreeProgram getregDegree()
        {
            return regDegree;
        }
        //for the list of degree program considered as preferences
        public List<DegreeProgram> getpreferences()
        {
            return preferences;
        }

        //setters
        //for name
        public void setname(string name)
        {
            this.name = name;
        }
        //for age
        public void setage(int age)
        {
            this.age = age;
        }
        //for fsc marks
        public void setfscmarks(double fscmarks)
        {
            this.fscmarks = fscmarks;
        }
        //for ecatmarks
        public void setecatmarks(double ecatmarks)
        {
            this.ecatmarks = ecatmarks;
        }
        //for merit
        public void setmerit(double merit)
        {
            this.merit = merit;
        }
        //for registerd degree program
        public void setregDegree(DegreeProgram regDegree)
        {
            this.regDegree = regDegree;
        }
        //---------------------------------
        //calculate merit
        public void calculatemerit()
        {
            double f, e;
            f = (fscmarks / 1100.0) * 100;
            e = (ecatmarks / 400.0) * 100;
            double agg = (f * 0.45) + (e * 0.55);
            this.merit = agg;
        }

        //calculate fee
        public float calculateFee()
        {
            float fee = 0;
            if (regDegree != null)
            {
                foreach (Subject sub in regsubject)
                {
                    fee = fee + sub.getsubjectfee();
                }
            }
            return fee;
        }

        //to get no. of credit hours of the subjects registered by students
        public int getCreditHours()
        {
            int count = 0;
            foreach (Subject sub in regsubject)
            {
                count = count + sub.getcredithours();
            }
            return count;
        }

        //register subjects of the student
        public bool regStudentSubject(Subject s)
        {
            int stCH = getCreditHours();
            if (regDegree != null && regDegree.searchSubject(s) && stCH + s.getcredithours() <= 9)
            {
                regsubject.Add(s);
                {
                    return true;
                }
            }
            return false;
        }
    }
}
