namespace MessageQueue
{
    public class Message
    {
        public int Size { get; set; }
        public int Speed { get; set; }
        public double Time { get; set; }
        public bool Single { get; set; }

        public Message(int size, int speed)
        {
            this.Size = size;
            this.Speed = speed;
        }
    }
}
