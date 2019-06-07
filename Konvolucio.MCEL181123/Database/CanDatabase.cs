namespace Konvolucio.MCEL181123.CanDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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

    public class NodeCollection : List<NodeItem>
    {
        public const string NODE_PC = "NODE_PC";
        public const string NODE_MCEL = "NODE_MCEL";
    }

    public class MessageItem
    {
       
      
        public string Name { get; set;}
        public byte Id { get;set; }
        public NodeItem Node { get; private set; }
        public UInt64 Value { get; set; }

        public MessageItem()  { }

        public MessageItem(string name, byte id, NodeItem node)
        {
            Name = name;
            Id = id;
            Node = node;
        }
    }

    public class MessageCollection : List<MessageItem>
    {
        /*** MCEL181123 Messages ***/
        public const string MSG_MCEL_V_MEAS = "MSG_MCEL_V_MEAS";
        public const string MSG_MCEL_C_MEAS = "MSG_MCEL_C_MEAS";
        public const string MSG_MCEL_STATUS = "MSG_MCEL_STATUS";
        public const string MSG_MCEL_LIVE = "MSG_MCEL_LIVE";

        /*** PC Messages ***/
        public const string MSG_PC_CC_SET = "MSG_PC_CC_SET";
        public const string MSG_PC_CV_SET = "MSG_PC_CV_SET";
    }

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

        public SignalItem(string name, MessageItem msg, string defaultValue, string type,int startBit, int bits, string description)
        {
            Name = name.ToUpper();
            Message = msg;
            DefaultValue = defaultValue;
            Type = type;
            StartBit = startBit;
            Bits = bits;
        }
    }

    public class SignalCollection : List<SignalItem>
    {
        /*** Tx By MCEL181123 ***/
        public const string SIG_MCEL_V_MEAS = "SIG_MCEL_V_MEAS";
        public const string SIG_MCEL_C_MEAS = "SIG_MCEL_C_MEAS";
        public const string SIG_MCEL_C_RANGE = "SIG_MCEL_C_RANGE";
        public const string SIG_MCEL_CC_STATUS = "SIG_MCEL_CC_STATUS";
        public const string SIG_MCEL_CV_STATUS = "SIG_MCEL_CV_STATUS";
        public const string SIG_MCEL_OE_STATUS = "SIG_MCEL_OE_STATUS";
        public const string SIG_MCEL_RUN_TIME_TICK = "SIG_MCEL_V_MEAS";

        /*** Tx By PC ***/
        public const string SIG_PC_CV_SET = "SIG_PC_CV_SET";
        public const string SIG_PC_CC_SET = "SIG_PC_CC_SET";
        public const string SIG_PC_C_MEAS_RNG_SET = "SIG_PC_C_MEAS_RNG_SET";
    }

    class CanDb
    {
        public static CanDb Instance { get; } = new CanDb();
        public NodeCollection Nodes { get; } = new NodeCollection();
        public MessageCollection Messages { get; } = new MessageCollection();
        public SignalCollection Signals { get; } = new SignalCollection();

        public CanDb()
        {
            Nodes.AddRange
            (
                new NodeItem[]
                {
                    new NodeItem(
                        name:NodeCollection.NODE_PC,
                        id:0x01),
                    new NodeItem(
                        name:NodeCollection.NODE_MCEL,
                        id:0x05),
                }
            );

            Messages.AddRange
            (
                new MessageItem[]
                {
                    /*** MCEL181123 Messages ***/
                    new MessageItem(
                        name:MessageCollection.MSG_MCEL_V_MEAS,
                        id:0x01,
                        node: Nodes.FirstOrDefault(n=>n.Name == NodeCollection.NODE_MCEL)
                        ),

                    new MessageItem(
                        name:MessageCollection.MSG_MCEL_C_MEAS,
                        id:0x02,
                        node: Nodes.FirstOrDefault(n=>n.Name == NodeCollection.NODE_MCEL)
                        ),

                    new MessageItem(
                        name:MessageCollection.MSG_MCEL_STATUS,
                        id:0x03,
                        node: Nodes.FirstOrDefault(n=>n.Name == NodeCollection.NODE_MCEL)
                        ),

                    new MessageItem(
                        name:MessageCollection.MSG_MCEL_LIVE,
                        id:0xFF,
                        node: Nodes.FirstOrDefault(n=>n.Name == NodeCollection.NODE_MCEL)
                        ),
                    
                    /*** PC Messages ***/
                    new MessageItem(
                        name:MessageCollection.MSG_PC_CC_SET,
                        id:0x02,
                        node: Nodes.FirstOrDefault(n=>n.Name == NodeCollection.NODE_PC)
                        ),
                    new MessageItem(
                        name:MessageCollection.MSG_PC_CV_SET,
                        id:0x03,
                        node: Nodes.FirstOrDefault(n=>n.Name == NodeCollection.NODE_PC)
                        ),


                }
            );

            Signals.AddRange
            (
                new SignalItem[]
                {

                    /*** Tx By MCEL181123 ***/
                    new SignalItem(
                                name: SignalCollection.SIG_MCEL_V_MEAS,
                                msg: Messages.FirstOrDefault(n=>n.Name == MessageCollection.MSG_MCEL_V_MEAS),
                                defaultValue: "0.00",
                                type: "FLOAT",
                                startBit: 0,
                                bits: 31,
                                description: "Mért feszültség."),

                    new SignalItem(
                                name: SignalCollection.SIG_MCEL_C_MEAS,
                                msg: Messages.FirstOrDefault(n=>n.Name == MessageCollection.MSG_MCEL_C_MEAS),
                                defaultValue: "0.00",
                                type: "FLOAT",
                                startBit: 32,
                                bits: 63,
                                description: "Mért áram."),

                    new SignalItem(
                                name: SignalCollection.SIG_MCEL_C_RANGE,
                                msg: Messages.FirstOrDefault(n=>n.Name == MessageCollection.MSG_MCEL_C_MEAS),
                                defaultValue: "0",
                                type: "UNSIGNED",
                                startBit: 32,
                                bits: 8,
                                description: "Mért áram méréshatára"),

                    new SignalItem(
                                name: SignalCollection.SIG_MCEL_CC_STATUS,
                                msg: Messages.FirstOrDefault(n=>n.Name == MessageCollection.MSG_MCEL_STATUS),
                                defaultValue: "0",
                                type: "UNSIGNED",
                                startBit: 0,
                                bits: 1,
                                description: ""),

                    new SignalItem(
                                name: SignalCollection.SIG_MCEL_CV_STATUS,
                                msg: Messages.FirstOrDefault(n=>n.Name == MessageCollection.MSG_MCEL_STATUS),
                                defaultValue: "0",
                                type: "UNSIGNED",
                                startBit: 1,
                                bits: 1,
                                description: ""),

                    new SignalItem(
                                name: SignalCollection.SIG_MCEL_OE_STATUS,
                                msg: Messages.FirstOrDefault(n=>n.Name == MessageCollection.MSG_MCEL_STATUS),
                                defaultValue: "0",
                                type: "UNSIGNED",
                                startBit: 2,
                                bits: 1,
                                description: ""),

                    new SignalItem(
                                name: SignalCollection.SIG_MCEL_RUN_TIME_TICK,
                                msg: Messages.FirstOrDefault(n=>n.Name == MessageCollection.MSG_MCEL_LIVE),
                                defaultValue: "0",
                                type: "UNSIGNED",
                                startBit: 0,
                                bits: 63,
                                description: ""),

                    /*** Tx By PC ***/
                    new SignalItem(
                                name: SignalCollection.SIG_PC_CV_SET,
                                msg: Messages.FirstOrDefault(n=>n.Name ==  MessageCollection.MSG_PC_CV_SET),
                                defaultValue: "0.00",
                                type: "FLOAT",
                                startBit: 0,
                                bits: 32,
                                description: "Constant Voltage beállítása."),

                    new SignalItem(
                                name: SignalCollection.SIG_PC_CC_SET,
                                msg: Messages.FirstOrDefault(n=>n.Name ==  MessageCollection.MSG_PC_CC_SET),
                                defaultValue: "0.00",
                                type: "FLOAT",
                                startBit: 0,
                                bits: 31,
                                description: "Constant Current értékét."),


                    new SignalItem(
                                name: SignalCollection.SIG_PC_C_MEAS_RNG_SET,
                                msg: Messages.FirstOrDefault(n=>n.Name ==  MessageCollection.MSG_PC_CC_SET),
                                defaultValue: "0",
                                type: "UNSIGNED",
                                startBit: 32,
                                bits: 8,
                                description: "Árammérés méréshatárának értékét.")
                }
            );
        }

        /// <summary>
        /// Egy signal küldése
        /// </summary>
        public static CanMsg MakeMessage(byte nodeId, SignalItem signal, string value, bool broadcast, byte devId)
        {
            uint arbId = (uint)(nodeId << 24 | devId << 16 | signal.Message.Id << 8);
            if (broadcast)
                arbId |= 0x1;

            ulong mask = 0;
            for (int i = 0; i < signal.Bits; i++)
                mask |= (ulong)1 << i;
            mask <<= signal.StartBit;
            signal.Message.Value &= ~mask;

            switch (signal.Type.ToUpper().Trim())
            {

                case "UNSIGNED":
                    {
                        ulong val = ulong.Parse(value);
                        signal.Message.Value |= val <<= signal.StartBit;
                        break;
                    }
                case "FLOAT":
                    {
                        float val = float.Parse(value);
                        var bytes = BitConverter.GetBytes(val);
                        ulong val64 = BitConverter.ToUInt32(bytes, 0);
                        signal.Message.Value |= val64 <<= signal.StartBit;
                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException("signal.Type");
                    }
            }
            return new CanMsg(arbId, BitConverter.GetBytes(signal.Message.Value));
        }

        public static byte GetNodeId(uint arbId)
        {
            return (byte)((arbId & 0x0F000000) >> 24);
        }

        public static byte GetMsgId(uint arbId)
        {
            return (byte)((arbId & 0x0000FF00) >> 8);
        }

        public static byte GetNodeAddress(uint arbId)
        {
            return (byte)((arbId & 0x00FF0000) >> 16);
        }

        public void InserMsg()
        {

        }

        public SignalItem GetSignal(NodeItem node, byte msgId)
        {
            var signalsOfNode = Signals.Where(n => n.Message.Node == node).Select(n=>n);
            return signalsOfNode.FirstOrDefault(n=>n.Message.Id == msgId);
        }
    }
}
