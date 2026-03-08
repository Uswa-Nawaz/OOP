using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manual_02_Task5
{
    internal class Program
    {
        public static void AddProduct(Product[] products, ref int count)
        {
            products[count] = new Product();

            Console.Write("Enter Product ID: ");
            int.TryParse(Console.ReadLine(), out products[count].id);

            Console.Write("Enter Product Name: ");
            products[count].name = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            double.TryParse(Console.ReadLine(), out products[count].price);

            Console.Write("Enter Category: ");
            products[count].category = Console.ReadLine();

            Console.Write("Enter Brand: ");
            products[count].brand = Console.ReadLine();

            Console.Write("Enter Country: ");
            products[count].country = Console.ReadLine();

            count++;
        }
        public static void ShowProducts(Product[] products, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("ID: " + products[i].id);
                Console.WriteLine("Name: " + products[i].name);
                Console.WriteLine("Price: " + products[i].price);
                Console.WriteLine("Category: " + products[i].category);
                Console.WriteLine("Brand: " + products[i].brand);
                Console.WriteLine("Country: " + products[i].country);
                Console.WriteLine();
            }
        }
        public static void TotalStoreWorth(Product[] products, int count)
        {
            double total = 0;

            for (int i = 0; i < count; i++)
            {
                total = total + products[i].price;
            }

            Console.WriteLine("Total Store Worth: " + total);
        }
        static void Main(string[] args)
        {
            Product[] products = new Product[100];
            int count = 0;
            int choice = 0;

            while (choice != 4)
            {
                Console.WriteLine("\n1. Add Product");
                Console.WriteLine("2. Show Products");
                Console.WriteLine("3. Total Store Worth");
                Console.WriteLine("4. Exit");

                Console.Write("Enter Choice: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice == 1)
                    {
                        AddProduct(products, ref count);
                    }
                    else if (choice == 2)
                    {
                        ShowProducts(products, count);
                    }
                    else if (choice == 3)
                    {
                        TotalStoreWorth(products, count);
                    }
                    else if (choice == 4)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Enter correct Input !");
                }
            }
        }
    }
}
