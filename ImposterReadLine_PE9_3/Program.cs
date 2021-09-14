using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImposterReadLine_PE9_3
{
    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Learn about using delegate functions by creating one for the ReadLine() function
    // Restrictions: None
    class Program
    {
        // create a delegate function that will have the ReadLine() function passed to it
        delegate string imposterRLDelegate();

        // Method: Main
        // Purpose: Ask the user to input a sentence
        //          Use a delegate function as a way to call the ReadLine() function
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare a variable for the delegate function
            imposterRLDelegate impRL;

            // pass the ReadLine() function to the delegate
            impRL = new imposterRLDelegate(Console.ReadLine);

            // ask the user to type in anything they would like
            Console.Write("Hello! Type in anything you want: ");

            // initialize a variable that will use the delegate function as a way to store their input
            string userInput = impRL();

            // create an space between user input and the goodbye 
            Console.WriteLine();

            // thank the user for typing something in and tell them goodbye
            Console.WriteLine("Thank you for entering \" {0} \", goodbye!", userInput);
            Console.WriteLine();

        }
    }
}
