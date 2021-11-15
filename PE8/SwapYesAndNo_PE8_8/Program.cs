using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapYesAndNo_PE8_8
{
    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Practice string manipulation by taking user input and replacing instances of the word "no" with "yes"
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Ask user to input a string
        //          Look through the user's string for all instances of the word "no" and replace them with "yes"
        //          Print the converted string to the console
        // Restrictions: None
        static void Main(string[] args)
        {
            // ask the user to input a string
            Console.WriteLine("Please enter a sentence: ");

            // store the user string into a variable
            string userInput = Console.ReadLine();

            // create a new string variable that will be used to store the user input after swapping all instances of "no" with "yes"
            string userInputSwap = null;

            // split the user input into separate words
            string[] words = userInput.Split(' ');

            // initialize a string to replace words
            string wordReplace = null;

            // initailize a string to check the current word
            string currentWord = null;

            // loop through each word of the user input to look for all instances of "no"
            foreach (string word in words)
            {
                // check if word starts with quotation mark, but doesn't end with one
                if (word.StartsWith("\"") && !word.EndsWith("\""))
                {
                    // trim the word of the quotation mark
                    currentWord = word.Trim('\"');

                    // check if "no" is followed by some sort of punctuation (e.g. "," or ".")
                    if (currentWord == "no," || currentWord == "no." || currentWord == "no" || currentWord == "no?" || currentWord == "no!")
                    {
                        // check for punctuation
                        if (currentWord.EndsWith(","))
                        {
                            // replace "no," with "yes,"
                            wordReplace = "yes,";
                        }
                        else if (currentWord.EndsWith("."))
                        {
                            // replace "no." with "yes."
                            wordReplace = "yes.";
                        }
                        else if (currentWord.EndsWith("?"))
                        {
                            // replace "no?" with "yes?"
                            wordReplace = "yes?";
                        }
                        else if (currentWord.EndsWith("!"))
                        {
                            // replace "no!" with "yes!"
                            wordReplace = "yes!";
                        }
                        else
                        {
                            // replace "no" with "yes"
                            wordReplace = "yes";
                        }

                        // pad and add the quotation mark back to the beginning of the wordReplace string
                        wordReplace = wordReplace.PadLeft(wordReplace.Length + 1, '\"');

                        // concatenate word onto the end of the userInputSwap string
                        userInputSwap += wordReplace;

                        // concatenate a space afterwards
                        userInputSwap += " ";
                    }
                    else if (currentWord == "No," || currentWord == "No." || currentWord == "No" || currentWord == "No?" || currentWord == "No!")
                    {
                        // check for punctuation
                        if (currentWord.EndsWith(","))
                        {
                            // replace "No," with "Yes,"
                            wordReplace = "Yes,";
                        }
                        else if (currentWord.EndsWith("."))
                        {
                            // replace "No." with "Yes."
                            wordReplace = "Yes.";
                        }
                        else if (currentWord.EndsWith("?"))
                        {
                            // replace "No?" with "Yes?"
                            wordReplace = "Yes?";
                        }
                        else if (currentWord.EndsWith("!"))
                        {
                            // replace "No!" with "Yes!"
                            wordReplace = "Yes!";
                        }
                        else
                        {
                            // replace "No" with "Yes"
                            wordReplace = "Yes";
                        }

                        // pad and add the quotation mark back to the beginning of the wordReplace string
                        wordReplace = wordReplace.PadLeft(wordReplace.Length + 1, '\"');

                        // concatenate word onto the end of the userInputSwap string
                        userInputSwap += wordReplace;

                        // concatenate a space afterwards
                        userInputSwap += " ";
                    }
                    else if (currentWord == "NO," || currentWord == "NO." || currentWord == "NO" || currentWord == "NO?" || currentWord == "NO!")
                    {
                        // check for punctuation
                        if (currentWord.EndsWith(","))
                        {
                            // replace "NO," with "YES,"
                            wordReplace = "YES,";
                        }
                        else if (currentWord.EndsWith("."))
                        {
                            // replace "NO." with "YES."
                            wordReplace = "YES.";
                        }
                        else if (currentWord.EndsWith("?"))
                        {
                            // replace "NO?" with "YES?"
                            wordReplace = "YES?";
                        }
                        else if (currentWord.EndsWith("!"))
                        {
                            // replace "NO!" with "YES!"
                            wordReplace = "YES!";
                        }
                        else
                        {
                            // replace "NO" with "YES"
                            wordReplace = "Yes";
                        }

                        // pad and add the quotation mark back to the beginning of the wordReplace string
                        wordReplace = wordReplace.PadLeft(wordReplace.Length + 1, '\"');

                        // concatenate word onto the end of the userInputSwap string
                        userInputSwap += wordReplace;

                        // concatenate a space afterwards
                        userInputSwap += " ";
                    }
                    else
                    {
                        // pad and add the quotation mark back to the beginning of the word string
                        currentWord = currentWord.PadLeft(currentWord.Length + 1, '\"');

                        // if the word is not "no" then concatenate it onto the userInputSwap string
                        userInputSwap += currentWord;

                        // concatenate a space afterwards
                        userInputSwap += " ";
                    }
                }
                // check if word ends with quotation mark, but doesn't start with one
                else if (word.EndsWith("\"") && !word.StartsWith("\""))
                {
                    // trim the word of the quotation mark
                    currentWord = word.Trim('\"');

                    // check if "no" is followed by some sort of punctuation (e.g. "," or ".")
                    if (currentWord == "no," || currentWord == "no." || currentWord == "no" || currentWord == "no?" || currentWord == "no!")
                    {
                        // check for punctuation
                        if (currentWord.EndsWith(","))
                        {
                            // replace "no," with "yes,"
                            wordReplace = "yes,";
                        }
                        else if (currentWord.EndsWith("."))
                        {
                            // replace "no." with "yes."
                            wordReplace = "yes.";
                        }
                        else if (currentWord.EndsWith("?"))
                        {
                            // replace "no?" with "yes?"
                            wordReplace = "yes?";
                        }
                        else if (currentWord.EndsWith("!"))
                        {
                            // replace "no!" with "yes!"
                            wordReplace = "yes!";
                        }
                        else
                        {
                            // replace "no" with "yes"
                            wordReplace = "yes";
                        }

                        // add the quotation mark to the end of wordReplace
                        wordReplace += "\"";

                        // concatenate word onto the end of the userInputSwap string
                        userInputSwap += wordReplace;

                        // concatenate a space afterwards
                        userInputSwap += " ";
                    }
                    else if (currentWord == "No," || currentWord == "No." || currentWord == "No" || currentWord == "No?" || currentWord == "No!")
                    {
                        // check for punctuation
                        if (currentWord.EndsWith(","))
                        {
                            // replace "No," with "Yes,"
                            wordReplace = "Yes,";
                        }
                        else if (currentWord.EndsWith("."))
                        {
                            // replace "No." with "Yes."
                            wordReplace = "Yes.";
                        }
                        else if (currentWord.EndsWith("?"))
                        {
                            // replace "No?" with "Yes?"
                            wordReplace = "Yes?";
                        }
                        else if (currentWord.EndsWith("!"))
                        {
                            // replace "No!" with "Yes!"
                            wordReplace = "Yes!";
                        }
                        else
                        {
                            // replace "No" with "Yes"
                            wordReplace = "Yes";
                        }

                        // add the quotation mark to the end of wordReplace
                        wordReplace += "\"";

                        // concatenate word onto the end of the userInputSwap string
                        userInputSwap += wordReplace;

                        // concatenate a space afterwards
                        userInputSwap += " ";
                    }
                    else if (currentWord == "NO," || currentWord == "NO." || currentWord == "NO" || currentWord == "NO?" || currentWord == "NO!")
                    {
                        // check for punctuation
                        if (currentWord.EndsWith(","))
                        {
                            // replace "NO," with "YES,"
                            wordReplace = "YES,";
                        }
                        else if (currentWord.EndsWith("."))
                        {
                            // replace "NO." with "YES."
                            wordReplace = "YES.";
                        }
                        else if (currentWord.EndsWith("?"))
                        {
                            // replace "NO?" with "YES?"
                            wordReplace = "YES?";
                        }
                        else if (currentWord.EndsWith("!"))
                        {
                            // replace "NO!" with "YES!"
                            wordReplace = "YES!";
                        }
                        else
                        {
                            // replace "NO" with "YES"
                            wordReplace = "Yes";
                        }

                        // add the quotation mark to the end of wordReplace
                        wordReplace += "\"";

                        // concatenate word onto the end of the userInputSwap string
                        userInputSwap += wordReplace;

                        // concatenate a space afterwards
                        userInputSwap += " ";
                    }
                    else
                    {
                        // add quotation mark onto the end of the current word of the loop
                        currentWord += "\"";

                        // if the word is not "no" then concatenate it onto the userInputSwap string
                        userInputSwap += currentWord;

                        // concatenate a space afterwards
                        userInputSwap += " ";
                    }
                }
                // check if words starts with and ends with quotation marks
                else if (word.StartsWith("\"") && word.EndsWith("\""))
                {
                    // trim the start and end of the word of quotations
                    currentWord = word.Trim('\"');

                    // check if "no" is followed by some sort of punctuation (e.g. "," or ".")
                    if (currentWord == "no," || currentWord == "no." || currentWord == "no" || currentWord == "no?" || currentWord == "no!")
                    {
                        // check for punctuation
                        if (currentWord.EndsWith(","))
                        {
                            // replace "no," with "yes,"
                            wordReplace = "yes,";
                        }
                        else if (currentWord.EndsWith("."))
                        {
                            // replace "no." with "yes."
                            wordReplace = "yes.";
                        }
                        else if (currentWord.EndsWith("?"))
                        {
                            // replace "no?" with "yes?"
                            wordReplace = "yes?";
                        }
                        else if (currentWord.EndsWith("!"))
                        {
                            // replace "no!" with "yes!"
                            wordReplace = "yes!";
                        }
                        else
                        {
                            // replace "no" with "yes"
                            wordReplace = "yes";
                        }

                        // pad and add the quotation mark back to the beginning of the wordReplace string
                        wordReplace = wordReplace.PadLeft(wordReplace.Length + 1, '\"');

                        // add the quotation mark to the end of wordReplace
                        wordReplace += "\"";

                        // concatenate word onto the end of the userInputSwap string
                        userInputSwap += wordReplace;

                        // concatenate a space afterwards
                        userInputSwap += " ";
                    }
                    else if (currentWord == "No," || currentWord == "No." || currentWord == "No" || currentWord == "No?" || currentWord == "No!")
                    {
                        // check for punctuation
                        if (currentWord.EndsWith(","))
                        {
                            // replace "No," with "Yes,"
                            wordReplace = "Yes,";
                        }
                        else if (currentWord.EndsWith("."))
                        {
                            // replace "No." with "Yes."
                            wordReplace = "Yes.";
                        }
                        else if (currentWord.EndsWith("?"))
                        {
                            // replace "No?" with "Yes?"
                            wordReplace = "Yes?";
                        }
                        else if (currentWord.EndsWith("!"))
                        {
                            // replace "No!" with "Yes!"
                            wordReplace = "Yes!";
                        }
                        else
                        {
                            // replace "No" with "Yes"
                            wordReplace = "Yes";
                        }

                        // pad and add the quotation mark back to the beginning of the wordReplace string
                        wordReplace = wordReplace.PadLeft(wordReplace.Length + 1, '\"');

                        // add the quotation mark to the end of wordReplace
                        wordReplace += "\"";

                        // concatenate word onto the end of the userInputSwap string
                        userInputSwap += wordReplace;

                        // concatenate a space afterwards
                        userInputSwap += " ";
                    }
                    else if (currentWord == "NO," || currentWord == "NO." || currentWord == "NO" || currentWord == "NO?" || currentWord == "NO!")
                    {
                        // check for punctuation
                        if (currentWord.EndsWith(","))
                        {
                            // replace "NO," with "YES,"
                            wordReplace = "YES,";
                        }
                        else if (currentWord.EndsWith("."))
                        {
                            // replace "NO." with "YES."
                            wordReplace = "YES.";
                        }
                        else if (currentWord.EndsWith("?"))
                        {
                            // replace "NO?" with "YES?"
                            wordReplace = "YES?";
                        }
                        else if (currentWord.EndsWith("!"))
                        {
                            // replace "NO!" with "YES!"
                            wordReplace = "YES!";
                        }
                        else
                        {
                            // replace "NO" with "YES"
                            wordReplace = "YES";
                        }

                        // pad and add the quotation mark back to the beginning of the wordReplace string
                        wordReplace = wordReplace.PadLeft(wordReplace.Length + 1, '\"');

                        // add the quotation mark to the end of wordReplace
                        wordReplace += "\"";

                        // concatenate word onto the end of the userInputSwap string
                        userInputSwap += wordReplace;

                        // concatenate a space afterwards
                        userInputSwap += " ";
                    }
                    else
                    {
                        // pad and add the quotation mark back to the beginning of the word string
                        currentWord = currentWord.PadLeft(currentWord.Length + 1, '\"');

                        // add quotation mark onto the end of the current word of the loop
                        currentWord += "\"";

                        // if the word is not "no" then concatenate it onto the userInputSwap string
                        userInputSwap += currentWord;

                        // concatenate a space afterwards
                        userInputSwap += " ";
                    }
                }
                else
                {
                    // check if "no" is followed by some sort of punctuation (e.g. "," or ".")
                    if (word == "no," || word == "no." || word == "no" || word == "no?" || word == "no!")
                    {
                        // check for punctuation
                        if (word.EndsWith(","))
                        {
                            // replace "no," with "yes,"
                            wordReplace = "yes,";
                        }
                        else if (word.EndsWith("."))
                        {
                            // replace "no." with "yes."
                            wordReplace = "yes.";
                        }
                        else if (word.EndsWith("?"))
                        {
                            // replace "no?" with "yes?"
                            wordReplace = "yes?";
                        }
                        else if (word.EndsWith("!"))
                        {
                            // replace "no!" with "yes!"
                            wordReplace = "yes!";
                        }
                        else
                        {
                            // replace "no" with "yes"
                            wordReplace = "yes";
                        }

                        // concatenate word onto the end of the userInputSwap string
                        userInputSwap += wordReplace;

                        // concatenate a space afterwards
                        userInputSwap += " ";
                    }
                    else if (word == "No," || word == "No." || word == "No" || word == "No?" || word == "No!")
                    {
                        // check for punctuation
                        if (word.EndsWith(","))
                        {
                            // replace "No," with "Yes,"
                            wordReplace = "Yes,";
                        }
                        else if (word.EndsWith("."))
                        {
                            // replace "No." with "Yes."
                            wordReplace = "Yes.";
                        }
                        else if (word.EndsWith("?"))
                        {
                            // replace "No?" with "Yes?"
                            wordReplace = "Yes?";
                        }
                        else if (word.EndsWith("!"))
                        {
                            // replace "No!" with "Yes!"
                            wordReplace = "Yes!";
                        }
                        else
                        {
                            // replace "No" with "Yes"
                            wordReplace = "Yes";
                        }

                        // concatenate word onto the end of the userInputSwap string
                        userInputSwap += wordReplace;

                        // concatenate a space afterwards
                        userInputSwap += " ";
                    }
                    else if (word == "NO," || word == "NO." || word == "NO" || word == "NO?" || word == "NO!")
                    {
                        // check for punctuation
                        if (word.EndsWith(","))
                        {
                            // replace "NO," with "YES,"
                            wordReplace = "YES,";
                        }
                        else if (word.EndsWith("."))
                        {
                            // replace "NO." with "YES."
                            wordReplace = "YES.";
                        }
                        else if (word.EndsWith("?"))
                        {
                            // replace "NO?" with "YES?"
                            wordReplace = "YES?";
                        }
                        else if (word.EndsWith("!"))
                        {
                            // replace "NO!" with "YES!"
                            wordReplace = "YES!";
                        }
                        else
                        {
                            // replace "NO" with "YES"
                            wordReplace = "Yes";
                        }

                        // concatenate word onto the end of the userInputSwap string
                        userInputSwap += wordReplace;

                        // concatenate a space afterwards
                        userInputSwap += " ";
                    }
                    else
                    {
                        // if the word is not "no" then concatenate it onto the userInputSwap string
                        userInputSwap += word;

                        // concatenate a space afterwards
                        userInputSwap += " ";
                    }
                }
            }

            // print the new string onto the console
            Console.WriteLine(userInputSwap);
        }
    }
}
