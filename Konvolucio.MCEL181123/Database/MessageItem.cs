namespace Konvolucio.MCEL181123.Database
{
    public class MessageItem
    {
        public string Name { get; set; }
        public byte Id { get; set; }
        public NodeItem TxNode { get; private set; }
        public ulong Value { get; set; }

        public MessageItem() { }

        public MessageItem(string name, byte id, NodeItem txNode)
        {
            Name = name;
            Id = id;
            TxNode = txNode;
        }
    }
}
