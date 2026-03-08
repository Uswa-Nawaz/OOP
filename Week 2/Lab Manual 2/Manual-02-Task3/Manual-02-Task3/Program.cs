using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_02_Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM(1000); // initial balance
            atm.deposited(500);
            atm.withdraw(200);
            atm.CheckBalance();
            atm.Showhistory();
        }
    }
}
