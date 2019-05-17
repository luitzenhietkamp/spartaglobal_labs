using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_59_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Child();
            c.Property01 = 10;      // INTERFACE FIELD
            c.UseThisTool02();      // INTERFACE METHOD
        }
    }

    interface IDoThis01
    {
        int Property01 { get; set; }
        void UseThisTool02();
    }

    interface IDoThis02
    {
        void UseThisTool02();
    }

    class Parent
    {

    }

    class Child : Parent, IDoThis01, IDoThis02
    {
        public int Property01 { get; set; }
        public void UseThisTool02() { }
    }

    abstract class Parent1
    {
        public abstract void DoSomething();

        public void DoSomethingElse()
        {
            Console.WriteLine("???");
        }
    }

    class Child2 : Parent1
    {
        public override void DoSomething()
        {
            DoSomethingElse();
            throw new NotImplementedException();
        }
        
    }
}
