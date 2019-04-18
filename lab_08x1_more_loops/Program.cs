// A slightly larger exercise involving loops
using System;

namespace lab_08x1_more_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output 1..1000 using a for loop
            for(int i = 0; i < 1000; ++i)
            {
                Console.WriteLine(i);
            }

            // Output 1..1000 using a while loop
            {
                int i = 0;
                while (true)
                {
                    if (i < 1000)
                    {
                        Console.WriteLine(i++);
                    }
                    else break;
                }
            }

            // Create an array and fill with 1..1000
            int[] numbers = new int[1000];
            for(int j = 0; j < numbers.Length; ++j)
            {
                numbers[j] = j;
            }

            // ..use foreach to output numbers in array
            foreach(var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
