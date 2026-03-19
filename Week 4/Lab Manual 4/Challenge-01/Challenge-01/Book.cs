using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Challenge_01
{
    internal class Book
    {
        public string title;
        public string[] authors=new string[4];
        public int authorCount; //track the no. of authors added
        public string publisher;
        public string isbn;
        public int price;
        public int stock;
        //parameterized constructor to set the values
        public Book(string title, string[] authors, int authorCount, string publisher, string isbn, int price, int stock)
        {
            this.title = title;
            this.authors = authors;
            this.authorCount = authorCount;
            this.publisher = publisher;
            this.isbn = isbn;
            this.price = price;
            this.stock = stock;
        }

        // ----------------methods for title----------------
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
            if(title.ToLower()==t.ToLower())
            {
                return true;
            }
            return false;
        }
        // ----------------methods for stock----------------

        //show stock
        public void showStock()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($" Stock : {stock}");

        }
        //update stock 
        public int updateStock(int s)
        {
            stock = stock + s;
            return stock;
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
        // ----------------methods for publisher ---------------
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
        // ----------------methods for ISBN----------------
        //show isbn
        public void showISBN()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($" ISBN : {isbn}");

        }
        //search by isbn
        public bool searchISBN(string i)
        {
            if(isbn.ToLower()==i.ToLower())
            {
                return true ;
            }
            return false;
        }
        //set isbn
        public void setISBN(string i)
        {
            isbn = i;
        }
        // ----------------methods for price ----------------
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
        // ----------------methods for authors ----------------

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
            if(authorCount<4)
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
            showISBN();
            showPrice();
            showStock();
        }
    }
}
