using System;

namespace _01_hello_world
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");

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


