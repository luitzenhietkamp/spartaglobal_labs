using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_03_loops
{
    class Program
    {
        static void Main(string[] args)
        {
            // ALL PROGRAMMING

            // 4 types of loops

            // for..
            // output square in range (0..10)
            Console.WriteLine("for loop (1):");
            for(int i = 0; i < 10; ++i)
            {
                Console.WriteLine(i * i);
            }

            // output squares in range of steps 3 (0..30)
            Console.WriteLine("-----\nfor loop (2):");
            for (int i = 0; i < 30; i += 3)
            {
                Console.WriteLine(i * i);
            }

            // while..
            // keep pestering the user for number 42
            Console.WriteLine("-----\nwhile loop:");
            int x = 0;

            while(x != 42)
            {
                Console.Write("Enter 42: ");
                x = Int32.Parse(Console.ReadLine());
            }

            // do..while..
            // keep pestering the user for number 24
            Console.WriteLine("-----\ndo-while loop:");
            do
            {
                Console.Write("Enter 24: ");
                x = Int32.Parse(Console.ReadLine());
            } while (x != 24);

            // foreach..
            // ask the user for input, then output each character of the input to the console
            Console.WriteLine("-----\nforeach loop:");
            Console.Write("Write something: ");
            string input = Console.ReadLine();
            foreach(var c in input)
            {
                Console.WriteLine(c);
            }
        }
    }
}
