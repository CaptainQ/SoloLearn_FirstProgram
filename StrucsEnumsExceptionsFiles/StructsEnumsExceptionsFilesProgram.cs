using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //Used for creating/deleting files, reading from/writing to files, choosing files, etc.

namespace StrucsEnumsExceptionsFiles
{
    class StructsEnumsExceptionsFilesProgram
    {
        static void Main(string[] args)
        {
            Book b;
            b.title = "Test";
            b.price = 6.99;
            b.author = "David";

            Point p = new Point(10, 15); //Used New to activate the struct's contructor.
            Console.WriteLine(p.x); //outputs 10

            int x = (int)Days.Tue; //in order to asign Enum values to int variables you have to specify the type in parentheses in the declaration, like this.
            Console.WriteLine(x);

            TrafficLights t = TrafficLights.Red;
            switch (t)
            {
                case TrafficLights.Green:
                    Console.WriteLine("Go!");
                    break;
                case TrafficLights.Red:
                    Console.WriteLine("Stop!");
                    break;
                case TrafficLights.Yellow:
                    Console.WriteLine("Caution!");
                    break;
            } //outputs "Stop!"

            try
            {
                int[] arr = new int[] { 4, 5, 8 };
                Console.Write(arr[8]);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            } // Index was outside the bounds of the array.

            //Try blocks can have multiple catch blocks based on different exceptions.
            /* Common exceptions are:
             * FileNotFoundException
             * FormatException
             * IndexOutOfRangeException
             * InvalidOperationException
             * OutOfMemoryException
             */

            int z;
            int y;
            try
            {
                Console.WriteLine("Enter numbers to divide");
                z = Convert.ToInt32(Console.ReadLine());
                y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(z / y);
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("Cannot divide by 0");
            }
            catch(Exception e)
            {
                Console.WriteLine("An error occured");
            }

            int result = 0;
            int num1 = 8;
            int num2 = 4;
            try
            {
                result = num1 / num2;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Error");
            }
            finally
            {
                Console.WriteLine(result);
            } //The finally code block executes whether or not the try block throws an exception.

            string str = "Some text";
            File.WriteAllText("Test.txt", str); //The WriteAllText() method saves the text from the variable to the file location written in ""'s. File reading is local to the application file.

            try
            {
                string txt = File.ReadAllText("test.txt"); //The ReadAllText() method returns a string containing the text of the file path.
                Console.WriteLine(txt);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //Other System.OI.File methods include:
            /* 
             * AppendAllText() - appends text to the end of the file (Useful for error logs i guess)
             * Create() - creates a file in the specified location.
             * Delete() - Deleted the specified file.
             * Exists() - Determines whether the specified file exists.
             * Copy() - Copies a file to a new location.
             * Move() - Moves a specified file to a new location.
             */
        }

        struct Book
        {
            //a Struct type is a value type that encapsulates small groups of related variables.
            //structs share most of the same syntax as classes but are more limited.
            //They can be instanciated without using a new operator.
            public string title;
            public double price;
            public string author;

            //structs can contain methods, properties, indexers, and so on.
            //structs cannot contain default constructors (A constructor without perameters)
        }

        struct Point
        {
            //example of a struct with a constructor that takes paremeters.
            public int x;
            public int y;
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        enum Days { Sun, Mon, Tue=4, Wed, Thu, Fri, Sat};
        //the Eum keyword is used to declare an enumeration: A type that consists of a set of names constants called the enumerator list.
        //By default the first Enum value in a set is given the value 0 and each one is increased by one. If an Enum value is set manualy the next one is one larger than the previous. (So in the above example Wed is actually 5 because the one before it is 4. Three gets skipped)

        enum TrafficLights { Green, Red, Yellow };
    }
}
