
using System;
using System.IO;
using static System.Console;

namespace lab_85_streaming
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = new string[] { "Some", "data", "here" };
            File.WriteAllLines("file.txt", data);
            File.AppendAllLines("file.txt", data);
            File.AppendAllText("file.txt", $"and some extra data here{Environment.NewLine}");
            File.AppendAllText("file.txt", DateTime.Now.ToString());

            // Several ways to read a file and determine
            // file has been read

            var Ⰸ = new StreamReader("file.txt");

            // variable to hold data while being read in
            string Ⰸ1 = null;

            // two things at once
            // firstly reading the next line of output => string
            // checking that this line is not null
            WriteLine($"{Environment.NewLine}{Environment.NewLine}Testing For Output Not Null");
            while((Ⰸ1 = Ⰸ.ReadLine()) != null)
            {
                WriteLine(Ⰸ1);
            }

            // Second way of determining end of file has been reached
            WriteLine($"{Environment.NewLine}{Environment.NewLine}Testing For End Of Stream reached");
            var Њ = new StreamReader("file.txt");
            while (!Њ.EndOfStream)
            {
                WriteLine(Њ.ReadLine());
            }
        }
    }
}
