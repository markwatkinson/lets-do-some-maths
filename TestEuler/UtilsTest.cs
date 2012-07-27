﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Euler;
namespace TestEuler
{
    [TestClass]
    public class UtilsTest
    {
       
        /// <summary>
        ///A test for IsPrime
        ///</summary>
        [TestMethod()]
        public void IsPrimeTest()
        {
            Assert.AreEqual(Utils.IsPrime(2), true);
            Assert.AreEqual(Utils.IsPrime(3), true);
            Assert.AreEqual(Utils.IsPrime(4), false);
            Assert.AreEqual(Utils.IsPrime(5), true);
            Assert.AreEqual(Utils.IsPrime(6), false);
            Assert.AreEqual(Utils.IsPrime(7), true);

            Assert.AreEqual(Utils.IsPrime(0), false);
            Assert.AreEqual(Utils.IsPrime(1), false);
        }


        /// <summary>
        ///A test for Range
        ///</summary>
        [TestMethod()]
        public void RangeTest()
        {

            IEnumerable<long> output = Utils.Range(0, 100);
            for (long i = 0; i < 99; i++)
            {
                Assert.AreEqual(i, output.ElementAt((int)i));
            }
            Assert.AreEqual(100, output.Count());
        }

        /// <summary>
        ///A test for GeneratePrimes
        ///</summary>
        [TestMethod()]
        public void GeneratePrimesTest()
        {
            IEnumerable<long> actual = Utils.GeneratePrimes(10);

            Assert.AreEqual(2, actual.ElementAt(0));
            Assert.AreEqual(3, actual.ElementAt(1));
            Assert.AreEqual(5, actual.ElementAt(2));
            Assert.AreEqual(7, actual.ElementAt(3));
            Assert.AreEqual(4, actual.Count());
        }

        /// <summary>
        ///A test for PrimeFactors
        ///</summary>
        [TestMethod()]
        public void PrimeFactorsTest()
        {
            IEnumerable<long> factors = Utils.PrimeFactors(288);
            Assert.AreEqual(2, factors.ElementAt(0));
            Assert.AreEqual(2, factors.ElementAt(1));
            Assert.AreEqual(2, factors.ElementAt(2));
            Assert.AreEqual(2, factors.ElementAt(3));
            Assert.AreEqual(2, factors.ElementAt(4));
            Assert.AreEqual(3, factors.ElementAt(5));
            Assert.AreEqual(3, factors.ElementAt(6));
            Assert.AreEqual(7, factors.Count());
        }

        /// <summary>
        ///A test for IsPalindrome
        ///</summary>
        [TestMethod()]
        public void IsPalindromeTest()
        {
            Assert.AreEqual(true, Utils.IsPalindrome(1));
            Assert.AreEqual(true, Utils.IsPalindrome(5));
            Assert.AreEqual(true, Utils.IsPalindrome(11));
            Assert.AreEqual(true, Utils.IsPalindrome(111));
            Assert.AreEqual(true, Utils.IsPalindrome(1111));
            Assert.AreEqual(true, Utils.IsPalindrome(1221));
            Assert.AreEqual(true, Utils.IsPalindrome(12321));

            Assert.AreEqual(false, Utils.IsPalindrome(10));
            Assert.AreEqual(false, Utils.IsPalindrome(12));
            Assert.AreEqual(false, Utils.IsPalindrome(5556));
            Assert.AreEqual(false, Utils.IsPalindrome(1211));
        }

        /// <summary>
        ///A test for Triangles
        ///</summary>
        [TestMethod()]
        public void TrianglesTest()
        {

            long upTo = 0; // TODO: Initialize to an appropriate value
            var expected = new List<long>() { 1, 3, 6, 10, 15, 21, 28 };
            IEnumerable<long> actual = Utils.Triangles(29);

            Assert.AreEqual(expected.ElementAt(0), actual.ElementAt(0));
            Assert.AreEqual(expected.ElementAt(1), actual.ElementAt(1));
            Assert.AreEqual(expected.ElementAt(2), actual.ElementAt(2));
            Assert.AreEqual(expected.ElementAt(3), actual.ElementAt(3));
            Assert.AreEqual(expected.ElementAt(4), actual.ElementAt(4));
            Assert.AreEqual(expected.ElementAt(5), actual.ElementAt(5));
            Assert.AreEqual(expected.ElementAt(6), actual.ElementAt(6));
            Assert.AreEqual(expected.Count(), actual.Count());
        }

        /// <summary>
        ///A test for NumDivisors
        ///</summary>
        [TestMethod()]
        public void NumDivisorsTest()
        {
            Assert.AreEqual(1, Utils.NumDivisors(1));
            Assert.AreEqual(2, Utils.NumDivisors(3));
            Assert.AreEqual(4, Utils.NumDivisors(6));
            Assert.AreEqual(4, Utils.NumDivisors(10));
            Assert.AreEqual(4, Utils.NumDivisors(15));
            Assert.AreEqual(4, Utils.NumDivisors(21));
            Assert.AreEqual(6, Utils.NumDivisors(28));
        }
    }
}