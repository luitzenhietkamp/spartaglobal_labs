using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using lab_42_testme;

namespace Tests_Microsoft
{
    [TestClass]
    public class Demo_Test_For_Lab_42_TestMe
    {
        [TestMethod]
        public void Lab_42_TestMe_Test01()
        {
            // arrange
            var instance = new TestMe();
            var expected = 14.0;

            // act
            var actual = instance.BIDMAS01(10, 20, 5);

            // assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Lab_42_TestMe_Test02()
        {
            // arrange
            var instance = new TestMe();
            var expected = 53.0;

            // act
            var actual = instance.BIDMAS01(50, 30, 10);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
