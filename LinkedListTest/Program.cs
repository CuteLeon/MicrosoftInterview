using System;

namespace LinkedListTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// OnePass 翻转链表
        /// </summary>
        /// <param name="head"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public LinkedNode ReverseBetween(LinkedNode head, int m, int n)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }

            LinkedNode curr = head;
            LinkedNode prev = null;
            while (m > 1)
            {
                prev = curr;
                curr = curr.Next;
                m--;
                n--;
            }

            LinkedNode front = null;
            LinkedNode tail = curr;
            while (n > 0)
            {
                LinkedNode next = curr.Next;
                curr.Next = front;
                front = curr;
                curr = next;
                n--;
            }
            if (prev != null)
            {
                prev.Next = front;
            }
            else
            {
                head = front;
            }

            tail.Next = curr;
            return head;
        }

        /// <summary>
        /// 倒插法 翻转链表
        /// </summary>
        /// <param name="head"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public static LinkedNode RevserseLinkedList(LinkedNode head, int startIndex, int endIndex)
        {
            if (head == null)
            {
                return null;
            }

            var dummyHead = new LinkedNode(0, head);
            var preNode = dummyHead;
            var currentNode = head;
            for (int index = 0; index < startIndex; index++)
            {
                if (currentNode == null)
                {
                    return head;
                }

                currentNode = currentNode.Next;
                preNode = preNode.Next;
            }

            int length = endIndex - startIndex;
            for (int index = 0; index < length; index++)
            {
                var nextNode = currentNode.Next;
                if (nextNode == null)
                {
                    break;
                }

                currentNode.Next = currentNode.Next.Next;
                nextNode.Next = preNode.Next;
                preNode.Next = nextNode;
            }

            return dummyHead.Next;
        }
    }
}
