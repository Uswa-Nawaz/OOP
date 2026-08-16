using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_03
{
    internal class Animal
    {
        protected string name;

        public Animal(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return "Animal[name=" + name + "]";
        }
    }
}
