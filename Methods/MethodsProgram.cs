using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class MethodsProgram
    {
        static void Main(string[] args)
        {
            /* Every Method follows this format:
             * 
             * <return type> name(type1 par1, type2 par2, ..., typeN parN)
             * {
             *   List of statements
             * }
             * 
             * Where the return type is a data type (int, bool, double, etc.) that the method returns.
             * Void is also a valid type for a method that returns nothing, however that method cannot be called in a variable asignment, obviously.
             * The parentheses list the different parameters passed to the method. They are initialized locally within the instance of the method when the method itself is called.
             * Parameters are also optional
             * Parameters can be given default values which makes them optional.
             * ex:
             * static void Example(int x, int y=2)
             * In the above example if only one parameter is given it will default to 2 for the second one. If two parameters are given it will use both given values and ignore the default 2 value
             * Using the type "static" alongside the method return type is required for use within Main
            */

            do
            {
                Console.Write("Enter a nmber to be squared or type \"exit\" to move on: ");
                string usrInput = Console.ReadLine();
                if (usrInput.ToLower() == "exit")
                    break;
                int result = Sqr(Convert.ToInt32(usrInput));
                Console.WriteLine("{0} Squared is {1}.", usrInput, result);
            } while (true);

            do
            {
                Console.Write("Enter height or type \"exit\" to move on: ");
                string usrInput = Console.ReadLine();
                if (usrInput.ToLower() == "exit")
                    break;
                int height = Convert.ToInt32(usrInput);

                Console.Write("Enter width or type \"exit\" to move on: ");
                usrInput = Console.ReadLine();
                if (usrInput.ToLower() == "exit")
                    break;
                int width = Convert.ToInt32(usrInput);

                int area = Area(w: width, h: height);
                //Here i have listed the parameters out of order, but because they are marked as which variables they belong to it doesnt mater

                Console.WriteLine("A rectangle with a height of {0} and a width of {1} is {2}.", height, width, area);
            } while (true);

            //The previous method calls have been passing arguments "by value" by directly copying the value of the argument into a new local variable within the instance of the method
            //This next method call will pass arguments "by reference" by copying the arguments memory address into the parameter, instead of a new copy of the paramerter
            //Since the method now has access to the actual memory location of the origional variable any changes the method makes are permanent
            //use the ref keyword in the method's variable initialization as well as in the method call
            do
            {
                Console.Write("Enter a nmber to be squared or type \"exit\" to move on: ");
                string usrInput = Console.ReadLine();
                if (usrInput.ToLower() == "exit")
                    break;
                int input = Convert.ToInt32(usrInput);
                Console.Write("{0} Squared is ", input);
                SqrRef(ref input);
                Console.WriteLine("{0}.", input);
            } while (true);

            //The last way to pass an argument is "by output"
            //this allows you to pass the memory locations of empty variables to the method so that it can return to those external variables
            do
            {
                int a, b;
                GetValues(out a, out b);
                //Now a equals 5, b equals 42
                Console.WriteLine("a = {0}, b = {1}", a, b);
            } while (false);

            //Method overloading is when multiple methods have the same name but different parameters.
            //For example, you may have a print method that can handle multiple types of variables. you can use method overloading to write mutltiple Print methods that accept different variable types.
            int integer = 3;
            double dbl = 17.45;
            Print(integer);
            Print(dbl);

            //The next Method is recursive, meaning it calls itself within its own code (which will call itself again)
            //This is different than calling methods sequentially, as these calls are nested within each other
            do
            {
                Console.Write("Enter a number to find it's factorial: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                    break;
                int data = Convert.ToInt32(input);
                Console.WriteLine("The factorial of {0} is {1}", data, Fac(data));
            } while (true);

            Console.WriteLine("(Type exit to skip the pyramid section)");
            do
            {
                Console.Write("How many layers do you want your pyramid to have? ");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                    break;
                int height = Convert.ToInt32(input);
                Console.WriteLine();
                DrawPyramid(height);
            } while (true);
        }

        //Squares the number given to it
        static int Sqr(int x)
        {
            int result = x * x;
            return result;
        }

        //Calculates area of rectangle
        static int Area(int h, int w)
        {
            return h * w;
        }

        //refference argument example version of Sqr
        static void SqrRef(ref int x)
        {
            x = x * x;
            //notice there is no return line since it changes the variable outside the method
        }

        //x =5, y = 42; passed by output
        static void GetValues(out int x, out int y)
        {
            x = 5;
            y = 42;
        }

        //Method Overloading
        static void Print(int a)
        {
            Console.WriteLine("Value " + a);
        }

        static void Print(double a)
        {
            Console.WriteLine("Value " + a);
        }

        //Recursive Method
        static int Fac(int num)
        {
            if (num == 1) //Exit condition
            {
                return 1;
            }
            return num * Fac(num - 1);
        }

        //Build a pyramid (sololearn example)
        static void DrawPyramidBroken(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= n; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= 2 * i - 1; k++)
                {
                    Console.Write("*"+" ");
                }
                Console.WriteLine();
            }
        }

        //Build a pyramid (My solution)
        static void DrawPyramid(int layers, int iteration = 0)
        {
            if (layers == 1)
            {
                for (int first = 0; first <= iteration; first++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine("*");
            }
            else
            {
                DrawPyramid(layers - 1, ++iteration);
                for (int sp = 1; sp <= iteration; sp++)
                {
                    Console.Write("  ");
                }
                for (int st = 1; st <= (layers * 2) - 1; st++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
    }
}
