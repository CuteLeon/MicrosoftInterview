using System;

namespace ConsecutiveArraySum
{
    class Program
    {
        /* 求一个数组Numbers内的连续子数组的和是否能够等于目标值
         * 使用一个数组Sums记录index及其之前所有数字的和，
         * Sum(i,j)=Sums[j]-Sums[i]+Numbers[i];
         * 使用两个指针实现窗口，当窗口的和小于目标值，让窗口扩大，当窗口的和小于目标值，让窗口缩小
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var numbers = new int[] { 1, 6, 2, 8, 3, 9, 4, 5, 0, 7 };
            Console.WriteLine(IsExistSubSum(numbers, 10));
            Console.WriteLine(IsExistSubSum(numbers, 0));
            Console.WriteLine(IsExistSubSum(numbers, 45));
            Console.WriteLine(IsExistSubSum(numbers, 46));
            Console.WriteLine(IsExistSubSum(numbers, -1));
            Console.ReadLine();
        }

        public static bool IsExistSubSum(int[] numbers, int target)
        {
            var leftSums = new int[numbers.Length];
            leftSums[0] = numbers[0];

            for (int index = 1; index < numbers.Length; index++)
                leftSums[index] = leftSums[index - 1] + numbers[index];
            int leftIndex = 0, rightIndex = 0;
            while (rightIndex < numbers.Length &&
                   leftIndex < numbers.Length)
            {
                var currentSum = leftSums[rightIndex] - leftSums[leftIndex] + numbers[leftIndex];
                if (currentSum < target)
                {
                    rightIndex++;
                }
                else if (currentSum > target)
                {
                    leftIndex++;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}
