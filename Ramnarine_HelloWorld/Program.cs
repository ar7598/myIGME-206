using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramnarine_HelloWorld
{
    // Class Program
    // Author: Ajay Ramnarine
    // Purpose: Contain comments to answer questions for PE1 as well as containing the main method which holds the code to be ran for PE1
    // Restrictions: None
    class Program
    {
        // What is the keyboard shortcut for "Build Solution" on your computer?
        // Ctrl + Shift + B

        // What is the keyboard shortcut for "Start Debugging" on your computer?
        // F5

        // Why do you think the program closed?
        // I belive the program closed because there is no code to be ran/prompt for user input currently (at the time of typing out this answer), therefore the window doesn't need to stay open.

        // What is the shortcut for "Start without Debugging" on your computer?
        // Ctrl + F5

        // Method: Main
        // Purpose: Contain code to be ran for PE1 as well as any practice code to learn the syntax of C#
        // Restrictions: Ending while loop runs into unexpected addition error, therefore has been commented out
        static void Main(string[] args)
        {
            // Practice writing to the console using the phrase "Hello World!"
            // Console.WriteLine("Hello World!");

            // Changing "Hello World!" to my name
            Console.WriteLine("Ajay Ramnarine");

            // Initialize an int variable to be used for math calculations
            int firstNum = 10;

            // Initialize a double variable to be used for calculations with the previous int
            double secondNum = 4.2;

            // Print to the console the product of firstNum and secondNum
            Console.WriteLine(firstNum*secondNum);

            // Print to the console the sum of firstNum and secondNum
            Console.WriteLine((firstNum + secondNum));

            // Implicitly cast a double variable
            double thirdNum = 6;

            // Explicitly cast secondNum to new int
            int fourthNum = (int)secondNum;

            // Print to the console the sum of thirdNum and fourthNum
            Console.WriteLine(thirdNum + fourthNum);

            // Check to see if the sum of thirdNum and fourthNum are equal to firstNum and print a statement to the console if they are
            if (firstNum == (thirdNum + fourthNum)) 
            {
                Console.WriteLine("Wow! They are the same value!");
            }
            else 
            {
                Console.WriteLine("Too bad!");
            }


            /* Was going to write a while loop to increment secondNum to eventually equal thirdNum through increments of 0.1.
            Initialized a variable i that would increment within the while loop to count the amount of loops that have occured.
            Interestingly the while loop would not complete, so I decided to debug the code (creating a breakpoint at the line secondNum += 0.1).
            The debug menu showed that the value of secondNum would become 4.3 and then 4.3999999..., and that ending value would continue to change throughout the loop.
            The value of secondNum would eventually become 6.09999999...  instead of reaching the value of 6.
            When incremented by 0.1f, the value would become 4.3000000014... instead of 4.3, and so on past the value of 6.
            Therefore the while loop would never reach a state where the statement becomes false, and would continue to loop.
            I'm not entirely sure why this occurs, and google doesn't seem to have any answers as well. */ 

            // Initialize an int that will count the amount of times the while statement has looped
            // int i = 0;

            // Increment secondNum to equal thirdNum and tell the user how many times they have looped after each loop
            // do
            // {
                // Increment secondNum to reach the value of thirdNum
                // secondNum += 0.1;

                // Increment i to count the amount of loops that have occured
                // i++;
            // } while (!(secondNum == thirdNum));

            // Congratulate the user on making it out of the while loop and tell them how many times they have looped
            // Console.WriteLine("Congratulations! You looped " + i + " times!");


        }
    }
}
