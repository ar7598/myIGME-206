using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;

namespace Traffic
{
    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Use the Vehicles.dll file and write the AddPassenger() function using the IPassengerCarrier interface
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Create an object using the IPassengerCarrier interface from the Vehicles.dll file
        //          Pass that object to the AddPassenger() function
        //          Try to pass an object that does not inherit from the IPassengerCarrier interface and explain what happens
        // Restrictions: None
        static void Main(string[] args)
        {
            // create an object of type Compact that inherits from the IPassengerCarrier interface
            Compact compact = new Compact();

            // pass the object to the AddPassenger() function
            AddPassenger(compact);

            // create an object of type SUV
            SUV sUV = new SUV();

            // pass the object to the AddPassenger() function
            AddPassenger(sUV);

            // create an object of type FreightTrain to try to pass to the AddPassenger() function
            // FreightTrain freight = new FreightTrain();

            // compile time error: object freight cannot be converted from Vehicles.FreightTrain to Vehicles.IPassengerCarrier
            // therefore, object freight cannot be passed to the function AddPassenger()
            // AddPassenger(freight);
        }

        // Function: AddPassenger
        // Purpose: Call the LoadPassenger() function for classes that inherit from the IPassengerCarrier interface
        //          Use the ToString() method to write to the console
        // Restrictions: None
        public static void AddPassenger(IPassengerCarrier passengerCarrier) 
        {
            // Call the LoadPassenger() method defined for classes that inherit from IPassengerCarrier
            passengerCarrier.LoadPassenger();

            // use the ToString() method with the passed object
            Console.WriteLine(passengerCarrier.ToString());
        
        }
    }
}
