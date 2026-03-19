using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Challenge_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //array of object, each object got deals with one book
            Book[] books = new Book[100];
            int totalBooks = 0; //counter
            //-----
            string title;
            string publisher;
            string isbn;
            int price;
            int stock;
            //-----

            while (true)
            {
                int choice = 0;
                Console.WriteLine("----------------------");
                Console.WriteLine("     <<< MENU >>>     ");
                Console.WriteLine("----------------------");
                Console.WriteLine("1. Add Book ");
                Console.WriteLine("2. Search by Title");
                Console.WriteLine("3. Search by ISBN ");
                Console.WriteLine("4. Update Book Info");
                Console.WriteLine("5. Display All Books");
                Console.WriteLine("6. Exit ");
                Console.Write("Enter Your Choice: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice == 1)
                    {
                        if (totalBooks >= 100)
                        {
                            Console.WriteLine("Library is full!");
                            continue;
                        }
                        //collecting info
                        Console.Write("Enter Book's Title: ");
                        title = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Enter publisher: ");
                        publisher = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Enter ISBN: ");
                        isbn = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Enter Price: ");
                        price = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.Write("Enter Stock: ");
                        stock = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        //multiple authors
                        string[] tempAuthors = new string[4];
                        int count = 0;
                        Console.Write("How many authors (1-4)? : ");
                        if (int.TryParse((string)Console.ReadLine(), out count) && count > 0 && count < 5)
                        {
                            for (int j = 0; j < count; j++)
                            {
                                Console.Write($"Enter Author {j + 1} Name: ");
                                tempAuthors[j] = Console.ReadLine();
                            }
                        }
                        //new object
                        books[totalBooks] = new Book(title, tempAuthors,count, publisher, isbn, price, stock);
                        totalBooks++;
                        Console.WriteLine("Book Added ! ");
                    }
                    else if (choice == 2)
                    {
                        if (totalBooks == 0)
                        {
                            Console.WriteLine("Library is empty ");
                            continue;
                        }
                        //search by title
                        Console.Write("Enter Search Term: ");
                        string search = Console.ReadLine();
                        bool found = false;
                        for (int j = 0; j < totalBooks; j++)
                        {
                            if (books[j].searchTitle(search) == true)
                            {
                                Console.WriteLine(" << BOOK FOUND >>");
                                found = true;
                                books[j].displayAll();
                            }
                            else
                            {
                                found = false;
                            }
                        }
                        if (found == false)
                        {
                            Console.WriteLine("Book not found ! ");
                        }
                    }
                    else if (choice == 3)
                    {
                        if (totalBooks == 0)
                        {
                            Console.WriteLine("Library is empty ");
                            continue;
                        }
                        //search by isbn
                        Console.Write("Enter ISBN: ");
                        string search = Console.ReadLine();
                        bool found = false;
                        for (int j = 0; j < totalBooks; j++)
                        {
                            if (books[j].searchISBN(search) == true)
                            {
                                Console.WriteLine(" << BOOK FOUND >>");
                                found = true;
                                books[j].displayAll();
                            }
                            else
                            {
                                found = false;
                            }
                        }
                        if(found==false)
                        {
                            Console.WriteLine("Book not found ! ");
                        }
                    }
                    else if (choice == 4)
                    {
                        if (totalBooks == 0)
                        {
                            Console.WriteLine("Library is empty ");
                            continue;
                        }
                        //update stock
                        //search by isbn
                        Console.Write("Enter ISBN: ");
                        string search = Console.ReadLine();
                        for (int j = 0; j < totalBooks; j++)
                        {
                            if (books[j].searchISBN(search) == true)
                            {
                                Console.Write("Add how many copies? ");
                                int amount = int.Parse(Console.ReadLine());
                                books[j].updateStock(amount);
                                Console.WriteLine("Stock Updated!");
                            }
                            else
                            {
                                Console.WriteLine("Book not found ! ");
                            }
                        }
                    }
                    else if (choice == 5)
                    {
                        if (totalBooks == 0)
                        {
                            Console.WriteLine("Library is empty ");
                            continue;
                        }
                        for (int j = 0; j < totalBooks; j++)
                        {
                            books[j].displayAll();
                            Console.WriteLine("-----------------------");
                        }
                    }
                    else if (choice == 6)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("[ERROR]: Please enter no. (1-6) ");
                }
            }
        }
    }
}
