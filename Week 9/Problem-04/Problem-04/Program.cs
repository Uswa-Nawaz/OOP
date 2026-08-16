using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Single common list for all shape types
            List<Shape> shapeList = new List<Shape>();

            ShapeUI ui = new ShapeUI(shapeList);

            // Create shapes through the UI class
            ui.CreateRectangle();
            ui.CreateCircle();
            ui.CreateSquare();
            ui.CreateRectangle();
            ui.CreateCircle();

            // Display all shapes, their type and area
            for (int i = 0; i < shapeList.Count; i++)
            {
                Console.WriteLine((i + 1) + ".The shape is " + shapeList[i].GetShapeType() + " and its area is " + shapeList[i].GetArea());
            }
        }
    }
}
