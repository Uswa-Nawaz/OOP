using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_03
{
    internal class Dog : Mammal
    {
        public Dog(string name)
            : base(name)
        {
        }

        public void Greets()
        {
            Console.WriteLine("Woof");
        }

        public void Greets(Dog another)
        {
            Console.WriteLine("Woooof");
        }

        public override string ToString()
        {
            return "Dog[" + base.ToString() + "]";
        }
    }
}
