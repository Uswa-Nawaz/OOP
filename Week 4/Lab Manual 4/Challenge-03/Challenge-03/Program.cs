using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_03
{
    internal class Program
    {

        // -------------------- search book by title --------------------
        static int searchBookByTitle(Book[] books, int totalBooks, string search)
        {
            for (int i = 0; i < totalBooks; i++)
            {
                if (books[i].searchTitle(search))
                    return i;
            }
            return -1;
        }
        // -------------------- search book by ISBN --------------------
        static int searchBookByISBN(Book[] books, int totalBooks, string isbn)
        {
            for (int i = 0; i < totalBooks; i++)
            {
                if (books[i].searchISBN(isbn))
                    return i;
            }
            return -1;
        }
        // -------------------- search member by ID --------------------
        static int searchMemberByID(Member[] members, int totalMembers, int id)
        {
            for (int i = 0; i < totalMembers; i++)
            {
                if (members[i].memberID == id)
                    return i;
            }
            return -1;
        }
        // -------------------- search member by name --------------------
        static int searchMemberByName(Member[] members, int totalMembers, string name)
        {
            for (int i = 0; i < totalMembers; i++)
            {
                if (members[i].searchByName(name))
                    return i;
            }
            return -1;
        }
        // -------------------- print divider --------------------
        static void printLine()
        {
            Console.WriteLine("  ========================================");
        }

        // -------------------- print header --------------------
        static void printHeader(string text)
        {
            printLine();
            Console.WriteLine($"       <<< {text} >>>");
            printLine();
        }
        static void Main(string[] args)
        {

            // Bookstore
            Book[] books = new Book[100];
            int totalBooks = 0;

            // Members and Customers
            Member[] members = new Member[200];
            int totalMembers = 0;

            // Bookstore Stats
            int totalSales = 0;
            int totalMembershipFees = 0;
            int memberCount = 0;

            int choice = 0;
            Console.WriteLine(" WELCOME TO THE BOOKSTORE SYSTEM");
            while (true)
            {
                Console.WriteLine("      <<< MENU >>>      ");
                Console.WriteLine("------------------------");
                Console.WriteLine("1. Add a Book ");
                Console.WriteLine("2. Search for a Book by Title ");
                Console.WriteLine("3. Search for a Book by ISBN ");
                Console.WriteLine("4. Update Stock of a Book ");
                Console.WriteLine("5. Add a member ");
                Console.WriteLine("6. Search for member by ID ");
                Console.WriteLine("7. Update Member Information ");
                Console.WriteLine("8. Purchase a Book ");
                Console.WriteLine("9. Display Total Sales and Membership Stats");
                Console.WriteLine("10. Exit ");
                Console.Write("  Enter Your Choice: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    // ==================================================
                    //  1. ADD A BOOK
                    // ==================================================
                    if (choice == 1)
                    {
                        printHeader("ADD A BOOK");
                        if (totalBooks >= 100)
                        {
                            Console.WriteLine("  Inventory is full! Cannot add more books.");
                            continue;
                        }
                        //collecting data + validating
                        Console.Write("  Enter Book Title: ");
                        string title = Console.ReadLine();

                        Console.Write("  Enter Publisher: ");
                        string publisher = Console.ReadLine();

                        Console.Write("  Enter ISBN: ");
                        string isbn = Console.ReadLine();

                        // Check duplicate ISBN
                        if (searchBookByISBN(books, totalBooks, isbn) != -1)
                        {
                            Console.WriteLine("  Error: A book with this ISBN already exists!");
                            continue;
                        }
                        Console.Write("  Enter Price ($): ");
                        int price;
                        while (!int.TryParse(Console.ReadLine(), out price) || price < 0)
                        {
                            Console.Write("  Invalid! Enter Price ($): ");
                        }
                        Console.Write("  Enter Stock: ");
                        int stock;
                        while (!int.TryParse(Console.ReadLine(), out stock) || stock < 0)
                        {
                            Console.Write("  Invalid! Enter Stock: ");
                        }
                        Console.Write("  Enter Year of Publication: ");
                        int year;
                        while (!int.TryParse(Console.ReadLine(), out year) || year < 1000 || year > DateTime.Now.Year)
                        {
                            Console.Write("  Invalid! Enter Year: ");
                        }
                        // Authors
                        string[] tempAuthors = new string[4];
                        int count = 0;
                        Console.Write("  How many authors? (1-4): ");
                        while (!int.TryParse(Console.ReadLine(), out count) || count < 1 || count > 4)
                        {
                            Console.Write("  Invalid! Enter (1-4): ");
                        }
                        for (int j = 0; j < count; j++)
                        {
                            Console.Write($"  Enter Author {j + 1} Name: ");
                            tempAuthors[j] = Console.ReadLine();
                        }

                        books[totalBooks] = new Book(title, tempAuthors, count, publisher, isbn, price, stock, year);
                        totalBooks++;
                        Console.WriteLine("\n  Book Added Successfully!");
                    }
                    // ==================================================
                    //  2. SEARCH BY TITLE
                    // ==================================================
                    else if (choice == 2)
                    {
                        printHeader("SEARCH BY TITLE");
                        if (totalBooks == 0)
                        {
                            Console.WriteLine("Inventory is empty!");
                            continue;
                        }
                        Console.Write("Enter Title to Search: ");
                        string search = Console.ReadLine();
                        bool found = false;

                        for (int j = 0; j < totalBooks; j++)
                        {
                            if (books[j].searchTitle(search))
                            {
                                Console.WriteLine("\n  << BOOK FOUND >>  ");
                                books[j].displayAll();
                                found = true;
                            }
                        }
                        if (!found)
                        {
                            Console.WriteLine("No book found with that title.");
                        }

                    }
                    // ==================================================
                    //  3. SEARCH BY ISBN
                    // ==================================================
                    else if (choice == 3)
                    {
                        printHeader("SEARCH BY ISBN");
                        if (totalBooks == 0)
                        {
                            Console.WriteLine("  Inventory is empty!");
                            continue;
                        }

                        Console.Write("  Enter ISBN to Search: ");
                        string search = Console.ReadLine();
                        int idx = searchBookByISBN(books, totalBooks, search);

                        if (idx != -1)
                        {
                            Console.WriteLine("\n  << BOOK FOUND >>");
                            books[idx].displayAll();
                        }
                        else
                            Console.WriteLine("  No book found with that ISBN.");
                    }
                    // ==================================================
                    //  4. UPDATE STOCK
                    // ==================================================
                    else if (choice == 4)
                    {
                        printHeader("UPDATE STOCK");
                        if (totalBooks == 0)
                        {
                            Console.WriteLine("Inventory is empty!");
                            continue;
                        }
                        Console.WriteLine("Search book by:");
                        Console.WriteLine("1. Title");
                        Console.WriteLine("2. ISBN");
                        Console.Write("Choice: ");
                        int searchChoice;
                        int.TryParse(Console.ReadLine(), out searchChoice);

                        int bookIdx = -1;
                        if (searchChoice == 1)
                        {
                            Console.Write("Enter Title: ");
                            string t = Console.ReadLine();
                            bookIdx = searchBookByTitle(books, totalBooks, t);
                        }
                        else if (searchChoice == 2)
                        {
                            Console.Write("Enter ISBN: ");
                            string i = Console.ReadLine();
                            bookIdx = searchBookByISBN(books, totalBooks, i);
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice.");
                            continue;
                        }
                        if (bookIdx == -1)
                        {
                            Console.WriteLine("Book not found!");
                            continue;
                        }
                        Console.WriteLine("\nBook Found:");
                        books[bookIdx].displayAll();

                        Console.WriteLine("Update stock:");
                        Console.WriteLine("1. Increase stock");
                        Console.WriteLine("2. Decrease stock");
                        Console.Write("Choice: ");
                        int upChoice;
                        int.TryParse(Console.ReadLine(), out upChoice);
                        Console.Write("Enter amount: ");
                        int amount;
                        while (!int.TryParse(Console.ReadLine(), out amount) || amount <= 0)
                        {
                            Console.Write("Invalid! Enter amount: ");
                        }
                        if (upChoice == 1)
                        {
                            books[bookIdx].updateStock(amount);
                            Console.WriteLine($"Stock increased! New Stock: {books[bookIdx].getStock()}");
                        }
                        else if (upChoice == 2)
                        {
                            if (amount > books[bookIdx].getStock())
                            {
                                Console.WriteLine("Error: Cannot reduce below 0!");
                            }
                            else
                            {
                                books[bookIdx].updateStock(-amount);
                                Console.WriteLine($"Stock decreased! New Stock: {books[bookIdx].getStock()}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice.");
                        }
                    }
                    // ==================================================
                    //  5. ADD A MEMBER
                    // ==================================================
                    else if (choice == 5)
                    {
                        printHeader("ADD A MEMBER");
                        if (totalMembers >= 200)
                        {
                            Console.WriteLine("Member list is full!");
                            continue;
                        }

                        Console.WriteLine("Register as:");
                        Console.WriteLine("1. Member (pays $10/year, gets 5% discount)");
                        Console.WriteLine("2. Non-Member (occasional buyer)");
                        Console.Write("Choice: ");
                        int mChoice;
                        int.TryParse(Console.ReadLine(), out mChoice);

                        Console.Write("Enter Name: ");
                        string mName = Console.ReadLine();

                        int mID = 0;
                        if (mChoice == 1)
                        {
                            Console.Write("Enter Member ID: ");
                            while (!int.TryParse(Console.ReadLine(), out mID) || mID <= 0)
                            {
                                Console.Write("Invalid! Enter Member ID: ");
                            }
                            // Check for duplicate ID
                            if (searchMemberByID(members, totalMembers, mID) != -1)
                            {
                                Console.WriteLine("Error: Member ID already exists!");
                                continue;
                            }
                        }
                        // Non-member, ID = 0

                        Console.Write("Enter Money in Bank ($): ");
                        int mBank;
                        while (!int.TryParse(Console.ReadLine(), out mBank) || mBank < 0)
                        {
                            Console.Write("Invalid! Enter amount: ");
                        }
                        bool isActualMember = (mChoice == 1);
                        members[totalMembers] = new Member(mName, mID, mBank, isActualMember);
                        totalMembers++;

                        if (isActualMember)
                        {
                            memberCount++;
                            totalMembershipFees += Member.MEMBERSHIP_FEE;
                            Console.WriteLine($"Member '{mName}' registered! $10 membership fee deducted.");
                        }
                        else
                        {
                            Console.WriteLine($"Non-member '{mName}' added.");
                        }
                    }
                    // ==================================================
                    //  6. SEARCH FOR A MEMBER
                    // ==================================================
                    else if (choice == 6)
                    {
                        printHeader("SEARCH FOR A MEMBER");
                        if (totalMembers == 0)
                        {
                            Console.WriteLine("No members registered!"); continue;
                        }

                        Console.WriteLine("Search by:");
                        Console.WriteLine("1. Name");
                        Console.WriteLine("2. Member ID (members only)");
                        Console.Write("Choice: ");
                        int sChoice;
                        int.TryParse(Console.ReadLine(), out sChoice);

                        int mIdx = -1;
                        if (sChoice == 1)
                        {
                            Console.Write("Enter Name: ");
                            string n = Console.ReadLine();
                            mIdx = searchMemberByName(members, totalMembers, n);
                        }
                        else if (sChoice == 2)
                        {
                            Console.Write("Enter Member ID: ");
                            int id;
                            if (int.TryParse(Console.ReadLine(), out id))
                                mIdx = searchMemberByID(members, totalMembers, id);
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice.");
                            continue;
                        }

                        if (mIdx != -1)
                        {
                            Console.WriteLine("\n<< MEMBER FOUND >>");
                            members[mIdx].displayAll();
                        }
                        else
                            Console.WriteLine("Member not found!");
                    }
                    // ==================================================
                    //  7. UPDATE MEMBER INFORMATION
                    // ==================================================
                    else if (choice == 7)
                    {
                        printHeader("UPDATE MEMBER INFO");
                        if (totalMembers == 0)
                        {
                            Console.WriteLine("No members registered!");
                            continue;
                        }

                        Console.WriteLine("Search by:");
                        Console.WriteLine("1. Name");
                        Console.WriteLine("2. Member ID (members only)");
                        Console.Write("Choice: ");
                        int sChoice;
                        int.TryParse(Console.ReadLine(), out sChoice);

                        int mIdx = -1;
                        if (sChoice == 1)
                        {
                            Console.Write("Enter Name: ");
                            string n = Console.ReadLine();
                            mIdx = searchMemberByName(members, totalMembers, n);
                        }
                        else if (sChoice == 2)
                        {
                            Console.Write("Enter Member ID: ");
                            int id;
                            if (int.TryParse(Console.ReadLine(), out id))
                            {
                                mIdx = searchMemberByID(members, totalMembers, id);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice.");
                            continue;
                        }

                        if (mIdx == -1)
                        {
                            Console.WriteLine("Member not found!");
                            continue;
                        }

                        Console.WriteLine("\nMember Found:");
                        members[mIdx].displayAll();

                        Console.WriteLine("What to update?");
                        Console.WriteLine("1. Name only");
                        Console.WriteLine("2. Member ID only (members only)");
                        Console.WriteLine("3. Both Name and ID");
                        Console.Write("Choice: ");
                        int uChoice;
                        int.TryParse(Console.ReadLine(), out uChoice);

                        if (uChoice == 1 || uChoice == 3)
                        {
                            Console.Write("Enter new Name: ");
                            string newName = Console.ReadLine();
                            members[mIdx].modifyName(newName);
                            Console.WriteLine("Name updated!");
                        }
                        if ((uChoice == 2 || uChoice == 3) && members[mIdx].isMember)
                        {
                            Console.Write("Enter new Member ID: ");
                            int newID;
                            if (int.TryParse(Console.ReadLine(), out newID) && newID > 0)
                            {
                                if (searchMemberByID(members, totalMembers, newID) != -1)
                                {
                                    Console.WriteLine("Error: That ID is already taken!");
                                }
                                else
                                {
                                    members[mIdx].setID(newID);
                                    Console.WriteLine("ID updated!");
                                }
                            }
                            else Console.WriteLine("Invalid ID.");
                        }
                        else if ((uChoice == 2 || uChoice == 3) && !members[mIdx].isMember)
                        {
                            Console.WriteLine("Non-members do not have an ID to update.");
                        }
                    }
                    // ==================================================
                    //  8. PURCHASE A BOOK
                    // ==================================================
                    else if (choice == 8)
                    {
                        printHeader("PURCHASE A BOOK");
                        if (totalBooks == 0)
                        {
                            Console.WriteLine("No books in inventory!");
                            continue;
                        }
                        if (totalMembers == 0)
                        {
                            Console.WriteLine("No customers registered!");
                            continue;
                        }

                        // Find member/customer
                        Console.WriteLine("Are you a:");
                        Console.WriteLine("1. Member");
                        Console.WriteLine("2. Non-Member");
                        Console.Write("Choice: ");
                        int pChoice;
                        int.TryParse(Console.ReadLine(), out pChoice);

                        int mIdx = -1;
                        if (pChoice == 1)
                        {
                            Console.Write("Enter Member ID: ");
                            int id;
                            if (int.TryParse(Console.ReadLine(), out id))
                            {
                                mIdx = searchMemberByID(members, totalMembers, id);
                            }
                            if (mIdx == -1 || !members[mIdx].isMember)
                            {
                                Console.WriteLine("Member not found!");
                                continue;
                            }
                        }
                        else if (pChoice == 2)
                        {
                            Console.Write("Enter Your Name: ");
                            string nm = Console.ReadLine();
                            // Search for non-member by name
                            for (int j = 0; j < totalMembers; j++)
                            {
                                if (!members[j].isMember && members[j].searchByName(nm))
                                {
                                    mIdx = j;
                                    break;
                                }
                            }
                            if (mIdx == -1)
                            {
                                Console.WriteLine("Non-member not found! Please register first (Option 5).");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice.");
                            continue;
                        }

                        // Find book
                        Console.Write("Enter Book Title or ISBN to purchase: ");
                        string bSearch = Console.ReadLine();
                        int bIdx = searchBookByTitle(books, totalBooks, bSearch);
                        if (bIdx == -1) bIdx = searchBookByISBN(books, totalBooks, bSearch);

                        if (bIdx == -1)
                        {
                            Console.WriteLine("Book not found!");
                            continue;
                        }

                        Console.WriteLine("\nBook Found:");
                        books[bIdx].displayAll();

                        Console.Write("Enter Quantity: ");
                        int qty;
                        while (!int.TryParse(Console.ReadLine(), out qty) || qty <= 0)
                        {
                            Console.Write("  Invalid! Enter quantity: ");
                        }
                        if (books[bIdx].getStock() < qty)
                        {
                            Console.WriteLine($"  Error: Not enough stock! Available: {books[bIdx].getStock()}");
                            continue;
                        }

                        // Process purchase
                        int paid = members[mIdx].buyBook(books[bIdx].getTitle(), books[bIdx].getPrice(), qty);
                        if (paid >= 0)
                        {
                            books[bIdx].updateStock(-qty);
                            totalSales += paid;
                            Console.WriteLine($"  Remaining Stock: {books[bIdx].getStock()}");
                        }
                    }

                    // ==================================================
                    //  9. SALES AND MEMBERSHIP STATS
                    // ==================================================
                    else if (choice == 9)
                    {
                        printHeader("SALES & MEMBERSHIP STATS");
                        Console.WriteLine($"  Total Sales Revenue     : ${totalSales}");
                        Console.WriteLine($"  Total Members Registered: {memberCount}");
                        Console.WriteLine($"  Total Membership Fees   : ${totalMembershipFees}");
                        Console.WriteLine($"  Total Non-Members       : {totalMembers - memberCount}");
                        Console.WriteLine($"  Total Customers (all)   : {totalMembers}");
                        Console.WriteLine($"  Books in Inventory      : {totalBooks}");
                        printLine();
                        Console.WriteLine("  --- Per Member/Customer Summary ---");
                        for (int j = 0; j < totalMembers; j++)
                        {
                            // Use your memberID logic: if ID is 0, they are non-members
                            if (members[j].memberID != 0)
                            {
                                Console.WriteLine($"[Member] {members[j].memberName}");
                            }
                            else
                            {
                                Console.WriteLine($"[Occasional] {members[j].memberName}");
                            }

                            Console.WriteLine($"Books Bought: {members[j].numOfBought}");
                            Console.WriteLine($"Total Spent:  ${members[j].totalSalesContrib}");
                            Console.WriteLine("-------------------------");
                        }
                    }
                    // ==================================================
                    //  10. EXIT
                    // ==================================================
                    else if (choice == 10)
                    {
                        printLine();
                        Console.WriteLine("  Thank you for using the Bookstore System!");
                        Console.WriteLine("  Goodbye!");
                        printLine();
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("  [ERROR]: Please enter a number (1-10).");
                    }
                }
                else
                {
                    Console.WriteLine("  [ERROR]: Please enter a number (1-10).");
                }
            }
        }
    }
}
