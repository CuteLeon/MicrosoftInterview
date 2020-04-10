using System;

namespace StreamNumbers
{
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
