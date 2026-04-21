using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_03.BL
{
    internal class DegreeProgram
    {
        //instances
        private string degreename;
        private float degreeduration;
        private int seats;
        private List<Subject> subjects;

        //constructor
        public DegreeProgram(string dn, float dd, int s)
        {
            setdegreename(dn);
            setdegreeduration(dd);
            setseats(s);
            subjects= new List<Subject>(); 
        }
        //getters
        //for degree name
        public string Degreename()
        {
            return degreename;
        }
        //for degree duration
        public float getDegreeduration()
        {
            return degreeduration;
        }
        //for seats
        public int getseats()
        {
            return seats;
        }
        public List<Subject> getSubjects()
        {
            return subjects;
        }
        //setters
        //for degree name
        public void setdegreename(string degreename)
        {
            this.degreename = degreename;
        }
        //for degree duration
        public void setdegreeduration(float degreeduration)
        {
            this.degreeduration = degreeduration;
        }
        //for seats
        public void setseats(int seats)
        {
            this.seats = seats;
        }

        //----------------------------
        //search subject
        public bool issubjectexist(Subject sub)
        { 
            foreach(Subject s in subjects)
            {
                if(s.getcode() == sub.getcode())
                {
                    return true;
                }
            }
            return false;
        }
        //add subject to list
        public bool addSubject(Subject s)
        {
            int credithour = calculateCreditHour();
            if(credithour+s.getcredithours() <= 20)
            {
                subjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }

        //to calculate credithours
        public int calculateCreditHour()
        {
            int count = 0;
            for(int x=0; x<subjects.Count; x++)
            {
                count = count + subjects[x].getcredithours();
            }
            return count;
        }
    }
}
