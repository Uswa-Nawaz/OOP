using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bicycle_and_MountainBike
{
    internal class Bicycle
    {
        private int candence;
        private int gear;
        private int speed;

        public Bicycle(int candence, int gear, int speed)
        {
            this.candence = candence;
            this.gear = gear;
            this.speed = speed;
        }

        public int getCandence()
        {
            return candence;
        }

        public int getGear()
        {
            return gear;
        }

        public int getSpeed()
        {
            return speed;
        }

        public void setCadence(int cadence)
        {
            this.candence = cadence;
        }

        public void setGear(int gear)
        {
            this.gear = gear;

        }

        public void applyBreak(int decrement)
        {
            speed -= decrement;
        }

        public void speedUp(int increment)
        {
            speed += increment;
        }
    }
}
