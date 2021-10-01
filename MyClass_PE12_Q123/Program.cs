using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass_PE12_Q123
{
    // Class: MyClass
    // Author: Ajay Ramnarine
    // Purpose: Contains a private field myString that can be returned using the GetString() for Q1
    //          myString becomes a write-only field by the property MyString for Q2
    // Restrictions: None
    public class MyClass 
    {
        // create a private field that stores my string
        private string myString;

        // Method: GetString
        // Purpose: return the private field myString of objects of type MyClass
        // Restrictions: None
        public virtual string GetString() 
        {
            return myString;
        }

        // Property: MyString
        // Purpose: make the private field myString a write-only field
        // Restrictions: the field can only set the value of myString, but can't return the value
        public string MyString
        {
            set 
            {
                myString = value;
            }
        }
    }

    // Class: MyDerivedClass
    // Author: Ajay Ramnarine
    // Purpose: Derives from class MyClass and overrides the GetString method from the base class
    // Restrictions: None
    public class MyDerivedClass : MyClass 
    {
        // Method: GetString
        // Purpoes: Override the GetString method from the base class and return the string from the base class
        //          Include text to show that the returned string is coming from the returned class
        // Restrictions: None
        public override string GetString()
        {
            return base.GetString() + " (output from the derived class)";
        }
    }


    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Use the Main method to test the created MyClass and MyDerived classes made for Q1, 2, and 3 of PE12
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Instantiate an object of the MyDerivedClass class
        //          Use the GetString() method of the class to output the string returned by the method
        // Restrictions: None
        static void Main(string[] args)
        {
            // instantiate an object of the class MyDerivedClass
            MyDerivedClass myDC = new MyDerivedClass();

            // output the string returned form the GetString method of MyDerivedClass
            Console.WriteLine(myDC.GetString());
        }
    }
}
