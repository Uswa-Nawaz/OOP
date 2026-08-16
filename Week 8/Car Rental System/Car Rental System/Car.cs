using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System
{
    internal class Car
    {
        protected string model;
        protected string color;
        protected double price;

        public Car(string model,string color,double price)
        {
            this.model = model;
            this.color = color;
            this.price = price;
        }

        public string getModel()
        {
            return model;
        }

        public void setModel(string model)
        {
            this.model=model;
        }

        public string getColor()
        {
            return color;
        }

        public void setColor(string color)
        { 
            this.color=color;
        }

        public double getPrice()
        {
            return price;
        }

        public void setPrice(double price)
        {
            this.price = price;
        }

        public string toString()
        {
            return $"Model: {model} \t Color: {color} \t Price: {price}";
        }

        public double calculateFuel(double km, double fuelEfficiency)
        {
            double fuel = km / fuelEfficiency;
            return fuel;
        }

    }
}
