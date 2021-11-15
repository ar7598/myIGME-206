using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordQuotes_PE8_9
{
    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Practice string manipulation by taking a user input string and putting quotes around each word
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Ask the user to input a string
        //          Split each word in the string and add quotation marks around each
        //          Concatenate each word back into a single string and print it to the console
        // Restrictions: None
        static void Main(string[] args)
        {
            // ask the user to input a string
            Console.Write("Type anything you want: ");

            // store the user string into a string variable
            string userString = Console.ReadLine();

            // split the string into an array of words
            string[] words = userString.Split(' ');

            // create a new string that will store the words after quotations have been added to each
            string quoteString = null;

            // for each word, add quotations around it
            foreach (string word in words)
            {
                // if the word has any punctuation, then remove the punctuation
                if (word.EndsWith(","))
                {
                    // create a new string to take the place of the current word of the array and trim any punctuation from the end of it
                    string currentWord = word.Trim(',');

                    // add the quotations around the word
                    currentWord = currentWord.PadLeft(currentWord.Length + 1, '\"');
                    currentWord += "\"";

                    // reattach the punctuation
                    currentWord += ",";

                    // concatenate the word into the new string
                    quoteString += currentWord;

                    // add a space after the word has been added into the string
                    quoteString += " ";
                }
                else if (word.EndsWith(".")) 
                {
                    // create a new string to take the place of the current word of the array and trim any punctuation from the end of it
                    string currentWord = word.Trim('.');

                    // add the quotations around the word
                    currentWord = currentWord.PadLeft(currentWord.Length + 1, '\"');
                    currentWord += "\"";

                    // reattach the punctuation
                    currentWord += ".";

                    // concatenate the word into the new string
                    quoteString += currentWord;

                    // add a space after the word has been added into the string
                    quoteString += " ";
                }
                else if (word.EndsWith("!")) 
                {
                    // create a new string to take the place of the current word of the array and trim any punctuation from the end of it
                    string currentWord = word.Trim('!');

                    // add the quotations around the word
                    currentWord = currentWord.PadLeft(currentWord.Length + 1, '\"');
                    currentWord += "\"";

                    // reattach the punctuation
                    currentWord += "!";

                    // concatenate the word into the new string
                    quoteString += currentWord;

                    // add a space after the word has been added into the string
                    quoteString += " ";
                }
                else if (word.EndsWith("?")) 
                {
                    // create a new string to take the place of the current word of the array and trim any punctuation from the end of it
                    string currentWord = word.Trim('?');

                    // add the quotations around the word
                    currentWord = currentWord.PadLeft(currentWord.Length + 1, '\"');
                    currentWord += "\"";

                    // reattach the punctuation
                    currentWord += "?";

                    // concatenate the word into the new string
                    quoteString += currentWord;

                    // add a space after the word has been added into the string
                    quoteString += " ";
                }
                else 
                {
                    // create a new string to take the place of the current word of the array
                    string currentWord = word;

                    // add the quotations around the word
                    currentWord = currentWord.PadLeft(currentWord.Length + 1, '\"');
                    currentWord += "\"";

                    // concatenate the word into the new string
                    quoteString += currentWord;

                    // add a space after the word has been added into the string
                    quoteString += " ";
                }
            }

            // print the new string to the console
            Console.WriteLine(quoteString);
        }
    }
}
