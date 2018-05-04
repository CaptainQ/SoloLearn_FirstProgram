using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceProject
{
    class InheritanceProgram
    {
        static void Main(string[] args)
        {
            Dog d = new Dog();
            Console.WriteLine(d.Legs); //outputs 4

            d.Bark(); //outputs "Woof!"

            Student s = new Student("David");
            s.Speak(); //outputs "Hi there"

            s.SpeakName(); //outputs "My name is David."
            //s.Name = "Bob" would return an error because Bob is a protected member and cannot be accessed from outside the derived class.
            //A private member is not inhereted by the derived class.

            Shape c = new Circle();
            c.Draw(); //outputs "Circle Draw"

            Shape r = new Rectangle(); 
            r.Draw(); //outputs "Rect Draw"
            //instanciating these as the parent class is possible due to pollymorphism. This is useful for example if you have an array of the parent object type but need to populate it dynamically with versions that have unique methods like the shapes here.
        }
    }

    class Animal
    {
        public int Legs { get; set; }
        public int Age { get; set; }

        public Animal()
        {
            Console.WriteLine("Animal created");
        }

        ~Animal()
        {
            Console.WriteLine("Animal deleted");
        }
    }

    class Dog : Animal //Dog is derived from Animal and inherits all public members from Animal
    {
        public Dog() //Dog does not technically inherit the constructor or destructor for Animal, but they do still run when Dog is created or destroyed. They run before the derived class's constructor/destructor.
        {
            Console.WriteLine("Dog created");
            Legs = 4;
        }

        ~Dog()
        {
            Console.WriteLine("Dog Deleted");
        }

        public void Bark()
        {
            Console.WriteLine("Woof!");
        }
    }

    class Person : Animal //the base class (Animal) can have as many derived classes as you want.
    {
        protected string Name { get; set; } //This member can only be accessed from the derived classes. Protected is like private only it lets derived classes access it.

        public Person()
        {
            Legs = 2;
        }

        public void Speak()
        {
            Console.WriteLine("Hi there");
        }
    }

    sealed class Student : Person //even a child of another class can act as the parent for another new class
    {
        //This class has the sealed modifier, which prevents other classes from inhereting it or any of its members.
        int number;

        public Student(string nm)
        {
            Name = nm; //When Student is instanciated with a string it applies the string to the protected variable inhereted from the Person class.
        }

        public void SpeakName()
        {
            Console.WriteLine("My name is " + Name + ".");
        }
    }

    class Shape
    {
        public virtual void Draw() //the virtual keyword allows this method to be overrided by derived classes.
        {
            Console.WriteLine("Base Draw");
        }
    }

    class Circle : Shape
    {
        public override void Draw() //the override keyword means this method atempts to override the parent's method of the same name.
        {
            Console.WriteLine("Circle Draw");
        }
    }

    class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Rect Draw");
        }
    }
}
