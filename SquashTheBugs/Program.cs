using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquashTheBugs
{
    // Class: Program
    // Author: David Schuh
    // Purpose: Bug squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop thorugh the numbers 1 through 10
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare int counter
            // int i = 0
            // compile error: missing semicolon
            // syntax: declare as double to print decimal values in line 50
            double i;

            // declare string to hold all numbers
            string allNumbers = null; 

            // loop thorugh the numbers 1 through 10
            // for (i = 1; i < 10; ++i)
            // syntax error: need to include 10 within the count, and the loop needs to check for i before incrementing 
            for (i = 1; i <= 10; i++)
            {
                // declare string to hold all numbers
                // string allNumbers = null;
                // allNumbers must be declared outside of the for loop as it is called outside of the loop at the end of the program

                // output explanation of calculation
                // Console.Write(i + "/" + i - 1 + " = ");
                // compile error: cannot use - operator with strings, thus need to surround i - 1 with parentheses  
                Console.Write(i + "/" + (i - 1) + " = ");

                // output the calculation based on the numbers
                // Console.WriteLine(i / (i - 1));
                // runtime error: DivideByZero with i = 1 if i is declared as int instead of double
                try 
                {
                    // output calculation based on the numbers
                    Console.WriteLine(i / (i - 1));
                } 
                catch (DivideByZeroException)
                {
                    // tell the user that a divide by zero error occurs
                    Console.WriteLine("Error! Cannot divide by zero!");
                }

                // concatenate each number to allNumbers
                allNumbers += i + " ";

                // increment the counter
                // i = i + 1;
                // logic error: unneccessary incrementation as i will increment as part of the for loop
            }

            // output all numbers which have been processed
            // Console.WriteLine("These numbers have been processed: " allNumbers);
            // logic error: missing + between end of quotation and string variable allNumbers
            Console.WriteLine("These numbers have been processed: " + allNumbers);
        }
    }
}
