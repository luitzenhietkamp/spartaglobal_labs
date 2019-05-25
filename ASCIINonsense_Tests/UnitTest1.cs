using NUnit.Framework;
using hw_106_interview_prep;

namespace Tests
{
    public class Tests
    {
        [TestCase("hello", 10, -1)] // invalid input
        [TestCase("hello", 1, 101)] // 'e' is 101
        [TestCase("there",              3, 114)] // 'r' is 114
        [TestCase("HOW", 2, 87)] // 'W' is 87
        [TestCase("ARE", 0, 65)] // 'A' is 65
        [TestCase("you?", 3, 63)] // '?' is 63
        public void TestASCIINonsense(string input, int index, int expectedValue)
        {
            // Arrange

            // Act
            int returnedValue = ASCIINonsense.ASCIIFromStringIndex(input, index);

            // Assert
            Assert.AreEqual(expectedValue, returnedValue);
        }
    }
}