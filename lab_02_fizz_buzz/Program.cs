using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
