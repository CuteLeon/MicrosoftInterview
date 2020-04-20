namespace LinkedListTest
{
    public class LinkedNode
    {
        public int Value { get; set; }
        public LinkedNode Next { get; set; }

        public LinkedNode(int value, LinkedNode next = null)
        {
            this.Value = value;
            this.Next = next;
        }
    }
}
