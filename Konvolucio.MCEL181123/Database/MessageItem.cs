namespace Konvolucio.MCEL181123.Database
{
    public class MessageItem
    {
        public string Name { get; set; }
        public byte Id { get; set; }
        public NodeItem NodeType { get; private set; }
        public ulong Value { get; set; }

        public MessageItem() { }

        public MessageItem(string name, byte id, NodeItem nodeType)
        {
            Name = name;
            Id = id;
            NodeType = nodeType;
        }
    }
}
