using Euler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestEuler
{
    
    
    /// <summary>
    ///This is a test class for TriangleSumTest and is intended
    ///to contain all TriangleSumTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TriangleSumTest
    {


        /// <summary>
        ///A test for calculateMaxRoute
        ///</summary>
        [TestMethod()]
        public void calculateMaxRouteTest()
        {

            TriangleSum target = new TriangleSum(); // TODO: Initialize to an appropriate value
            target.Set(@"3
7 4
2 4 6
8 5 9 3");
            long max = target.calculateMaxRoute();
            Assert.AreEqual(23, max);
        }
    }
}
