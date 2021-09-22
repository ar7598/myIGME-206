using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT1_ImprovedGiveRaise
{
    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Create a struct for employees that will have variables for the name and salary
    //          Then pass that struct to a function to see if the user is qualified for a raise
    // Restrictions: None
    class Program
    {
        // Struct: Employee
        // Purpose: Can be used to create structures of type Employee
        // Restrictions: None
        struct Employee 
        {
            // declare a string for the user's name
            public string sName;

            // declare a double variable that will hold the users salary
            public double dSalary;
        }

        // Method: Main
        // Purpose: Create a struct of type Employee
        //          Ask the user to input their name, which will be held in the created Employee struct
        //          Call a function to check to see if the user is qualified for a raise
        //          Congratulate the user if they got a raise and display their salary
        // Restrictions: None
        static void Main(string[] args)
        {
            // intialize a new employee
            Employee userEmp = new Employee();

            // ask the user for their name and store it in the sName of the new employee
            Console.Write("Please enter your name: ");
            userEmp.sName = Console.ReadLine();

            // set the users starting salary
            userEmp.dSalary = 30000;

            // call the GiveRaise function to check to see if the user is qualified for the raise
            bool bRaise = GiveRaise(ref userEmp);

            if (bRaise)
            {
                Console.WriteLine("Congratulations on your raise! Your new salary is {0}!", userEmp.dSalary);
            }
            else
            {
                Console.WriteLine("Sorry! You are not qualified to receive a raise.");
            }
        }

        // Function: GiveRaise
        // Purpose: Check to see if the users name is qualified to receive a raise by passing in a struct of type Employee
        //          Return true if they are qualified, and false if not
        // Restrictions: None
        static bool GiveRaise(ref Employee employee)
        {
            // create a string to compare to name
            string myName = "Ajay Ramnarine";

            // compare the name with myName
            if (myName.Equals(employee.sName))
            {
                // increase the salary of the user
                employee.dSalary += 19999.99;

                // because type double, make sure to round to 2 decimal places after addition
                employee.dSalary = Math.Round(employee.dSalary, 2);

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
