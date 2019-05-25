using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_73_dynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = 7;
            Console.WriteLine(x.GetType());
            dynamic y = 7;
            Console.WriteLine(y.GetType());
            y = "hi";
            Console.WriteLine(y.GetType());
            y = true;
            Console.WriteLine(y.GetType());
            y = new int[10];
            Console.WriteLine(y.GetType());
        }
    }
}
