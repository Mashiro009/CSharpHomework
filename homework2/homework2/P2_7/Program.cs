using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 9, 6, 5, 8, 7, 4, 2, 3, 1 };
            int max, min, sum = 0;
            double average;
            max = min = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
                if (arr[i] < min)
                    min = arr[i];
                sum += arr[i];
            }
            average = sum / arr.Length;
            Console.WriteLine("最大值：" + max);
            Console.WriteLine("最小值：" + min);
            Console.WriteLine("平均值：" + average);
            Console.WriteLine("和：" + sum);
        }
    }
}
