using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge01_rabbit_population
{
    public class Program
    {
        static List<Rabbit> rabbitList;
        static void Main(string[] args)
        {
            Console.WriteLine($"Number of rabbits: {RabbitSimulation(20)[20]}");
            Process.Start("rabbit_population.csv");
        }

        /// <summary>
        /// Will do a simulation on a rabbit population.
        /// </summary>
        /// <param name="seconds">For how many seconds we want the simulation to run.</param>
        /// <returns>The number of rabbits when the simulation is finished.</returns>
        public static ArrayList RabbitSimulation(int maxTime)
        {
            int popLimit = 100000;
            ArrayList popAfterIteration = new ArrayList();

            // Write header to CSV file
            File.WriteAllText("rabbit_population.csv",
                              $"sep=,{Environment.NewLine}Time (seconds),Population");

            rabbitList = new List<Rabbit>();
            rabbitList.Add(new Rabbit());
            rabbitList.Add(new Rabbit());
            // Add the first population to the ArrayList
            popAfterIteration.Add(rabbitList.Count);

            int seconds = 0;

            while(seconds < maxTime)
            {
                // Write time and rabbit population to CSV file
                File.AppendAllText("rabbit_population.csv",
                                    $"{Environment.NewLine}{seconds},{rabbitList.Count}");

                System.Threading.Thread.Sleep(10);
                ++seconds;

                List<Rabbit> babyRabbits = new List<Rabbit>();
                foreach (var rabbit in rabbitList)
                {
                    if(rabbitList.Count + babyRabbits.Count >= popLimit)
                    {
                        break;
                    }
                    babyRabbits.Add(new Rabbit());
                }
                rabbitList.AddRange(babyRabbits);

                // Add the new population size to the array list
                popAfterIteration.Add(rabbitList.Count);

            }

            // Write final population to file
            File.AppendAllText("rabbit_population.csv",
                               $"{Environment.NewLine}{seconds},{rabbitList.Count}");

            return popAfterIteration;
        }
    }

    /// <summary>
    /// Template for rabbits
    /// </summary>
    class Rabbit
    {

    }
}
