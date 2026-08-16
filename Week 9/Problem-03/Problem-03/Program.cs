using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cat cat1 = new Cat("Whiskers");
            Cat cat2 = new Cat("Luna");
            Dog dog1 = new Dog("Bruno");
            Dog dog2 = new Dog("Max");

            // Using polymorphism without IF statement
            // Store all animals in a common list
            List<Animal> animals = new List<Animal>();
            animals.Add(cat1);
            animals.Add(cat2);
            animals.Add(dog1);
            animals.Add(dog2);

            // Call greets() and toString() without IF using direct references
            cat1.Greets();
            Console.WriteLine(cat1.ToString());

            cat2.Greets();
            Console.WriteLine(cat2.ToString());

            dog1.Greets();
            Console.WriteLine(dog1.ToString());

            dog2.Greets();
            Console.WriteLine(dog2.ToString());
        }
    }
}
