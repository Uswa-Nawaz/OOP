using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_03.UI
{
    internal class MenuUI
    {
        // Displays the application header
        public static void header()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("*                     UAMS                       *");
            Console.WriteLine("**************************************************");
        }

        // Clears the console after a key press
        public static void clearScreen()
        {
            Console.WriteLine("Press any key to Continue..");
            Console.ReadKey();
            Console.Clear();
        }

        // Displays the main menu and returns the selected option
        public static int Menu()
        {
            header();
            int option;
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Generate Merit");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students of a Specific Program");
            Console.WriteLine("6. Register Subjects for a Specific Student");
            Console.WriteLine("7. Calculate Fees for all Registered Students");
            Console.WriteLine("8. Exit");
            Console.Write("Enter Option: ");

            // Validating input to prevent crashes on non-numeric entry
            if (int.TryParse(Console.ReadLine(), out option))
            {
                return option;
            }
            return 0; // Return an invalid option if parsing fails
        }
    }
}
