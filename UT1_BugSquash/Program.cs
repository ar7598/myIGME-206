using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT1_BugSquash
{
    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Check the code in the main method for bugs, comment the bug type, comment out the line and rewrite it correctly so the program runs successfully
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Calculate x^y for y>0 using a recursive function
        //          Find all the bugs, comment them out, and correct the lines so the program runs successfully
        // Restrictions: None
        static void Main(string[] args)
        {
            string sNumber;
            int nX;
            // compile-time error: didn't include a semi colon after declaring int variable nY 
            // int nY
            int nY;
            int nAnswer;

            // compile-time error: didn't include quotes around the comment within Console.WriteLine()
            // Console.WriteLine(This program calculates x^y.);
            Console.WriteLine("This program calculates x^y.");

            do
            {
                Console.Write("Enter a whole number for x: ");
                // compile-time error: need to set sNumber equal to Console.ReadLine() to make the do while loop work
                // Console.ReadLine();
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nX));

            // runtime error: the while loop will run forever as the input is always true
            // logical error: the Console.Write asks for y, but the out is set to nX instead of nY
            /*do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
            } while (int.TryParse(sNumber, out nX));*/
            do 
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nY));

            // compute the factorial of the number using a recursive function
            nAnswer = Power(nX, nY);

            // logical error: This will print {nX}^{nY} = {nAnswer} instead of printing the actual values of those variables 
            // Console.WriteLine("{nX}^{nY} = {nAnswer}");
            Console.WriteLine("{0}^{1} = {2}", nX, nY, nAnswer);
        }

        // Function: Power
        // Purpose: Calculate and return the value of a base number to an exponent
        // Restrictions: None (previously needed to be declared as static, which has now been corrected)
        // compile-time error: function needs to be declared as static to be called within the main function
        // int Power(int nBase, int nExponent) 
        static int Power(int nBase, int nExponent)
        {
            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                // logical error: returnVal should equal 1 when nExponent is 0
                // returnVal = 0;
                returnVal = 1;
            }
            else 
            {
                // compute the subsequent values using nExponent - 1 to eventually reach the base case
                // runtime error: nExponent will keep increasing and won't reach the base case
                // nextVal = Power(nBase, nExponent + 1);
                nextVal = Power(nBase, nExponent - 1);

                // multiply the base with all subsequent values
                returnVal = nBase * nextVal;
            }

            // compile-time error: returnVal must be returned as is expected by the Power function
            // returnVal;
            return returnVal;
        
        }
    }
}
