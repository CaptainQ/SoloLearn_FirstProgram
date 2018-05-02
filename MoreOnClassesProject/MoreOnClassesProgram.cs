using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreOnClassesProject
{
    class MoreOnClassesProgram
    {
        static void Main(string[] args)
        {
            Dog d = new Dog();
            //This program starts, creates a new instance of Dog which runs the constructor, and then the Main method ends which clears the heap and triggers all destructors for any classes still on the heap.

            Cat c1 = new Cat();
            Cat c2 = new Cat();

            Console.WriteLine(Cat.count);
            //static memebers, like count here, can be directly accessed using the class name instead of having to specify c1.count or c2.count. They each share the same static variable within the Cat class so we can call it via Cat.count. They cannot be called using a refference, even though it seems like they should be able to be.

            //The same concept applies to static methods.
            //This is also why the Main method is static, as well as why methods often need to be static if they belong inside the Main method.

            Dog.Bark(); //Refferencing a static method within Dog, so no object call is needed.

            Console.WriteLine(MathClass.ONE); //ONE is a constant, which are always static, so it can be called without instanciating MathClass.

            Console.WriteLine(MathClass.X); //This refferences a static member of a class with a static constructor. It will run the static constructor before accessing the variable X without instanciating a version of MathClass.
            //This does not apply to constants. constants do not trigger static contructors, even though technically they are static.

            //Classes can be static as well. These static classes can only contain static members and can not be instanced because only one can exist within one program.
            //The C# Math class is an example of a built in static class with static members.
            Console.WriteLine(Math.Pow(2, 3)); //Outputs 8
            //Math can do lots of nice things, google it later.

            Clients c = new Clients();
            c[0] = "Dave";
            c[1] = "Bob";

            Console.WriteLine(c[1]); //outputs "Bob"

            Box b1 = new Box(14, 3);
            Box b2 = new Box(5, 7);
            Box b3 = b1 + b2;

            Console.WriteLine(b3.Height); //19
            Console.WriteLine(b3.Width); //10
        }

        class Dog
        {
            public Dog()
            {
                Console.WriteLine("Constructor");
            }

            ~Dog() //This is a destructor, it's marked with a ~ and runs automatically when an object is destroyed or deleted.
            {
                //A class may only have one Destructor and cannot be overloaded with different sets of parameters.
                //They cannot have any arguments at all.
                //They have a tilde (~) just like the homestuck joke.

                Console.WriteLine("Destructor");
            }

            public static void Bark()
            {
                Console.WriteLine("Woof!");
            }
        }

        class Cat //This class contains a static member.
        {
            public static int count = 0; //This is a static member, which means each instance of the class Cat all access the same memory slot for int count. They do not instance their own version of count, the variable is a single "static" variable.
            
            public Cat()
            {
                count++; //This constructor increments the global variable to count how many cats have been instanced.
            }
        }

        class MathClass
        {
            public const int ONE = 1;
            public static int X { get; set; }

            static MathClass()
            {
                Console.WriteLine("MathClass Constructor");
            }
        }

        class Person
        {
            private readonly string name; //This member has the readonly atribute, which means that it can only be modified using a constructor and therfore can not be changed once each instance of Person has been created.
            //The benefits of using read only instead of constants are that you can declare them without initializing them with a vlaue.

            public Person(string name)
            {
                this.name = name; //this refferes to the curent object which is why I can use a local parameter with the same name as a class member. this.name is the name that belongs to the class containing the constructor.
            }
        }

        class Clients //an example of a class using indexing. (This is confusing)
        {
            private string[] names = new string[10];

            public string this[int index] //an indexer uses the "this" keyword. This allows you to call an instance of "this" class with an indexer, and the get/set codes figure out what to do based on the index of the instance called.
            {
                get
                {
                    return names[index];
                }
                set
                {
                    names[index] = value;
                }
            }
            //This doesn't really seem that different to calling a class method with an argument, and then using that argument to check the index of a string? But it doesn't use the dot operator so i guess it's different. It's treated like a variable property and can be used to access a private variable "directly" instead of calling a method which might be more eficient? i guess?
        }

        class Box //This contains an overloaded operator (Also confusing)
        {
            public int Height { get; set; }
            public int Width { get; set; }

            public Box(int h, int w)
            {
                Height = h;
                Width = w;
            }

            public static Box operator+ (Box a, Box b) //Overloaded operator
            {
                int h = a.Height + b.Height;
                int w = a.Width + b.Width;
                Box res = new Box(h, w);
                return res;
                //This seems to instantiate a new Box object based on the addition of other objects.
                //the overloaded operator checks for that specific operation of objects of that type and then does that operation.
                //The object before the operator keyword defines what type of object to check for and return, in this case it checks for asigning instances of the Box class and return a new Box
            }
        }
    }
}
