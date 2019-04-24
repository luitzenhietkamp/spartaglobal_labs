using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab_38x1_t_unit_testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAdd()
        {               // Expect        // Result
            Assert.AreEqual(11, lab_38x1_unit_testing.SimpleMath.AddOne(10));
        }
    }
}
