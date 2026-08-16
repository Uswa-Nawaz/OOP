using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Example
{
    class DayScholar : Student
    {
        private string pickUpPoint;
        private int busNo;
        private int pickUpDistance;

        public string GetPickUpPoint()
        {
            return pickUpPoint;
        }
        public void SetPickUpPoint(string value)
        {
            pickUpPoint = value;
        }

         
        public int GetBusNo()
        {
            return busNo;
        }
        public void SetBusNo(int value)
        {
            busNo = value;
        }

       
        public int GetPickUpDistance()
        {
            return pickUpDistance;
        }
        public void SetPickUpDistance(int value)
        {
            pickUpDistance = value;
        }

        public int getBusFee()
    {
        // Define a rate per unit of distance $15 per km
        int ratePerKm = 15;
    
        int fee = pickUpDistance * ratePerKm;
        
        return fee;
    }
    }
}
