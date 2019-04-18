// Small practice exercise involving namespaces
using System;
using luitzen1;

namespace lab_06_namespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // name space luitzen1 does not need to be mentioned
            // due to using declaration at the top of the file
            var item = new luitzen1.GreatStudent();
            var item2 = new GreatStudent();

            // name space luitzen2 does need to be mentioned
            // due to missing using declaration
            var item3 = new luitzen2.ExcellentLearning();
            Console.WriteLine(item3.LearnLots);
        }
    }
}

// Separate namespace
namespace luitzen1
{
    public class GreatStudent { }
}

// Separate namespace
namespace luitzen2
{
    public class ExcellentLearning {
        public string LearnLots = "running C#";
    }
}