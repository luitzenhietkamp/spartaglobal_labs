using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab_79_task_wait
{
    class Program
    {
        static void Main(string[] args)
        {
            // Real life : array of tasks simulate batch jobs processed
            // during night
            var s = new Stopwatch();
            s.Start();

            var taskArray = new Task[3];
            taskArray[0] = Task.Run(() =>
            {
                Thread.Sleep(500);
                Console.WriteLine($"Task01 finishing at {s.ElapsedTicks}");
            });
            taskArray[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Task02 finishing at {s.ElapsedTicks}");
            });
            taskArray[2] = Task.Run(() =>
            {
                Thread.Sleep(1500);
                Console.WriteLine($"Task03 finishing at {s.ElapsedTicks}");
            });

            var singleTask = Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine($"Single task is finishing at {s.ElapsedTicks}");
            });
            
            Task.WaitAny(taskArray);    // wait until at least one task has completed
            Task.WaitAll(taskArray);
            singleTask.Wait();

            Console.WriteLine($"Program finished at {s.ElapsedTicks}");
            Console.ReadLine();
        }
    }
}
