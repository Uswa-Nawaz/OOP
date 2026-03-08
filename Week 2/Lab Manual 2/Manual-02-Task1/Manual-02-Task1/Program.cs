using Manual_02_Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_02_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Transaction t1 = new Transaction();
            t1.inputdetails();
            t1.displaydetails();
            Transaction t2 = new Transaction(t1);
            t2.displaydetails();
        }
    }
}
