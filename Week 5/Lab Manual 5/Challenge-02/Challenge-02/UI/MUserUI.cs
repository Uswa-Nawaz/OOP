using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_02.BL;
using Challenge_02.DL;

namespace Challenge_02.UI
{
    internal class MUserUI
    {
        // Menu 
        public static int menu()
        {
            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. SignUp");
            Console.WriteLine("3. Exit");
            Console.Write("Enter option: ");
            return int.Parse(Console.ReadLine());
        }

        // Input for SignUp
        public static MUserBL takeInputFromConsole()
        {
            Console.Write("Enter Username: ");
            string name = Console.ReadLine();
            Console.Write("Enter Password: ");
            string pass = Console.ReadLine();
            Console.Write("Enter Role (Admin/Customer): ");
            string role = Console.ReadLine();

            return new MUserBL(name, pass, role);
        }

        // Input for SignIn
        public static MUserBL takeInputWithoutRole()
        {
            Console.Write("Enter Username: ");
            string name = Console.ReadLine();
            Console.Write("Enter Password: ");
            string pass = Console.ReadLine();

            return new MUserBL(name, pass);
        }
    }
}