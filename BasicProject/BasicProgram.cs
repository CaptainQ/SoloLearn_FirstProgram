using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearn_FirstProgram
{
    class BasicProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!!");

            int x = 89;
            Console.WriteLine(x);

            x = 10;
            double y = 20;
            Console.WriteLine("x = {0}; y = {1}", x, y);
            //The {#} within the string defines a temp variable local to the Console.WriteLine() method, and then the temp vars are defined starting from 0 seperated by commas.
            //Console.WriteLine adds a line break after the text, Console.Write does not.

            string yourName;
            Console.WriteLine("What is your name?");
            yourName = Console.ReadLine();
            Console.WriteLine("Hello {0}", yourName);

            Console.Write("How old are you? (Only enter numbers please) ");
            int age = Convert.ToInt32(Console.ReadLine());
            //This take input from the user in the form of a string and converts it to 32-bit integer.
            //Other int options include Convert.ToInt16, Convert.ToInt64. the default int in C# is 32-bit.
            //If a non-integer value is entered (for example, letters), the Convert.ToInt will fail and throw and error.
            Console.WriteLine("You are {0} years old", age);

            //Comments:
            //These are single-line comments.

            /* Longer comments need multi-line comments
             * 
             * Those coments are marked with /'s and *'s
             * 
             * /'s go on the outside
             */

            /* Multi-line comments don't need the *'s on the left hand side.
               
               But they do kinda help organize the comment.
            */

            var num = 15;
            //Variables do not always need to be declared before use. C# can decide the type based on the expression it is asigned to.
            //These Variables can not change once asigned.
            //Attempting to change num to a string throws an error.
            //These implicitily typed variables must be initialized when declared.
            /*
             * var num;
             * num = 42;
             * 
             * This will throw an error because numb does not have a type when it is declared.
             * 
             */

            const double PI = 3.14;
            //Constants may not be changed later, they are read only
            //PI = 8; later on in the code will throw an error

            //Arithmetic Operators
            /*
             * Operator      Symbol    Form
             * Addition         +      x + y
             * Subtraction      -      x - y
             * Multiplication   *      x * y
             * Division         /      x / y
             * Modulus          %      x % y
             */

            int a = 10;
            int b = 4;
            Console.WriteLine("{0} plus {1} equals {2}", a, b, a + b);
            //Expressions can also be used in place of a single variable in a Console.Write

            int c = 10 / 4;
            Console.WriteLine(c);
            //Because both opperands are integers the remainder is dropped in order to return a third integer.
            //Avoid division by 0.

            int d = 10 % 4;
            Console.WriteLine(d);
            //The Modulus operator returns the remainder of an integer division.

            //Order of operations applies just like everywhere else.
            //When in doubt, use ( )

            // The = counts an an operator as well, the assignment operator
            //C# allows for compound assignment operators that preform an operation and an asignment in one statement.
            int z = 42;
            z += 2; //equivalent to z = z + 2
            z -= 6; //equivalent to z = z - 6
                    //etc.

            //The increment operator increases an integer's value by one
            //Presumably only works on integers
            z++; //equivalent to z = z + 1

            int prePost = 5;
            int check = ++prePost;
            Console.WriteLine("prePost: {0}, check: {1}", prePost, check);
            prePost = 5;
            check = prePost++;
            Console.WriteLine("prePost: {0}, check: {1}", prePost, check);
            //the prefix and postfix form of the increment operator are confusing.
            //The prefix version where the operator comes before the variable litterally changes the variable in question on its own, and then does whatever expresion the operator was used in. This "permanently" changes the value of the var used in the prefix operator.
            //in the example above:
            //check = ++prePost;
            //actually executes as
            //prePost++; check = prePost;
            //The Postfix version also "permanently" changes the value of the var, but not until after the expresion has used the old value.
            //example:
            //check = prePost++;
            //executes as
            //check = prePost; prePost++;

            //-------------------------------------------------------------

            //If-Else statements

            int ifX = 8;
            int ifY = 3;
            if (ifX > ifY)
            {
                Console.WriteLine("x is greater than y");
            }
            else
            {
                Console.WriteLine("Never runs lol");
            }
            //Just an If/Else statement

            /* Relational operators
             * >= Greater than or equal to
             * <= Less than or equal to
             * == Equal to
             * != Not equal to
             */

            int ifElseIf = 33;
            if (ifElseIf == 8)
            {
                Console.WriteLine("Value of x is 8");
            }
            else if (ifElseIf == 18)
            {
                Console.WriteLine("Value of x is 18");
            }
            else if (ifElseIf == 33)
            {
                Console.WriteLine("Value of x is 33");
            }
            else
            {
                Console.WriteLine("No match");
            }
            //Outputs "Value of x is 33"
            //if else if statements

            int switchNum = 3;
            switch (switchNum)
            {
                case 1:
                    Console.WriteLine("one");
                    break;
                case 2:
                    Console.WriteLine("two");
                    break;
                case 3:
                    Console.WriteLine("three");
                    break;
                default:
                    Console.WriteLine("No match");
                    break;
            }
            //Outputs "three"
            //the number after "case" is the value it checks to be true, not the 1st case in the switch.
            //default acts as else in switch.
            //Make sure to close each case with break;
            //break prevents the code from "falling through" to the next case. This can be used intentionally if you want to trigger all following cases once true case has been found.
            //break can also be used to stop loops

            int whileLoop = 1;
            while (whileLoop < 6)
            {
                Console.WriteLine(whileLoop);
                whileLoop++;
            }
            /* Outputs
            1
            2
            3
            4
            5
            */
            //Just a while loop
            //Checks condition before first iteration

            int comp = 0;
            while (++num < 6)
            {
                Console.WriteLine(comp);
            }
            //Can use pre/sufix operations in the condition to increment the itteration value.
            //In this case the loop itterates the value FIRST and then runs.

            for (int i = 10; i < 15; i++)
            {
                Console.WriteLine("Value of i: {0}", i);
            }
            /*
            Value of i: 10
            Value of i: 11
            Value of i: 12
            Value of i: 13
            Value of i: 14
            */
            //The init and incriment statments can be left out if not needed
            //For example
            /*
            int x = 10;
            for ( ; x > 0 ; )
            {
                Console.WriteLine(x);
                x -= 3;
            }
            */
            //Semicolons are still needed even if they are blank.
            //for (; ;) {} is an infinite loop, don't do it, its bad.

            int doInt = 0;
            do
            {
                Console.WriteLine(doInt);
                doInt++;
            } while (doInt < 5);
            /* Outputs
            0
            1
            2
            3
            4
            */
            //Do While loops are just while loops only they check conditions after the loop.
            //Always runs once

            int breakNum = 0;
            while (breakNum < 20)
            {
                if (breakNum == 5)
                    break;

                Console.WriteLine(breakNum);
                breakNum++;
            }
            /* Outputs:
            0
            1
            2
            3
            4
            */
            //As soon as breakNum hits 5 it stops the loop cold and never gets to the part where it does the Writeline
            //continue; is simmilar to break, only instead of stopping the loop it just skips the remaining code on the CURRENT itteration and moves on to the next iteration.

            //Logical Operators
            /*
            Operator    Name of Operator    Form
              &&            And            x && y
              ||            Or             x || y
              !             Not              !x
            */
            int newAge = 42;
            int grade = 75;
            if (newAge > 16 && newAge < 80 && grade > 50)
                Console.WriteLine("Hey there");
            //&& combines the < > operations.

            //The ? : Operator
            newAge = 42;
            string msg;
            msg = (newAge >= 18) ? "Welcome" : "Sorry";
            Console.WriteLine(msg);
            //the ? : operator works like this
            //Exp1 ? Exp2 : Exp3;
            //in this case Exp1 is checked and then if true it stes value to "welcome", and if not it sets value to "Sorry"

            //Calculator
            do
            {
                Console.Write("x = ");
                string str = Console.ReadLine().ToLower();
                if (str == "exit")
                    break;
                int first = Convert.ToInt32(str);

                Console.Write("y = ");
                str = Console.ReadLine().ToLower();
                if (str == "exit")
                    break;
                int second = Convert.ToInt32(str);

                int sum = first + second;
                Console.WriteLine("Result: {0}", sum);
            } while (true);
        }
    }
}
