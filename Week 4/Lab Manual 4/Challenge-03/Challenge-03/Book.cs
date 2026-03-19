using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_03
{
    internal class Book
    {
        public string title;
        public string[] authors = new string[4];
        public int authorCount; //track the no. of authors added
        public string publisher;
        public string isbn;
        public int price;
        public int stock;
        public int yearOfPublication; //* for challenge 3

        // Parameterized constructor
        public Book(string title, string[] authors, int authorCount, string publisher, string isbn, int price, int stock, int yearOfPublication)
        {
            this.title = title;
            this.authors = authors;
            this.authorCount = authorCount;
            this.publisher = publisher;
            this.isbn = isbn;
            this.price = price;
            this.stock = stock;
            this.yearOfPublication = yearOfPublication;
        }
        // ----------------for title----------------
        //show title
        public void showTitle()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($" Title : {title}");
        }
        //set title 
        public void setTitle(string t)
        {
            title = t; 
        }
        //get title
        public string getTitle()
        {
            return title;
        }
        //Search by title
        public bool searchTitle(string t)
        {
            if (title.ToLower() == t.ToLower())
            {
                return true;
            }
            return false;
        }
        // ----------------for stock----------------
        //show stock
        public void showStock()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($" Stock : {stock}");
        }
        //set stock
        public void setStock(int s)
        {
            stock = s;
        }
        //get stock
        public int getStock()
        {
            return stock;
        }
        //update stock
        public int updateStock(int s)
        {
            stock = stock + s;
            return stock;
        }
        // ----------------for publisher----------------
        //show publisher
        public void showpublisher()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($" Publisher : {publisher}");

        }
        //set publisher
        public void setPublisher(string p)
        {
            publisher = p;
        }
        //get publisher
        public string getPublisher()
        {
            return publisher;
        }
        // ----------------for ISBN----------------
        //show isbn
        public void showISBN()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($" ISBN : {isbn}");

        }
        //search by isbn
        public bool searchISBN(string i)
        {
            if (isbn.ToLower() == i.ToLower())
            {
                return true;
            }
            return false;
        }
        //set isbn
        public void setISBN(string i)
        {
            isbn = i;
        }
        // ---------------- for price ----------------
        //show price
        public void showPrice()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($" Price : {price}");

        }
        //set price
        public void setPrice(int p)
        {
            price = p;
        }
        //get price
        public int getPrice()
        {
            return price;
        }
        // ---------------- for year ----------------
        public void showYear()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($" Year Published   : {yearOfPublication}");
        }
        //show author
        public void showAuthor()
        {
            Console.WriteLine("------------------------");
            for (int i = 0; i < authorCount; i++)
            {
                Console.WriteLine($"Author {i + 1} is: {authors[i]}");
            }
        }
        //add author to array
        public void addAuthor(String name)
        {
            if (authorCount < 4)
            {
                authors[authorCount] = name;
                authorCount++;
                Console.WriteLine("Author added !");
            }
            else
            {
                Console.WriteLine("Error: Maximum of 4 authors reached!");
            }
        }
        //get author
        public int getAuthorCount()
        {
            return authorCount;
        }
        //----------------display all ----------------
        public void displayAll()
        {
            showTitle();
            showAuthor();
            showpublisher();
            showYear();
            showISBN();
            showPrice();
            showStock();
        }
    }
}
