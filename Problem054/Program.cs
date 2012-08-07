using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
namespace Problem054
{
    using CardList = List<string>;
    class Poker
    {
        public enum Players
        {
            Tie,
            A,
            B
        };
        enum Ranks {
            HighCard=1,
            OnePair,
            TwoPairs,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush,
            RoyalFlush
        };


        public delegate int RankDelegate(CardList cards, ref int tieBreaker);


        /// <summary>
        /// Returns the house of a card, this is just a character, e.g hearts => 'H'
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        private static char House(string card) {
            return card[1];
        }
        /// <summary>
        /// Returns the value of a card, 2 => 2, 10 => 10, Jack => 11, etc, ace => 14
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        private static int Value(string card)
        {
            char c = card[0];
            if (c >= '1' && c <= '9')
            {
                return c - '0';
            }
            switch (c)
            {
                case 'T': return 10;
                case 'J': return 11;
                case 'Q': return 12;
                case 'K': return 13;
                case 'A': return 14;
            }
            throw new Exception();
        }


        static IEnumerable<int> Values(CardList cards)
        {
            return cards.Select(c => Value(c));
        }
        static IEnumerable<char> Houses(CardList cards)
        {
            return cards.Select(c => House(c));
        }

        static bool AllSameHouse(CardList cards)
        {
            var DiffHouses = Houses(cards).Where(h => h != House(cards.ElementAt(0)));
            return DiffHouses.Count() == 0;
        }


        private static int RankHighCard(CardList cards, ref int tie)
        {
            return Values(cards).Max();
        }

        private static int RankOnePair(CardList cards, ref int tie)
        {
            var values = Values(cards).ToList();
            foreach (int v in values)
            {
                if (values.Count(x => x == v) >= 2)
                {
                    tie = v;
                    return (int)Ranks.OnePair;
                }
            }
            return 0;
        }

        private static int RankTwoPairs(CardList cards, ref int tie)
        {
            var values = Values(cards).ToList();
            List<int> counted = new List<int>();

            foreach (int v in values)
            {
                if (counted.Contains(v)) continue;

                if (values.Count(x => x == v) >= 2)
                {
                    counted.Add(v);
                }
            }
            if (counted.Count >= 2)
            {
                tie = counted.Max();
                return (int)Ranks.TwoPairs;
            }
            return 0;
        }

        private static int RankThreeOfAKind(CardList cards, ref int tie)
        {
            var values = Values(cards);
            foreach (int v in values)
            {
                if (values.Count(x => x == v) >= 3)
                {
                    tie = v;
                    return (int)Ranks.ThreeOfAKind;
                }
            }
            return 0;
        }

        /// <summary>
        /// Ranks a straight
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="tieBreaker"></param>
        /// <returns></returns>
        private static int RankStraight(CardList cards, ref int tieBreaker)
        {
            var values = Values(cards).ToList();
            values.Sort();
            for (int i = 1; i < values.Count; i++)
            {
                if (values[0] + i != values[i])
                {
                    return 0;
                }
            }
            tieBreaker = values.Max();
            return (int)Ranks.Straight;
        }


        /// <summary>
        /// Ranks  a flush
        /// </summary>
        /// <param name="cards"></param>
        /// <param name="tieBreaker"></param>
        /// <returns></returns>
        private static int RankFlush(CardList cards, ref int tieBreaker)
        {
            if (!AllSameHouse(cards)) { return 0; }
            tieBreaker = Values(cards).Max();
            return (int)Ranks.Flush;
        }


        /// <summary>
        /// Rank a full house and remove cards
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private static int RankFullHouse(CardList cards, ref int tieBreaker)
        {
            var values = Values(cards).ToList();
            int triple = -1;
            int pair = -1;
            foreach (int v in values)
            {
                if (values.Count(x => x == v) == 3)
                {
                    triple = v;
                }
                else if (values.Count(x => x == v) == 2)
                {
                    pair = v;
                }
            }
            if (pair == -1 || triple == -1) { return 0; }
            tieBreaker = triple;
            return (int)Ranks.FullHouse;
        }

        /// <summary>
        /// Ranks matching a four of a kind
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private static int RankFourOfAKind(CardList cards, ref int tieBreaker)
        {
            var values = Values(cards).ToList();
            foreach (int v in values)
            {
                if (values.Count(x => x == v) >= 4)
                {
                    tieBreaker = v;
                    return (int)Ranks.FourOfAKind;
                }
            }
            return 0;
        }


        /// <summary>
        /// Ranks a straight flush and removes cards
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private static int RankStraightFlush(CardList cards, ref int tieBreaker)
        {
            if (!AllSameHouse(cards)) { return 0; }
            var values = Values(cards).ToList();
            values.Sort();

            for (int i = 1; i < values.Count; i++)
            {
                if (values.ElementAt(i) != values.ElementAt(0) + i)
                {
                    return 0;
                }
            }

            // is a flush
            tieBreaker = values.Max();
            //cards.RemoveRange(0, cards.Count);
            return (int)Ranks.StraightFlush;
        }
        /// <summary>
        /// Ranks a royal flush and removes cards
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private static int RankRoyalFlush(CardList cards, ref int tieBreaker)
        {
            if (!AllSameHouse(cards))
            {
                return 0;
            }
            tieBreaker = 0;
            var flushVals = new List<string>() { 
                "T", "J", "Q", "K", "A" 
            }.Select(c => Value(c)).ToList();

            var ourVals = Values(cards).ToList();
            flushVals.Sort();
            ourVals.Sort();
            if (Enumerable.SequenceEqual(flushVals, ourVals))
            {
                //cards.RemoveRange(0, cards.Count);
                return (int)Ranks.RoyalFlush;
            }
            return 0;
        }


        private static Players CompareHighest(CardList A, CardList B)
        {
            var aVals = Values(A).ToList();
            var bVals = Values(B).ToList();
            aVals.Sort();
            bVals.Sort();
            aVals.Reverse();
            bVals.Reverse();

            for (int i = 0; i < aVals.Count; i++)
            {
                int a = aVals[i], b = bVals[i];
                if (a == b) { continue; }
                if (a > b)
                {
                    return Players.A;
                }
                else
                {
                    return Players.B;
                }
            }
            return Players.Tie;
        }


        private static Players CompareScore(int a, int tieA, int b, int tieB)
        {
            if (a > b) { return Players.A; }
            if (a < b) { return Players.B; }
            if (a > 0 && tieA > tieB) { return Players.A; }
            if (a > 0 && tieA < tieB) { return Players.B; }
            return Players.Tie;
        }


        public static Players Compare(CardList A, CardList B)
        {
            int tieA = 0, tieB = 0;
            int rankA, rankB;
            Players tieBreaker = CompareHighest(A, B);

            // seems like we should be able to fix this horrible sequence with
            // delegates/function pointers but I can't see how to do it
            // easily

            var functions = new List<RankDelegate>() {
                RankRoyalFlush, 
                RankStraightFlush,
                RankFourOfAKind,
                RankFullHouse,
                RankFlush,
                RankStraight,
                RankThreeOfAKind,
                RankTwoPairs,
                RankOnePair,
                RankHighCard
            };


            foreach (RankDelegate f in functions)
            {
                tieA = 0;
                tieB = 0;
                rankA = f(A, ref tieA);
                rankB = f(B, ref tieB);
                if (rankA + rankB > 0)
                {
                    Players p = CompareScore(rankA, tieA, rankB, tieB);
                    if (p == Players.Tie)
                    {
                        p = tieBreaker;
                    }
                    Console.Write(String.Join(", ", A));
                    Console.Write(" | ");
                    Console.Write(String.Join(", ", B));
                    Console.WriteLine();
                    Console.WriteLine("Player {0} won on {1}",
                        p.ToString(),
                        f.Method.Name
                    );
                    return p;
                }
            }
            throw new Exception("");
        }

        static void Main(string[] args)
        {

            List<string> A, B;
            A = new List<string>() {
                "5H", "5C", "6S", "7S", "KD"
            };
            B = new List<string>() {
                "2C", "3S", "8S", "8D", "TD"
            };
            Compare(A, B);

            A = new List<string>() {
                "5D", "8C", "9S", "JS", "AC"
            };
            B = new List<string>() {
                "2C", "5C", "7D", "8S", "QH"
            };
            Compare(A, B);

            A = new List<string>() {
                "2D", "9C", "AS", "AH", "AC"
            };
            B = new List<string>() {
                "3D", "6D", "7D", "TD", "QD"
            };
            Compare(A, B);

            A = new List<string>() {
                "4D", "6S", "9H", "QH", "QC"
            };
            B = new List<string>() {
                "3D", "6D", "7H", "QD", "QS"
            };
            Compare(A, B);

            A = new List<string>() {
                "2H", "2D", "4C", "4D", "4S"
            };
            B = new List<string>() {
                "3C", "3D", "3S", "9S", "9D"
            };
            Compare(A, B);
            Console.ReadLine();
            //System.Environment.Exit(0);


            string[] lines = File.ReadAllLines("poker.txt");
            int aWins = 0;
            int bWins = 0;
            int draws = 0;
            foreach (string line in lines)
            {
                string[] s = line.Split(' ');
                CardList a = new CardList();
                CardList b = new CardList();
                for (int i = 0; i < s.Length; i++)
                {
                    if (i < 5) a.Add(s[i]);
                    else b.Add(s[i]);
                }
                if (a.Count != b.Count || a.Count != 5)
                {
                    throw new Exception();
                }
                Players winner = Compare(a, b);
                if (winner == Players.A)
                {
                    aWins++;
                }
                else if (winner == Players.B)
                {
                    bWins++;
                }
                else if (winner == Players.Tie)
                {
                    draws++;
                }
            }
            Console.WriteLine("{0} {1} {2}", aWins, bWins, draws);
            Euler.Utils.OutputAnswer(aWins.ToString());
        }
    }
}
