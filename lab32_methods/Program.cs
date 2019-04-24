using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab32_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. in another methods (not recommended as gets messy)

            void DoSomething()
            {
                Console.WriteLine("Hey I am doing something");
            }

            // call it
            DoSomething();
            DoSomethingElse();

            // let's look at class Dog
            var d = new Dog();
            d.Bark();
            // static field ATTACHED TO WHOLE CLASS NOT PARTICULAR INSTANCE
            Console.WriteLine(Dog.NumLegs);
        }

        // 2. In the same class using STATIC KEYWORD WHICH ATTACHES METHOD TO THIS CLASS
        static void DoSomethingElse()
        {
            Console.WriteLine("Hey I'm now doing something else");
        }
    }


    // 3. In another class either as STATIC OR INSTANCE method

    class Dog
    {
        // instance method
        public void Bark()
        {
            Console.WriteLine("Dog is now barking loudly");
        }

        // static method
        public static int NumLegs = 4;


    }
}
