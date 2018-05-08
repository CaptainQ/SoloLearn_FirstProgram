using System;
using System.Collections.Generic; //Prebuilt Collections tools in .NET Framework useful for storing and manipulating data.
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class GenericsProgram
    {
        static void Main(string[] args)
        {
            int a = 4;
            int b = 9;
            Swap<int>(ref a, ref b); //When calling a generic method you have to set the generic variable by writing the type instead of T like we did down below.
            //Now b is 4 and a is 9

            string x = "Hello";
            string y = "World";
            Swap<string>(ref x, ref y); //Here we used the same method with strings instead of int's
            //Now x is "World" and y is "Hello"

            double num = 7.42;
            string wrd = "Test";
            Func(num, wrd); //Apparently it isn't even required that you specify what type you are working with as long as the values you are passing have established types, the new local generic variables will attempt to use that type. (This allows for conflicts if you only create one generic type and try to use it for more than one type)

            Func<double, string>(num, wrd); //Thgis is how you'd write it out with multiple specified types.

            Stack<int> intStack = new Stack<int>();
            Stack<string> stringStack = new Stack<string>();
            Stack<Person> PersonStack = new Stack<Person>(); //Can use custom class types too

            intStack.Push(3);
            intStack.Push(6);
            intStack.Push(7);
            //Generic class methods work just like normal

            Console.WriteLine(intStack.Get(1)); //Outputs 6

            List<string> colors = new List<string>();
            colors.Add("Red");
            colors.Add("Green");
            colors.Add("Pink");
            colors.Add("Blue");
            //Defined a List that stores strings

            foreach (var color in colors)
            {
                Console.WriteLine(color);
            } //Itterated through that list with a for loop
            //Outputs
            /* Red
             * Green
             * Pink
             * Blue
             */

            //The list class has usefull methods:
            /* Add adds an element to the List.
             * Clear removes all elements from the List.
             * Contains determines whether the specified element is contained in the List.
             * Count returns the number of elements in the List.
             * Insert adds an element at the specified index.
             * Reverse reverses the order of the elements in the List
             */

            //Lists are more useful than arrays because the list can grow and shrink dynamically but an array must be instanciated with a specific size.

            //Commonly used generic collections include:
            /*
             * Dictionary<Tkey, TValue> represents a collection of key/value pairs that are organized based on the key.
             * List<T> represents a list of objects that can be accessed by index. Provides methods to search, sort, and modify lists.
             * Queue<T> represents a first in, first out (FIFO) collection of objects.
             * Stack<T> represents a last in, first out (LIFO) collection of objects.
             */
            
        }

        static void SwapInt(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;

            //This method only works with integers. Making it work with other types would require lots overloading, lots of rewriting code, and makes it hard to manage changes to the method across all overloaded versions.
        }

        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;

            //T is the gode for a generic type. It can be named anything but T is most common.
            //the <T> pert of the name sets the name of the generic type name for this method
        }

        static void Func<T, U>(T x, U y)
        {
            Console.WriteLine(x + " " + y);
        }

        class Stack<T>
        {
            int index = 0;
            T[] innerArray = new T[100];
            public void Push(T item)
            {
                innerArray[index++] = item;
            }
            public T Pop()
            {
                return innerArray[--index];
            }
            public T Get(int k)
            {
                return innerArray[k];
            }
        }

        class Person
        {
            
        }
    }
}
