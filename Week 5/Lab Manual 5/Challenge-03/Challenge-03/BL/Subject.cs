using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_03.BL
{
    internal class Subject
    {
        //instances
        private string code;
        private string type;
        private int credithour;
        private int subjectfee;

        //constructor
        public Subject(string c, string t, int ch, int s)
        {
            setcode(c);
            settype(t);
            setcedithour(ch);
            setsubjectfee(s);
        }

        //getters
        //for code
        public string getcode()
        {
            return code;
        }
        //for type
        public string getType()
        {
            return type;
        }
        //for cedithour
        public int getcredithours()
        {
            return credithour;
        } 
        //for subject fee
        public int getsubjectfee()
        {
            return subjectfee;
        }
        //setters +validations can be applied here
        //for code
        public void setcode(string code)
        {
            this.code = code;
        }
        //for type
        public void settype(string type)
        {
            this.type = type;
        }
        //for cedithour
        public void setcedithour(int credithour)
        {
            this.credithour = credithour;
        }
        //for subject fee
        public void setsubjectfee(int subjectfee)
        {
            this.subjectfee = subjectfee; 
        }
    }
}
