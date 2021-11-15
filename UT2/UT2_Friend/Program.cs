using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT2_Friend
{
    // Class: Friend
    // Author: Ajay Ramnarine (struct orignally by David Schuh for Question 14)
    // Purpose: Rework the Friend struct as a public class
    // Restrictions: None
    public class Friend : ICloneable
    {
        public string name;
        public string greeting;
        public DateTime birthday;
        public string address;

        // Method: Clone
        // Purpose: Create a copy of a Friend object
        // Restrictions: None
        public object Clone() 
        {
            Friend copy = (Friend)this.MemberwiseClone();
            
            return copy;
        }
    }

    
    // Class: Program
    // Author: Ajay Ramnarine (originally David Schuh for Question 14)
    // Purpose: Rework the struct Friend as a public class, and then use the Main method to check if the output is the same
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Create two instances of Friend
        //          Set your friend as your enemy
        //          Set the enemy greeting and address without changing the friend variable
        // Restrictions: None
        static void Main(string[] args)
        {
            Friend friend = new Friend();
            Friend enemy;

            // create my friend Charlie Sheen
            friend.name = "Charlie Sheen";
            friend.greeting = "Dear Charlie";
            friend.birthday = DateTime.Parse("1967-12-25");
            friend.address = "123 Any Street, NY NY 12202";

            // now he has become my enemy
            enemy = (Friend)friend.Clone();

            // set the enemy greeting and address without changing the friend variable
            enemy.greeting = "Sorry Charlie";
            enemy.address = "Return to sender. Address unknown.";

            Console.WriteLine($"friend.greeting => enemy.greeting: {friend.greeting} => {enemy.greeting}");
            Console.WriteLine($"friend.address => enemy.address: {friend.address} => {enemy.address}");
        }
    }
}
