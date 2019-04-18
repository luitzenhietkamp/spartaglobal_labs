// C# implementation of FizzBuzz
// Prints 100 numbers. If the number is divisible by 3,
// the program outputs "Fizz" to the console instead of
// the number. If the number is divisible by 5, the
// console output is "Buzz". If the number is divisible
// by both 3 and 5, i.e. divisible by 15, the output
// will be "FizzBuzz".
//
// There are two (slightly) different solutions in the
// file. It's possible to switch between the solutions
// by unccommenting the commented code and commenting
// the current solution out.

using System;

namespace lab_02_fizz_buzz
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 1; i < 101; ++i)
            {
                //if(i % 15 == 0)
                //{
                //    Console.WriteLine("fizzbuzz");
                //} else if(i % 3 == 0)
                //{
                //    Console.WriteLine("fizz");
                //} else if(i % 5 == 0)
                //{
                //    Console.WriteLine("buzz");
                //} else
                //{
                //    Console.WriteLine(i);
                //}
                if(i % 3 == 0)
                {
                    Console.Write("fizz");
                }
                if(i % 5 == 0)
                {
                    Console.Write("buzz");
                }
                if(i % 3 != 0 && i % 5 != 0)
                {
                    Console.Write(i);
                }
                Console.WriteLine();
            }
        }
    }
}
