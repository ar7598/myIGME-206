using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT1_3Questions
{
    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Recreate the 3questions.exe file
    // Restrictions: None
    class Program
    {
        // set up a timer to be used
        private static System.Timers.Timer timer;

        // string variable that will hold the correct answer to the chosen question
        static string sAnswer = "";

        // bool to check if the timer has elapsed
        static bool bTimeOut = false;

        // Method: Main
        // Purpose: Ask the user which question they would like to be asked (1-3)
        //          They have 5 seconds to answer each question
        //          If they got it wrong, tell them what the answer is, otherwise congratulate them
        //          Prompt the user to ask if they would like to play again
        // Restrictions: None
        static void Main(string[] args)
        {
            // create a timer and set up a 5 second interval
            timer = new System.Timers.Timer();
            timer.Interval = 5000;

            // attach an elapsed event for the timer
            timer.Elapsed += OnTimedEvent;

            // declare string and number variable to check for user input
            int nQChoice = 0;
            string sQChoice = "";

            // create a string variable that will be used to store the user's answer to the questions
            string sUserAnswer = "";

            

            // bool to check if the user has input a correct number for choice of question
            bool bValidChoice = false;

            // bool to check if the user has input a valid response
            bool bValidAns = false;

            // bool to check if the user wants to play again
            bool bPlayAgain = false;

            // string to check user input if they want to play again
            string sPlayAgain = "";


            start:

            // ask the user to choose a question (1-3)
            do
            {
                // ask the user to choose a question
                Console.Write("Choose your question (1-3): ");
                sQChoice = Console.ReadLine();

                try
                {
                    // parse the user choice into an int
                    nQChoice = Int32.Parse(sQChoice);

                    // check to see if choice is above or below the question choices
                    if (nQChoice > 3 || nQChoice <= 0)
                    {
                        bValidChoice = false;
                    }
                    else
                    {
                        bValidChoice = true;
                    }
                }
                catch
                {
                    bValidChoice = false;
                }

            } while (!bValidChoice);

            do
            {
                // once they have chosen a number, tell them "You have 5 seconds to answer the following question:"
                Console.WriteLine("You have 5 seconds to answer the following question:");

                // initialize time out boolean
                bTimeOut = false;

                // start the timer
                timer.Start();

                // Question 1
                if (nQChoice == 1)
                {
                    // What is your favorite color? 
                    Console.WriteLine("What is your favorite color?");

                    // correct answer is black
                    sAnswer = "black";

                    // prompt the user to enter their answer
                    sUserAnswer = Console.ReadLine();

                    // stop the timer when the user presses enter
                    timer.Stop();

                    if (bTimeOut)
                    {
                        break;
                    }


                    // check the answer of the user
                    if (!sAnswer.Equals(sUserAnswer))
                    {
                        // tell the user they are incorrect and what they answer is
                        Console.WriteLine("Wrong! The answer is: {0}", sAnswer);

                        // set bValidAns to true to break out of loop
                        bValidAns = true;

                    }
                    else if (sAnswer.Equals(sUserAnswer))
                    {
                        // congratulate the user
                        Console.WriteLine("Well done!");

                        // set bValidAns to true to break out of loop
                        bValidAns = true;

                    }

                }
                // Question 2
                else if (nQChoice == 2)
                {
                    // What is the answer to life, the universe and everything? 
                    Console.WriteLine("What is the answer to life, the universe and everything?");

                    // correct answer is 42
                    sAnswer = "42";

                    // prompt the user to enter their answer
                    sUserAnswer = Console.ReadLine();

                    // stop the timer when the user presses enter
                    timer.Stop();

                    if (bTimeOut)
                    {
                        break;
                    }


                    // check the answer of the user
                    if (!sAnswer.Equals(sUserAnswer))
                    {
                        // tell the user they are incorrect and what they answer is
                        Console.WriteLine("Wrong! The answer is: {0}", sAnswer);

                        // set bValidAns to true to break out of loop
                        bValidAns = true;

                    }
                    else if (sAnswer.Equals(sUserAnswer))
                    {
                        // congratulate the user
                        Console.WriteLine("Well done!");

                        // set bValidAns to true to break out of loop
                        bValidAns = true;

                    }

                }
                // Question 3
                else 
                {
                    // What is the airspeed velocity of an unladen swallow? 
                    Console.WriteLine("What is the airspeed velocity of an unladen swallow?");

                    // correct answer is "What do you mean? African or European swallow?"
                    sAnswer = "What do you mean? African or European swallow?";

                    // prompt the user to enter their answer
                    sUserAnswer = Console.ReadLine();

                    // stop the timer when the user presses enter
                    timer.Stop();

                    if (bTimeOut)
                    {
                        break;
                    }


                    // check the answer of the user
                    if (!sAnswer.Equals(sUserAnswer))
                    {
                        // tell the user they are incorrect and what they answer is
                        Console.WriteLine("Wrong! The answer is: {0}", sAnswer);

                        // set bValidAns to true to break out of loop
                        bValidAns = true;

                    }
                    else if (sAnswer.Equals(sUserAnswer))
                    {
                        // congratulate the user
                        Console.WriteLine("Well done!");

                        // set bValidAns to true to break out of loop
                        bValidAns = true;

                    }

                }
                
            } while (!bValidAns);

            // ask if they would like to play again (should check for yes, no, y, and n)
            do 
            {
                Console.Write("Play again? ");
                sPlayAgain = Console.ReadLine();

                // check to see if the user has input a valid response
                if (sPlayAgain.ToLower().StartsWith("y"))
                {
                    Console.WriteLine("");
                    goto start;

                }
                else if (sPlayAgain.ToLower().StartsWith("n"))
                {
                    break;
                }
                else 
                {
                    bPlayAgain = false;
                }

            } while (!bPlayAgain);

        }

        // Method: OnTimedEvent
        // Purpose: event that is elapsed every 5 seconds once the timer is enabled
        // Restrictions: None
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            // Tell the user that their time is up
            Console.WriteLine("Time's up!");
            Console.WriteLine("The answer is: {0}", sAnswer);
            Console.WriteLine("Please press enter.");

            // set the boolean for the timer to be true
            bTimeOut = true;

            timer.Stop();
        }
    }
}
