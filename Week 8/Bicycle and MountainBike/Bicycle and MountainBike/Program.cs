using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bicycle_and_MountainBike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Seat Height:");

            int seatHeight;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(),out seatHeight))
                {
                    break;
                }
                else 
                {
                    Console.Write("Enter a valid no.");
                }
            }


            Console.Write("Enter no. of cadence:");
            int cadence;  

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out cadence))
                {
                    break;
                }
                else
                {
                    Console.Write("Enter a valid no.");
                }
            }


            Console.Write("Enter bike speed:");
            int speed;   

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out speed))
                {
                    break;
                }
                else
                {
                    Console.Write("Enter a valid no.");
                }
            }


            Console.Write("Enter the no. of gear:");
            int gear;   

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out gear))
                {
                    break;
                }
                else
                {
                    Console.Write("Enter a valid no.");
                }
            }

            MountainBike mb = new MountainBike(seatHeight,cadence,speed, gear);


            Console.Write("Enter speed increment:");
            int increment;   

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out increment))
                {
                    break;
                }
                else
                {
                    Console.Write("Enter a valid no.");
                }
            }

            mb.speedUp(increment);


            Console.Write("Enter new Seat Height:");       //What do you want to change the seat height to
            int newSeatHeight;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out newSeatHeight))
                {
                    break;
                }
                else
                {
                    Console.Write("Enter a valid no.");
                }
            }

            mb.setSeatHeight(newSeatHeight);

            //displaying
            Console.WriteLine($"Final Speed : {mb.getSpeed()}");
            Console.WriteLine($"Gear : {mb.getGear()}");
            Console.WriteLine($"Candence : {mb.getCandence()}");
            Console.WriteLine($"New seat height : {mb.getSeatHeight()}");
        }
    }
}
