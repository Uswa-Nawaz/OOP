using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_02_Task2
{
    internal class Calculator
    {
        public double num1;
        public double num2;
        public double addition;
        public double subtraction;
        public double multiplication;
        public double division;

        // Default constructor to initialize
        public Calculator()
        {
            num1 = 0.0;
            num2 = 0.0;
        }
        // Parameterized Constructor to assign the values to artributes
        public Calculator(double n1, double n2)
        {
            num1 = n1;
            num2 = n2;
        }

        // Add function
        public double add()
        {
            addition= num1 + num2; 
            return addition;
        }
        // Subtract function
        public double subtract()
        {
            subtraction= num1 - num2;
            return subtraction;
        }
        // Multiply function
        public double multiply()
        {
            multiplication= num1 * num2;
            return multiplication;
        }
        // Divide Function
        public double divide()
        {
            if(num2==0)
            {
                return 0;
            }
            else
            {
                division= num1 / num2;
                return division;
            }
        }
        // function that inputs data
        public void inputdata()
        {
            Console.WriteLine("Enter  first number: " + num1);
            num1=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter  Second number: " + num2);
            num2 = int.Parse(Console.ReadLine());
        }
        // function to display data
        public void outputdata()
        {
            Console.WriteLine("Addition : " + add());
            Console.WriteLine("Subtraction : " + subtract());
            Console.WriteLine("Multiplication : " + multiply());
            Console.WriteLine("Division : " + divide());
        }
    }
}
