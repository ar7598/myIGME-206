using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT1_ImposterReadLine
{
    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Use a delegate function to impersonate the Console.ReadLine() function
    // Restrictions: None
    class Program
    {
        // create a delegate function that will have the ReadLine() function passed to it
        delegate string impDelReadLine();

        // Method: Main
        // Purpose: Using a delegate function, prompt the user to input something and use the delegate to read their input
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare a variable for the delegate function
            impDelReadLine impRL;

            // pass the ReadLine() function to the delegate function
            impRL = new impDelReadLine(Console.ReadLine);

            // prompt the user to type in anything they want
            Console.Write("Hello! Please type in anything you want: ");

            // create a string variable that will use the delegate function as a way to store the user input
            string userInput = impRL();

            // create a space between the user input and the goodbye line
            Console.WriteLine();

            // thank the user, tell them what they typed, and then tell them goodbye
            Console.WriteLine("Thank you for entering \"{0}\" ", userInput);
            Console.WriteLine("GoodBye!");
            Console.WriteLine();
        }
    }
}
