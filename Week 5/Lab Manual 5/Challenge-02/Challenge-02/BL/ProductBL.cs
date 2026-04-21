using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02.BL
{
    internal class ProductBL
    {
        //instances
        private string name;
        private string category;
        private int price;
        private int stock;
        private int threshold;

        //constructor
        public ProductBL(string n, string c, int p, int s, int t)
        {
            setname(n);
            setcategory(c);
            setprice(p);
            setstock(s);
            setthreshold(t);
        }
        //getters
        //for name
        public string getname()
        {
            return name;
        }
        //for category
        public string getcategory()
        {
            return category;
        }
        //for price
        public int getprice()
        {
            return price;
        }
        //for stock
        public int getstock()
        {
            return stock;
        }
        //for threshold
        public int getthreshold()
        {
            return threshold;
        }
        //setters
        //for name
        public void setname(string n)
        {
            if(!string.IsNullOrEmpty(n))
            {
                name = n;
            }
            else
            {
                name = "unknown";
            }
        }
        //for category
        public void setcategory(string c)
        {
            if (!string.IsNullOrEmpty(c))
            {
                category = c;
            }
            else
            {
                category = "unknown";
            }
        }
        //for price
        public void setprice(int p)
        {
            if(p>=0)
            {
                price = p;
            }
            else
            {
                price = 0;
            }
        }
        //for stock
        public void setstock(int s)
        {
            if (s >= 0)
            {
                stock=s;
            }
            else
            {
                stock = 0;
            }
        }
        //for threshold 
        public void setthreshold(int t)
        {
            if (t >= 0)
            {
                threshold=t;
            }
            else
            {
                threshold = 0;
            }
        }

        public double calculateTax()
        {
            double taxRate = 0;
            string cat = category.ToLower();

            if (cat == "grocery")
            {
                taxRate = 10;
            }
            else if (cat == "fruit")
            {
                taxRate = 5;
            }
            else
            {
                taxRate = 15;
            }
            return (price * taxRate) / 100.0;
        }
    }
}
