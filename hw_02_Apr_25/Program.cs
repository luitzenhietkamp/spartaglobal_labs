using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_02_Apr_25
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Collections
    {
        public static int UseCollections(int a, int b, int c, int d, int e)
        {
            // Create List with 5 items
            var list = new List<int>() { a, b, c, d, e };
            var stack = new Stack<int>();
            var queue = new Queue<int>();

            // Iterate over list : multiply each item by 2 : add to a Stack!
            for (int i = 0; i < list.Count; i++)
            {
                stack.Push(2 * list[i]);
            }

            // Iterate over stack : add 10 to each number : add to a Queue!
            while (stack.Count != 0)
            {
                queue.Enqueue(10 + stack.Pop());
            }

            // Iterate over queue : return total
            var sum = 0;

            while(queue.Count != 0)
            {
                sum += queue.Dequeue();
            }

            return sum;
        }
    }
}
