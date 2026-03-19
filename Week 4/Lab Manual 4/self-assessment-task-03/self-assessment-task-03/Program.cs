using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_assessment_task_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer c = new Customer();

            Console.Write("Enter Customer Name: ");
            c.CustomerName = Console.ReadLine();

            Console.Write("Enter Customer Address: ");
            c.CustomerAddress = Console.ReadLine();

            Console.Write("Enter Customer City: ");
            c.CustomerCity = Console.ReadLine();

            Console.Write("How many products to add? ");
            int numProducts = int.Parse(Console.ReadLine());

            for (int i = 0; i < numProducts; i++)
            {
                Product p = new Product();

                Console.WriteLine($"\nEnter details for Product #{i + 1}:");

                Console.Write("Name: ");
                p.ProductName = Console.ReadLine();

                Console.Write("Category: ");
                p.Category = Console.ReadLine();

                Console.Write("Price: ");
                p.ProductPrice = int.Parse(Console.ReadLine());

                // Add product to customer
                c.addProduct(p);
            }

            //Display Products
            Console.WriteLine($"\nCustomer: {c.CustomerName}, Address: {c.CustomerAddress}, Contact: {c.CustomerCity}");
            Console.WriteLine("Products purchased:\n");


            List<Product> list = c.getAllproduct();

            foreach (Product p in list)
            {
                Console.WriteLine($"Product Name: {p.ProductName}");
                Console.WriteLine($"Category: {p.Category}");
                Console.WriteLine($"Price: {p.ProductPrice}");
                Console.WriteLine($"Tax: {p.CalculateTax()}");
                Console.WriteLine();
            }
        }
    }
}
