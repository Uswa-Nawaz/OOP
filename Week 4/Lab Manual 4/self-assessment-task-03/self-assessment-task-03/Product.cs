using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_assessment_task_03
{
    internal class Product
    {
        public string ProductName;
        public float ProductPrice;
        public string Category;

        public float CalculateTax()
        {
            return ProductPrice * 0.1f;
        }
    }
}
