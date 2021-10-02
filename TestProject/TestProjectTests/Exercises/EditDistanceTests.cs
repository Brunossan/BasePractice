
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.Exercises.Tests
{
    [TestClass]
    public class EditDistanceTests
    {
        [TestMethod]
        public void TestCase2()
        {
            var testClass = new EditDistance();

            Assert.AreEqual(testClass.MinDistance("intention","execution"), 5);

        }

        [TestMethod]
        public void TestCase1()
        {
            var testClass = new EditDistance();

            Assert.AreEqual(testClass.MinDistance("horse","ros"), 3);
        }

    }
}