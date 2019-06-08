namespace Konvolucio.MCEL181123.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    public class NodeItem
    {
        public string Name { get; set; }
        public byte Id { get; set; }

        public NodeItem(string name, byte id)
        {
            Name = name;
            Id = id;
        }
    }
}
