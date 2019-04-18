// Small practice with dll programming.
// The dll file referenced here is coded in the the "lab_04_dll"
// (sub)project

using System;
using lab_04_dll;   // Important to make dll file available in current program

namespace lab_05_use_dll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading from another library");
            var item = new LuitzenLibrary();
            Console.WriteLine(item.LuitzensData);
            Console.WriteLine(item.LuitzensFixedData);
        }
    }
}
