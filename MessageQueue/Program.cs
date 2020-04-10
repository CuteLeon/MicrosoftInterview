using System;
using System.Collections.Generic;

namespace MessageQueue
{
    class Program
    {
        /* 有一组消息(List<Message>)需要写入到硬盘，每条消息可以选择并发写入或者单个写入，
         * 如果单个写入的话，写入速度会受一个最大单个写入速度参数(MaxSingleSpeed）的限制，
         * 每个消息有一个Size属性记录消息的长度，一个Speed属性记录此条消息在并发写入时的写入速度，
         * 函数输入三个参数：这一组消息List<Message>、单个写入时的最大写入速度maxSingleSpeed、最大任务并发数maxThreadCount
         * 返回这些消息完全写入需要的时间
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var messages = new List<Message>()
            {
                new Message(10,5),
                new Message(12,6),
                new Message(8,4),
                new Message(20,10),
                new Message(4,2),
            };
            int maxSingleSpeed = 10;
            int maxThreadCount = 3;
            Console.WriteLine(GetLeastTime(messages, maxSingleSpeed, maxThreadCount));
            Console.Read();
        }

        public static double GetLeastTime(List<Message> messages, int maxSingleSpeed, int maxThreadCount)
        {
            double result = 0;
            foreach (var message in messages)
            {
                if (message.Speed * maxThreadCount >= maxSingleSpeed)
                {
                    message.Single = false;
                    message.Time = message.Size / (double)message.Speed;
                }
                else
                {
                    message.Single = true;
                    message.Time = message.Size / (double)maxSingleSpeed;
                    result += message.Time;
                }
            }

            return result;
        }
    }
}
