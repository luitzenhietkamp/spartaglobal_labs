using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_41_constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            // 2. instatiate with default constructor
            var c = new MyClass();

            // 3. then create proper constructor
            // default one does not work anymore!
            var d = new MyClass(5, 10);
        }
    }

    class MyClass
    {
        int _a;
        int _b;

        public MyClass(int a, int b)
        {
            _a = a;
            _b = b;
        }

        public MyClass() { } // to make line 14 work again
    }
}
