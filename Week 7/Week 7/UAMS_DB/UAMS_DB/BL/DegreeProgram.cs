using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS_DB.BL
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
            subjects = new List<Subject>();
        }
        //getters
        //for degree name
        public string getDegreename()
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

        // Function to search for a subject
        public bool searchSubject(Subject s)
        {
            foreach(Subject sub in subjects)
            {
                if(sub.getcode()==s.getcode())
                {
                    return true;
                }
            }
            return false;
        }

        //Function to calculate credit hours
        public int calculatecredithour()
        {
            int count = 0;
            for(int x=0; x<subjects.Count; x++)
            {
                count = count + subjects[x].getcredithours();
            }
            return count;
        }

        //Functions to add subject to the list
        public bool addsubjectToList(Subject s)
        {
            int credithour = calculatecredithour();
            if (credithour+s.getcredithours() <= 20)  //understand this line
            {
                subjects.Add(s);
                return true;
            }
            return false;
        }
    }
}
