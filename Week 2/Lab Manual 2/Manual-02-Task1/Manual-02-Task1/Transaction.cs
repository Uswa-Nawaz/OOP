using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_02_Task1
{
    internal class Transaction
    {
        public int transactionId;
        public string productname;
        public double amount;
        public string datetime;

        //default costructor to initialize the value
        public Transaction()
        {
            transactionId = 0;
            productname = string.Empty;
            amount = 0;
            datetime = string.Empty;
        }
        //parameterised constructor to assign the values
        public Transaction(int id, string n, double a, string t)
        {
            transactionId = id;
            productname = n;
            amount = a;
            datetime = t;
        }
        // Copy constructor
        public Transaction(Transaction t)
        {
            transactionId = t.transactionId;
            productname = t.productname;
            amount = t.amount;
            datetime = t.datetime;
        }
        // method to get data
        public void inputdetails()
        {
            Console.WriteLine("Enter transaction id: ");
            transactionId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter product name :");
            productname = Console.ReadLine();
            Console.WriteLine("Enter amount: ");
            amount = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter date :");
            datetime = Console.ReadLine();
        }

        //method to display the data
        public void displaydetails()
        {
            Console.Write("Transaction ID : ");
            Console.WriteLine(transactionId);
            Console.Write("Product name : ");
            Console.WriteLine(productname);
            Console.Write("Amount : ");
            Console.WriteLine(amount);
            Console.Write("Date: ");
            Console.WriteLine(datetime);
        }
    }
}
