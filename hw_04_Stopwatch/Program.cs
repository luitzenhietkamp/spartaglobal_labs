using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_04_Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Time: {Stopwatch.CountToPower(i)}");
            }
        }
    }

    public class Stopwatch
    {
        public static int CountToPower(int n)
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            int count = 1;

            for (int i = 1; i < Math.Pow(10, n); i++)
            {
                ++count;
            }

            stopwatch.Stop();

            return (int)stopwatch.ElapsedMilliseconds;
        }
    }


}
