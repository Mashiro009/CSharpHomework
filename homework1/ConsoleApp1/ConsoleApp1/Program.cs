using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            int x = 0;
            int y = 0;
            Console.Write("Please input an int:");
            s = System.Console.ReadLine();
            x = Int32.Parse(s);
            Console.Write("Please input an int:");
            s = System.Console.ReadLine();
            y = Int32.Parse(s);
            Console.WriteLine(x * y);
        }
    }
}
