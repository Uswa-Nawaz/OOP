using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01
{
    internal class Author
    {
        //Task 1: author class can exist independently
        //The relationship between Author and book is aggregation, author can exist without the book
        //instances
        public string name;
        public string bio;

        //constructor
        public Author(string n, string bio)
        {
            setname(n);
            setname(bio);
        }
        //getters
        public string getname()
        {
            return name;
        }
        public string getbio()
        {
            return bio;
        }
        //setters
        public void setname(string name)
        {
            this.name = name;
        }
        public void setbio(string bio)
        {
            this.bio = bio;
        }
    }
}
