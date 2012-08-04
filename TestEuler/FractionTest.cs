using Euler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestEuler
{
    
    
    /// <summary>
    ///This is a test class for FractionTest and is intended
    ///to contain all FractionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FractionTest
    {

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        
        /// <summary>
        ///A test for Simplify
        ///</summary>
        [TestMethod()]
        public void SimplifyTest()
        {
            Fraction target = new Fraction() { numerator = 10, denominator = 2 };
            target.Simplify();
            Assert.AreEqual(5, target.numerator);
            Assert.AreEqual(1, target.denominator);
        }

        /// <summary>
        ///A test for op_Multiply
        ///</summary>
        [TestMethod()]
        public void op_MultiplyTest()
        {
            Fraction a = new Fraction() { numerator = 1, denominator = 2 };
            Fraction b = new Fraction() { numerator = 2, denominator = 1 };
            Fraction actual;
            actual = (a * b);
            Assert.AreEqual(2, actual.numerator);
            Assert.AreEqual(2, actual.denominator);
        }
        
    }
}
