using System;
using StreamNumbers;

namespace StreamNUmbers
{
    class Program
    {
        /* 扩展题：
         * 说出一个 3*4 的矩阵，从左下角走到右下角的最短路径共有几种路径方案 => 10
         * x*y的矩阵，最短路径总数 => Cx * Cy，x和y的组合的乘积
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var window = new MovingAverage(3);
            Console.WriteLine(window.Next(1));
            Console.WriteLine(window.Next(10));
            Console.WriteLine(window.Next(5));
            Console.WriteLine(window.Next(8));
            Console.Read();
        }
    }
}
