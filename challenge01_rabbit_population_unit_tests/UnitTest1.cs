using NUnit.Framework;
using challenge01_rabbit_population;

namespace Tests
{
    public class Tests
    {
        /// <summary>
        /// Tests the RabbitSimulation method
        /// </summary>
        /// <param name="seconds">The amount of time the simulation is running</param>
        /// <param name="rabbits">The number of rabbits in the simulation</param>
        [TestCase(0, 2)]
        [TestCase(1, 4)]
        [TestCase(2, 8)]
        [TestCase(3, 16)]
        [TestCase(4, 32)]
        [TestCase(5, 64)]
        [TestCase(16, 100000)]  // If populationLimit is set to 100k
        public void TestRabbitSimulation(int seconds, int rabbitsExpected)
        {
            // arrange

            // act
            var result = Program.RabbitSimulation(seconds)[seconds];

            // assert
            Assert.AreEqual(rabbitsExpected, result);
        }
    }
}