using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            ConcurrentBag<int> primes = new ConcurrentBag<int>();

            Parallel.For(100, 1000, (i) =>
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            });

            Console.WriteLine("Простые числа:");
            foreach (int prime in primes)
            {
                Console.WriteLine(prime);
            }

            Console.ReadKey();
        }
    }

}
