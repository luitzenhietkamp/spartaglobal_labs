using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_46_dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Dictionary<int, string>();
            d.Add(10, "hi");
            d.Add(20, "there");
            d.Add(30, "amazing");
            d.Add(40, "C# coders");

            // forbidden
            // d.Add(40, "some more data")
           
            // iterate : loop over items
            foreach(var key in d.Keys)
            {
                Console.WriteLine($"Index is {key} and value is {d[key]}");
            }

            var d2 = new SortedDictionary<string, int>();
            d2["hi"]++;

            foreach (var item in d2)
            {
                Console.WriteLine($"Index is {item.Key} and value is {d2[item.Key]}");
            }
        }
    }
}
