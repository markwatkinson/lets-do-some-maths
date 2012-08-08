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
            Fraction target = new Fraction(10, 2);
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
            Fraction a = new Fraction(1, 2);
            Fraction b = new Fraction(2, 1);
            Fraction actual;
            actual = (a * b);
            Assert.AreEqual(2, actual.numerator);
            Assert.AreEqual(2, actual.denominator);
        }


        /// <summary>
        ///A test for op_Division
        ///</summary>
        [TestMethod()]
        public void op_DivisionTest()
        {

            Fraction expected = new Fraction(1, 2); 
            Fraction actual = new Fraction(1) / new Fraction(2);
            Assert.AreEqual(true, expected == actual);

            expected = new Fraction(3, 2);
            actual = new Fraction(3) / new Fraction(2);
            Assert.AreEqual(true, expected == actual);

            actual = new Fraction(1, 2) / new Fraction(1, 6);
            actual.Simplify();
            expected = new Fraction(3, 1);
            Assert.AreEqual(true, expected == actual);
        }
    }
}
