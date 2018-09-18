using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please input an integer:");
            //int n = Convert.ToInt32(Console.Read());
            string s = System.Console.ReadLine();
            int n = Int32.Parse(s);
            int i = 2;
            Console.Write("所有的素数因子：");
            while (i * i <= n)
            {
                while (n % i == 0)
                {
                    n = n / i;
                    Console.Write(i + " ");
                }
                i++;
            }
            if(n != 1)
                Console.Write(n);
        }
    }
}
