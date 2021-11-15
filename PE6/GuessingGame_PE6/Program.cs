using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame_PE6
{
    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Practice parsing and formatting in a guessing game using a random number generator
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: A guessing game based on a random number generator
        //          Will ask the user to guess the number within 8 attempts
        // Restrictions: None
        static void Main(string[] args)
        {
            Random rand = new Random();

            // generate a random number between 0 inclusive and 101 exclusive
            int randomNumber = rand.Next(0, 101);

            // Print the random number at the top of the program for testing purposes, comment out the code if running for others
            Console.WriteLine(randomNumber);

            // declare an int variable that will store the user's guess
            int userGuess;

            // initialize a boolean value that will be used for an internal while loop within the for loop for the game
            bool bValid = false;

            // initialize a counter to check if the user has taken used all 8 of their turns
            int guessCounter = 0;

            // for loop to run the code that will prompt the user for their guess of the random number
            for (int i = 1; i <= 8; i++) 
            { 
                // while loop in case the user enters a value that is an invalid guess
                while (!bValid) 
                { 
                    // try catch in case the user enters a string or decimal value instead of an int
                    try 
                    {
                        // prompt the user for an input
                        Console.Write("Turn #" + i + ": Enter your guess: ");

                        // store the user guess to check if it is out of range, and if not then if it is too high, too low, or equal to the random number
                        userGuess = Convert.ToInt32(Console.ReadLine());

                        // if statement to determine if the value is out of range, is too high, or too low
                        if (userGuess < 0 || userGuess > 100) 
                        {
                            // tell the user they have made an invalid guess and repeat the guess attempt
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Invalid guess - try again.");

                            // return the console color to its orignal color
                            Console.ForegroundColor = ConsoleColor.White;

                            // keep bValid as false to repeat within the while loop
                            bValid = false;
                        } 
                        else if (userGuess > randomNumber) 
                        {
                            // tell the user that their guess is too high 
                            Console.WriteLine("Too high");

                            // set bValid to be true to exit out of the while loop
                            bValid = true;    
                        }
                        else if (userGuess < randomNumber) 
                        {
                            // tell the user that their guess is too low
                            Console.WriteLine("Too low");

                            // set bValid to be true to exit out of the while loop
                            bValid = true;
                        } 
                        else 
                        {
                            // congratulate the user on guessing the number correctly
                            Console.WriteLine(" ");
                            Console.WriteLine("Correct! You won in " + i + " turns.");

                            // set i = 8 if they guessed correctly to exit out of the for loop
                            i = 8;

                            // set bValid to true to exit out of the while loop as well
                            bValid = true;
                        }
                    }
                    catch
                    {
                        // tell the user that their guess is invalid
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Invalid guess - try again.");

                        // return the console color to its original state
                        Console.ForegroundColor = ConsoleColor.White;

                        // set bValid to false to remain in the while loop
                        bValid = false;
                    }
                }

                // increment the guess counter every time the user has escaped the while loop
                guessCounter++;

                // if the counter has reached 8 then tell the user that they have used up all of their turns
                if (guessCounter == 8) 
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("You ran out of turns. The number was " + randomNumber + ".");
                }

                // set bValid back to false to return to the while loop for the next for loop iteration
                bValid = false;
            }
        }
    }
}
