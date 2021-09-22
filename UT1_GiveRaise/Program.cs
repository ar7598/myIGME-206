using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT1_GiveRaise
{
    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Create a function that checks for user input to see if the user is qualified for a raise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Ask the user to input their name
        //          Call a function to check to see if the user is qualified for a raise
        //          Congratulate the user if they got a raise and display their salary
        static void Main(string[] args)
        {
            // declare a string for the user's name
            string sName = null;

            // initialize a double variable that will hold the users salary
            double dSalary = 30000;

            // ask the user for their name and store it in sName
            Console.Write("Please enter your name: ");
            sName = Console.ReadLine();

            // call the GiveRaise function to check to see if the user is qualified for the raise
            bool bRaise = GiveRaise(sName, ref dSalary);

            if (bRaise)
            {
                Console.WriteLine("Congratulations on your raise! Your new salary is {0}!", dSalary);
            }
            else 
            {
                Console.WriteLine("Sorry! You are not qualified to receive a raise.");
            }
        }

        // Function: GiveRaise
        // Purpose: Check to see if the users name is qualified to receive a raise
        //          Return true if they are qualified, and false if not
        // Restrictions: None
        static bool GiveRaise(string name, ref double salary) 
        {
            // create a string to compare to name
            string myName = "Ajay Ramnarine";

            // compare the name with myName
            if (myName.Equals(name))
            {
                // increase the salary of the user
                salary += 19999.99;

                // because type double, make sure to round to 2 decimal places after addition
                salary = Math.Round(salary, 2);

                // return true if the name is equal to myName
                return true;
            }
            else 
            {
                // if the names don't match then return false
                return false;
            }
        }
    }
}
