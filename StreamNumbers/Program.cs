using System;
using StreamNumbers;

namespace StreamNUmbers
{
    class Program
    {
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
