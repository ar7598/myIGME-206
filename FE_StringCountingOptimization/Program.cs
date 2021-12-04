using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE_StringCountingOptimization
{
    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Create a better data-oriented version of UT3 Q1b that prints how many of each letter are within a user entered string
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Call both methods for the older version of UT3 Q1b and the new version to prove the performance has been improved
        // Restrictions: None
        static void Main(string[] args)
        {
            // call the method that contains the old code for UT3 Q1b and check its performance in the profiler
            //UT3Q1();
            // Based on profiler, the code has an average exclusive elapsed time of 679.38ms

            // call the method that contains the updated code with better performance
            ImprovedUT3Q1();
            // Based on profiler, the code has an average exclusive elapsed time of 155.70ms

            /*
             I believe the main difference for the elapsed time between the original code and the updated code has to do with the use of a sorted list

             The original code was set to check each letter of the string against an array of chars containing each letter of the alphabet
             Afterwards, if a match was found, the code would move to an int array and would use the index from the first array to increment the corresponding int in the second array
             That means there would be time spent traversing between the two arrays for each letter within the string, which would take some time to get through each
             
             In the case of the updated code, a sorted list was used instead of two parallel arrays
             For each letter in the string, the sorted list would either create a new instance of a char-int pair, or increment an already existing instance within the list
             This means that the code would only have to check one place to increment instead of jumping from one array to another
             Afterwards, the code can print the information from the sorted list instead of printing from two arrays
             */
        }

        // Method: UT3Q1
        // Purpose: A copy of the code used for Q1b of UT3 that counts each letter within an entered string and prints how many of each letter are present
        // Restrictions: None
        static void UT3Q1() 
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

            // bool to check if the users string contains any numbers
            bool isNumber = true;

            // uncomment this section of code to prompt the user to input a string
            // for testing purposes, this section will be commented out to instead create a random assortment of 200000 letters
            /*
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
            */

            // this block of code will be used to test the performance of the code from UT3 Q1b
            // create a random assortment of 200000 letters that will be counted 
            Random rand = new Random();

            for(int i = 0; i < 200000; ++i) 
            {
                userInput += (char)(rand.Next(26) + 'a');
            }

            // Count how many of each letter of the alphabet are in the string
            foreach (char letter in userInput)
            {
                for (int i = 0; i < 26; i++)
                {
                    // use ToLower to make sure that the check is case insensitive
                    if (Char.ToLower(letter).Equals(alphabet[i]))
                    {
                        ++letterCounter[i];
                    }
                }
            }

            // print how many of each letter are within the string
            for (int i = 0; i < 26; i++)
            {
                Console.WriteLine("{0}: {1}", alphabet[i], letterCounter[i]);

                // reset letterCounter to 0 for each letter of the alphabet
                letterCounter[i] = 0;
            }
        }

        // Method: ImprovedUT3Q1
        // Purpose: Improve upon the performance of the code from the UT3Q1 method
        // Restrictions: None
        static void ImprovedUT3Q1() 
        {
            // string that will hold the characters to be counted
            string sentence = null;

            // sorted list that will keep count of each specific character in the string
            SortedList<char, int> charCount = new SortedList<char, int>();

            // random variable that will create a random assortment of characters for the string
            Random rand = new Random();

            // uncomment this section of code to prompt the user to input a string
            // for testing purposes, this section will be commented out to instead create a random assortment of 200000 letters
            /*
            
            // bool to check if the users string contains any numbers
            bool isNumber = true; 
             
            // Prompt the user for a string
            while (isNumber)
            {
                Console.Write("Please enter a string: ");
                sentence = Console.ReadLine();

                // check if userInput has any numbers
                // if it does, reprompt them for a new string
                if (sentence.Any(char.IsDigit))
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
            */

            // create a random assortment of 200000 characters to be stored in the sentence string
            for(int i = 0; i < 200000; ++i) 
            {
                sentence += (char)(rand.Next(26) + 'a');
            }

            // count how many of each character are within the string and store them in the sorted list
            foreach(char c in sentence.ToLower()) 
            {
                // checks to see if the character in the sentence is a letter
                if (Char.IsLetter(c))
                {
                    // checks to see if the sorted list contains the letter already to increase the count of the letter
                    // if it does not already contain the letter then it sets the count of that letter to one
                    if (charCount.ContainsKey(c)) 
                    {
                        ++charCount[c];
                    }
                    else 
                    {
                        charCount[c] = 1;
                    }
                }
            }

            Console.WriteLine("Character Counts: ");

            // print the amount of each character present in the string
            foreach(KeyValuePair<char, int> kvp in charCount) 
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
