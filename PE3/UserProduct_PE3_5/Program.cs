using System;

namespace UserProduct_PE3_5
{
    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Practice converting and manipulating user inputs
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Ask user to input 4 integers
        //          Convert the integers from strings to int
        //          Multiply the 4 integers and display the product
        // Restrictions: Only takes integers as inputs
        static void Main(string[] args)
        {
            // create four int variables that will store the user input after converting from string to int
            int userNumOne = 0;
            int userNumTwo = 0;
            int userNumThree = 0;
            int userNumFour = 0;

            // create a boolean to use for while loop 
            bool bValid = false;

            // while loop to check for user error in case they mistakenly enter an incorrect value
            while (!bValid)
            {
                // use a try catch to check for any error in inputs
                try
                {
                    // prompt for first integer
                    Console.Write("Please enter your first integer: ");

                    // read the user input and convert to int variable
                    userNumOne = Convert.ToInt32(Console.ReadLine());

                    // prompt for second integer
                    Console.Write("Please enter your second integer: ");

                    // read and convert user input
                    userNumTwo = Convert.ToInt32(Console.ReadLine());

                    // prompt for third integer
                    Console.Write("Please enter your third integer: ");

                    // read and convert user input
                    userNumThree = Convert.ToInt32(Console.ReadLine());

                    // prompt for fourth integer
                    Console.Write("Please enter your fourth integer: ");

                    // read and convert user input
                    userNumFour = Convert.ToInt32(Console.ReadLine());

                    // set bValid to true if no errors occurred to escape the while loop
                    bValid = true;
                }
                catch
                {
                    // inform the user they made a mistake
                    Console.WriteLine("That is not an integer! Now you have to start over!");

                    // keep bValid as false to continue the loop until the user has properly completed entering the four integers
                    bValid = false;
                }
            }

            // Write to the console the product of the four user integers
            Console.WriteLine("The product of your four integers is " + (userNumOne * userNumTwo * userNumThree * userNumFour) + "!");
        }
    }
}
