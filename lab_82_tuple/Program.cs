using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_82_tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            DoThis();
            Console.WriteLine($"AlsoDoThis() = {AlsoDoThis()}");
            Console.WriteLine($"AndThis: {AndThis(out string y), -10}{y}");

            var output = ReturnTupleWare();

            Console.WriteLine($"ReturnTupleWare() = ({output.Item1}, {output.Item2})");
        }

        static void DoThis()
        {
            Console.WriteLine("I am doing nothing");
        }

        static int AlsoDoThis()
        {
            return -1;
        }

        static int AndThis(out string y)
        {
            y = "returning this string";
            return -100;
        }

        static Tuple<int, string> ReturnTupleWare()
        {
            return new Tuple<int, string>(-1000, "This was easy.");
        }

        static (int Number, string Text) ReturnTupleWareB()
        {
            return (33, "some text");
        }
    }
}
