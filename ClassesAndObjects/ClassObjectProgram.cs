using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    class ClassObjectProgram
    {
        static void Main(string[] args)
        {
            //A Class is like a variable in the sens that it is a data type that stores values
            //Classes are a uniquely defined data type that contain variables and methods
            //A Class is like a blueprint. It defines the data and behavior for a type of object
            //A Class definition starts with the keyword class followed by the class name.
            //Since a class is just a definition for an object like any other int or other var, you can create more than one at once.
            //An object is called an "Instance" of a class

            //C# has two ways of storing data: by Reference and by Value
            //Built in data types (like int and double) are used to declare variables that are value types
            //value types get stored in the Stack
            //refference types are used for storing objects
            //Refference types get stored in the Heap
            //A refference object's data is stored in the Heap, and that Heap memory adress is stored in the Stack
            //This is why it's called a refference type, it contains a refference (memory adress) to the actual instance of the object on the heap

            Person p1 = new Person(); //Creates new instance of the class person. p1 is now treated like any other variable
            p1.SayHi();
            Console.Write("What is my name? ");
            p1.name = Console.ReadLine(); //the  dot operator is used to get things like variables from inside objects.
            p1.SayName(); //Demonstrates that you can access and modify the variable contained within a class, as long as the class and the variable have a public acess modifier.
            p1.GetAge();
            p1.SayAge();

            //The different access modifiers are: public, private, protected, internal, and protected internal.
            //Public makes the member accessibale from anywhere as long as you have access to the object it's in.
            //Private makes members accessible from only within the class and hides them from the outside.
            //For example, in the person example the variabe for age must be accessed through a method inside the object rather than just asigning it from a Console.Read() comand directly because it has been given the private access modifier.

            //A Constructer is a special method of a class that is executed whenever a new object of that class is created.
            //A Constructer has the same name as its class and must also be public and cannot return any type.
            //Constructers can be passed variables if needed when called, just like any other method. This is why when declaring a new objct it still has the () so that you can pass arguments to it if it requires any.
            //Constructers can be overloaded to allow for multiple amounts of starting variables.

            Console.Write("Would you like to change my age? (Type y if yes) ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Write("What is my new age? ");
                p1.Age = Convert.ToInt32(Console.ReadLine()); //Uses p1.Age property to Set a value
            }
            Console.WriteLine("My age is {0}", p1.Age); //Uses p1.Age property to Get the new value.
        }
    }

    class Person
    {
        private int age;
        public int Age //This is a "Property" and it acts as a publicly accessiblemechanism to read or write to a private field, in this case the vprivate int age. They include special methods called accessors.
                       //Propperties can also be Private if need be.
        {
            get { return age; }
            set
            { //Accessors can be used to intercept data and check for problems before asigning them. for example here this accessor prevents someone from changing the age to a negative value. If they enter a negative value it simply ignores it and moves on.
                if (value >= 0)
                    age = value;
            }
            //Either of these accessors may be omitted. Missing a set accessor makes the variable read only, and missing a get accessor makes it invisible even if you can still change its value.
        }

        public string name; //For some reason variables do not default to Public if no access modifier is given.

        public Person() //Constructer method
        {
            Console.WriteLine("Hello World!");
        }

        public void SayHi() //This method has been given a public access modifier which allows it to be accessed from outside the class. Other options include Private and Protected. If no access modifier is defined the memeber is private by default.
        {
            Console.WriteLine("Hi");
        }

        public void SayName()
        {
            Console.WriteLine("My name is {0}!", name);
        }

        public void GetAge()
        {
            Console.Write("What is my age? ");
            age = Convert.ToInt32(Console.ReadLine());
        }

        public void SayAge()
        {
            Console.WriteLine("I am {0} years old!", age);
        }
    }
}
