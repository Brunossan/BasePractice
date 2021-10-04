using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject.Exercises;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Exercises.Tests
{
    [TestClass]
    public class IslandPerimeterTests
    {
        [TestMethod]
        public void Example1()
        {
            var testObj = new IslandPerimeter();
            var grid = new int[][]{new int[]{0,1,0,0},new int[]{1,1,1,0}, new int[]{0,1,0,0}, new int[]{1,1,0,0} };
            Assert.AreEqual(testObj.FindIslandPerimeter(grid), 16);
        }

        [TestMethod]
        public void Example2()
        {
            var testObj = new IslandPerimeter();
            var grid = new int[][]{new int[]{1}};
            Assert.AreEqual(testObj.FindIslandPerimeter(grid), 4);
        }

        [TestMethod]
        public void Example3()
        {
            var testObj = new IslandPerimeter();
            var grid = new int[][]{new int[]{1,0}};
            Assert.AreEqual(testObj.FindIslandPerimeter(grid), 4);
        }
    }
}