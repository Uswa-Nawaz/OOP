using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Challenge_02
{
    internal class Member
    {
        public string memberName;
        public int memberID;
        public int moneyInBank;
        // ------------
        public List<string> boughtBooks = new List<string>();
        public int numOfBought;
        // ------------
        public int amountspent;
        // ------------
        //parameterzed constructor to assign the values
        public Member(string memberName, int memberID, int moneyInBank)
        {
            this.memberName = memberName;
            this.memberID = memberID;
            this.moneyInBank = moneyInBank;
            this.numOfBought = 0;
            this.amountspent = 0;
            this.boughtBooks = new List<string>();
        }
        //bought books list
        public void addboughtBooks(string booktitle, int price)
        {
            if ((moneyInBank - amountspent) >= price)
            {
                boughtBooks.Add(booktitle);
                updateNumOfBooks(1); //this updates the no. of book
                updateAmountspent(price); //this will add the price to total spending 
                Console.WriteLine("Purchase Successful!");
            }
            else
            {
                Console.WriteLine("Transaction Declined: Not enough money in bank!");
            }
        }
        //show bought books
        public void showboughtBooks()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("Books Purchased: ");
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
        // ------------ functions for amount spent ------------
        //update amount spent
        public int updateAmountspent(int a)
        {
            amountspent = amountspent + a;
            return amountspent;
        }
        //modify amount spent
        public int modifyAmountSpent(int a)
        {
            amountspent = a;
            return amountspent;
        }
        //show amountspent
        public void showAmountSpent()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"Amount Spent : {amountspent}");
        }
        //show bank balance
        public void showBankBalance()
        {
            Console.WriteLine("------------------------");
            int currentBalance = moneyInBank - amountspent;
            Console.WriteLine($"Original Bank Balance: {moneyInBank}");
            Console.WriteLine($"Total Amount Spent:    {amountspent}");
            Console.WriteLine($"Current Remaining:     {currentBalance}");
        }
        //display all 
        public void displayAll()
        {
            showname();
            showNumOfBooks();
            showBankBalance();
            showboughtBooks();
            showAmountSpent();
        }
    }
}
