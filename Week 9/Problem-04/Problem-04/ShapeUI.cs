using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_04
{
    internal class ShapeUI
    {
        private List<Shape> shapeList;

        public ShapeUI(List<Shape> shapeList)
        {
            this.shapeList = shapeList;
        }

        public void CreateRectangle()
        {
            Console.Write("Enter Width: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("Enter Height: ");
            double height = double.Parse(Console.ReadLine());
            shapeList.Add(new Rectangle(width, height));
        }

        public void CreateCircle()
        {
            Console.Write("Enter radius: ");
            double radius = double.Parse(Console.ReadLine());
            shapeList.Add(new Circle(radius));
        }

        public void CreateSquare()
        {
            Console.Write("Enter Side: ");
            double side = double.Parse(Console.ReadLine());
            shapeList.Add(new Square(side));
        }
    }
}
