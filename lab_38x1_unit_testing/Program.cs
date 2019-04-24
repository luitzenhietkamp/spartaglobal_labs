using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_38x1_unit_testing
{
    class Program
    {
        static void Main(string[] args)
        {

            int x = 10;

            Console.WriteLine($"Your new number is {SimpleMath.AddOne(x)}");
        }
    }

    public class SimpleMath
    {
        public static int AddOne(int x)
        {
            return x + 1;
        }
    }
}