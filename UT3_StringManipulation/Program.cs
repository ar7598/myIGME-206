using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT3_StringManipulation
{
    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Prompt the user for a string and print the different manipulations to the console
    // Restrictions: None
    class Program
    {
        
        // Method: Main
        // Purpose: Prompt the user for a string
        //          Print how many of each letter of the alphabet are in the string (case insensitive)
        //          Print the string in reverse order
        //          Test if the string is a palindrome
        //Restrictions: None
        static void Main(string[] args)
        {

            // array of chars to check for each letter of the alphabet within the user input string
            char[] alphabet = new char[]
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            };

            // parallel array of ints that will increment based on the number of times the letter appears within the user input string
            int[] letterCounter = new int[]
            { 
                /*a*/ 0,
                /*b*/ 0,
                /*c*/ 0,
                /*d*/ 0,
                /*e*/ 0,
                /*f*/ 0,
                /*g*/ 0,
                /*h*/ 0,
                /*i*/ 0,
                /*j*/ 0,
                /*k*/ 0,
                /*l*/ 0,
                /*m*/ 0,
                /*n*/ 0,
                /*o*/ 0,
                /*p*/ 0,
                /*q*/ 0,
                /*r*/ 0,
                /*s*/ 0,
                /*t*/ 0,
                /*u*/ 0,
                /*v*/ 0,
                /*w*/ 0,
                /*x*/ 0,
                /*y*/ 0,
                /*z*/ 0
            };

            // string variable to hold the user input
            string userInput = null;

            // string variable to hold the user input without any punctuation or spaces
            string uInputOnlyLetters = null;

            // string variable to hold the reverse of the user input to test for palindrome
            string reverseInput = null;

            // bool to check if the users string contains any numbers
            bool isNumber = true;

            // Prompt the user for a string
            while (isNumber)
            {
                Console.Write("Please enter a string: ");
                userInput = Console.ReadLine();

                // check if userInput has any numbers
                // if it does, reprompt them for a new string
                if (userInput.Any(char.IsDigit)) 
                {
                    Console.WriteLine("Please make sure not to enter any numbers in your string.");
                    Console.WriteLine(" ");

                    // set isNumber to true to reprompt the user for a string
                    isNumber = true;
                }
                else 
                {
                    // set isNumber to false if the user has input a string without any numbers
                    isNumber = false;
                }

            }

            // Count how many of each letter of the alphabet are in the string
            foreach(char letter in userInput) 
            {
                for(int i = 0; i < 26; i++) 
                {
                    // use ToLower to make sure that the check is case insensitive
                    if (Char.ToLower(letter).Equals(alphabet[i])) 
                    {
                        ++letterCounter[i];

                        // make the letter lowercase
                        char lowercaseLetter = Char.ToLower(letter);

                        // add that letter to uInputOnlyLetters to be used to check for palindromes later
                        uInputOnlyLetters += lowercaseLetter;
                    }
                }
            }
            
            // print how many of each letter are within the string
            for(int i = 0; i < 26; i++) 
            {
                Console.WriteLine("{0}: {1}", alphabet[i], letterCounter[i]);

                // reset letterCounter to 0 for each letter of the alphabet
                letterCounter[i] = 0;
            }

            // Print the string in reverse order
            for(int i = (userInput.Length - 1); i >= 0; --i) 
            {
                Console.Write(userInput[i]);

                // inner for loop to check the letter with the alphabet array
                for (int j = 0; j < 26; j++)
                {
                    // check each char in the string to see if it's a letter
                    if (Char.ToLower(userInput[i]).Equals(alphabet[j]))
                    {
                        // make the letter of the userInput to lowercase
                        char lowercaseLetter = Char.ToLower(userInput[i]);

                        // add that letter to the reverseInput string
                        reverseInput += lowercaseLetter;
                    }
                }
            }

            // Create a space between the printing of the reverse string and the palindrome test
            Console.WriteLine(" ");

            // Test if palindrome
            if (uInputOnlyLetters.Equals(reverseInput)) 
            {
                Console.WriteLine("Your input is a palindrome!");
            }
            else 
            {
                Console.WriteLine("This is not a palindrome!");
            }

        }
    }
}
