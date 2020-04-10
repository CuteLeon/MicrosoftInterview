using System;

namespace LinkedListLength
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var head = new LinkedNode();
            var entry = head.Add().Add().Add();
            var last = entry.Add().Add().Add().Add();
            last.Next = entry;
        }

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
            fast.Next = null;
            fast = newHead;
            slow = head;

            int result = 0;
            while (fast != slow)
            {
                result++;
                fast = fast.Next == null ? head : fast.Next;
                slow = slow.Next == null ? newHead : slow.Next;
            }

            return result;
        }
    }
}
