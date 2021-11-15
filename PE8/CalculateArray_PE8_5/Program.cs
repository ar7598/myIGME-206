using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateArray_PE8_5
{
    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Practice using 3D arrays as a means of calculating different outputs of a given equation
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Create a 3D array to hold values of x, y, and z
        //          Enter the equation for z = 3y^2 + 2x - 1
        //          Solve for all values of z given the ranges of x and y
        //          Input values of x, y, and z into the created 3D array
        // Restrictions: None
        static void Main(string[] args)
        {
            // initialize a double 3-dimensional array to hold values of x, y and z
            // the x position should be 20, and the y position should be 30
            double[,,] calcArray3 = new double[21, 30, 3];

            // declare int counters for x and y that will increment to index values into calcArray3 with every loop
            int xCounter = 0;
            int yCounter = 0;

            // use nested for loops to increment between the ranges for x and y and calculate the values of z
            // outer for loop increments by 0.1 for the range of -1 <= x <= 1
            for (double x = -1; x <= 1; x += 0.1)
            {
                // set yCounter to 0 after every loop for the inner for loop
                yCounter = 0;

                // inner for loop increments by 0.1 for the range of 1 <= y <= 4
                for (double y = 1; y <= 4; y += 0.1)
                {
                    // initialize the value of z based on the current values of x and y 
                    double z = 3 * Math.Pow(y, 2) + 2 * x - 1;

                    // store the current value of x within the first element of calcArray3
                    calcArray3[xCounter, yCounter, 0] = x;

                    // store the current value of y within the second element of calcArray3
                    calcArray3[xCounter, yCounter, 1] = y;

                    // store the value of z within the third element of calcArray3
                    calcArray3[xCounter, yCounter, 2] = z;

                    // increment yCounter to go to the next y index of calcArray3
                    yCounter++;
                }

                // increment xCounter to go to the next x index of calcArray3
                xCounter++;
            }
        }
    }
}
