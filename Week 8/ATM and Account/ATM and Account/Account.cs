using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_and_Account
{
    internal class Account
    {
        protected string title;
        protected int id;
        protected double balance;

        public Account(string title, int id, double balance)
        {
            this.title = title;
            this.id = id;
            this.balance = balance;
        }

        public string getTitle()
        {
            return title;
        }

        public void setTitle(string title)
        {
            this.title = title;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id=id;
        }

        public double getBalance()
        {
            return balance;
        }

        public void setBalance(double balance)
        {
            this.balance = balance;
        }

        public double credit (double amount)
        {
            balance += amount;
            return balance;
        }

        public double debit(double amount)
        {
            if (balance - amount < 0)
            {
                Console.WriteLine("--Insufficient Balance--");
                return balance;
            }
            else 
            {
                balance -= amount;
                return balance;
            }
             
        }

        public string toString()
        {
            return $"Account Title: {title}\t Account ID: {id} \t Account balance: {balance}";
        }
    }
}
