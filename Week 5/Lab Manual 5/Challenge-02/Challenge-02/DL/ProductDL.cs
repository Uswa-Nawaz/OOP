using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_02.BL;

namespace Challenge_02.DL
{
    internal class ProductDL
    {
        private static List<ProductBL> productlist = new List<ProductBL>();
        //add to list
        public static void addproductTolist(ProductBL p)
        {
            productlist.Add(p);
        }
        //retrieve from the list
        public static List<ProductBL> returnproductlist()
        {
            return productlist;
        }
        //highest price product
        public static ProductBL gethighestpriceproduct()
        {
            if (productlist.Count == 0)
            {
                return null;
            }
            ProductBL highestprice = productlist[0];
            foreach (ProductBL p in productlist)
            {
                if(p.getprice()>=highestprice.getprice())
                {
                    highestprice = p;
                }    
            }
            return highestprice;
        }

        //threshold check: result containing only the "low stock" items.
        public static List<ProductBL> thresholdcheck()
        {
            List<ProductBL> lowstock = new List<ProductBL>();
            foreach (ProductBL p in productlist)
            {
                if(p.getstock()<p.getthreshold())
                {
                    lowstock.Add(p);
                }
            }
            return lowstock;
        }
        //sun of taxes
        public static double getTotalTaxForAllProducts()
        {
            double totalTax = 0;

            foreach (ProductBL p in productlist)
            {
                totalTax = totalTax + p.calculateTax();
            }
            return totalTax;
        }
        // Method to find a product by name
        public static ProductBL isProductExist(string name)
        {
            foreach (ProductBL p in productlist)
            {
                if (p.getname().ToLower() == name.ToLower())
                {
                    return p;
                }
            }
            return null;
        }
    }
}