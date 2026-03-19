using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_03
{
    internal class Member
    {
        public string memberName;
        public int memberID;    //  for non-member id is zero
        public int moneyInBank;
        public bool isMember;
        // ------------
        public List<string> boughtBooks = new List<string>();
        public int numOfBought;
        // ------------
        public int amountSpent;        // tracks total spent (resets on 11th book logic)
        public int totalSalesContrib;  // total money actually paid (never resets, for stats)

        // For 11 book logic, it track prices of last 10 books
        public List<int> last10Prices = new List<int>();

        public const int MEMBERSHIP_FEE = 10;
        public const double MEMBER_DISCOUNT = 0.05; // 5%

        //parameterized Constructor
        public Member(string memberName, int memberID, int moneyInBank, bool isMember)
        {
            this.memberName = memberName;
            this.memberID = memberID;
            this.moneyInBank = moneyInBank;
            this.isMember = isMember;
            this.numOfBought = 0;
            this.amountSpent = 0;
            this.totalSalesContrib = 0;
            this.boughtBooks = new List<string>();
            this.last10Prices = new List<int>();

            if (isMember)
            {
                this.amountSpent = amountSpent+ MEMBERSHIP_FEE;
                this.totalSalesContrib = totalSalesContrib+ MEMBERSHIP_FEE;
                Console.WriteLine($"  [$10 membership fee deducted for {memberName}]");
            }
        }

        //Buy a book 
        public int buyBook(string bookTitle, int bookPrice, int quantity)
        {
            int finalPrice = bookPrice;
            if (isMember)
            {
                finalPrice = (int)(bookPrice * 0.95);
                Console.WriteLine("Member 5% Discount Applied!");
            }
            int totalCost = finalPrice * quantity;
            if (isMember && numOfBought > 0 && numOfBought % 10 == 0)
            {
                // Calculate average of purchased last 10 books 
                int avg = amountSpent / 10;
                Console.WriteLine($"\n11th Book Special!");
                Console.WriteLine($"Average of last 10 books: ${avg}");
                Console.WriteLine($"Discounting: ${avg} ");

                totalCost = totalCost - avg;
                if (totalCost < 0)
                {
                    totalCost= 0;
                }
                // Reset amountSpent tracking for next 10
                amountSpent = 0;
                last10Prices.Clear();
            }

            // Check if member has enough balance
            int currentBalance = moneyInBank - totalSalesContrib;
            if (currentBalance < totalCost)
            {
                Console.WriteLine("Transaction Declined: Not enough balance!");
                return -1;
            }
            // Process purchase
            for (int i = 0; i < quantity; i++)
            {
                boughtBooks.Add(bookTitle);
                numOfBought++;
                last10Prices.Add(finalPrice);
                amountSpent =amountSpent+ finalPrice;
                totalSalesContrib =totalSalesContrib+ finalPrice;
            }

            Console.WriteLine($"Total Charged: ${totalCost}");
            return totalCost;
        }
        //show bought books
        public void showboughtBooks()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("Books Purchased: ");
            if (boughtBooks.Count == 0)
            {
                Console.WriteLine("(No purchases yet)");
                return;
            }
            foreach (string book in boughtBooks)
            {
                Console.WriteLine($"{book}");
            }
        }
        // ------------ functions for name ------------
        //show name 
        public void showname()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"Name: {memberName}");
        }
        //set name
        public void setName(string n)
        {
            this.memberName = n;
        }
        //modify name
        public string modifyName(string n)
        {
            if (!string.IsNullOrEmpty(n))
            {
                this.memberName = n;
            }
            return memberName;
        }
        // ---------------- functions for ID ----------------
        public void showID()
        {
            if (isMember)
            {
                Console.WriteLine($" Member ID: {memberID}");
            }
            else
            {
                Console.WriteLine($" Member ID: 0 (Non-Member)");
            }
        }
        public void setID(int id) 
        {
            memberID = id; 
        }
        // ------------ functions for no. of books ------------
        //show no. of books
        public void showNumOfBooks()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"No. of Bought Books: {numOfBought}");
        }
        //modify no. of books
        public int modifyNumOfBooks(int n)
        {
            if (n >= 0)
            {
                this.numOfBought = n;
            }
            return numOfBought;
        }
        //update no. of books
        public int updateNumOfBooks(int n)
        {
            numOfBought = numOfBought + n;
            return numOfBought;
        }
        //totalSalesContrib
        public void showtotalSalesContrib()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"Amount Spent : {totalSalesContrib}");
        }
        //show bank balance
        public void showBankBalance()
        {
            Console.WriteLine("------------------------");
            int currentBalance = moneyInBank - totalSalesContrib;
            Console.WriteLine($"Original Bank Balance: {moneyInBank}");
            Console.WriteLine($"Total Amount Spent: {totalSalesContrib}");
            Console.WriteLine($"Current Remaining: {currentBalance}");
        }
        //display all 
        public void displayAll()
        {
            showname();
            showID();
            showNumOfBooks();
            showBankBalance();
            showboughtBooks();
            showtotalSalesContrib();
        }
        // Search by name
        public bool searchByName(string name)
        {
            return memberName.ToLower().Contains(name.ToLower());
        }
    }
}
