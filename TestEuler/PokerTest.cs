using Problem054;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestEuler
{
/// <summary>
///This is a test class for PokerTest and is intended
///to contain all PokerTest Unit Tests
///</summary>
    [TestClass()]
    public class PokerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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




       
    }
/// <summary>
///This is a test class for PokerTest and is intended
///to contain all PokerTest Unit Tests
///</summary>
    [TestClass()]
    public class Problem054Test
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

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
        ///A test for Value
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Problem054.exe")]
        public void ValueTest()
        {
            Assert.AreEqual(2, Poker_Accessor.Value("2H"));
            Assert.AreEqual(9, Poker_Accessor.Value("9H"));
            Assert.AreEqual(10, Poker_Accessor.Value("TH"));
            Assert.AreEqual(11, Poker_Accessor.Value("JH"));
            Assert.AreEqual(12, Poker_Accessor.Value("QH"));
            Assert.AreEqual(13, Poker_Accessor.Value("KH"));
            Assert.AreEqual(14, Poker_Accessor.Value("AH"));
        }

        /// <summary>
        ///A test for Compare
        ///</summary>
        [TestMethod()]
        public void CompareTest()
        {

            List<string> A, B;
            A = new List<string>() {
                "5H", "5C", "6S", "7S", "KD"
            };
            B = new List<string>() {
                "2C", "3S", "8S", "8D", "TD"
            };
            Poker_Accessor.Players p =  Poker_Accessor.Compare(A, B);
            Assert.AreEqual(Poker_Accessor.Players.B, p);

            A = new List<string>() {
                "5D", "8C", "9S", "JS", "AC"
            };
            B = new List<string>() {
                "2C", "5C", "7D", "8S", "QH"
            };
            p = Poker_Accessor.Compare(A, B);
            Assert.AreEqual(Poker_Accessor.Players.A, Poker_Accessor.Compare(A, B));

            A = new List<string>() {
                "2D", "9C", "AS", "AH", "AC"
            };
            B = new List<string>() {
                "3D", "6D", "7D", "TD", "QD"
            };
            p = Poker_Accessor.Compare(A, B);
            Assert.AreEqual(Poker_Accessor.Players.B, Poker_Accessor.Compare(A, B));

            A = new List<string>() {
                "4D", "6S", "9H", "QH", "QC"
            };
            B = new List<string>() {
                "3D", "6D", "7H", "QD", "QS"
            };
            p = Poker_Accessor.Compare(A, B);
            Assert.AreEqual(Poker_Accessor.Players.A, Poker_Accessor.Compare(A, B));

            A = new List<string>() {
                "2H", "2D", "4C", "4D", "4S"
            };
            B = new List<string>() {
                "3C", "3D", "3S", "9S", "9D"
            };
            p = Poker_Accessor.Compare(A, B);
            Assert.AreEqual(Poker_Accessor.Players.A, Poker_Accessor.Compare(A, B));
        }

        /// <summary>
        ///A test for RankRoyalFlush
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Problem054.exe")]
        public void RankRoyalFlushTest()
        {
            int tie = 0;
            List<string> cards = new List<string>() {
                "TC", "JC", "QC", "KC", "AC"
            };
            Poker_Accessor.Ranks r = Poker_Accessor.Ranks.RoyalFlush;
            int actual = Poker_Accessor.RankRoyalFlush(cards, ref tie);
            int expected = r.value__;
            Assert.AreEqual(expected, actual);
            //Assert.AreEqual(0, cards.Count);

            cards = new List<string>() {
                "TC", "JC", "QH", "KC", "AC"
            };
            actual = Poker_Accessor.RankRoyalFlush(cards, ref tie);
            expected = 0;
            Assert.AreEqual(expected, actual);
            //Assert.AreEqual(5, cards.Count);

        }


        /// <summary>
        ///A test for RankFlush
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Problem054.exe")]
        public void RankFlushTest()
        {
            int tie = 0;
            List<string> cards = new List<string>() {
                "8C", "9C", "TC", "JC", "QC"
            };
            Poker_Accessor.Ranks r = Poker_Accessor.Ranks.StraightFlush;
            int actual = Poker_Accessor.RankStraightFlush(cards, ref tie);
            int expected = r.value__;
            Assert.AreEqual(expected, actual);
            //Assert.AreEqual(0, cards.Count);

            // bad house
            cards = new List<string>() {
                "TC", "JC", "QH", "KC", "AC"
            };
            actual = Poker_Accessor.RankStraightFlush(cards, ref tie);
            expected = 0;
            Assert.AreEqual(expected, actual);
            //Assert.AreEqual(5, cards.Count);

            // bad order
            cards = new List<string>() {
                "AC", "JC", "QC", "KC", "2C"
            };
            actual = Poker_Accessor.RankStraightFlush(cards, ref tie);
            expected = 0;
            Assert.AreEqual(expected, actual);
            //Assert.AreEqual(5, cards.Count);
        }

        /// <summary>
        ///A test for RankFourOfAKind
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Problem054.exe")]
        public void RankFourOfAKindTest()
        {
            int tie = 0;
            List<string> cards = new List<string>() {
                "8C", "8D", "8H", "8S", "QC"
            };

            Poker_Accessor.Ranks r = Poker_Accessor.Ranks.FourOfAKind;
            int actual = Poker_Accessor.RankFourOfAKind(cards, ref tie);
            int expected = r.value__;
            Assert.AreEqual(expected, actual);
            //Assert.AreEqual(1, cards.Count);
            //Assert.AreEqual("QC", cards[0]);

            // not four
            cards = new List<string>() {
                "2C", "2S", "2H", "3C", "3H"
            };
            actual = Poker_Accessor.RankFourOfAKind(cards, ref tie);
            expected = 0;
            Assert.AreEqual(expected, actual);
            //Assert.AreEqual(5, cards.Count);
        }



        /// <summary>
        ///A test for RankFullHouse
        ///</summary>
        [TestMethod()]
        [DeploymentItem("Problem054.exe")]
        public void RankFullHouseTest()
        {
            int tie = 0;
            List<string> cards = new List<string>() {
                "8C", "8D", "8H", "2S", "2C"
            };
            Poker_Accessor.Ranks r = Poker_Accessor.Ranks.FullHouse;
            int actual = Poker_Accessor.RankFullHouse(cards, ref tie);
            int expected = r.value__;
            Assert.AreEqual(expected, actual);
            //Assert.AreEqual(0, cards.Count);

            // not a pair
            cards = new List<string>() {
                "8C", "8D", "8H", "2S", "3C"
            };
            actual = Poker_Accessor.RankFullHouse(cards, ref tie);
            expected = 0;
            Assert.AreEqual(expected, actual);
            //Assert.AreEqual(5, cards.Count);

            // not a triple
            cards = new List<string>() {
                "8C", "3D", "8H", "2S", "3C"
            };
            actual = Poker_Accessor.RankFullHouse(cards, ref tie);
            expected = 0;
            Assert.AreEqual(expected, actual);
            //Assert.AreEqual(5, cards.Count);
        }
    }
}
