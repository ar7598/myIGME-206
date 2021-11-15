using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringReversal_PE8_7
{
    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Practice string manipulation with user inputs and reversing the order of the input
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Take a string input from the user
        //          Using string manipulation, reverse the order of the user input string
        //          Output the reversed string to the console
        // Restrictions: None
        static void Main(string[] args)
        {
            // Ask the user to input a string
            Console.Write("Enter any string to be reversed: ");

            // initialize a string variable that will store the input of the user
            string userInput = Console.ReadLine();

            // convert the user input into a char array
            char[] cUserInputArray = userInput.ToCharArray();

            // initialize a string variable that will store the reverse of the user input
            string reverseUserInput = null;

            // use a for loop to go through the char array backwards and concatenate the characters to the reverse string variable
            for (int i = cUserInputArray.Length - 1; i >= 0; i--) 
            {
                // concatenate the characters of the user input to the reverse string variable
                reverseUserInput += cUserInputArray[i];
            }

            // output the reverse string to the console
            Console.WriteLine("The reverse of your string is: " + reverseUserInput);

        }
    }
}
