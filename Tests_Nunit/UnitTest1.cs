using NUnit.Framework;

using lab_42_testme;
using hw_02_Apr_25;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var instance = new TestMe();
        }

        [Test]
        public void Lab_42_TestMe_Test01()
        {
            // arrange
            var instance = new TestMe();
            var expected = 53.0;

            // act
            var actual = instance.BIDMAS01(50, 30, 10);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10, 20, 5, 14.0)]
        [TestCase(20, 30, 6, 25.0)]
        [TestCase(30, 50, 10, 35.0)]
        public void Lab_42_TestMe_Test02(int a, int b, int c, double expected)
        {
            // arrange
            var instance = new TestMe();

            // act
            var actual = instance.BIDMAS01(a, b, c);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, 3, 4, 5, 80)]
        [TestCase(1, 1, 1, 1, 1, 60)]
        [TestCase(13, 14, 15, 16, 17, 200)]
        public void hw_02_Apr_25(int a, int b, int c, int d, int e, int expected)
        {
            // arrange

            // act
            var actual = Collections.UseCollections(a, b, c, d, e);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}