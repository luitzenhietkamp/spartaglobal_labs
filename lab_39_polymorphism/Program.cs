using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_39_polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new BaseParent();
            p.HaveAParty();
            var c = new DerivedChild();
            c.HaveAParty();
            var t = new DerivedTeenager();
            t.HaveAParty();

            var cat = new Cat();
            cat.Sound();
            var dog = new Dog();
            dog.Sound();
        }
    }

    class BaseParent {
        // Parent is VIRTUAL (can be overriden)
        public virtual void HaveAParty() { Console.WriteLine("Having A Dinner Party"); }
    }

    class DerivedChild : BaseParent {
        public override void HaveAParty() { Console.WriteLine("Having A Swimming Party"); }
    }

    class DerivedTeenager : BaseParent {
        public override void HaveAParty() { Console.WriteLine("Going Out With Friends"); }
    }

    class Animal
    {
        public virtual void Sound() { Console.WriteLine("*Animal noise*"); }
    }

    class Cat : Animal
    {
        public override void Sound() { Console.WriteLine("Meow"); }
    }

    class Dog : Animal
    {
        public override void Sound() { Console.WriteLine("Woof"); }
    }
}
