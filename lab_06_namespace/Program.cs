using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luitzen1;

namespace lab_06_namespace
{
    class Program
    {
        static void Main(string[] args)
        {
            var item = new luitzen1.GreatStudent();
            var item2 = new GreatStudent();

            var item3 = new luitzen2.ExcellentLearning();
            Console.WriteLine(item3.LearnLots);
        }
    }
}

namespace luitzen1
{
    public class GreatStudent { }
}

namespace luitzen2
{
    public class ExcellentLearning {
        public string LearnLots = "running C#";
    }
}