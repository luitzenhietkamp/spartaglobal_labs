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
                foreach (var ޠஇቜðʣ in args)
                {
                    Console.WriteLine("Your item is - " + ޠஇቜðʣ.ToUpper());
                }
            }
        }

        static string ReverseString(string s)
        {
            string ret = "";

            for(int i = s.Length -1; i >= 0; --i)
            {
                ret += s[i];
            }

            return ret;
        }
    }
}


