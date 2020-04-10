namespace LinkedListLength
{
    public class LinkedNode
    {
        public LinkedNode Next { get; set; }

        public LinkedNode Add()
            => this.Next = new LinkedNode();
    }
}
