using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysStringsProject
{
    class ArrayStringProgram
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[5];
            //int[] is an object. That means it needs to be instantiated with the new keyword. this int[] holds 5 integer variables.
            //all basic data types can be given []'s and a number to be made into arrays
            //Keep in mind that while arrays count from zero when checking the index of a cell, they do NOT count from zero when declaring how many cells to have. This array has 5 cells, indexed at 0, 1, 2, 3, and 4.

            myArray[0] = 23;
            //This assigns the value 23 to the first (starting from zero) element on the array.

            string[] names = new string[3] { "John", "Mary", "Jessica" };
            //you can provide initial values to the array when it is declared by using curly braces and seperating values with commas.

            double[] prices = new double[] { 3.6, 9.8, 6.4, 5.9 };
            //In this case we can leave the size declaration blank since we used the curly braces when we initialized it.

            string[] states = { "Maryland", "Ohio", "Nevada", "Texas" };
            //We don't even need the new operator, you can declare them the same as basic variables.

            Console.WriteLine("The first slot on the array \"states\" is {0}", states[0]);
            //This is how you get the value of a specific index of an array.

            Console.Write("How many fibonacci numbers do you want to generate? ");
            int length = Convert.ToInt32(Console.ReadLine());
            int[] fib = FibGen(length);
            for (int f = 0; f < length; f++)
            {
                if (f != length-1)
                {
                    Console.Write("{0}, ", fib[f]);
                }
                else
                {
                    Console.WriteLine("{0}", fib[f]);
                }
            }
            //This demonstrates that you can use variables to define which index you are refferencing, as well as use the results of calculations within the index number.

            Console.WriteLine("");
            Console.WriteLine("And now for a more efficiently coded version:");
            foreach (int k in fib)
            {
                Console.Write("{0} ", k);
            }
            //The foreach loop is used specifically to itterate through an array.
            //the foreach loop sets the value od k to each index of the array it's given one by one until it is out of indexes.

            Console.WriteLine("");
            Console.WriteLine("");

            //Arrays can have more than one dimension. This is done by using commas inside the brackets
            int[,] x = new int[3, 4]; //This array is initiated with two dimensions, the first of length 3 and the second of length 4. adding extra dimensions is done by adding commas within the brackets.

            Console.WriteLine("This is how you would visualize an 3 x 4 sized array:");
            Console.WriteLine("       Col 1   col 2   col 3   col 4");
            for (int a = 0; a < 3; a++)
            {
                Console.Write("Row {0} ", a + 1);
                for (int b = 0; b < 4; b++)
                {
                    Console.Write("x[{0}][{1}] ", a, b);
                }
                Console.WriteLine("");
            }

            //You can initialize multidimensional arrays with curly braces just like single dimensional ones, but it gets messy. the curly braces need to be nested.
            int[,] someNums = { { 2, 3 }, { 5, 6 }, { 4, 6 } };
            //Each position in the top level curly braces defines what roww, and then the contents of that row are listed in the lower level curly braces. This can go as many levels deep as you feel like figureing out.
            Console.WriteLine("");
            Console.WriteLine("This is how you would visualize an 3 x 2 sized array:");
            Console.WriteLine("int[,] someNums = { { 2, 3 }, { 5, 6 }, { 4, 6 } };");
            Console.WriteLine("           Col 1         col 2");
            for (int a = 0; a < 3; a++)
            {
                Console.Write("Row {0} |", a + 1);
                for (int b = 0; b < 2; b++)
                {
                    Console.Write(" x[{0}][{1}] = {2} |", a, b, someNums[a,b]);
                }
                Console.WriteLine("");
            }

            //An array whos elements contain more arrays is called a jagged  array.
            int[][] jaggedArr = new int[3][]; //this is a decloration of a single dimensional array that has three elements, each of which is a single dimensional array in fintegers.
            //Putting [] after a variable declaration makes it an array, so the way to think of this is as if you took an int[] array as a variable type and added [] onto the end of it to make an array that contains int[]'s

            int[][] jaggedArr2 = new int[][]
            {
                new int[] {1,8,2,7,9 },
                new int[] {2,4,6},
                new int[] {33,42}
            };
            //This is the same as using curly braces on any other array, only i have aranged it vertically and each entry on the array is an int[] instantiation.
            int check = jaggedArr2[2][1]; //42
            //this accesses the second ellement of the 3rd array.
            //It's backwards because array is constructed like this: (jagged2[2]) [1]
            //The "first" index is reffering to the array contained within the top level array. The index loations cascade backwards because they are nested.

            //Arrays come with helpful properties and methods, like Length and Rank.
            //array.Length returns the number of elements in the array
            //array.Rank returns the number of dimensions of the array
            //The .Length propert can be useful in things like for loops where you need to know the number of times to itterate through that array (And the foreach wont work for your use case)

            //Array methods:
            //.Max returns the largest value
            //.Min returns the smallest value
            //.Sum returns the sum of all elements
            //These all return the actual value, not the index of where the largest value lives

            //Strings are basically just single dimensional arrays of characters, but this is a slight simplification.
            //TECHNICALLY speaking, they are their own objects. They may be built on top of the default array variable but they are more complex than that and contain a lot of unique methods, and there are some methods for regular arrays that dont work on strings.

            //Some string method examples:
            Console.WriteLine("");

            string s = "some text";
            Console.WriteLine(s.Length);
            //Outputs 9

            Console.WriteLine(s.IndexOf('t'));
            //Outputs 5

            s = s.Insert(0, "This is ");
            Console.WriteLine(s);
            //Outputs "This is some text"

            s = s.Replace("This is", "I am");
            Console.WriteLine(s);
            //Outputs "I am some text"

            if (s.Contains("some"))
                Console.WriteLine("found");
            //Outputs "found"

            s = s.Remove(4);
            Console.WriteLine(s);
            //Outputs "I am"

            s = s.Substring(2);
            Console.WriteLine(s);
            //Outputs "am"

            Console.WriteLine("");
            Console.WriteLine("Please type a short story about a dog:");
            Console.WriteLine(DogRemover(Console.ReadLine()));
        }

        static int[] FibGen(int l)
        {
            int[] a = new int[l];
            a[0] = 1;
            a[1] = 1;

            for (int i = 2; i< l; i++)
            {
                a[i] = a[i - 1] + a[i - 2];
            }

            return a;
        }

        static string DogRemover(string text)
        {
            text = text.ToLower().Replace("dog", "cat");

            return text;
        }
    }
}
