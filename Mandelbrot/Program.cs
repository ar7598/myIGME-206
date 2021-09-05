using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
    // Class: Program
    // Author: Ajay Ramnarine (and code from "Beginning C#" by Karli Watson)
    // Purpose: Exercise in understanding and modifying code for a Mandelbrot image from "Beginning C#" by Karli Watson
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Used to call the Mandelbrot generator
        //          Prompt the user for new starting and ending values for variables realCoord and imagCoord
        // Restrictions: None
        static void Main(string[] args)
        {
            // initialize the variables for the real and imaginary parts of N
            // double realCoord; 
            // double imagCoord;

            // declare temporary variables that will be used for calculations within the nested for loops 
            double realTemp, imagTemp, realTemp2, arg;

            // declare a counter for the amount of iterations it takes for N(arg) to be greater than or equal to 2
            int iterations;

            // initailize the variables that will be used to store the users input for the beginning values of realCoord and imagCord
            double userRealCoord = 0;
            double userImagCoord = 0;

            // initialize the variables that will be used for the ending values for the real and imaginary coordinates
            double realCoordEnd = 0; 
            double imagCoordEnd = 0;

            // create a boolean value for a while loop with a nested for loop
            bool bValid = false;

            // use a while loop with a nested for loop to ask the user to input starting and ending values of imagCoord
            while (!bValid)
            {
                // try catch in case the user inputs a string or char, the catch will throw the error
                try
                {
                    Console.Write("Enter the starting value of the imaginary coordinates (default range is 1.2 to -1.2): ");
                    userImagCoord = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter the ending value of the imaginary coordinates (default range is 1.2 to -1.2): ");
                    imagCoordEnd = Convert.ToDouble(Console.ReadLine());

                    // if statement to check that imagCoordEnd < userImagCoord
                    if (userImagCoord < imagCoordEnd)
                    {
                        Console.WriteLine("Please make sure that the ending value is less than the starting value.");
                        bValid = false;
                    }
                    else 
                    {
                        bValid = true;
                    }
                }
                catch 
                {
                    Console.WriteLine("Make sure that you are entering numbers and nothing else.");
                    bValid = false;
                }
            }

            // reset bValid to be false for the next while loop
            bValid = false;

            // use a while loop with a nested for loop to ask the user to input the starting and ending values of realCoord
            while(!bValid)
            {
                // try catch in case the user inputs a string or char, the catch will throw the error
                try
                {
                    Console.Write("Enter the starting value of the real coordinates (default range is -0.6 to 1.77): ");
                    userRealCoord = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter the ending value of the real coordinates (default range is -0.6 to 1.77): ");
                    realCoordEnd = Convert.ToDouble(Console.ReadLine());

                    // if statement to check that realCoordEnd > userRealCoord
                    if (userRealCoord > realCoordEnd)
                    {
                        Console.WriteLine("Please make sure that the ending value is greater than the starting value.");
                        bValid = false;
                    }
                    else
                    {
                        bValid = true;
                    }
                }
                catch
                {
                    Console.WriteLine("Make sure that you are entering numbers and nothing else.");
                    bValid = false;
                }

            }

            // calculate the value for decrementing imagCoord in 48 values
            double imagDec = (Math.Abs(userImagCoord) + Math.Abs(imagCoordEnd)) / 48;

            // calculate the incrementing value for realCoord in 80 values
            double realInc = (Math.Abs(realCoordEnd) + Math.Abs(userRealCoord)) / 80; 


            for (double imagCoord = userImagCoord; imagCoord >= imagCoordEnd; imagCoord -= imagDec)
            {
                for (double realCoord = userRealCoord; realCoord <= realCoordEnd; realCoord += realInc)
                {
                    iterations = 0;
                    realTemp = realCoord;
                    imagTemp = imagCoord;
                    arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    while ((arg < 4) && (iterations < 40))
                    {
                        realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp)
                           - realCoord;
                        imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                        iterations += 1;
                    }
                    switch (iterations % 4)
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
