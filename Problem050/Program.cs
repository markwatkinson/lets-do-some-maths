using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem050
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> primes = Euler.Utils.GeneratePrimes(1000000).ToList();
            // Which prime, below one-million, can be written as the sum of the most consecutive primes?
            // I don't see a clever way to do this and it seems like brute force will take a while.
            // I see some optimisations in not summing the same long sequence twice but they seem
            // complex to implement

            long bestChain = 0;
            long prime = 0;

            for (int i = 0; i < primes.Count(); i++)
            {

                long sum = 0;
                int chain = 0;
                for (int j = i; j < primes.Count(); j++)
                {
                    sum += primes[j];
                    chain++;

                    if (sum > 1000000) break;

                    if (Euler.Utils.IsPrime(sum) && chain > bestChain)
                    {
                        bestChain = chain;
                        prime = sum;
                    }

                }
            }
            Euler.Utils.OutputAnswer(prime.ToString());

        }
    }
}
