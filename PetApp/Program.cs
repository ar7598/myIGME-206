using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp
{
    // Class: Pets
    // Author: Ajay Ramnarine
    // Purpose: Creates a list of pets that can be referenced, counted, added, or removed
    // Restrictions: None
    public class Pets 
    {
        // list of pets
        public List<Pet> petList = new List<Pet>();

        // indexer property to get and set from the Pet list
        public Pet this[int nPetEl] 
        {
            get 
            {
                Pet returnVal;
                try 
                {
                    returnVal = (Pet)petList[nPetEl];
                }
                catch 
                {
                    returnVal = null;
                }
                return (returnVal);
            }

            set 
            {
                // if the index is less than the number of list elements
                if (nPetEl < petList.Count)
                {
                    // update the existing value at that index
                    petList[nPetEl] = value;
                }
                else 
                {
                    // add the value to the list
                    petList.Add(value);
                }
            }
        }

        // Method: Count
        // Purpose: Returns the number of pets in the list
        // Restrictions: This is a read only method
        public int Count
        {
            get 
            {
                return petList.Count;
            }
        }

        // Method: Add
        // Purpose: Add pets to the list of pets
        // Restrictions: None
        public void Add(Pet pet) 
        {
            petList.Add(pet);
        }

        // Method: Remove
        // Purpose: Remove a specific pet from the list
        // Restrictions: None
        public void Remove(Pet pet) 
        {
            petList.Remove(pet);
        }

        // Method: RemoveAt
        // Purpose: Remove a pet at a specific index in the list of pets
        // Restrictions: None
        public void RemoveAt(int petEl) 
        {
            petList.RemoveAt(petEl);
        }
    }

    // Class: Pet
    // Author: Ajay Ramnarine
    // Purpose: Create instances of class Pet, and act as a parent class for the Cat and Dog classes
    // Restrictions: None
    public abstract class Pet 
    {
        private string name;
        public int age;

        // readwrite property for the private name field
        public string Name
        {
            get 
            {
                return this.name;
            }

            set 
            {
                this.name = value;
            }
        }

        // Method: Eat
        // Purpose: Base method of Eat
        // Restrictions: No body because abstract
        public abstract void Eat();

        // Method: Play
        // Purpose: Base method of Play
        // Restrictions: No body because abstract
        public abstract void Play();

        // Method: GoToVet
        // Purpose: Base method of GoToVet
        // Restrictions: No body because abstract
        public abstract void GoToVet();

        // default constructor
        public Pet() 
        {
        }

        // constructor that requires name and age of pet
        public Pet(string name, int age) 
        {
            this.name = name;
            this.age = age;
        }
    }

    // Interface: ICat
    // Author: Ajay Ramnarine
    // Purpose: Contains methods to be used by the Cat class
    // Restrictions: None
    public interface ICat 
    {
        void Eat();
        void Play();
        void Scratch();
        void Purr();
    }

    // Interface: IDog
    // Author: Ajay Ramnarine
    // Purpose: Contains methods to be used by the Dog class
    // Restrictions: None
    public interface IDog 
    {
        void Eat();
        void Play();
        void Bark();
        void NeedWalk();
        void GoToVet();
    }

    // Class: Cat
    // Author: Ajay Ramnarine
    // Purpose: Create objects of type Cat
    // Restrictions None
    public class Cat : Pet, ICat 
    {
        // Method: Eat
        // Purpose: Return a quirky line for when a cat is called to eat
        // Restrictions: None
        public override void Eat()
        {
            Console.WriteLine(this.Name + ": Feed me for I hunger.");
        }

        // Method: Play
        // Purpose: Return a quirky line for when a cat wants to play
        // Restrictions: None
        public override void Play()
        {
            Console.WriteLine(this.Name + ": Come hither so that I may knead at your clothing.");
        }

        // Method: Purr
        // Purpose: Return a cat purring
        // Restrictions: None
        public void Purr() 
        {
            Console.WriteLine(this.Name + ": Purr I say, PURRRRRRRRRRRRRR!");
        }

        // Method: Scratch
        // Purpose: Return the scratching of a cat
        // Restrictions: None
        public void Scratch() 
        {
            Console.WriteLine(this.Name + ": Hmph, my claws are almost as sharp as my wit.");
        }

        // Method: GoToVet
        // Purpose: Return the cats reaction to going to the vet
        // Restrictions: None
        public override void GoToVet() 
        {
            Console.WriteLine(this.Name + ": No... NO... NOOOOOOOOOOOO!");
        }

        // default constructor
        public Cat() 
        {
        }
    }

    // Class: Dog
    // Author: Ajay Ramnarine
    // Purpose: Create objects of type Dog
    // Restrictions: None
    public class Dog : Pet, IDog 
    {
        public string license;

        // Method: Eat
        // Purpose: Return a quirky comment for when a dog eats
        // Restrictions: None
        public override void Eat()
        {
            Console.WriteLine(this.Name + ": OH BOY! I SURE AM HUNGRY!!!");
        }

        // Method: Play
        // Purpose: Return a comment for when a dog wants to play
        // Restrictions: None
        public override void Play()
        {
            Console.WriteLine(this.Name + ": WAT R WE GONNA DO?!?!?!?");
        }

        // Method: Bark
        // Purpose: Return the dog barking
        // Restrictions: None
        public void Bark() 
        {
            Console.WriteLine(this.Name + ": ARF ARF WOOF BOOF ARF");
        }

        // Method: NeedWalk
        // Purpose: Return what the dog asks for when they want to walk
        // Restrictions: None
        public void NeedWalk() 
        {
            Console.WriteLine(this.Name + ": WHERE R WE GOIN?!?!?!? HUH??? WHERE WHERE???");
        }

        // Method: GoToVet
        // Purpose: Return the dogs reaction when they are going to the vet
        // Restrictions: None
        public override void GoToVet()
        {
            Console.WriteLine(this.Name + ": awwwww noooooooo, I don't wanna :(");
        }

        // constructor for Dog
        public Dog(string szLicense, string szName, int nAge) : base(szName, nAge) 
        {
            this.license = szLicense;
        }
    }

    // Class: Program
    // Author: Ajay Ramnarine
    // Purpose: Run the PetApp in the Main method, which uses the created classes and interfaces that have to do with Cats and Dogs
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Using the classes and interfaces that have to do with Pets, randomly generate buying a new pet or playing an activity with an existing pet
        // Restrictions: None
        static void Main(string[] args)
        {
            // create reference variables for the pets and interfaces
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            // create list of pets
            Pets pets = new Pets();

            // create a random number generator
            Random rand = new Random();

            // for loop that iterates 50 times
            for (int i = 0; i < 50; i++) 
            {
                if (rand.Next(1, 11) == 1) 
                {
                    if (rand.Next(0, 2) == 0) 
                    {
                        // add a dog
                        Console.WriteLine("You bought a dog!");

                        Console.Write("Dog's Name => ");
                        string dName = Console.ReadLine();

                        bool isAge = false;
                        int dAge = 0;
                        do
                        {
                            Console.Write("Age => ");
                            try
                            {
                                dAge = Int32.Parse(Console.ReadLine());
                                isAge = true;
                            }
                            catch 
                            {
                                Console.WriteLine("Please enter an integer");
                                isAge = false;
                            }
                        } while (!isAge);

                        Console.Write("License => ");
                        string dLicense = Console.ReadLine();

                        dog = new Dog(dLicense, dName, dAge);

                        pets.Add(dog);
                    }
                    else
                    {
                        Console.WriteLine("You bought a cat!");

                        Console.Write("Cat's Name => ");
                        string cName = Console.ReadLine();

                        bool isAge = false;
                        int cAge = 0;
                        do
                        {
                            Console.Write("Age => ");
                            try
                            {
                                cAge = Int32.Parse(Console.ReadLine());
                                isAge = true;
                            }
                            catch
                            {
                                Console.WriteLine("Please enter an integer");
                                isAge = false;
                            }
                        } while (!isAge);

                        cat = new Cat();
                        cat.Name = cName;
                        cat.age = cAge;

                        pets.Add(cat);
                    }
                } 
                else 
                {
                    thisPet = pets[rand.Next(0, pets.Count)];
                    if (thisPet == null)
                    {
                        continue;
                    }
                    else 
                    {
                        if (thisPet.GetType().Equals(typeof(Dog)))
                        {
                            iDog = (Dog)thisPet;

                            int randNum = rand.Next(0, 5);

                            if (randNum == 0)
                            {
                                iDog.Eat();
                            }
                            else if (randNum == 1)
                            {
                                iDog.Play();
                            }
                            else if (randNum == 2)
                            {
                                iDog.Bark();
                            }
                            else if (randNum == 3)
                            {
                                iDog.NeedWalk();
                            }
                            else
                            {
                                iDog.GoToVet();
                            }
                        }
                        else 
                        {
                            iCat = (Cat)thisPet;

                            int randNum = rand.Next(0, 5);

                            if (randNum == 0)
                            {
                                iCat.Eat();
                            }
                            else if (randNum == 1)
                            {
                                iCat.Play();
                            }
                            else if (randNum == 2)
                            {
                                iCat.Purr();
                            }
                            else if (randNum == 3)
                            {
                                iCat.Scratch();
                            }
                            else 
                            {
                                ((Cat)iCat).GoToVet();
                            }
                        }
                    }
                }
            }

        }
    }
}
