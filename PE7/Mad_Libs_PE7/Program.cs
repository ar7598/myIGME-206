using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mad_Libs_PE7
{
    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Create a Mad Lib game to practice working with strings, lists, and input/output
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Use input/output to open and store the stories from the MadLibsTemplate.txt file
        //          Ask the user to choose a story from the list of stories
        //          Prompt the user to fill in the Mad Libs where appropriate
        // Restrictions: None
        static void Main(string[] args)
        {
            // initialize int variable to count number of Mad Libs in txt file
            int numLibs = 0;

            // initialize int variable as counter to sort through array that will store the Mad Libs
            int counter = 0;

            // initialize int variable for user input
            int userChoice = 0;

            // declare string variable to hold the users name
            string userName;

            // open the template file to count how many Mad Libs are contained in the file
            StreamReader input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");

            // count the number of Mad Libs in txt file
            string line = null;
            while((line = input.ReadLine()) != null) 
            {
                ++numLibs;
            }

            // close the file
            input.Close();

            // string array to allocate as many strings as there are Mad Libs
            string[] madLibs = new string[numLibs];

            // read the Mad Libs into the array of strings
            input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");

            // read each line out of the file into the madLibs array
            line = null;
            while((line = input.ReadLine()) != null) 
            {
                // set current array element to the current line of the txt file
                madLibs[counter] = line;

                // replace the "\\n" tag with the newline escape character
                madLibs[counter] = madLibs[counter].Replace("\\n", "\n");

                // increment the counter to go to the next Mad Lib in the array
                ++counter;
            }

            // close the file
            input.Close();

            // prompt the user for their name
            Console.Write("Hello! Please enter your name here: ");
            userName = Console.ReadLine();

            // ask the user if they would like to play Mad Libs
            Console.Write("Hello, " + userName + "! Would you like to play Mad Libs? ");

            string userResponse = Console.ReadLine();

            // create a boolean value to be used for a while loop to check for error of user input
            bool bValid = false;

            // create a while loop to check to see if the user has responded yes or no
            while (!bValid)
            {
                if (userResponse.ToLower() == "yes")
                {

                    // prompt the user for which Mad Lib they want to play
                    Console.Write("Excellent! Please enter the number of the Mad Lib you would like to use: ");

                    // create a boolean value to check if the user has input a number within range of the number of Mad Libs
                    bool userNumError = false;

                    // while loop to check for user error and to reprompt them for the Mad Lib they would like to use
                    while (!userNumError)
                    {
                        // try catch to check if the user has entered an appropriate int value
                        try
                        {
                            // store the users choice of Mad Lib
                            userChoice = Convert.ToInt32(Console.ReadLine());

                            // use if statement to see if the users choice is out of range of the number of Mad Libs available
                            if (userChoice <= 0 || userChoice > numLibs)
                            {
                                // inform the user that their input is out of range and tell them how many Mad Libs are available
                                Console.WriteLine("Uh-oh! There are only 1 through " + numLibs + " Mad Libs available.");

                                // reprompt the user for their choice
                                Console.Write("Please enter the number of the Mad Lib you would like to use: ");

                                // set userNumError as false to return to the top of the while loop
                                userNumError = false;
                            }
                            else
                            {
                                // set userNumError to true to continue with the program
                                userNumError = true;
                            }
                        }
                        catch
                        {
                            // inform the user that they need to enter a full integer as an input
                            Console.WriteLine("Uh-oh! You need to enter an integer to select your Mad Lib.");

                            // reprompt the user for their choice
                            Console.Write("Please enter the number of the Mad Lib you would like to use: ");

                            // set userNumError to false to return to the top of the while loop
                            userNumError = false;
                        }
                    }

                    // create a result string that will hold the Mad Lib including the user inputs
                    string resultString = null;

                    // split the Mad Lib into separate words
                    string[] words = madLibs[(userChoice - 1)].Split(' ');

                    // loop through each word of the story
                    foreach (string word in words)
                    {
                        // initialize char array to contain characters that will be trimmed from placeholder words
                        char[] trimPlaceHolder = { '{', '}' };

                        // if word is a placeholder, prompt the user for the replacement
                        if (word[0] == '{')
                        {
                            // replace the '_' character with a space within the placeholder word
                            string placeHolder = word.Replace('_', ' ');

                            //check to see if the placeholder has a comma attached to the end of it
                            if (placeHolder.EndsWith(","))
                            {
                                // trim the punctuation off of the end of the placeholder
                                placeHolder = placeHolder.Trim(',');

                                // trim the curly braces off of the placeholder word
                                placeHolder = placeHolder.Trim(trimPlaceHolder);

                                // prompt the user to enter their word for the placeholder
                                Console.Write(placeHolder + ": ");

                                // create a string to save the users entered word
                                string userWord = Console.ReadLine();

                                // append a comma to the end of the user word
                                userWord += ",";

                                // append the user response to the result string
                                resultString += userWord;

                            }
                            else 
                            {
                                // trim the curly braces off of the placeholder word
                                placeHolder = placeHolder.Trim(trimPlaceHolder);

                                // prompt the user to enter their word for the placeholder
                                Console.Write(placeHolder + ": ");

                                // create a string to save the users entered word
                                string userWord = Console.ReadLine();

                                // append the user response to the result string
                                resultString += userWord;
                            }

                            // append a space after the word
                            resultString += " ";
                        }
                        else if (word == "\n")
                        {
                            // append the new line character to the result string
                            resultString += "\n";

                            // append a space after the word
                            resultString += " ";
                        }
                        else
                        {
                            // append word to the result string
                            resultString += word;

                            // append a space after the word
                            resultString += " ";
                        }
                    }

                    // print a gap between the Mad Lib fill in and the full story at the end
                    Console.WriteLine(" ");

                    // print the full story to the console after the user has finshed their Mad Lib
                    Console.WriteLine(resultString);

                    // create a boolean value to check to see if the user wants to play again
                    bool repeatPlay = false;

                    // create a while loop to see if the user wants to play again
                    while (!repeatPlay)
                    {
                        // ask the user if they would like to play again
                        Console.WriteLine(" ");
                        Console.Write("Would you like to play again? ");

                        userResponse = Console.ReadLine();

                        if (userResponse.ToLower() == "yes")
                        {
                            // set repeatPlay to true to exit the inner while loop
                            repeatPlay = true;

                            // set bValid to false to remain in the outer while loop
                            bValid = false;
                        }
                        else if (userResponse.ToLower() == "no")
                        {
                            // tell the user goodbye and exit the program
                            Console.WriteLine("Goodbye!");

                            // set repeatPlay to true to exit the inner while loop
                            repeatPlay = true;

                            //set bValid to true to exit the loop
                            bValid = true;
                        }
                        else 
                        {
                            // tell the user they have made an error in choosing to play again or not
                            Console.WriteLine("Uh-oh! Was that a yes or a no to playing again?");

                            // set repeatPlay to false to ask the user if they would like to play again
                            repeatPlay = false;
                        }
                    }

                }
                else if (userResponse.ToLower() == "no")
                {
                    // tell the user goodbye and exit the program
                    Console.WriteLine("Goodbye!");

                    //set bValid to true to exit the loop
                    bValid = true;
                }
                else 
                {
                    // tell the user to enter yes or no
                    Console.WriteLine("Uh-oh! That wasn't a yes or no!");

                    // reprompt user to ask if they would like to play Mad Libs
                    Console.Write("Would you like to play Mad Libs? ");

                    // store new input into userResponse
                    userResponse = Console.ReadLine();

                    // keep bValid as false to remain in while loop
                    bValid = false;
                }
            }

            Environment.Exit(0);
        }
    }
}
