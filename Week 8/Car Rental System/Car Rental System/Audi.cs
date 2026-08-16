using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System
{
    internal class Audi : Car
    {
        private double fuelEfficiency = 20.0;

        public Audi(double fuelEfficiency, string model, string color, double price) : base(model, color, price)
        {
            this.fuelEfficiency = fuelEfficiency;
            //other attributes are handled by parent class
        }

        public double calculateFuel(double km)
        {
            return base.calculateFuel(km, fuelEfficiency);     // calls parent method
        }
    }
}
