using System;
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

        /// <summary>
        ///A test for Collatz
        ///</summary>
        [TestMethod()]
        public void CollatzTest()
        {
            IEnumerable<long> output = Utils.Collatz(13);
            Assert.AreEqual(13, output.ElementAt(0));
            Assert.AreEqual(40, output.ElementAt(1));
            Assert.AreEqual(20, output.ElementAt(2));
            Assert.AreEqual(10, output.ElementAt(3));
            Assert.AreEqual(5, output.ElementAt(4));
            Assert.AreEqual(16, output.ElementAt(5));
            Assert.AreEqual(8, output.ElementAt(6));
            Assert.AreEqual(4, output.ElementAt(7));
            Assert.AreEqual(2, output.ElementAt(8));
            Assert.AreEqual(1, output.ElementAt(9));
        }

        /// <summary>
        ///A test for Divisors
        ///</summary>
        [TestMethod()]
        public void DivisorsTest()
        {
            long n = 220; // TODO: Initialize to an appropriate value
            IList<long> actual = null; // TODO: Initialize to an appropriate value
            List<long> expected = new List<long> {
                1, 2, 4, 5, 10, 11, 20, 22, 44, 55, 110
            };
            actual = Utils.Divisors(n);
            Assert.AreEqual(true, actual.SequenceEqual(expected));

            n = 36;
            expected = new List<long>{
                1, 2, 3, 4, 6, 9, 12, 18
            };
            actual = Utils.Divisors(n);
            Assert.AreEqual(true, actual.SequenceEqual(expected));
        }

        /// <summary>
        ///A test for LexicographicPermutation
        ///</summary>
        [TestMethod()]
        public void LexicographicPermutationTestHelper()
        {
            var list = new List<Int32> { 0, 1, 2 };

            list = Utils.LexicographicPermutation<Int32>(list).ToList();
            Assert.AreEqual(true, list.SequenceEqual(new List<Int32> { 0, 2, 1 }));

            list = Utils.LexicographicPermutation<Int32>(list).ToList();
            Assert.AreEqual(true, list.SequenceEqual(new List<Int32> { 1, 0, 2 }));

            list = Utils.LexicographicPermutation<Int32>(list).ToList();
            Assert.AreEqual(true, list.SequenceEqual(new List<Int32> { 1, 2, 0 }));

            list = Utils.LexicographicPermutation<Int32>(list).ToList();
            Assert.AreEqual(true, list.SequenceEqual(new List<Int32> { 2, 0, 1 }));

            list = Utils.LexicographicPermutation<Int32>(list).ToList();
            Assert.AreEqual(true, list.SequenceEqual(new List<Int32> { 2, 1, 0 }));

            Assert.AreEqual(Utils.LexicographicPermutation<Int32>(list), null);
        }



        /// <summary>
        ///A test for Fibonacci
        ///</summary>
        [TestMethod()]
        public void FibonacciTest()
        {
            IEnumerable<long> list = new List<long>() {
                1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144
            };

            IEnumerable<long> output = Utils.Fibonacci();

            for (int i = 0; i < list.Count(); i++)
            {
                Assert.AreEqual(list.ElementAt(i), output.ElementAt(i));
            }
        }

        /// <summary>
        ///A test for ModPow
        ///</summary>
        [TestMethod()]
        public void ModPowTest()
        {   
            Assert.AreEqual(100, Utils.ModPow(10, 2, 101));
            Assert.AreEqual(0, Utils.ModPow(10, 2, 100));
            Assert.AreEqual(0, Utils.ModPow(10, 2, 10));
        }

        /// <summary>
        ///A test for ToBinary
        ///</summary>
        [TestMethod()]
        public void ToBinaryTest()
        {
            // NOTE: ToBinary doesn't yet work for negative numbers but
            // as we don't need that yet we're omitting test cases for it
            Assert.AreEqual("0", Utils.ToBinary(0));
            Assert.AreEqual("1", Utils.ToBinary(1));
            Assert.AreEqual("10", Utils.ToBinary(2));
            Assert.AreEqual("11", Utils.ToBinary(3));
            Assert.AreEqual("100", Utils.ToBinary(4));
            Assert.AreEqual("1001001001", Utils.ToBinary(585));
        }

        /// <summary>
        ///A test for IsTriangle
        ///</summary>
        [TestMethod()]
        public void IsTriangleTest()
        {
            // 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
            Assert.AreEqual(true, Utils.IsTriangle(1));
            Assert.AreEqual(true, Utils.IsTriangle(3));
            Assert.AreEqual(true, Utils.IsTriangle(6));
            Assert.AreEqual(true, Utils.IsTriangle(10));
            Assert.AreEqual(true, Utils.IsTriangle(15));
            Assert.AreEqual(true, Utils.IsTriangle(21));
            Assert.AreEqual(true, Utils.IsTriangle(28));
            Assert.AreEqual(true, Utils.IsTriangle(36));
            Assert.AreEqual(true, Utils.IsTriangle(45));
            Assert.AreEqual(true, Utils.IsTriangle(55));

            Assert.AreEqual(false, Utils.IsTriangle(2));
            Assert.AreEqual(false, Utils.IsTriangle(4));
            Assert.AreEqual(false, Utils.IsTriangle(5));
            Assert.AreEqual(false, Utils.IsTriangle(7));
        }


        [TestMethod()]
        public void PermutationsTest()
        {
            List<int> set = new List<int>() {  1, 2, 3 };

            IEnumerable<IEnumerable<int>> output = Utils.Permutations(set);

            List<List<int>> expected = new List<List<int>>() {
                new List<int>() { 1, 2, 3},
                new List<int>() { 1, 3, 2},
                new List<int>() { 2, 1, 3},
                new List<int>() { 2, 3, 1},
                new List<int>() { 3, 1, 2},
                new List<int>() { 3, 2, 1},
            };

            Assert.AreEqual(expected.Count(), output.Count());
            Assert.AreEqual(true, Enumerable.SequenceEqual(output.ElementAt(0), expected[0]));
            Assert.AreEqual(true, Enumerable.SequenceEqual(output.ElementAt(1), expected[1]));
            Assert.AreEqual(true, Enumerable.SequenceEqual(output.ElementAt(2), expected[2]));
            Assert.AreEqual(true, Enumerable.SequenceEqual(output.ElementAt(3), expected[3]));
            Assert.AreEqual(true, Enumerable.SequenceEqual(output.ElementAt(4), expected[4]));
            Assert.AreEqual(true, Enumerable.SequenceEqual(output.ElementAt(5), expected[5]));


        }

        /// <summary>
        ///A test for IsPentagonal
        ///</summary>
        [TestMethod()]
        public void IsPentagonalTest()
        {
            // 1, 5, 12, 22, 35, 51, 70, 92, 117, 145, ...
            Assert.AreEqual(true, Utils.IsPentagonal(1));
            Assert.AreEqual(true, Utils.IsPentagonal(5));
            Assert.AreEqual(true, Utils.IsPentagonal(12));
            Assert.AreEqual(true, Utils.IsPentagonal(22));
            Assert.AreEqual(true, Utils.IsPentagonal(35));
            Assert.AreEqual(true, Utils.IsPentagonal(51));
            Assert.AreEqual(true, Utils.IsPentagonal(70));
            Assert.AreEqual(true, Utils.IsPentagonal(92));
            Assert.AreEqual(true, Utils.IsPentagonal(117));
            Assert.AreEqual(true, Utils.IsPentagonal(145));

            Assert.AreEqual(false, Utils.IsPentagonal(2));
            Assert.AreEqual(false, Utils.IsPentagonal(3));
            Assert.AreEqual(false, Utils.IsPentagonal(4));
            Assert.AreEqual(false, Utils.IsPentagonal(6));
        }
    }
}
