using Challenge_02.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02.BL
{
    internal class Customer
    {
        private List<ProductBL> cart = new List<ProductBL>();
        public void addProductToCart(ProductBL p)
        {
            cart.Add(p);
        }
        public List<ProductBL> getCart()
        {
            return cart;
        }
        public double calculateTotalBill()
        {
            double total = 0;
            foreach (ProductBL p in cart)
            {
                total += p.getprice() + p.calculateTax();
            }
            return total;
        }
    }
}
