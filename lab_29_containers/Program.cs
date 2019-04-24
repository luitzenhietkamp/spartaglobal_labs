using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static List<int> list01 = new List<int>();
        static List<string> list02 = new List<string>();
        static Stack<int> stack01 = new Stack<int>();
        static Queue<int> queue01 = new Queue<int>();

        static void Main(string[] args)
        {
            list01.Add(10);
            list01.Add(20);

            foreach (var item in list01)
            {
                Console.WriteLine(item);
            }
            // Shorthand 'lambda' or 'arrow' syntax for a loop
            list01.ForEach(item => Console.WriteLine(item));

            stack01.Push(10);
            stack01.Push(20);
            stack01.Push(30);
            Console.WriteLine(stack01.Contains(30));  // true
            Console.WriteLine(stack01.Pop());  // yield 30 and remove from stack
            Console.WriteLine("On the stack:");
            foreach (int item in stack01)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Top item is {stack01.Peek()}");

            // add 2 more items
            stack01.Push(50);
            stack01.Push(60);
            // use every item in the stack
            Console.WriteLine("On the stack:");
            while (stack01.Count != 0)
            {
                Console.WriteLine(stack01.Pop());
            }
            Console.WriteLine($"Items on the stack: {stack01.Count}");

            Console.WriteLine("\n\nQueue:");

            for (int i = 0; i < 10; ++i)
            {
                queue01.Enqueue(i * 13 + i % 3 + i % 5);
            }

            Console.WriteLine("Enter a number: ");
            int input = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Queue contains {input}: {queue01.Contains(input)}");

            Console.WriteLine($"The first item in line is {queue01.Peek()}");

            for (int i = 0; i < 3; i++)
            {
                queue01.Dequeue();
            }

            Console.WriteLine("Remaining items in the queue:");
            foreach (var item in queue01)
            {
                Console.WriteLine(item);
            }
        }

        static void DoThis()
        {

        }
    }
}
