using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konvolucio.MCEL181123.Signals
{

    public class SignalItem
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public int FrameId { get; set; }
        public int StartBit { get; set; }
        public int Bits { get; set; }
        public string Description { get; set; }

        public SignalItem(string name, string value, string type, int frameId, int startBit, int bits, string description)
        {
            Name = name.ToUpper();
            Value = value;
            Type = type;
            FrameId = frameId;
            StartBit = startBit;
            Bits = bits;
        }
    }

    public class SignalCollection : List<SignalItem>
    {

    }

    class SiganlDictinary
    {
        public SignalCollection Signals { get; } = new SignalCollection();

        public SiganlDictinary()
        {
            Signals.AddRange
                (
                   new SignalItem[]
                   {
                     new SignalItem("CV_SET","0.00", "FLOAT", 0x02, 0, 32,"Ezzel állítod be a Constant Voltage értékét."),
                     new SignalItem("CM_RNG_SET", "0", "UNSIGNED", 0x02, 32, 8, "Ezzel állítod be a Current Monitor méréshatárát."),
                     new SignalItem("CC_SET", "0.00", "FLOAT", 0x02, 0, 32, "Ezzel állítod be a Constant Current értékét.")
                   });
        }
    }
}
