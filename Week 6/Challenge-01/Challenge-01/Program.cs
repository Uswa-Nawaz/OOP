using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<<< Library Input System >>>");

            // 1. Get Author Data
            Console.Write("Enter Author Name: ");
            string authorName = Console.ReadLine();
            Console.Write("Enter Author Bio: ");
            string authorBio = Console.ReadLine();

            Author userAuthor = new Author(authorName, authorBio);

            // 2. Get Book Data
            Console.Write("\nEnter Book Title: ");
            string bookTitle = Console.ReadLine();
            Console.Write("Enter Book ISBN: ");
            string bookIsbn = Console.ReadLine();

            Book userBook = new Book(bookTitle, bookIsbn);

            // Association
            userBook.AssignAuthor(userAuthor);

            // Display Result
            userBook.DisplayInfo();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
