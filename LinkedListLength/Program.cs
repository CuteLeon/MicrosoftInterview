using System;

namespace LinkedListLength
{
    class Program
    {
        /* 扩展题目
         * 随机打乱一个数组，尽量使每个数字的随机概率相等：
         * 将index从0遍历到length-2 个数，从index_length-1里随机选取一个索引，与index索引位置的数据交换
         * 证明较为复杂，没能完整说出来，但是得到面试官认可
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var head = new LinkedNode();
            var entry = head.Add().Add().Add();
            var last = entry.Add().Add().Add().Add();
            last.Next = entry;
            Console.WriteLine(GetLinkedListLength(head));
            Console.Read();
        }

        /// <summary>
        /// 返回一个带环链表的长度
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static int GetLinkedListLength(LinkedNode head)
        {
            if (head == null) throw new ArgumentNullException(nameof(head));

            // 寻找两个指针相遇节点
            LinkedNode fast = head, slow = head;
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;

                if (fast == slow) break;
            }
            if (fast == null) throw new ArgumentException($"链表不存在环");

            // 记录新的链表头并断开链表
            var newHead = fast.Next;
            // TODO: 不断开，仅比较
            fast = newHead;
            slow = head;

            int result = 0;
            while (fast != slow)
            {
                result++;
                fast = fast.Next == newHead ? head : fast.Next;
                slow = slow.Next == newHead ? newHead : slow.Next;
            }

            return result;
        }
    }
}
