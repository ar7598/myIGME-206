using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT3_Wizards
{
    // Class: Wizard
    // Author: Ajay Ramnarine
    // Purpose: Create wizards with a name and age
    // Restrictions: None
    public class Wizard : IComparable<Wizard>
    {
        string name;
        int age;

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int Age
        {
            get 
            {
                return age;
            }
        }

        // Constructor
        public Wizard(string n, int a) 
        {
            this.name = n;
            this.age = a;
        }

        // Method: CompareTo
        // Purpose: Compare wizards based on their age
        // Restrictions: None
        public int CompareTo(Wizard wiz) 
        {
            return this.age.CompareTo(wiz.age);
        }
    }

    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Create a list of wizards to compare by age
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Create a list of 10 wizards
        //          Sort the list by the age of the wizards
        //          Sort the list using a delegate expression or lambda expression as well
        // Restrictions: None
        static void Main(string[] args)
        {
            // create a list that will hold the wizards
            List<Wizard> wizList;

            // create an array of wizards
            Wizard[] wizArray = new Wizard[]
            {
                new Wizard("Argoth the Abominable", 37),
                new Wizard("Franklin the Frightening Turtle", 211),
                new Wizard("Martha the Magnificent Master of the Macabre", 88),
                new Wizard("Genevive the Generous", 318),
                new Wizard("Gaston the Gaseous", 543),
                new Wizard("Barbara the Baker of All", 2021),
                new Wizard("Nevil the Neverending Nuisance", 103),
                new Wizard("Patty the Punisher Who Defintely Uses Magic and Not Her Fists", 605),
                new Wizard("Wanda the Wielder of Many Wands", 404),
                new Wizard("Tim", 4000)
            };

            // insert the array into the list of wizards
            wizList = new List<Wizard>(wizArray);

            // sort the list
            wizList.Sort();

            // print the sorted list
            foreach(Wizard wiz in wizList) 
            {
                Console.WriteLine(wiz.Name);
                Console.WriteLine("Age: " + wiz.Age);
                Console.WriteLine(" ");
            }

            // sort by a delegate expression
            wizList = wizList.OrderBy(delegate (Wizard wiz) { return wiz.Age; }).ToList();

            // sort by a lambda expression
            wizList = wizList.OrderBy((Wizard wiz) => wiz.Age ).ToList();
        }
    }
}
