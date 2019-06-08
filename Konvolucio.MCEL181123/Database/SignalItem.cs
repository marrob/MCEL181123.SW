namespace Konvolucio.MCEL181123.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

    public class SignalItem
    {

        public string Name { get; set; }
        public MessageItem Message { get; private set; }
        public string DefaultValue { get; set; }
        public string Type { get; set; }
        public int StartBit { get; set; }
        public int Bits { get; set; }
        public string Description { get; set; }

        public SignalItem() { }

        public SignalItem(string name, MessageItem msg, string defaultValue, string type, int startBit, int bits, string description)
        {
            Name = name.ToUpper();
            Message = msg;
            DefaultValue = defaultValue;
            Type = type;
            StartBit = startBit;
            Bits = bits;
        }
    }
}
