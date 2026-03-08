using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_02_Task3
{
    internal class ATM
    {
        public double balance;
        List<double> history = new List<double>();
    
        //public double deposite;
        //public double withdraw;

        //parameterized constructor to assign value to balance from main
        public ATM(double b)
        {
            balance = b;
            Console.WriteLine("Your balance: " + balance);
            Console.WriteLine("------------------------");
        }
        public void deposited(double amountd)
        {
            balance = balance + amountd;
            history.Add(balance);
            Console.WriteLine("You deposited: " + amountd);
            Console.WriteLine("Your New balance: "+ balance);
            Console.WriteLine("------------------------");
        }
        public void withdraw(double amountw)
        {
            if (amountw <= balance)
            {
                balance = balance - amountw;
                history.Add(balance);
                Console.WriteLine("You withdrawed: " + amountw);
                Console.WriteLine("Your New balance: " + balance);
                Console.WriteLine("------------------------");
            }
            else
            {
                Console.WriteLine("Insufficient balance");
            }
        }
        public void  inputdata()
        {
            Console.WriteLine("Enter the Balance: ");
            balance = double.Parse(Console.ReadLine());
        }
        public void CheckBalance()
        {
            Console.WriteLine("Current Balance: " + balance);
            Console.WriteLine("------------------------");

        }
        public void Showhistory()
        {
            Console.WriteLine("Transaction History:");

            for (int i = 0; i < history.Count; i++)
            {
                Console.WriteLine(history[i]);
            }
        }
    }

}
