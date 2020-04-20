using System;

namespace StringTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 判断字符串是否为回文
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// <remarks>
        /// 忽略非字母和数字的字符
        /// 使用双指针收缩判断
        /// </remarks>
        public static bool StringTestFunction(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return true;
            }

            text = text.ToLower();
            int startIndex = 0, endIndex = text.Length - 1;
            while (startIndex <= endIndex)
            {
                var startChar = text[startIndex];
                var endChar = text[endIndex];

                if (!char.IsLetterOrDigit(startChar))
                {
                    startIndex++;
                    continue;
                }

                if (!char.IsLetterOrDigit(endChar))
                {
                    endIndex--;
                    continue;
                }

                if (startChar == endChar)
                {
                    startIndex++;
                    endIndex--;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
