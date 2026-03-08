using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Employee_Management_System
{
    internal class Program
    {
        // ===============( HEADERS )===============

        static void globalHeader()
        {
            Console.WriteLine("================================================================================");
            Console.WriteLine(" ||                       EMPLOYEE MANAGEMENT CONSOLE                        ||");
            Console.WriteLine(" ||                     EMPLOYEE INFORMATION & SECURITY                      ||");
            Console.WriteLine("================================================================================");
            Console.WriteLine("  [ ACCESS: GRANTED ]         [ DATE: 1-1-2026 ]          [ SYSTEM: STABLE ]");
            Console.WriteLine(" --------------------------------------------------------------------------------");
        }

        static void signupHeader()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("                REGISTRATION              ");
            Console.WriteLine("==========================================");
        }

        static void signinHeader()
        {
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("               USER LOGIN                 ");
            Console.WriteLine("------------------------------------------");
        }

        static void adminDashboardHeader()
        {
            Console.WriteLine("\n================================================");
            Console.WriteLine("           A D M I N  D A S H B O A R D        ");
            Console.WriteLine("================================================");
        }

        static void employeeDashboardHeader()
        {
            Console.WriteLine("\n================================================");
            Console.WriteLine("        E M P L O Y E E  D A S H B O A R D     ");
            Console.WriteLine("================================================");
        }

        static void addEmployeeHeader()
        {
            Console.WriteLine("\n================================================");
            Console.WriteLine("               REGISTER NEW EMPLOYEE            ");
            Console.WriteLine("================================================");
        }

        static void searchEmployeeHeader()
        {
            Console.WriteLine("\n================================================");
            Console.WriteLine("               EMPLOYEE SEARCH PORTAL           ");
            Console.WriteLine("================================================");
        }

        static void deleteEmployeeHeader()
        {
            Console.WriteLine("================================================");
            Console.WriteLine("           REMOVE EMPLOYEE RECORD               ");
            Console.WriteLine("================================================");
            Console.WriteLine(" [WARNING]: This action cannot be undone!       ");
            Console.WriteLine("------------------------------------------------");
        }

        static void updateEmployeeHeader()
        {
            Console.WriteLine("\n================================================");
            Console.WriteLine("               UPDATE EMPLOYEE PORTAL           ");
            Console.WriteLine("================================================");
        }

        static void empPasswordUpdateHeader()
        {
            Console.WriteLine("\n================================================");
            Console.WriteLine("               CHANGE YOUR PASSWORD             ");
            Console.WriteLine("================================================");
        }

        // ===============( SHOW INTERFACE )===============

        static void showInterface(string mode)
        {
            Console.WriteLine("INSTRUCTIONS");
            Console.WriteLine("---------------------------------");

            if (mode == "ADMIN_SIGNUP")
            {
                Console.WriteLine("--> Name: 4-15 chars, No spaces.");
                Console.WriteLine("--> Name: First letter Capital.");
                Console.WriteLine("--> Name: No numbers or symbols.");
                Console.WriteLine("--> Pass: 4-8 characters.");
                Console.WriteLine("--> Pass: No spaces & 1 Num & 1 Spec Char & 1 Letter (Must)");
            }
            else if (mode == "ADMIN_LOGIN")
            {
                Console.WriteLine("--> Enter registered credentials.");
                Console.WriteLine("--> Maximum 3 attempts allowed.");
                Console.WriteLine("--> Do not leave fields empty.");
            }
            else if (mode == "EMP_LOGIN")
            {
                Console.WriteLine("--> Enter your assigned Employee ID.");
                Console.WriteLine("--> Maximum 3 attempts allowed.");
                Console.WriteLine("--> Password is case sensitive.");
            }
            else if (mode == "ADD_EMP")
            {
                Console.WriteLine("--> ID: Unique, No spaces, Not empty, 1-4 chars, must include a number.");
                Console.WriteLine("--> Name/Dept: Alphabets & spaces only.");
                Console.WriteLine("--> Salary: Positive numbers only.");
                Console.WriteLine("--> Pass: 4-8 characters.");
                Console.WriteLine("--> Pass: No spaces & 1 Num & 1 Spec Char & 1 Letter (Must)");
            }

            Console.WriteLine("---------------------------------");
        }

        // ===============( MENU FUNCTIONS )===============

        static int menu()
        {
            while (true)
            {
                Console.Clear();
                globalHeader();
                Console.WriteLine("1. SignUp ");
                Console.WriteLine("2. SignIn ");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.Write("Enter your Choice: ");
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice >= 1 && choice <= 3)
                    {
                        return choice;
                    }
                    else
                    {
                        Console.WriteLine("[ERROR]: Invalid Choice! Enter a number between 1-3.");
                    }
                }
                else
                {
                    Console.WriteLine("[ERROR]: Please enter a number (1-3)");
                }
            }
        }

        static int roleMenu()
        {
            while (true)
            {
                Console.Clear();
                globalHeader();
                Console.WriteLine("<<<-----SELECT YOUR ROLE----->>>");
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
                        Console.WriteLine("[ERROR]: Invalid Choice! Enter 1 or 2.");
                    }
                }
                else
                {
                    Console.WriteLine("[ERROR]: Please enter a number 1 or 2");
                }
            }
        }

        // ===============( SIGNUP )===============

        static void signup(string[] username, string[] password, ref int count)
        {
            string tempU;
            string tempPw;
            bool flag = false;

            // --- Username ---
            while (!flag)
            {
                Console.Clear();
                globalHeader();
                signupHeader();
                showInterface("ADMIN_SIGNUP");

                Console.Write("Enter Username: ");
                tempU = Console.ReadLine();
                if (usernameChecker(tempU, username, count))
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

            // --- Password ---
            flag = false;
            while (!flag)
            {
                Console.Clear();
                globalHeader();
                signupHeader();
                showInterface("ADMIN_SIGNUP");

                Console.Write("Enter Password: ");
                tempPw = Console.ReadLine();
                if (passwordChecker(tempPw))
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
            Console.WriteLine(">>> Sign up successful! <<<\n");
        }

        // ===============( VALIDATION: USERNAME )===============
        // Rules:
        //   - Cannot be empty
        //   - No spaces
        //   - Length between 4-15 characters
        //   - First letter must be capital
        //   - Letters only (no numbers, no special characters)
        //   - No duplicate usernames

        static bool usernameChecker(string u, string[] username, int count)
        {
            if (string.IsNullOrEmpty(u))
            {
                return false;
            }
            if (!noSpaces(u))
            {
                return false;
            }
            if (u.Length < 4 || u.Length > 15)
            {
                return false;
            }
            if (!isFirstCap(u))
            {
                return false;
            }
            if (hasNumbers(u))
            {
                return false;
            }
            if (hasSpecialCharacter(u))
            {
                return false;
            }
            if (isduplicate(username, u, count))
            {
                return false;
            }
            return true;
        }

        // ===============( VALIDATION: PASSWORD )===============
        // Rules:
        //   - Cannot be empty
        //   - No spaces
        //   - Length 4-8 characters
        //   - Must have at least one letter (upper OR lowercase)
        //   - Must have at least one number
        //   - Must have at least one special character

        static bool passwordChecker(string p)
        {
            if (string.IsNullOrEmpty(p))
            {
                return false;
            }
            if (!noSpaces(p))
            {
                return false;
            }
            if (p.Length < 4 || p.Length > 8)
            {
                return false;
            }
            if (!hasLetter(p))
            {
                return false;
            }
            if (!hasNumbers(p))
            {
                return false;
            }
            if (!hasSpecialCharacter(p))
            {
                return false;
            }
            return true;
        }

        // ===============( VALIDATION FUNCTIONS )===============

        static bool noSpaces(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    return false;
                }
            }
            return true;
        }

        // Checks uppercase and lowercase
        static bool hasLetter(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if ((text[i] >= 'A' && text[i] <= 'Z') || (text[i] >= 'a' && text[i] <= 'z'))
                {
                    return true;
                }
            }
            return false;
        }

        static bool isFirstCap(string text)
        {
            return text[0] >= 'A' && text[0] <= 'Z';
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

        // ===============( SIGNIN )===============

        static bool signin(string[] username, string[] password, int count)
        {
            int tries = 0;
            while (tries < 3)
            {
                Console.Clear();
                globalHeader();
                signinHeader();
                showInterface("ADMIN_LOGIN");

                Console.Write("Enter Username: ");
                string inputU = Console.ReadLine();
                Console.Write("Enter Password: ");
                string inputPw = Console.ReadLine();

                if (checkCredentials(username, password, inputU, inputPw, count))
                {
                    Console.WriteLine(" <<< User Verified >>> ");
                    Console.ReadLine();
                    return true;
                }
                else
                {
                    tries++;
                    Console.WriteLine($"[ERROR]: Incorrect Username or Password! Attempts remaining: {3 - tries}\n");
                }
            }
            Console.WriteLine("[WARNING]: Too many failed attempts.\n");
            return false;
        }

        // ===============( EMPLOYEE SIGNIN )===============

        static int empSignin(string[] empID, string[] empPassword, int empCount)
        {
            int tries = 0;
            while (tries < 3)
            {
                Console.Clear();
                globalHeader();
                signinHeader();
                showInterface("EMP_LOGIN");

                Console.Write("Enter your ID: ");
                string reqID = Console.ReadLine();
                Console.Write("Enter your Password: ");
                string reqPass = Console.ReadLine();

                int foundIndex = findEmployeeIndex(empID, empCount, reqID);
                if (foundIndex != -1 && reqPass == empPassword[foundIndex])
                {
                    Console.WriteLine(" <<< Employee Verified >>> ");
                    Console.ReadLine();
                    return foundIndex;
                }
                else
                {
                    tries++;
                    Console.WriteLine($"[ERROR]: Incorrect ID or Password! Attempts remaining: {3 - tries}\n");
                }
            }
            Console.WriteLine("[WARNING]: Too many failed attempts.\n");
            return -1;
        }

        static bool checkCredentials(string[] username, string[] password, string name, string pass, int count)
        {
            for (int i = 0; i < count; i++)
                if (username[i] == name && password[i] == pass) return true;
            return false;
        }

        // ===============( ADMIN DASHBOARD )===============

        static int AdminChoiceDashboard()
        {
            int choice = 0;
            while (true)
            {
                Console.Clear();
                globalHeader();
                adminDashboardHeader();

                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View Employee");
                Console.WriteLine("3. Search Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Update Employee");
                Console.WriteLine("6. Logout");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice >= 1 && choice <= 6)
                    {
                        return choice;
                    }
                    else
                    {
                        Console.WriteLine("[Error]: Invalid menu option selected. Please enter a valid choice (1-6).");
                    }
                }
                else
                {
                    Console.WriteLine("[Error]: Letters or symbols are not accepted. Please enter a number (1-6).");
                }
            }
        }

        // ===============( EMPLOYEE DASHBOARD )===============

        static int employee_choice_dashboard()
        {
            int choice = 0;
            while (true)
            {
                Console.Clear();
                globalHeader();
                employeeDashboardHeader();

                Console.WriteLine("\n1. View Digital ID Card");
                Console.WriteLine("2. View Company Roster");
                Console.WriteLine("3. Salary slip");
                Console.WriteLine("4. Update Security Password");
                Console.WriteLine("5. Logout");
                Console.Write("Enter Choice: ");

                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice >= 1 && choice <= 5)
                        return choice;
                    else
                        Console.WriteLine("[Error]: Invalid menu option selected. Please enter a valid choice (1-5).");
                }
                else
                {
                    Console.WriteLine("[Error]: Letters or symbols are not accepted. Please enter a number (1-5).");
                }
            }
        }

        // ===============( ADD EMPLOYEE )===============

        static void addEmployee(string[] empID, string[] empPassword, string[] empUsername,
                                string[] empDepartment, int[] empsalary, ref int empCount, int MAX_EMP)
        {
            Console.Clear();
            globalHeader();
            addEmployeeHeader();
            showInterface("ADD_EMP");

            if (empCount >= MAX_EMP)
            {
                Console.WriteLine("[ERROR]: Storage full !");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                return;
            }

            // --- Employee ID ---
            while (true)
            {
                Console.Write("Enter employee ID: ");
                string tempID = Console.ReadLine();
                if (validempID(tempID, empID, empCount))
                {
                    empID[empCount] = tempID;
                    break;
                }
                else
                {
                    Console.WriteLine("[ERROR]: Invalid ID. Rules: 1-4 chars, at least one number, no special chars, no spaces, no duplicates.");
                }
            }

            // --- Employee Password ---
            while (true)
            {
                Console.Write("Enter Employee Password: ");
                string tempPass = Console.ReadLine();
                if (passwordChecker(tempPass))
                {
                    empPassword[empCount] = tempPass;
                    break;
                }
                else
                {
                    Console.WriteLine("[ERROR]: Invalid password format.");
                }
            }

            // --- Employee Name ---
            while (true)
            {
                Console.Write("Enter employee Name: ");
                string tempName = Console.ReadLine();
                if (validName(tempName))
                {
                    empUsername[empCount] = tempName;
                    break;
                }
                else
                {
                    Console.WriteLine("[ERROR]: Invalid name. Letters and spaces only.\n");
                }
            }

            // --- Department Name ---
            while (true)
            {
                Console.Write("Enter Department Name: ");
                string tempDept = Console.ReadLine();
                if (validName(tempDept))
                {
                    empDepartment[empCount] = tempDept;
                    break;
                }
                else
                {
                    Console.WriteLine("[ERROR]: Invalid department. Letters and spaces only.");
                }
            }

            // --- Employee Salary ---
            while (true)
            {
                Console.Write("Enter Employee Salary: ");
                int tempSalary;
                if (int.TryParse(Console.ReadLine(), out tempSalary))
                {
                    if (tempSalary >= 0)
                    {
                        empsalary[empCount] = tempSalary;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("[ERROR]: Salary Cannot be Negative!");
                    }
                }
                else
                {
                    Console.WriteLine("[ERROR]: Please Enter a valid integer.");
                }
            }

            empCount++;
            Console.WriteLine(">>> Employee added successfully! <<<");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        // ===============( VALIDATION: EMPLOYEE ID )===============
        // Rules:
        //   - Cannot be empty
        //   - No spaces
        //   - Length 1-4 characters
        //   - Must contain at least one number
        //   - No special characters
        //   - No duplicate IDs

        static bool validempID(string tempID, string[] empID, int empCount)
        {
            if (string.IsNullOrEmpty(tempID))
            {
                return false;
            }
            if (!noSpaces(tempID))
            {
                return false;
            }
            if (tempID.Length < 1 || tempID.Length > 4)
            {
                return false;
            }
            if (!hasNumbers(tempID))
            {
                return false;
            }
            if (hasSpecialCharacter(tempID))
            {
                return false;
            }
            if (isduplicate(empID, tempID, empCount))
            {
                return false;
            }
            return true;
        }

        // ===============( VALIDATION: NAME / DEPARTMENT )===============

        static bool validName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            for (int i = 0; i < name.Length; i++)
            {
                if (!((name[i] >= 'a' && name[i] <= 'z') || (name[i] >= 'A' && name[i] <= 'Z')) && name[i] != ' ')
                {
                    return false;
                }
            }
            return true;
        }

        // ===============( STORAGE CHECK )===============

        static bool isStorageEmpty(int empCount)
        {
            if (empCount == 0)
            {
                Console.WriteLine("[ERROR]: No employee record found in system");
                Console.WriteLine(" Press any key to continue ");
                Console.ReadKey();
                return true;
            }
            return false;
        }

        // ===============( VIEW EMPLOYEES )===============

        static void ViewEmployee(string[] empID, string[] empUsername, string[] empDepartment,
                                 int[] empSalary, int empCount)
        {
            Console.Clear();
            globalHeader();
            if (isStorageEmpty(empCount)) return;

            Console.WriteLine();
            Console.WriteLine("========================================================================");
            Console.WriteLine("                    E M P L O Y E E   D A T A B A S E                   ");
            Console.WriteLine("========================================================================");
            Console.WriteLine($"Total employees: {empCount}\n");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine($"{"S.No",-8}{"ID",-12}{"Name",-20}{"Department",-20}{"Salary",-10}");
            Console.WriteLine("------------------------------------------------------------------------");

            for (int i = 0; i < empCount; i++)
                Console.WriteLine($"{i + 1,-8}{empID[i],-12}{empUsername[i],-20}{empDepartment[i],-20}{empSalary[i],-10}");

            Console.WriteLine("========================================================================");
            Console.WriteLine("Press Enter to return to Dashboard...");
            Console.ReadKey();
        }

        // ===============( SEARCH EMPLOYEE )===============

        static void searchEmployee(string[] empID, string[] empUsername, string[] empDepartment,
                                   int[] empsalary, int empCount)
        {
            Console.Clear();
            globalHeader();
            searchEmployeeHeader();
            if (isStorageEmpty(empCount))
            {
                return;
            }

            Console.Write("Enter Employee ID to search: ");
            string targetID = Console.ReadLine();
            int index = findEmployeeIndex(empID, empCount, targetID);

            if (index != -1)
            {
                Console.WriteLine("\n--- EMPLOYEE FOUND ---");
                Console.WriteLine("Name: " + empUsername[index]);
                Console.WriteLine("ID: " + empID[index]);
                Console.WriteLine("Dept: " + empDepartment[index]);
                Console.WriteLine("Salary: " + empsalary[index]);
                Console.WriteLine("----------------------");
            }
            else
            {
                Console.WriteLine("<<<ID NOT FOUND>>>");
            }
            Console.WriteLine(" Press any key to continue ");
            Console.ReadKey();
        }

        // ===============( DELETE EMPLOYEE )===============

        static void deleteEmployee(string[] empID, string[] empPassword, string[] empUsername,
                                   string[] empDepartment, int[] empsalary, ref int empCount)
        {
            Console.Clear();
            globalHeader();
            deleteEmployeeHeader();
            if (isStorageEmpty(empCount))
            {
                return;
            }

            Console.Write("Enter Employee ID to delete: ");
            string targetID = Console.ReadLine();
            int victim = findEmployeeIndex(empID, empCount, targetID);

            if (victim != -1)
            {
                Console.WriteLine($"\n[WARNING]: Deleting record for '{empUsername[victim]}'...");

                for (int j = victim; j < empCount - 1; j++)
                {
                    empID[j] = empID[j + 1];
                    empUsername[j] = empUsername[j + 1];
                    empDepartment[j] = empDepartment[j + 1];
                    empsalary[j] = empsalary[j + 1];
                    empPassword[j] = empPassword[j + 1];
                }

                empID[empCount - 1] = null;
                empPassword[empCount - 1] = null;
                empUsername[empCount - 1] = null;
                empDepartment[empCount - 1] = null;
                empsalary[empCount - 1] = 0;

                empCount--;
                Console.WriteLine(">>> Record deleted successfully. <<<");
            }
            else
            {
                Console.WriteLine("<<<ID NOT FOUND>>>");
            }
            Console.WriteLine(" Press any key to continue ");
            Console.ReadKey();
        }

        // ===============( UPDATE EMPLOYEE )===============

        static void updateEmployee(string[] empID, string[] empUsername, string[] empPassword,
                                   string[] empDepartment, int[] empsalary, int empCount)
        {
            Console.Clear();
            globalHeader();
            updateEmployeeHeader();
            if (isStorageEmpty(empCount))
            {
                return;
            }
            Console.Write("Enter Employee ID to Update: ");
            string targetID = Console.ReadLine();
            int index = findEmployeeIndex(empID, empCount, targetID);

            if (index != -1)
            {
                Console.WriteLine($"\n>>> UPDATING RECORD FOR ID: {empID[index]} <<<");
                Console.WriteLine($"Current Name:   {empUsername[index]}");
                Console.WriteLine($"Current Dept:   {empDepartment[index]}");
                Console.WriteLine($"Current Salary: {empsalary[index]}");
                Console.WriteLine("------------------------------------------------");

                // --- Update Name ---
                while (true)
                {
                    Console.Write("Enter New Name: ");
                    string tempName = Console.ReadLine();
                    if (validName(tempName))
                    {
                        empUsername[index] = tempName;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("[ERROR]: Invalid name. Letters and spaces only.");
                    }
                }

                // --- Update Password ---
                while (true)
                {
                    Console.Write("Enter employee Password: ");
                    string tempPass = Console.ReadLine();
                    if (passwordChecker(tempPass))
                    {
                        empPassword[index] = tempPass;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("[ERROR]: Invalid password.");
                    }
                }

                // --- Update Department ---
                while (true)
                {
                    Console.Write("Enter Department Name: ");
                    string tempDept = Console.ReadLine();
                    if (validName(tempDept))
                    {
                        empDepartment[index] = tempDept;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("[ERROR]: Invalid department.");
                    }
                }

                // --- Update Salary ---
                while (true)
                {
                    Console.Write("Enter Employee Salary: ");
                    int tempSalary;
                    if (int.TryParse(Console.ReadLine(), out tempSalary))
                    {
                        if (!(tempSalary < 0))
                        {
                            empsalary[index] = tempSalary;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("[ERROR]: Salary Cannot be Negative!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("[ERROR]: Please Enter a Valid Integer.");
                    }
                }

                Console.WriteLine("Employee Profile Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Employee ID not found");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        // ===============( FILE HANDLING: LOAD ADMINS )===============

        static void LoadAdminsFromFile(string[] username, string[] password, ref int count)
        {
            string path = "admins.txt";
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lines[i])) continue;
                    string[] parts = lines[i].Split(',');
                    if (parts.Length < 2) continue;
                    username[count] = parts[0];
                    password[count] = parts[1];
                    count++;
                }
            }
        }

        // ===============( FILE HANDLING: SAVE ADMINS )===============

        static void SaveAdminsToFile(string[] username, string[] password, int count)
        {
            string path = "admins.txt";
            string[] lines = new string[count];
            for (int i = 0; i < count; i++)
            {
                lines[i] = username[i] + "," + password[i];
            }
            File.WriteAllLines(path, lines);
        }

        // ===============( FILE HANDLING: LOAD EMPLOYEES )===============

        static void LoadEmployeesFromFile(string[] empID, string[] empPassword, string[] empUsername,
                                          string[] empDepartment, int[] empsalary, ref int empCount)
        {
            string path = "employees.txt";
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lines[i])) continue;
                    string[] parts = lines[i].Split(',');
                    if (parts.Length < 5) continue;
                    empID[empCount] = parts[0];
                    empPassword[empCount] = parts[1];
                    empUsername[empCount] = parts[2];
                    empDepartment[empCount] = parts[3];
                    int salary;
                    int.TryParse(parts[4], out salary);
                    empsalary[empCount] = salary;
                    empCount++;
                }
            }
        }

        // ===============( FILE HANDLING: SAVE EMPLOYEES )===============

        static void SaveEmployeesToFile(string[] empID, string[] empPassword, string[] empUsername,
                                        string[] empDepartment, int[] empsalary, int empCount)
        {
            string path = "employees.txt";
            string[] lines = new string[empCount];
            for (int i = 0; i < empCount; i++)
            {
                lines[i] = empID[i] + "," + empPassword[i] + "," + empUsername[i] + ","
                          + empDepartment[i] + "," + empsalary[i];
            }
            File.WriteAllLines(path, lines);
        }


        // ===============( EMPLOYEE FEATURES )===============

        static void displayIDCard(string[] empName, string[] empID, string[] empDepartment, int index)
        {
            Console.Clear();
            globalHeader();
            Console.WriteLine();
            Console.WriteLine("\n\t+---------------------------------------+");
            Console.WriteLine("\t|            OFFICIAL ID CARD           |");
            Console.WriteLine("\t+---------------------------------------+");
            Console.WriteLine("\t| NAME: " + empName[index].PadRight(32) + "|");
            Console.WriteLine("\t| ID:   " + empID[index].PadRight(32) + "|");
            Console.WriteLine("\t| DEPT: " + empDepartment[index].PadRight(32) + "|");
            Console.WriteLine("\t| STATUS: ACTIVE                        |");
            Console.WriteLine("\t+---------------------------------------+");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        static void displayCompanyRoster(string[] empName, string[] empDepartment, int empCount)
        {
            Console.Clear();
            globalHeader();
            Console.WriteLine();
            Console.WriteLine("====================================================================");
            Console.WriteLine("                C O M P A N Y   D I R E C T O R Y                  ");
            Console.WriteLine("====================================================================");
            Console.WriteLine($"{"S.No",-10}{"Employee Name",-22}{"Department",-20}{"Status",-15}");
            Console.WriteLine("--------------------------------------------------------------------");

            for (int i = 0; i < empCount; i++)
            {
                string status = (i % 2 == 0) ? "Available" : "In Meeting";
                Console.WriteLine($"{i + 1,-10}{empName[i],-22}{empDepartment[i],-20}{status,-15}");
            }

            Console.WriteLine("====================================================================");
            Console.WriteLine("Total Staff Members: " + empCount);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        static void salaryCalculator(string[] empName, string[] empID, int[] empSalary, int index)
        {
            Console.Clear();
            globalHeader();
            Console.WriteLine();

            double tax = empSalary[index] * 0.07;
            double netPay = empSalary[index] - tax;

            Console.WriteLine("\n====================================================");
            Console.WriteLine("              OFFICIAL SALARY RECEIPT               ");
            Console.WriteLine("====================================================");
            Console.WriteLine(" Employee Name : " + empName[index]);
            Console.WriteLine(" Employee ID   : " + empID[index]);
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($" {"DESCRIPTION",-29} | AMOUNT (PKR)");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($" {"Monthly Gross Salary",-29} | {empSalary[index]}");
            Console.WriteLine($" {"Income Tax (7%)",-29} | {tax}");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($" {"NET TAKE-HOME PAY",-29} | {netPay}");
            Console.WriteLine("====================================================");
            Console.WriteLine(" Status: PROCESSED SECURELY");
            Console.WriteLine("====================================================");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        static void UpdatePassword(string[] empID, string[] empPassword, string[] empName,
                                   string[] empDepartment, int[] empsalary, int empCount, int index)
        {
            Console.Clear();
            globalHeader();
            empPasswordUpdateHeader();
            Console.WriteLine();

            while (true)
            {
                string newPass;
                Console.Write("Enter new Password: ");
                newPass = Console.ReadLine();
                if (passwordChecker(newPass))
                {
                    empPassword[index] = newPass;
                    break;
                }
                else
                {
                    Console.WriteLine("\n[ERROR]: Password must be 4-8 chars with a letter, number & special char.");
                }
            }

            Console.WriteLine("\n[SUCCESS]: Password updated securely.");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        // ===============( FIND EMPLOYEE INDEX )===============

        static int findEmployeeIndex(string[] empID, int empCount, string targetID)
        {
            for (int i = 0; i < empCount; i++)
                if (empID[i] == targetID) return i;
            return -1;
        }
        static void Main(string[] args)
        {

            const int MAX_ADMIN = 50;
            string[] adminUsername = new string[MAX_ADMIN];
            string[] adminPassword = new string[MAX_ADMIN];
            int adminCount = 0;

            // Load persisted admin accounts from file
            LoadAdminsFromFile(adminUsername, adminPassword, ref adminCount);

            const int MAX_EMP = 50;
            string[] empUsername = new string[MAX_EMP];
            string[] empPassword = new string[MAX_EMP];
            string[] empID = new string[MAX_EMP];
            string[] empDepartment = new string[MAX_EMP];
            int[] empsalary = new int[MAX_EMP];
            int empCount = 0;

            // Load persisted employee records from file
            LoadEmployeesFromFile(empID, empPassword, empUsername, empDepartment, empsalary, ref empCount);


            int option = 0;
            while (option != 3)
            {
                option = menu();

                // ===== SIGNUP =====
                if (option == 1)
                {
                    int roleSelection = roleMenu();
                    if (roleSelection == 1)
                    {
                        if (adminCount >= MAX_ADMIN)
                            Console.WriteLine("[ERROR]: Admin storage full. No more admins can be added.\n");
                        else
                            signup(adminUsername, adminPassword, ref adminCount);
                        // Persist new admin to file
                        SaveAdminsToFile(adminUsername, adminPassword, adminCount);
                    }
                    else if (roleSelection == 2)
                    {
                        if (empCount >= MAX_EMP)
                            Console.WriteLine("[ERROR]: Employee storage full.\n");
                        else
                            signup(empUsername, empPassword, ref empCount);
                        // Persist new employee login to file
                        SaveEmployeesToFile(empID, empPassword, empUsername, empDepartment, empsalary, empCount);

                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }

                // ===== SIGNIN =====
                else if (option == 2)
                {
                    int roleSelection = roleMenu();
                    if (roleSelection == 1)
                    {
                        if (adminCount == 0)
                        {
                            Console.WriteLine("[ERROR]: No admin accounts exist yet. Please sign up first.\n");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        else if (signin(adminUsername, adminPassword, adminCount))
                        {
                            Console.WriteLine("--- ADMIN ACCESS GRANTED ---\n");
                            int action = 0;
                            while (action != 6)
                            {
                                action = AdminChoiceDashboard();
                                if (action == 1)
                                {
                                    addEmployee(empID, empPassword, empUsername, empDepartment, empsalary, ref empCount, MAX_EMP);
                                    // Persist after add
                                    SaveEmployeesToFile(empID, empPassword, empUsername, empDepartment, empsalary, empCount);
                                }
                                else if (action == 2)
                                {
                                    ViewEmployee(empID, empUsername, empDepartment, empsalary, empCount);
                                }
                                else if (action == 3)
                                {
                                    searchEmployee(empID, empUsername, empDepartment, empsalary, empCount);
                                }
                                else if (action == 4)
                                {
                                    deleteEmployee(empID, empPassword, empUsername, empDepartment, empsalary, ref empCount);
                                    // Persist after delete
                                    SaveEmployeesToFile(empID, empPassword, empUsername, empDepartment, empsalary, empCount);
                                }
                                else if (action == 5)
                                {
                                    updateEmployee(empID, empUsername, empPassword, empDepartment, empsalary, empCount);
                                    // Persist after update
                                    SaveEmployeesToFile(empID, empPassword, empUsername, empDepartment, empsalary, empCount);
                                }
                                else if (action == 6)
                                {
                                    Console.WriteLine("Logging out...\n");
                                }
                            }
                        }
                    }
                    else if (roleSelection == 2)
                    {
                        if (empCount == 0)
                        {
                            Console.WriteLine("[ERROR]: No employee accounts exist yet. Please sign up first.\n");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            // Returns actual matched index so employee features show correct data
                            int empIndex = empSignin(empID, empPassword, empCount);
                            if (empIndex != -1)
                            {
                                int action = 0;
                                while (action != 5)
                                {
                                    action = employee_choice_dashboard();
                                    if (action == 1)
                                    {
                                        displayIDCard(empUsername, empID, empDepartment, empIndex);
                                    }
                                    else if (action == 2)
                                    {
                                        displayCompanyRoster(empUsername, empDepartment, empCount);
                                    }
                                    else if (action == 3)
                                    {
                                        salaryCalculator(empUsername, empID, empsalary, empIndex);
                                    }
                                    else if (action == 4)
                                    {
                                        UpdatePassword(empID, empPassword, empUsername, empDepartment, empsalary, empCount, empIndex);
                                    }
                                    else if (action == 5)
                                    {
                                        Console.WriteLine("Logging out...\n");
                                    }
                                }
                            }
                        }
                    }
                }

                // ===== EXIT =====
                else if (option == 3)
                {
                    Console.WriteLine("Exiting system...");
                }
            }
        }
    }
}
