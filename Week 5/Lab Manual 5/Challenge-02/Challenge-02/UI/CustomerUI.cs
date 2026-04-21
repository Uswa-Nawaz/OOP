using Challenge_02.BL;
using Challenge_02.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02.UI
{
    internal class CustomerUI
    {
        public static int customerMenu()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("     CUSTOMER MENU        ");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. View All Products");
            Console.WriteLine("2. Buy Product");
            Console.WriteLine("3. Generate Invoice");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            if (int.TryParse(choice, out int option))
            {
                return option;
            }
            return 0;
        }

        // Logic to View 
        public static void viewAllProducts()
        {
            List<ProductBL> list = ProductDL.returnproductlist();
            Console.WriteLine("Name\tCategory\tPrice\tStock");
            foreach (ProductBL p in list)
            {
                Console.WriteLine($"{p.getname()}\t{p.getcategory()}\t{p.getprice()}\t{p.getstock()}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }


        //method to buy a product
        public static void buyProduct(Customer c)
        {
            Console.Write("Enter Product Name you want to buy: ");
            string name = Console.ReadLine();
            ProductBL p = ProductDL.isProductExist(name);
            if (p != null)
            {
                // 2. Check if we actually have stock
                if (p.getstock() > 0)
                {
                    c.addProductToCart(p); // Add to customer's basket
                    p.setstock(p.getstock() - 1); // Logic: Decrease store stock
                    Console.WriteLine("Product added to cart successfully!");
                }
                else
                {
                    Console.WriteLine("Sorry, this item is out of stock!");
                }
            }
            else
            {
                Console.WriteLine("Product not found in our store.");
            }
        }
        //method for invoice
        public static void generateInvoice(Customer c)
        {
            Console.WriteLine("--- INVOICE ---");
            foreach (ProductBL p in c.getCart())
            {
                Console.WriteLine($"{p.getname()} \t Price: {p.getprice()} \t Tax: {p.calculateTax()}");
            }
            Console.WriteLine("----------------");
            Console.WriteLine($"Total Bill (with tax): {c.calculateTotalBill()}");
        }
    }
}
