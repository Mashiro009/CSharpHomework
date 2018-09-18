using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_9
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[] isPrime = new bool[101];
            for (int i = 2; i <= 100; i++)
                isPrime[i] = true;
            for (int i = 2; i <= 100; i++)
            {
                int j = 2;
                while (i * j <= 100)
                {
                    isPrime[i * j] = false;
                    j++;
                }
            }
            for (int i = 2; i <= 100; i++)
                if (isPrime[i])
                    Console.Write(i + " ");
        }
    }
}
