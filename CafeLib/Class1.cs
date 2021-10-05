using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeLib
{
    // Class: HotDrink
    // Author: Ajay Ramnarine
    // Purpose: Create objects of type HotDrink
    // Restrictions: None
    public abstract class HotDrink 
    {
        public bool instant;
        public bool milk;
        private byte sugar;
        public string size;
        public Customer customer;

        // default constructor
        public HotDrink() 
        {
            // do something that uses the above fields
        }

        // constructor passing a type of brand
        public HotDrink(string brand) 
        {
            // check the brand and then do something with that and the above fields
        }

        // Method: AddSugar
        // Purpose: Increase the amount of sugar in the drink by a certain amount
        // Restrictions: None
        public virtual void AddSugar(byte amount) 
        {
            // increase sugar by the passed amount
        }

        // Method: Steam
        // Purpose: To be overridden by child classes that can be steamed
        // Restrictions: Has no body
        public abstract void Steam();
    }

    // Interface: IMood
    // Author: Ajay Ramnarine
    // Purpose: Contains a read only string for the mood of customers and waiters
    // Restrictions: None
    public interface IMood 
    {
        string Mood { get; }
    }

    // Interface: ITakeOrder
    // Author: Ajay Ramnarine
    // Purpose: Passes the TakeOrder method to the different "CupOf_" classes
    // Restrictions: None
    public interface ITakeOrder 
    {
        void TakeOrder();
    }

    // Class: Waiter
    // Author: Ajay Ramnarine
    // Purpose: Creates object of type Waiter that can serve objects related to the HotDrink class
    // Restrictions: None
    public class Waiter : IMood 
    {
        public string name;

        // Property to return mood of waiter
        public string Mood
        {
            get 
            {
                return "Wants higher wage";
            }
        }

        // Method: ServeCustomer
        // Purpose: Serve an object of type HotDrink
        // Restrictions: None
        public void ServeCustomer(HotDrink cup) 
        {
            // serve the hot drink
        }
    }

    // Class: Customer
    // Author: Ajay Ramnarine
    // Purpose: Create object of type Customer that can be related to the HotDrink object they order
    // Restrictions: None
    public class Customer : IMood 
    {
        public string name;
        public string creditCardNumber;

        // property to return mood of customer
        public string Mood
        {
            get 
            {
                return "Cranky";
            }
        }
    }

    // Class: CupOfCoffee
    // Author: Ajay Ramnarine
    // Purpose: Create cups of coffee to be ordered
    // Restrictions: None
    public class CupOfCoffee: HotDrink, ITakeOrder 
    {
        public string beanType;

        // constructor that utilizes a base constructor
        public CupOfCoffee(string brand) : base(brand) 
        { 
        }

        // Method: Steam
        // Purpose: Overrides the Steam method from the HotDrink class
        // Restrictions: None
        public override void Steam()
        {
            // steam the drink
        }

        // Method: TakeOrder
        // Purpose: Takes the order of the drink
        // Restrictions: None
        public void TakeOrder() 
        { 
            // takes the order of the drink
        }
    }

    // Class: CupOfTea
    // Author: Ajay Ramnarine
    // Purpose: Create cups of tea to be ordered
    // Restrictions: None
    public class CupOfTea : HotDrink, ITakeOrder 
    {
        public string leafType;

        // constructor that checks if the customer is wealthy
        public CupOfTea(bool customerIsWealthy) 
        { 
            // checks to see if customerIsWealthy is true or not and does something
        }

        // Method: Steam
        // Purpose: Overrides the Steam method from the HotDrink class
        // Restrictions: None
        public override void Steam()
        {
            // steam the drink
        }

        // Method: TakeOrder
        // Purpose: Takes the order of the drink
        // Restrictions: None
        public void TakeOrder() 
        { 
            // takes the order of the drink
        }
    }

    // Class: CupOfCocoa
    // Author: Ajay Ramnarine
    // Purpose: Create cups of cocoa
    // Restrictions: None
    public class CupOfCocoa : HotDrink, ITakeOrder 
    {
        public static int numCups;
        public bool marshmallows;
        private string source;

        // default constructor
        public CupOfCocoa() : this(false) 
        {
            // auto sets the want of marshmallows to false (who wouldn't want marshmallows?)
        }

        // constructor that checks to see if the customer wants marshmallows, and uses base class for the brand of cocoa
        public CupOfCocoa(bool marshmallows) : base("Expensive Organic Brand") 
        {
            // sets the want of marshmallows to true and sets the brand of cocoa
        }

        // property to write to the private source field
        public string Source
        {
            set 
            {
                source = value;
            }
        }

        // Method: Steam
        // Purpose: Overrides the Steam method from the HotDrink class
        // Restrictions: None
        public override void Steam() 
        { 
            // steam the drink
        }

        // Method: AddSugar
        // Purpose: Adds sugar to the drink of cocoa
        // Restrictions: None
        public override void AddSugar(byte amount)
        {
            // increase the sugar of the Cocoa by the passed amount
        }

        // Method: TakeOrder
        // Purpose: Takes the order of the drink
        // Restrictions: None
        public void TakeOrder() 
        { 
            // takes the order of the drink
        }
    }
}
