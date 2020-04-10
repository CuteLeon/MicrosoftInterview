using System;

namespace StreamNumbers
{
    /// <summary>
    /// 一个流式数组，计算这个数组上滑动窗口内所有值的平均数
    /// </summary>
    /// <remarks>
    /// 初步考虑使用双端队列/链表，但题目要求使用数组
    /// 其次考虑使用List，用于动态增删，但是删除时间复杂度是O(n)
    /// 最后确定使用int[]，使用指针来记录下一个将被替换的数字
    /// 最后动态维护 currentSum，将 int[].Sum() 的O(n)优化至O(1)
    /// </remarks>
    public class MovingAverage
    {
        private readonly int windowSize;
        private int lastIndex = 0;
        private int count = 0;
        private int currentSum = 0;
        private readonly int[] window;

        public MovingAverage(int windowSize)
        {
            if (windowSize <= 0)
                throw new ArgumentException(nameof(windowSize));

            this.windowSize = windowSize;
            this.window = new int[windowSize];
        }

        public double Next(int nextNumber)
        {
            this.currentSum += nextNumber;
            if (this.count < this.windowSize)
            {
                this.window[this.lastIndex++] = nextNumber;
                this.count++;
            }
            else if (this.count >= this.windowSize)
            {
                this.currentSum -= this.window[lastIndex];
                this.window[this.lastIndex++] = nextNumber;
            }
            if (this.lastIndex == this.windowSize)
            {
                this.lastIndex = 0;
            }

            return this.currentSum / (double)count;
        }
    }
}
