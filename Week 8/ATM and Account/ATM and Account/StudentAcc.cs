using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_and_Account
{
    internal class StudentAcc : Account
    {
        private double maxCreditLimit = 500000.0;

        public StudentAcc(string title, int id, double balance) : base (title,id,balance)
        {
            //other attributes are handled by parent class
            // maxCreditLimit is already 500000.0
        }

        public void creditCheck(double amount)
        {
            if (amount<=0)
            {
                Console.WriteLine("--Invalid Amount--");
            }
            else if (balance + amount > maxCreditLimit)
            {
                Console.WriteLine("--Limit Exceed--");
            }
            else 
            {
                balance += amount;
            }
        }
    }
}
