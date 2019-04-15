using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_08_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            // FOR
            for(int i = 0; i < 10; ++i)
            {
                Console.WriteLine($"Your number is {i}");
                Console.WriteLine($"Number squared is {i * i}");
            }
        }
    }
}
