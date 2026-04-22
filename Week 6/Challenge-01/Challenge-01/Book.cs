using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01
{
    internal class Book
    {
        //instances
        public string title;
        public string isbn;
        public Author bookAuthor; //association

        //constructor
        public Book(string title, string isbn)
        {
            settitle(title);
            setisbn(isbn);
        }
        //getters
        public string gettitle()
        {
            return title;
        }
        public string getisbn()
        {
            return isbn;
        }

        //setters
        public void settitle(string title)
        {
            this.title = title;
        }
        public void setisbn(string isbn)
        {
            this.isbn = isbn;
        }
        public void AssignAuthor(Author author)
        {
            this.bookAuthor = author;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("--- Book Information ---");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"ISBN:  {isbn}");

            if (bookAuthor != null)
            {
                // Accessing Author class properties
                Console.WriteLine($"Author: {bookAuthor.name}");
                Console.WriteLine($"Bio:    {bookAuthor.bio}");
            }
            else
            {
                Console.WriteLine("Author: Unknown");
            }
            Console.WriteLine("------------------------\n");
        }
    }
}
