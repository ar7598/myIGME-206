using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT2_TardisOrPhoneBooth
{
    // Class: Phone
    // Author: Ajay Ramnarine (schUML by David Schuh)
    // Purpose: Create an abstract parent class of which other classes will derive from
    // Restrictions: None
    public abstract class Phone
    {
        private string phoneNumber;
        public string address;

        // rw property to get and/or set private field phoneNumber
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }

        // Method: Connect
        // Purpose: Connect two phone calls
        // Restrictions: No body because of abstract declaration
        public abstract void Connect();

        // Method: Disconnect
        // Purpose: Disconnect phone calls
        // Restrictions: No body because of abstract declaration
        public abstract void Disconnect();
    }

    // Interface: PhoneInterface
    // Purpose: Contains methods to be used and defined by child classes
    // Restrictions: The schUML diagram is called PhoneInterface, but usually interfaces will have an "I" in the front of their identifiers
    //              Unsure if I should have placed the "I" infront of the identifier, but I left it off just in case
    public interface PhoneInterface
    {
        void Answer();
        void MakeCall();
        void HangUp();
    }

    // Class: RotaryPhone
    // Author: Ajay Ramnarine (schUML diagram by David Schuh)
    // Purpose: Override the connect and disconnect from the Phone parent as well as define the methods in the PhoneInterface
    // Restrictions: None
    public class RotaryPhone : Phone, PhoneInterface
    {
        // Method: Answer
        // Purpose: Answers the phone when someone calls
        // Restrictions: No defined body as yet
        public void Answer()
        {
            // answers phone call
        }

        // Method: MakeCall
        // Purpose: Makes a phone call
        // Restrictions: No defined body as yet
        public void MakeCall()
        {
            Console.WriteLine("Guess I should start turning this dial.");
        }

        // Method: HangUp
        // Purpose: Ends a phone call
        // Restrictions: No defined body as yet
        public void HangUp()
        {
            Console.WriteLine("Do I just hang up the phone or do I have to turn something else?");
        }

        // Method: Connect
        // Purpose: Overrides method from Phone parent 
        // Restrictions: No defined body as yet
        public override void Connect()
        {
            // Connect call with other person
        }

        // Method: Disconnect
        // Purpose: Overrides method from Phone parent
        // Restrictions: No defined body as yet
        public override void Disconnect()
        {
            // Disconnect call with other person when call ends
        }

    }

    // Class: PushButtonPhone
    // Author: Ajay Ramnarine (schUML diagram by David Schuh)
    // Purpose: Override the connect and disconnect from the Phone parent as well as define the methods in the PhoneInterface
    // Restrictions: None
    public class PushButtonPhone : Phone, PhoneInterface
    {
        // Method: Answer
        // Purpose: Answers the phone when someone calls
        // Restrictions: No defined body as yet
        public void Answer()
        {
            // answers phone call
        }

        // Method: MakeCall
        // Purpose: Makes a phone call
        // Restrictions: No defined body as yet
        public void MakeCall()
        {
            Console.WriteLine("Ugh, I forgot my hand sanitizer.");
        }

        // Method: HangUp
        // Purpose: Ends a phone call
        // Restrictions: No defined body as yet
        public void HangUp()
        {
            Console.WriteLine("Goodbye!");
        }

        // Method: Connect
        // Purpose: Overrides method from Phone parent 
        // Restrictions: No defined body as yet
        public override void Connect()
        {
            // Connect call with other person
        }

        // Method: Disconnect
        // Purpose: Overrides method from Phone parent
        // Restrictions: No defined body as yet
        public override void Disconnect()
        {
            // Disconnect call with other person when call ends
        }

    }

    // Class: Tardis
    // Author: Ajay Ramnarine (schUML diagram by David Schuh)
    // Purpose: Implements fields and methods used by the Tardis and its users over many years
    // Restrictions: None
    public class Tardis : RotaryPhone
    {
        private bool sonicScrewdriver;
        private byte whichDrWho;
        private string femaleSideKick;
        public double exteriorSurfaceArea;
        public double interiorVolume;

        // read only property which returns the value of whichDrWho
        public byte WhichDrWho
        {
            get
            {
                return whichDrWho;
            }
        }

        // read only property which returns the value of femaleSideKick
        public string FemaleSideKick
        {
            get
            {
                return femaleSideKick;
            }
        }
        
        // Method: TimeTravel
        // Purpose: Travels through time when used
        // Restrictions: No defined body as yet
        public void TimeTravel()
        {
            Console.WriteLine("Listen! There's no time! We have to go back... Wait wrong reference.");
        }

        // overload the operators for ==, !=, <, >, <=, and >=
        public static bool operator ==(Tardis t1, Tardis t2) 
        {
            return (t1.WhichDrWho == t2.WhichDrWho);
        }
        public static bool operator !=(Tardis t1, Tardis t2) 
        {
            return (t1.WhichDrWho != t2.WhichDrWho);
        }
        public static bool operator <(Tardis t1, Tardis t2) 
        { 
            if(t1.WhichDrWho == 10 && t2.WhichDrWho != 10) 
            {
                return false;
            }
            else if(t2.WhichDrWho == 10 && t1.WhichDrWho != 10) 
            {
                return true;
            }
            else 
            {
                return (t1.WhichDrWho < t2.WhichDrWho);
            }
        }
        public static bool operator >(Tardis t1, Tardis t2)
        {
            if (t1.WhichDrWho == 10 && t2.WhichDrWho != 10)
            {
                return true;
            }
            else if (t2.WhichDrWho == 10 && t1.WhichDrWho !=10)
            {
                return false;
            }
            else
            {
                return (t1.WhichDrWho > t2.WhichDrWho);
            }
        }
        public static bool operator <=(Tardis t1, Tardis t2)
        {
            if (t1.WhichDrWho == 10 && t2.WhichDrWho != 10)
            {
                return false;
            }
            else if (t2.WhichDrWho == 10 && t1.WhichDrWho != 10)
            {
                return true;
            }
            else
            {
                return (t1.WhichDrWho <= t2.WhichDrWho);
            }
        }
        public static bool operator >=(Tardis t1, Tardis t2)
        {
            if (t1.WhichDrWho == 10 && t2.WhichDrWho != 10)
            {
                return true;
            }
            else if (t2.WhichDrWho == 10 && t1.WhichDrWho != 10)
            {
                return false;
            }
            else
            {
                return (t1.WhichDrWho >= t2.WhichDrWho);
            }
        }
    }

    // Class: Phone Booth
    // Author: Ajay Ramnarine (schUML diagram by David Schuh)
    // Purpose: Can pay for calls and check if there's a phonebook or if Superman is currently occupying the space
    // Restrictions: None
    public class PhoneBooth : PushButtonPhone
    {
        private bool superMan;
        public double costPerCall;
        public bool phoneBook;

        // Method: OpenDoor
        // Purpose: Opens the door to the phone booth
        // Restrictions: No defined body as yet
        public void OpenDoor() 
        {
            Console.WriteLine("Gosh, I hope Clark Kent isn't in here again.");
        }

        // Method: CloseDoor
        // Purpose: Closes the door to the phone booth
        // Restrictions: No defined body as yet
        public void CloseDoor() 
        { 
            // closes the door
        }
    }

    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Using the above classes to create objects in the Main method and then pass them to the UsePhone method
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Create objects based on the above classes and pass them to the UsePhone method
        // Restrictions: None
        static void Main(string[] args)
        {
            // create objects of type Tardis and PhoneBooth
            Tardis tardis = new Tardis();
            PhoneBooth phoneBooth = new PhoneBooth();

            // pass both objects to the UsePhone method
            UsePhone(tardis);
            Console.WriteLine(" ");
            UsePhone(phoneBooth);
        }

        // Method: UsePhone
        // Purpose: Using the PhoneInterface, call the methods for the passed objects
        //          Also call methods specific to type Phonebooth or Tardis depending on the type of object passed
        // Restrictions: None
        static void UsePhone(object obj) 
        {
            // Create a variable of the PhoneInterface and then set the passed obj to the variable
            PhoneInterface iPhone;
            iPhone = (PhoneInterface)obj;

            // Check if the passed obj is of type PhoneBooth or type Tardis and then call respective methods
            if(obj.GetType() == typeof(PhoneBooth)) 
            {
                PhoneBooth pBooth;
                pBooth = (PhoneBooth)obj;
                pBooth.OpenDoor();
            }
            if(obj.GetType() == typeof(Tardis)) 
            {
                Tardis tardis;
                tardis = (Tardis)obj;
                tardis.TimeTravel();
            }

            // Call the MakeCall and the HangUp methods
            iPhone.MakeCall();
            iPhone.HangUp();

        }
    }
}
