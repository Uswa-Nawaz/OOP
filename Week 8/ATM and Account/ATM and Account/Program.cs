using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_and_Account
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******** ATM System ********");

            Console.WriteLine("1. Student Account");
            Console.WriteLine("2. Saving Account");
            Console.WriteLine("3. Salary Account");

            int choice;
            while (true)
            {
                Console.WriteLine("Enter your choice:");

                if (int.TryParse(Console.ReadLine(),out choice))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid choice(1-3)!!");
                }
            }

            if (choice == 1)
            {
                Console.Write("Enter account title: ");
                string title = Console.ReadLine();

                int id;
                while (true)
                {
                    Console.Write("Enter Account ID: ");
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid id number!!\n");
                    }
                }

                double balance;
                while (true)
                {
                    Console.Write("Enter Balance: ");
                    if (double.TryParse(Console.ReadLine(), out balance))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter correct balance amount!!\n");
                    }
                }

                StudentAcc stdAcc = new StudentAcc(title, id, balance);

                double amount;
                while (true)
                {
                    Console.Write("Enter amount: ");
                    if (double.TryParse(Console.ReadLine(), out amount))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter valid amount!!\n");
                    }
                }

                stdAcc.creditCheck(amount);
                stdAcc.getBalance();
                Console.WriteLine($"Updated Balance: {stdAcc.getBalance()}");
            }

            else if (choice == 2)
            {
                Console.Write("Enter account title: ");
                string title = Console.ReadLine();

                int id;
                while (true)
                {
                    Console.Write("Enter Account ID: ");
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid id number!!\n");
                    }
                }

                double balance;
                while (true)
                {
                    Console.Write("Enter Balance: ");
                    if (double.TryParse(Console.ReadLine(), out balance))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter correct balance amount!!\n");
                    }
                }

                double profitRate;
                while (true)
                {
                    Console.Write("Enter profit rate: ");
                    if (double.TryParse(Console.ReadLine(), out profitRate))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter correct profit rate amount!!\n");
                    }
                }

                double taxRate;
                while (true)
                {
                    Console.Write("Enter rate rate: ");
                    if (double.TryParse(Console.ReadLine(), out taxRate))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter correct tax rate amount!!\n");
                    }
                }

                SavingAcc save = new SavingAcc(profitRate,taxRate,title,id,balance);

                Console.WriteLine("\n\n1. Calculate Profit");
                Console.WriteLine("2. Withdraw");

                int subchoice;
                while (true)
                {
                    Console.WriteLine("Enter your choice:");

                    if (int.TryParse(Console.ReadLine(), out subchoice))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid choice(1,2)!!");
                    }
                }

                if (subchoice == 1)
                {
                    save.calculateProfit();
                }
                else if (subchoice == 2)
                {
                    double amount;
                    while (true)
                    {
                        Console.Write("Enter amount: ");
                        if (double.TryParse(Console.ReadLine(), out amount))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Enter valid amount!!\n");
                        }
                    }

                    save.Savingdebit(amount);
                }

                Console.WriteLine($"Balance : {save.getBalance()}");

            }

            else if (choice == 3)
            {
                Console.Write("Enter account title: ");
                string title = Console.ReadLine();

                int id;
                while (true)
                {
                    Console.Write("Enter Account ID: ");
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid id number!!\n");
                    }
                }

                double balance;
                while (true)
                {
                    Console.Write("Enter Balance: ");
                    if (double.TryParse(Console.ReadLine(), out balance))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter correct balance amount!!\n");
                    }
                }

                double overdraftLimit;
                while (true)
                {
                    Console.Write("Enter over draft limit: ");
                    if (double.TryParse(Console.ReadLine(), out overdraftLimit))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter correct over draft limit!!\n");
                    }
                }

                SalaryAcc sal = new SalaryAcc(overdraftLimit,title,id,balance);

                double withdraw;
                while (true)
                {
                    Console.Write("Enter withdrawal amount: ");
                    if (double.TryParse(Console.ReadLine(), out withdraw))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter correct withdraw amount!!\n");
                    }
                }

                sal.Salarydebit(withdraw);

                Console.WriteLine($"Balance: {sal.getBalance()}");
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }
        }
    }
}
