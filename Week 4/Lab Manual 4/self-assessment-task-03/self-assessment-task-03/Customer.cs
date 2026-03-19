using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_assessment_task_03
{
    internal class Customer
    {
        public string CustomerName;
        public string CustomerAddress;
        public string CustomerCity;

        public List<Product> prod = new List<Product>();
        public List<Product> getAllproduct()
        {
            return prod;
        }

        public void addProduct(Product product)
        {
            prod.Add(product);
        }
    }
}
