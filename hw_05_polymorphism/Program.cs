using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_05_polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Parent
    {
        public virtual string AsString()
        {
            return "I am a parent.";
        }
    }

    public class Child : Parent
    {
        public override string AsString()
        {
            return "I am a child.";
        }
    }
}
