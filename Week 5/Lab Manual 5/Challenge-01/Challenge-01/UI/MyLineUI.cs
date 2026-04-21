using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Challenge_01.BL;
using Challenge_01.DL;

namespace Challenge_01.UI
{
    internal class MyLineUI
    {
        public static void menu()
        {
            while (true)
            {
                Console.WriteLine("<<<   MENU   >>>");
                Console.WriteLine("1. Make a Line");
                Console.WriteLine("2. Update the begin point");
                Console.WriteLine("3. Update the end point");
                Console.WriteLine("4. Show the update point");
                Console.WriteLine("5. Show the end point");
                Console.WriteLine("6. Get Length of the Line");
                Console.WriteLine("7. Get Gradient of the Line");
                Console.WriteLine("8. Distance of begin point from zero coorinate");
                Console.WriteLine("9. Distane of end point from zero coordinate");
                Console.WriteLine("10. Exit");
                int choice = 0;
                Console.Write("Enter Your Choice: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    if (choice == 1)
                    {
                        makeLine();
                    }
                    else if (choice == 2)
                    {
                        updatebegin();
                    }
                    else if (choice == 3)
                    {
                        updateEnd();
                    }
                    else if (choice == 4)
                    {
                        showUpdatePoint();
                    }
                    else if (choice == 5)
                    {
                        showendpoint();
                    }
                    else if (choice == 6)
                    {
                        linelength();
                    }
                    else if (choice == 7)
                    {
                        linegradient();
                    }
                    else if (choice == 8)
                    {
                        begindistancewithzero();
                    }
                    else if (choice == 9)
                    {
                        enddistancewithzero();
                    }
                    else if (choice == 10)
                    {
                        Console.WriteLine("Exiting...");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("[ERROR]: Please Enter a Number (1-10)");
                        Console.WriteLine("Press Any Key to Continue...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("[ERROR]: Please Enter a Number (1-10)");
                    Console.WriteLine("Press Any Key to Continue...");
                    Console.ReadKey();
                }
            }
        }
        //method for option 1: make a line
        public static void makeLine()
        {
            //taking inputs
            Console.WriteLine("Enter value of x1: ");
            int x1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter value of y1: ");
            int y1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter value of x2: ");
            int x2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter value of y2: ");
            int y2 = int.Parse(Console.ReadLine());

            //creating mypoints
            MyPoint p1 = new MyPoint(x1, y1);
            MyPoint p2 = new MyPoint(x2, y2);

            //creating myline
            MyLine newLine = new MyLine(p1, p2);

            //saving in Dl
            MyLineDL.setline(newLine);

            Console.WriteLine("Line made successfully !");
        }
        //method for option 2: update the begin point 
        public static void updatebegin()
        {
            MyLine currentline = MyLineDL.getline();
            if (currentline != null)
            {
                //take new beginning points
                Console.WriteLine("Enter new x1: ");
                int nx1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new y1: ");
                int ny1 = int.Parse(Console.ReadLine());

                MyPoint newp1 = new MyPoint(nx1, ny1);
                currentline.setbegin(newp1);
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Press Any Key to Continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Please create a line first (Option 1).");
            }
        }

        //method for option 3: update the endpoint
        public static void updateEnd()
        {
            MyLine currentline = MyLineDL.getline();
            if (currentline != null)
            {
                //take new ending points
                Console.WriteLine("Enter new x2: ");
                int nx2 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new y2: ");
                int ny2 = int.Parse(Console.ReadLine());

                MyPoint newp2 = new MyPoint(nx2, ny2);
                currentline.setend(newp2);
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Press Any Key to Continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Please create a line first (Option 1).");
            }
        }

        //method for option 4: show the update point
        public static void showUpdatePoint()
        {
            //fetch the line from dl
            MyLine currentline = MyLineDL.getline();
            if (currentline != null)
            {
                MyPoint p1 = currentline.getbegin();
                MyPoint p2 = currentline.getend();
                Console.WriteLine($"x1: {p1.getX()}");
                Console.WriteLine($"y1: {p1.getY()}");
                Console.WriteLine($"x2: {p2.getX()}");
                Console.WriteLine($"y2: {p2.getY()}");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Press Any Key to Continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Please create a line first (Option 1).");
            }
        }

        //method for option 5: show the end points
        public static void showendpoint()
        {
            MyLine currentline = MyLineDL.getline();
            if (currentline != null)
            {
                MyPoint p2 = currentline.getend();
                Console.WriteLine($"x2: {p2.getX()}");
                Console.WriteLine($"y2: {p2.getY()}");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Press Any Key to Continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Please create a line first (Option 1).");
            }
        }

        //method for option 6: Get the length of the line
        public static void linelength()
        {
            MyLine currentline = MyLineDL.getline();
            if (currentline != null)
            {
                double l = currentline.getlength();
                Console.WriteLine($"The length of the line is: {l}");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Press Any Key to Continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Please create a line first (Option 1).");
            }
        }

        //method for option 7: get the gradient of the line
        public static void linegradient()
        {
            MyLine currentline = MyLineDL.getline();
            if (currentline != null)
            {
                double g = currentline.getgradient();
                Console.WriteLine($"The gradient of the line is: {g}");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Press Any Key to Continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Please create a line first (Option 1).");
            }
        }

        //method for option 8: distance of beginning point from zero
        public static void begindistancewithzero()
        {
            MyLine currentline = MyLineDL.getline();
            if (currentline != null)
            {
                MyPoint p1 = currentline.getbegin();
                Console.WriteLine($"x1: {p1.getX()}");
                Console.WriteLine($"y1: {p1.getY()}");
                double d = p1.distancewithzero();
                Console.WriteLine($"Distance of beginning from zero is : {d}");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Press Any Key to Continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Please create a line first (Option 1).");
            }
        }

        //method for option 9: distance of end point from zero
        public static void enddistancewithzero()
        {
            MyLine currentline = MyLineDL.getline();
            if (currentline != null)
            {
                MyPoint p2 = currentline.getend();
                Console.WriteLine($"x2: {p2.getX()}");
                Console.WriteLine($"y2: {p2.getY()}");
                double d = p2.distancewithzero();
                Console.WriteLine($"Distance of end from zero is : {d}");
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Press Any Key to Continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Please create a line first (Option 1).");
            }
        }
    }
}
