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

            }

            {
                Console.WriteLine(i++);

                // is the same as
                
                Console.WriteLine(i);
                i += 1;
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }


            {
                int i = 0;

                while (i < 10)
                {
                    Console.WriteLine(i);
                    ++i;
                }
            }

            Console.WriteLine(i);

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


