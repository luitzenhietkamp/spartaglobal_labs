using System;

namespace _01_hello_world
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");

            int i = 10;

            {
                Console.WriteLine(++i);

                // is the same as
                i += 1;
                Console.WriteLine(i);

                string test = "hello";
                string output = "";

                for (int j = test.Length - 1; j >= 0; --j)
                {
                    output += test[j];
                }
                string temp = test.Substring(4, -5);

                Console.WriteLine(test);

            }

            return;

            if (args.Length == 0)
            {
                Console.WriteLine("There are no arguments");
            }
            else
            {
                Console.WriteLine("Printing out arguments array");
                foreach (var word in args)
                {
                    Console.WriteLine("Your item is - " + word.ToUpper());
                }
            }
        }
    }
}


