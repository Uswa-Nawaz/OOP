using Challenge_02.BL;
using Challenge_02.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02.UI
{
    internal class AdminUI
    {
        // 1. The Admin's specific menu
        public static int adminMenu()
        {
            Console.WriteLine("--- Admin Menu ---");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View All Products");
            Console.WriteLine("3. Find Product with Highest Unit Price");
            Console.WriteLine("4. View Sales Tax of All Products");
            Console.WriteLine("5. Products to be Ordered (Low Stock)");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            return int.Parse(Console.ReadLine());
        }

        // 2. Logic to display the highest priced product
        public static void displayHighestPrice()
        {
            ProductBL p = ProductDL.gethighestpriceproduct();
            if (p != null)
            {
                Console.WriteLine("Highest Price Product: " + p.getname() + " Price: " + p.getprice());
            }
            else
            {
                Console.WriteLine("No products available.");
            }
        }

        // 3. Logic to display products below threshold
        public static void displayLowStock()
        {
            List<ProductBL> lowStockList = ProductDL.thresholdcheck();
            Console.WriteLine("Products that need to be ordered:");
            foreach (ProductBL p in lowStockList)
            {
                Console.WriteLine(p.getname() + " (Remaining: " + p.getstock() + ")");
            }
        }

        // 4. Logic to display total taxes
        public static void displayTotalTax()
        {
            double total = ProductDL.getTotalTaxForAllProducts();
            Console.WriteLine("Total Sales Tax collected for all products: " + total);
        }
        //add product

        public static ProductBL takeProductInput()
        {
            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Category: ");
            string cat = Console.ReadLine();
            Console.Write("Enter Price: ");
            int price = int.Parse(Console.ReadLine());
            Console.Write("Enter Stock: ");
            int stock = int.Parse(Console.ReadLine());
            Console.Write("Enter Threshold: ");
            int threshold = int.Parse(Console.ReadLine());

            return new ProductBL(name, cat, price, stock, threshold);
        }
    }
}
