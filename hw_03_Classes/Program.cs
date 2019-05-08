using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_03_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Dog {
        public int Age { get; set; }
        public int Height { get; set; }

        public Dog() { }

        public Dog(int age, int height)
        {
            Age = age;
            Height = height;
        }
        
        public void Grow()
        {
            ++Age;
            Height += 5;
        }
    }
}
