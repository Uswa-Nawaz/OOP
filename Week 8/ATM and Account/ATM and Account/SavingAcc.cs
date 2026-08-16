using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_and_Account
{
    internal class SavingAcc : Account
    {
        private double profitRate;
        private double taxRate;

        public SavingAcc(double profitRate,double taxRate,string title, int id, double balance) : base(title, id, balance)
        {
            this.profitRate = profitRate;
            this.taxRate = taxRate;
            //other attributes are handled by parent class
        }

        public double getProfitRate()
        {
            return profitRate;
        }

        public void setProfitRate(double profitRate)
        {
            this.profitRate= profitRate;
        }
        public double getTaxRate() 
        {
            return taxRate;
        }

        public void setTaxRate(double taxRate)
        {
            this.taxRate= taxRate;
        }

        public double calculateProfit()
        {
            double profit = balance * profitRate / 100;
            balance += profit;
            return balance;
        }

        public double Savingdebit(double amount)
        {
            double tax = amount * taxRate / 100;
            balance -= (amount + tax);
            return balance;
        }



    }
}
