using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classy_PE14
{
    // Interface: IShape
    // Author: Ajay Ramnarine
    // Purpose: Interface for the two shape based classes
    // Restrictions: None
    public interface IShape 
    {
        void MyArea();
    }

    // Class: Rectangle
    // Author: Ajay Ramnarine
    // Purpose: Create objects of type Rectangle
    // Restrictions: Contains one method that prints the equation for the area of a rectangle
    public class Rectangle : IShape 
    { 
        // Method: MyArea
        // Purpose: Prints the equation for the area of a rectangle
        // Restrictions: Only prints the equation, does not calculate the area
        public void MyArea() 
        {
            Console.WriteLine("rectangle area = base * height");
        }
    }

    // Class: Circle
    // Author: Ajay Ramnarine
    // Purpose: Creates objects of type Circle
    // Restrictions: Contains one method that prints the equation for the area of a circle
    public class Circle : IShape 
    {
        // Method: MyArea
        // Purpose: Prints the equation for the area of a circle
        // Restrictions: Only prints the equation, does not calculate the area
        public void MyArea() 
        {
            Console.WriteLine("circle area = pi * (radius ^ 2)");
        }
    }

    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Create objects of the 2 different shape classes in the Main method and then call them through the MyMethod method
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Create obejcts of type Rectangle and Circle
        //          Pass both objects through the MyMethod method
        // Restrictions: None
        static void Main(string[] args)
        {
            // create an object of type rectangle
            Rectangle rectangle = new Rectangle();

            // create an object of type circle
            Circle circle = new Circle();

            // pass the objects to the MyMethod method
            MyMethod(rectangle);
            MyMethod(circle);

        }

        // Method: MyMethod
        // Purpose: Pass the created IShape interface and returns the MyArea method of the specific shape that is passed thorugh
        // Restrictions: None
        public static void MyMethod(object myObject) 
        {
            // create variable of the IShape interface type
            IShape shape;

            // cast myObject as IShape type to the created IShape variable
            shape = (IShape)myObject;

            // call MyArea, which should print a different result depending on the type of shape passed into the MyMethod method
            shape.MyArea();
        }
    }
}
