namespace Konvolucio.MCEL181123.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    public class MessageItem
    {
        public string Name { get; set; }
        public byte Id { get; set; }
        public NodeItem Node { get; private set; }
        public ulong Value { get; set; }

        public MessageItem() { }

        public MessageItem(string name, byte id, NodeItem node)
        {
            Name = name;
            Id = id;
            Node = node;
        }
    }
}
