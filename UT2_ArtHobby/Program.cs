using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT2_ArtHobby
{
    // Class: Art
    // Author: Ajay Ramnarine
    // Purpose: A parent class that can be derived from for other classes related about art
    // Restrictions: None
    public abstract class Art 
    {
        private string underDrawing;

        // rw property to get and set the underDrawing field
        public string UnderDrawing
        {
            get 
            {
                return underDrawing;
            }
            set 
            {
                underDrawing = value;
            }
        }

        // Method: CreateShape
        // Purpose: Return what the person is thinking when creating shapes
        // Restrictions: None
        public virtual void CreateShape() 
        {
            Console.WriteLine("I'm free handing these shapes.");
        }

        // Method: Blend
        // Purpose: Return what they person is thinking when blending colors
        // Restrictions: Will be inherited and defined by other classes
        public abstract void Blend();
    }

    // Interface: IMix
    // Purpose: Classes will inherit the method for mixing on a palette
    // Restrictions: None
    public interface IMix 
    {
        void OnPalette();
    }

    // Interface: ICanvas
    // Purpose: Classes will inherit the canvas they use
    // Restrictions: None
    public interface ICanvas 
    {
        void MyCanvas();
    }

    // Class: Oil
    // Author: Ajay Ramnarine
    // Purpose: Inherit and override methods to explain the thought process behind oil painting
    // Restrictions: None
    public class Oil : Art, IMix, ICanvas 
    {
        // Method: OnPalette
        // Purpose: Write the thought process about mixing oil on a palette
        // Restrictions: None
        public void OnPalette() 
        {
            Console.WriteLine("I'm using my palette knife to mix these colors.");
        }

        // Method: MyCanvas
        // Purpose: Write how I prepare my canvas before oil painting
        // Restrictions: None
        public void MyCanvas() 
        {
            Console.WriteLine("Prepared with several layers of black gesso.");
        }

        // Method: CreateShape
        // Purpose: Write how I create shapes on the canvas before painting
        // Restrictions: None
        public override void CreateShape()
        {
            Console.WriteLine("I can use pencil or just start using paint for shapes.");
        }

        // Method: Blend
        // Purpose: Write how I blend colors on the canvas
        // Restrictions: None
        public override void Blend()
        {
            Console.WriteLine("Dark to light and it looks pretty smooth.");
        }
    }

    // Class: Watercolor
    // Author: Ajay Ramnarine
    // Purpose: Inherit and override methods to explain the thought process behind watercolor painting
    // Restrictions: None
    public class Watercolor : Art, IMix, ICanvas
    {
        // Method: OnPalette
        // Purpose: Write the thought process about mixing watercolor on a palette
        // Restrictions: None
        public void OnPalette()
        {
            Console.WriteLine("I mix these colors and add water to lighten them.");
        }

        // Method: MyCanvas
        // Purpose: Write how I prepare my canvas before watercolor painting
        // Restrictions: None
        public void MyCanvas()
        {
            Console.WriteLine("Have to make sure that the paper weight is correct.");
        }

        // Method: CreateShape
        // Purpose: Write how I create shapes on the canvas before painting
        // Restrictions: None
        public override void CreateShape()
        {
            Console.WriteLine("I should use pencil first to erase later if necessary.");
        }

        // Method: Blend
        // Purpose: Write how I blend colors on the canvas
        // Restrictions: None
        public override void Blend()
        {
            Console.WriteLine("Make sure to have a paper towel handy!");
        }
    }

    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Use the create hobby classes and interfaces to create objects in the Main method and pass through MyMethod
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Create objects of the child classes created about my hobby
        //          Pass those objects through MyMethod
        // Restrictions: None
        static void Main(string[] args)
        {
            // create objects of type Oil and Watercolor
            Oil oil = new Oil();
            Watercolor watercolor = new Watercolor();

            // pass the objects through MyMethod to call their methods
            MyMethod(oil);
            Console.WriteLine(" ");
            MyMethod(watercolor);
        }

        // Method: MyMethod
        // Purpose: Pass the objects of my hobby through this method
        //          Call the methods from the interface or through the derived classes based on the object type
        // Restrictions: None
        static void MyMethod(object obj) 
        {
            // create variables of the interfaces and then set the passed obj to the variables
            IMix mix;
            mix = (IMix)obj;
            mix.OnPalette();

            ICanvas canvas;
            canvas = (ICanvas)obj;
            canvas.MyCanvas();

            // check the type of the obj passed and call respective methods based on the class
            if (obj.GetType() == typeof(Oil)) 
            {
                Oil oil;
                oil = (Oil)obj;

                oil.CreateShape();
                oil.Blend();
            }
            if (obj.GetType() == typeof(Watercolor)) 
            {
                Watercolor watercolor;
                watercolor = (Watercolor)obj;

                watercolor.CreateShape();
                watercolor.Blend();
            }
        }
    }
}
