using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            /* [6]
             * 04381
             * 04061
             * 06061
             * 06161
             * 06181
             * 06761
             */
            Console.WriteLine(GetPathCount(4));
            /*
            Console.WriteLine(GetPathCount(0));
            Console.WriteLine(GetPathCount(1));
            Console.WriteLine(GetPathCount(2));
            Console.WriteLine(GetPathCount(6));
            Console.WriteLine(GetPathCount(1000000));
             */
            Console.ReadLine();
        }

        /// <summary>
        /// 在一个拨号键盘上，每次只能移动到2x3或3x2的矩形的对角线端点处（类似象棋马走日的规则），
        /// 返回从 0 开始移动特定步长(stepCount)后到达 1 的不同路线数量
        /// </summary>
        /// <param name="stepCount">移动步长</param>
        /// <returns></returns>
        /// <example>
        /// 单元测试用例：
        /// 0、1、2、3、4、1000000000
        /// </example>
        /// <remarks>
        /// 1 使用动态规划框架
        /// 2 二维DP数组可以合并为一维
        /// 3 可以使用Map表实现O(1)空间复杂度
        /// </remarks>
        public static int GetPathCount(int stepCount)
        {
            // 使用字典记录每个键可以到达的下一个键，因为数字和*#的ASCII码不连续，因此使用字典实现O(1)查找
            Dictionary<char, char[]> keyRelationMap = new Dictionary<char, char[]>()
            {
                ['1'] = new[] { '6', '8' },
                ['2'] = new[] { '7', '9' },
                ['3'] = new[] { '4', '8' },
                ['4'] = new[] { '3', '9', '0' },
                ['5'] = new[] { '*', '#' },
                ['6'] = new[] { '1', '7', '0' },
                ['7'] = new[] { '2', '6', '#' },
                ['8'] = new[] { '1', '3' },
                ['9'] = new[] { '2', '4', '*' },
                ['*'] = new[] { '5', '9' },
                ['0'] = new[] { '4', '6' },
                ['#'] = new[] { '5', '7' },
            };
            // 当前步每个键出现的次数，从 0 出发，因此初始条件 ['0'] = 1
            Dictionary<char, int> keyMap = new Dictionary<char, int>()
            {
                ['0'] = 1,
            };

            // 迭代步长
            for (int step = 0; step < stepCount; step++)
            {
                Console.WriteLine($"当前步数：{step + 1}");
                // 记录下一步可能的键及对应次数
                var nextKeyMap = new Dictionary<char, int>();
                // 遍历当前可到达的键
                foreach (var currentKey in keyMap.Keys)
                {
                    Console.WriteLine($"键 {currentKey} (次数={keyMap[currentKey]}) 可到达：{string.Join("、", keyRelationMap[currentKey])}");
                    // 遍历当前键下一步可以到达的键
                    foreach (var nextKey in keyRelationMap[currentKey])
                    {
                        // 这里 Value 不是从 1 自增，而是继承当前键的次数，因为需要记录每种到达当前键的路径方案数量
                        if (nextKeyMap.ContainsKey(nextKey))
                        {
                            nextKeyMap[nextKey] += keyMap[currentKey];
                        }
                        else
                        {
                            nextKeyMap.Add(nextKey, keyMap[currentKey]);
                        }
                    }
                }

                // 迭代当前键字典
                keyMap = nextKeyMap;
            }

            // 获取特定步长后，到达 1 的方案数量
            var result = keyMap.ContainsKey('1') ? keyMap['1'] : 0;
            Console.WriteLine($"总步长为 {stepCount} 时，共有 {result} 种从 0 到 1 的路线");
            Console.WriteLine($"当前键及次数：{string.Join("、", keyMap.Select(pair => $"[{pair.Key}] = {pair.Value}"))}");
            return result;
        }
    }
}
