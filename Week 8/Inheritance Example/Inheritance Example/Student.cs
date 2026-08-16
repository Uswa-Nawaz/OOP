using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Example
{
    internal class Student
    {
        private string name;
        private string session;
        private int subjects;

        public void setName(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return this.name;
        }

        public void setSession(string session)
        {
            this.session = session;
        }

        public string getSession()
        {
            return this.session;
        }
 
        public void setSubjects(int subjects)
        {
            if (subjects >= 0)      //validating
            {
                this.subjects = subjects;
            }
        }

        public int getSubjects()
        {
            return this.subjects;
        }
 
        public int getFee()
        {
            int fee = subjects * 4000;
            return fee;
        }
    }
}
