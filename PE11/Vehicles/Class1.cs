using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Class List: Vehicles
// Author: Ajay Ramnarine
// Purpose: Create a list of classes from the schUML diagram illustrated in PE11 Q5
// Restrictions: None
namespace Vehicles
{
    // Class: Vehicle
    // Purpose: Uppermost base Vehicle class of which other classes will derive from
    // Restrictions: None
    public abstract class Vehicle 
    {
        // Method: LoadPassenger
        // Purpose: Load passengers onto vehicle
        // Restrictions: Empty function that returns nothing
        public virtual void LoadPassenger() { }
    }

    // Class: Car
    // Purpose: Be a child class of Vehicle, and be a parent class for other classes that will derive from here
    // Restrictions: None
    public abstract class Car : Vehicle 
    {
    }

    // Interface: IPassengerCarrier
    // Purpose: Interface for several classes that carry passengers
    // Restrictions: None
    public interface IPassengerCarrier 
    {
        // Method: LoadPassenger
        // Purpose: Load passengers onto certain vehicles
        // Restrictions: None
        void LoadPassenger();
    }

    // Interface: IHeavyLoadCarrier
    // Purpose: Interface for several vehicle based classes that carry heavy loads
    // Restrictions: None
    public interface IHeavyLoadCarrier { }

    // Class: Train
    // Purpose: Derives from Vehicle, but is a parent class for other train based classes
    // Restrictions: None
    public abstract class Train : Vehicle
    { 
    }

    // Class: Compact
    // Purpose: Inherit from the Car class and the IPassengerCarrier interface
    // Restrictions: None
    public class Compact : Car, IPassengerCarrier 
    {
    }

    // Class: SUV
    // Purpose: Inherit from the Car class and the IPassengerCarrier interface
    // Restrictions: None
    public class SUV : Car, IPassengerCarrier 
    {
    }

    // Class: Pickup
    // Purpose: Inherit from the Car class and the IPassengerCarrier and the IHeavyLoadCarrier interfaces
    // Restrictions: None
    public class Pickup : Car, IPassengerCarrier, IHeavyLoadCarrier 
    {
    }

    // Class: PassengerTrain
    // Purpose: Inherit from the Train class and the IPassengerCarrier interface
    // Restrictions: None
    public class PassengerTrain : Train, IPassengerCarrier 
    {
    }

    // Class: FreightTrain
    // Purpose: Inherit from the Train class and the IHeavyLoadCarrier interface
    // Restrictions: None
    public class FreightTrain : Train, IHeavyLoadCarrier 
    {
    }

    // Class: _424DoubleBogey
    // Purpose: Inherit from the Train class and the IHeavyLoadCarrier interface
    // Restrictions: None
    public class _424DoubleBogey : Train, IHeavyLoadCarrier 
    {
    }
}
