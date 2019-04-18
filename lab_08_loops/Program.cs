// In this program a small exercise on loops was implemented
using System;

namespace lab_08_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            // Print a number and it's square for 0..9
            for(int i = 0; i < 10; ++i)
            {
                Console.WriteLine($"Your number is {i}");
                Console.WriteLine($"Number squared is {i * i}");
            }
        }
    }
}
