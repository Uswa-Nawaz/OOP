using Challenge_02.BL;
using Challenge_02.DL;
using Challenge_02.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mainOption = 0;

            while (mainOption != 3)
            {
                Console.Clear();
                mainOption = MUserUI.menu(); // STATE 1: LOGIN MENU

                if (mainOption == 1) // SIGN IN
                {
                    MUserBL temp = MUserUI.takeInputWithoutRole();
                    MUserBL validUser = MUserDL.SignIn(temp);

                    if (validUser != null)
                    {
                        if (validUser.isAdmin())
                        {
                            // STATE 2: ADMIN MENU
                            AdminMenuLogic();
                        }
                        else
                        {
                            // STATE 3: CUSTOMER MENU
                            CustomerMenuLogic();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Credentials! Press any key to try again...");
                        Console.ReadKey();
                    }
                }
                else if (mainOption == 2) // SIGN UP
                {
                    MUserBL newUser = MUserUI.takeInputFromConsole();
                    MUserDL.addUserIntoList(newUser);
                    Console.WriteLine("Registration Successful! Press any key...");
                    Console.ReadKey();
                }
            }
        }

        // Logic for Admin Sub-Loop
        static void AdminMenuLogic()
        {
            int adminChoice = 0;
            while (adminChoice != 6)
            {
                Console.Clear();
                adminChoice = AdminUI.adminMenu();
                if (adminChoice == 1)
                {
                    ProductBL p = AdminUI.takeProductInput();
                    ProductDL.addproductTolist(p);
                }
                else if (adminChoice == 2) { CustomerUI.viewAllProducts(); }
                else if (adminChoice == 3) { AdminUI.displayHighestPrice(); Console.ReadKey(); }
                else if (adminChoice == 4) { AdminUI.displayTotalTax(); Console.ReadKey(); }
                else if (adminChoice == 5) { AdminUI.displayLowStock(); Console.ReadKey(); }
            }
        }

        // Logic for Customer Sub-Loop
        static void CustomerMenuLogic()
        {
            Customer currentCustomer = new Customer(); // Fresh basket for this session
            int custChoice = 0;
            while (custChoice != 4)
            {
                Console.Clear();
                custChoice = CustomerUI.customerMenu();
                if (custChoice == 1) { CustomerUI.viewAllProducts(); }
                else if (custChoice == 2) { CustomerUI.buyProduct(currentCustomer); Console.ReadKey(); }
                else if (custChoice == 3) { CustomerUI.generateInvoice(currentCustomer); Console.ReadKey(); }
            }
        }
    }
}
