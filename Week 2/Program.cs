using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace LoginSystem
{
    internal class Program
    {
        //---------------( menu function )----------------
        static int menu()
        {
            while (true)
            {
                Console.WriteLine("1. SignUp ");
                Console.WriteLine("2. SignIn ");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.Write("Enter your Choice: ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice == 1 || choice == 2 || choice == 3)
                    {
                        return choice;
                    }
                    else
                    {
                        Console.WriteLine("[ERROR]: Invalid Choice! Enter no between (1-3).");
                    }
                }
                else
                {
                    Console.WriteLine("[ERROR]: Please enter the no (1-3)");
                }
            }
        }

        static int roleMenu()
        {
            while (true)
            {
                Console.WriteLine("<<< YOUR ROLE >>>");
                Console.WriteLine("1. Admin ");
                Console.WriteLine("2. Employee ");
                Console.WriteLine();
                Console.Write("Enter Your Role: ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice == 1 || choice == 2)
                    {
                        return choice;
                    }
                    else
                    {
                        Console.WriteLine("[ERROR]: Invalid Choice! Enter no. 1 or 2.");
                    }
                }
                else
                {
                    Console.WriteLine("[ERROR]: Please enter the number 1 or 2");
                }
            }

        }

        //---------------( signup function )----------------
        static void signup(string[] username, string[] password, ref int count)
        {
            string tempU;
            string tempPw;
            bool flag = false;
            while (flag == false)
            {
                Console.Write("Enter Username: ");
                tempU = Console.ReadLine();
                if (usernameChecker(tempU, username, count) == true)
                {
                    username[count] = tempU;
                    flag = true;
                }
                else
                {
                    Console.WriteLine("[ERROR]: Invalid Format.");
                    Console.WriteLine($"You entered {tempU}. Please try again...");
                }
            }
            flag = false;
            while (flag == false)
            {
                Console.Write("Enter Password: ");
                tempPw = Console.ReadLine();
                if (passwordChecker(tempPw) == true)
                {
                    password[count] = tempPw;
                    flag = true;
                }
                else
                {
                    Console.WriteLine("[ERROR]: Invalid Format.");
                    Console.WriteLine($"You entered {tempPw}. Please try again...");
                }
            }
            count++;
        }
        //-----------------------------------|
        static bool usernameChecker(string u, string[] username, int count)
        {
            if (containSpaces(u) == false) //if no space rule is false
            {
                return false; // username is invalid
            }
            if (!(u.Length >= 4 && u.Length <= 15)) //check if the username is 4-15 char long
            {
                return false;
            }
            if (isFirstCap(u) == false) //if 1st letter capital rule is false
            {
                return false;
            }
            if (hasNumbers(u) == true)
            {
                return false;
            }
            if (hasSpecialCharacter(u) == true)
            {
                return false;
            }
            if (isduplicate(username, u, count) == true)
            {
                return false;
            }
            return true;    //passed all the if checkpoints, means now the username is valid
        }
        static bool passwordChecker(string p)
        {
            if (containSpaces(p) == false) //if no space rule is false
            {
                return false; //  is invalid
            }
            if (!(p.Length >= 4 && p.Length <= 8))
            {
                return false;
            }
            if (hasCapital(p) == false)
            {
                return false;
            }
            if (hasNumbers(p) == false)
            {
                return false;
            }
            if (hasSpecialCharacter(p) == false)
            {
                return false;
            }
            return true;    //passed all the if checkpoints, means now the password is valid
        }
        //----------------------------------------------|
        //---------------( Validations )----------------|
        //----------------------------------------------|

        //Checks that the username and password are not empty and do not have spaces
        static bool containSpaces(string text)
        {
            if (text == null || text.Length == 0)
            {
                return false; //It is left empty
            }
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    return false; //found a space
                }
            }
            return true; //not left empty and has no space (required)
        }
        // for passwords, it checks if it has a capital letter or not
        static bool hasCapital(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= 'A' && text[i] <= 'Z')
                {
                    return true;
                }
            }
            return false;
        }
        // for username, it checks if its first letter is capital
        static bool isFirstCap(string text)
        {
            if (text[0] >= 'A' && text[0] <= 'Z')
            {
                return true;
            }
            return false;
        }
        static bool hasNumbers(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= '0' && text[i] <= '9')
                {
                    return true;
                }
            }
            return false;
        }
        static bool hasSpecialCharacter(string text)
        {
            string special = "!@#$%^&*()-_=+[{]};:,.<>/?";
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < special.Length; j++)
                {
                    if (text[i] == special[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static bool isduplicate(string[] existingUsers, string currentUser, int currentCount)
        {
            for (int i = 0; i < currentCount; i++)
            {
                if (existingUsers[i] == currentUser)
                {
                    return true;
                }
            }
            return false;
        }
        static void signin(string[] username, string[] password, int count)
        {
            string inputU;
            string inputPw;
            int tries = 0;
            while(tries<3)
            {
                Console.Write("Enter Username: ");
                inputU = Console.ReadLine();
                Console.Write("Enter Password: ");
                inputPw = Console.ReadLine();
                if(checkCredentials(username, password, inputU, inputPw, count)==true)
                {
                    Console.WriteLine("User Verified");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect Username or Password !!");
                    tries++;
                    Console.WriteLine($"(Attempts remaining: {3 - tries} )");
                }
            }
        }
        static bool checkCredentials(string[] username, string[] password, string name, string pass, int count)
        {
            for(int i=0; i<count; i++)
            {
                if (username[i]==name && password[i] ==pass)
                {
                    return true;
                }
            }
            return false;
        }
        //---------------( file handling )----------------|
        static void saveUserData(string path, string name, string pass)
        {
            StreamWriter fileVariable = new StreamWriter(path, true);
            fileVariable.WriteLine(name + "," + pass);
            fileVariable.Close();
        }
        static void readData(string path, string[] names, string[] passwords, ref int count)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string[] parts = record.Split(',');
                    names[count] = parts[0];
                    passwords[count] = parts[1];
                    count++; // This updates adminCount or empCount in Main

                    if (count >= 5) { break; }
                }
                fileVariable.Close();
            }
        }
        static void Main(string[] args)
        {
            //array to store admin info
            string[] adminUsername = new string[5];
            string[] adminPassword = new string[5];
            //arrays to store employee info
            string[] empUsername = new string[5];
            string[] empPassword = new string[5];
            int adminCount = 0;
            int empCount = 0;
            //file handling 
            string adminPath = "admins.txt";
            string empPath = "employees.txt";
            readData(adminPath, adminUsername, adminPassword, ref adminCount);
            readData(empPath, empUsername, empPassword, ref empCount);
            int option = 0;
            while (option != 3)
            {
                option = menu();
                if (option == 1)
                {
                    int roleSelection = roleMenu();
                    if (roleSelection == 1) //ADMIN SIGNUP
                    {
                        if (adminCount >= 5)
                        {
                            Console.WriteLine("No more space available");
                        }
                        else
                        {
                            signup(adminUsername, adminPassword, ref adminCount);
                            // Save to admin file
                            saveUserData("admins.txt", adminUsername[adminCount - 1], adminPassword[adminCount - 1]);
                        }
                    }
                    else //EMPLOYEE SIGNUP
                    {
                        if (empCount >= 5)
                        {
                            Console.WriteLine("No more space available");
                        }
                        else
                        {
                            signup(empUsername, empPassword, ref empCount);
                            // Save to employee file
                            saveUserData(empPath, empUsername[empCount - 1], empPassword[empCount - 1]);
                        }
                    }
                }
                else if (option == 2)
                {
                    int roleSelection = roleMenu();
                    if (roleSelection == 1)
                    {
                        signin(adminUsername, adminPassword, adminCount);
                    }
                    else
                    {
                      
                        signin(empUsername, empPassword, empCount);
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }
}
