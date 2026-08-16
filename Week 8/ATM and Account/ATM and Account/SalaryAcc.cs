using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_and_Account
{
    internal class SalaryAcc : Account
    {
        private double overdraftLimit;

        public SalaryAcc(double overdraftLimit, string title, int id, double balance) : base(title, id, balance)
        {
            this.overdraftLimit = overdraftLimit;
            //other attributes are handled by parent class
        }

        public double getDraftLimit()
        {
            return overdraftLimit;
        }

        public void setDraftLimit(double overdraftLimit)
        {
            this.overdraftLimit = overdraftLimit;
        }

        public double Salarydebit(double amount)
        {
            if (balance-amount < -overdraftLimit)    //-overdraftLimit : if overdraftLimit = 10000, it means you can go up to -10000 in your balance.
            {
                Console.WriteLine("The Overdraft Limit is rejected");
                return balance;
            }
            else
            {
                balance -= amount;
                return balance;
            }

        }
    }
}
