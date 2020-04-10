using System;

namespace ConsecutiveArraySum
{
    class Program
    {
        /* 求一个数组Numbers内的连续子数组的和是否能够等于目标值
         * 使用一个数组Sums记录index及其之前所有数字的和，
         * Sum(i,j)=Sums[j]-Sums[i]+Numbers[i];
         * 使用两个指针实现窗口，当窗口的和小于目标值，让窗口扩大，让窗口的和小于目标值，让窗口缩小
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
