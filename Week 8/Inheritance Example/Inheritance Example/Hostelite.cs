using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Example
{
    class Hostelite : Student
    {
        private string hostelName;
        private int roomNo;
        private int monthlyRent;

        public string GetHostelName()
        {
            return hostelName;
        }
        public void SetHostelName(string name)
        {
            hostelName = name;
        }

       
        public int GetRoomNo()
        {
            return roomNo;
        }
        public void SetRoomNo(int room)
        {
            roomNo = room;
        }

    
        public int GetMonthlyRent()
        {
            return monthlyRent;
        }
        public void SetMonthlyRent(int rent)
        {
            monthlyRent = rent;
        }

      
        public int GetHostelFee()
        {
            int monthsInSemester = 6;
            int totalFee = monthlyRent * monthsInSemester;

            return totalFee;
        }
    }
}
