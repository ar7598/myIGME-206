using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoGreaterThan10_PE4_2
{
    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Practice using logical expressions based on user input
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Ask the user to input two numbers which will then be displayed
        //          If both numbers are greater than 10 then remprompt the user for two new numbers
        // Restrictions: The numbers need to be whole integers, not decimals
        static void Main(string[] args)
        {
            // create two variables that will hold the users input values
            int userNumOne = 0;
            int userNumTwo = 0;

            // create a boolean for a while loop
            bool bValid = false;

            // while loop to repeat if the user has entered both numbers that are greater than 10
            while (!bValid)
            {
                // try catch if the user inputs anything that isn't a number
                try
                {
                    // ask user for two numbers and store them into the int variables
                    Console.Write("Please enter your first integer: ");
                    userNumOne = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Please enter your second integer: ");
                    userNumTwo = Convert.ToInt32(Console.ReadLine());

                    // if statament to check if the users numbers are BOTH greater than 10
                    // if both are greater than 10 then it should reprompt the user for two new numbers
                    if(!((userNumOne > 10) ^ (userNumTwo > 10))) 
                    {
                        // if both are less than 10 then exit the loop
                        if (userNumOne <= 10 && userNumTwo <= 10)
                        {
                            bValid = true;
                        }
                        else
                        {
                            Console.WriteLine("Both numbers cannot be greater than 10, please try again.");
                            bValid = false;
                        }
                    }
                    else 
                    {
                        bValid = true;
                    }
                }
                catch 
                {
                    Console.WriteLine("You need to enter two integers, please try again.");
                    bValid = false;
                }
            }

            // print out both numbers to the user
            Console.WriteLine("Your two numbers are " + userNumOne + " and " + userNumTwo + ".");
        }
    }
}
