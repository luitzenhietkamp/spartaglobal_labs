using NUnit.Framework;

using lab_42_testme;
using hw_02_Apr_25;
using hw_03_Classes;
using hw_05_polymorphism;

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

        // hw_02_Apr_25() adds 5 numbers to a list
        // multiplies each entry by 2
        // adds 10 to each number (+50 in total)
        // adds up all numbers
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

        [TestCase(3, 40, 4, 45)]
        public void hw_03_classes(int Age, int Height, int expectedAge, int expectedHeight)
        {
            // arrange
            var dog = new Dog(Age, Height);

            // act
            dog.Grow();

            // assert
            Assert.AreEqual(expectedAge, dog.Age);
            Assert.AreEqual(expectedHeight, dog.Height);
        }

        [TestCase("Parent", "I am a parent.")]
        [TestCase("Child", "I am a child.")]
        public void hw_05_polymorphism(string option, string expected)
        {
            Parent person;

            // arrange
            if (option == "Parent")
            {
                person = new Parent();
            }
            else
            {
                person = new Child();
            }

            // act
            var reply = person.AsString();

            // assert
            Assert.AreEqual(reply, expected);
        }
    }
}