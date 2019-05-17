using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace challenge01_rabbit_population_web
{
    public partial class Population : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int iteration = 0;
            int population = 2;

            do
            {

                population = RabbitSimulation(iteration++);
            } while (Int32.Parse(maxPop.Text) > population);
            
            Label1.Text = $"{Environment.NewLine}{Environment.NewLine}" +
                $"It takes {iteration-1} iterations to reach a population limit of {maxPop.Text} rabbits.";
        }

        /// <summary>
        /// Will do a simulation on a rabbit population.
        /// </summary>
        /// <param name="seconds">For how many seconds we want the simulation to run.</param>
        /// <returns>The number of rabbits when the simulation is finished.</returns>
        public static int RabbitSimulation(int maxTime)
        {
            int popLimit = 1000000000;
            List<Rabbit> rabbitList;

            rabbitList = new List<Rabbit>
            {
                new Rabbit(),
                new Rabbit()
            };

            int seconds = 0;

            while (seconds < maxTime)
            {
                ++seconds;

                List<Rabbit> babyRabbits = new List<Rabbit>();
                foreach (var rabbit in rabbitList)
                {
                    if (rabbitList.Count + babyRabbits.Count >= popLimit)
                    {
                        break;
                    }
                    babyRabbits.Add(new Rabbit());
                }
                rabbitList.AddRange(babyRabbits);
            }
            return rabbitList.Count;
        }
    }

    /// <summary>
    /// Template for rabbits
    /// </summary>
    class Rabbit
    {

    }
}