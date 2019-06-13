namespace Konvolucio.MCEL181123.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;

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
                        nodeTypeId:0x01),
                    new NodeItem(
                        name:NodeCollection.NODE_MCEL,
                        nodeTypeId:0x05),
                }
            );

            Messages.AddRange
            (
                new MessageItem[]
                {
                    /*** MCEL181123 Messages ***/
                    new MessageItem(
                        name:MessageCollection.MSG_MCEL_V_MEAS,
                        id:MessageCollection.MSG_MCEL_V_MEAS_ID,
                        nodeType: Nodes.FirstOrDefault(n=>n.Name == NodeCollection.NODE_MCEL)
                        ),

                    new MessageItem(
                        name:MessageCollection.MSG_MCEL_C_MEAS,
                        id:MessageCollection.MSG_MCEL_C_MEAS_ID,
                        nodeType: Nodes.FirstOrDefault(n=>n.Name == NodeCollection.NODE_MCEL)
                        ),

                    new MessageItem(
                        name:MessageCollection.MSG_MCEL_STATUS,
                        id:MessageCollection.MSG_MCEL_STATUS_ID,
                        nodeType: Nodes.FirstOrDefault(n=>n.Name == NodeCollection.NODE_MCEL)
                        ),

                    new MessageItem(
                        name:MessageCollection.MSG_MCEL_TEMPS,
                        id:MessageCollection.MSG_MCEL_TEMPS_ID,
                        nodeType: Nodes.FirstOrDefault(n=>n.Name == NodeCollection.NODE_MCEL)
                        ),

                    new MessageItem(
                        name:MessageCollection.MSG_MCEL_LIVE,
                        id:MessageCollection.MSG_MCEL_LIVE_ID,
                        nodeType: Nodes.FirstOrDefault(n=>n.Name == NodeCollection.NODE_MCEL)
                        ),

                    /*** PC Messages ***/
                    new MessageItem(
                        name:MessageCollection.MSG_PC_CV_SET,
                        id:MessageCollection.MSG_PC_CV_SET_ID,
                        nodeType: Nodes.FirstOrDefault(n=>n.Name == NodeCollection.NODE_PC)
                        ),

                    new MessageItem(
                        name:MessageCollection.MSG_PC_CC_SET,
                        id:MessageCollection.MSG_PC_CC_SET_ID,
                        nodeType: Nodes.FirstOrDefault(n=>n.Name == NodeCollection.NODE_PC)
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
                                bits: 32,
                                description: "Mért feszültség."),

                    new SignalItem(
                                name: SignalCollection.SIG_MCEL_C_MEAS,
                                msg: Messages.FirstOrDefault(n=>n.Name == MessageCollection.MSG_MCEL_C_MEAS),
                                defaultValue: "0.00",
                                type: "FLOAT",
                                startBit: 0,
                                bits: 32,
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
                                name: SignalCollection.SIG_MCEL_OE_STATUS,
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
                                name: SignalCollection.SIG_MCEL_CC_STATUS,
                                msg: Messages.FirstOrDefault(n=>n.Name == MessageCollection.MSG_MCEL_STATUS),
                                defaultValue: "0",
                                type: "UNSIGNED",
                                startBit: 2,
                                bits: 1,
                                description: ""),

                    new SignalItem(
                                name: SignalCollection.SIG_MCEL_UC_TEMP,
                                msg: Messages.FirstOrDefault(n=>n.Name == MessageCollection.MSG_MCEL_TEMPS),
                                defaultValue: "0",
                                type: "UNSIGNED",
                                startBit: 2,
                                bits: 1,
                                description: ""),

                     new SignalItem(
                                name: SignalCollection.SIG_MCEL_TR_TEMP,
                                msg: Messages.FirstOrDefault(n=>n.Name == MessageCollection.MSG_MCEL_TEMPS),
                                defaultValue: "0",
                                type: "UNSIGNED",
                                startBit: 2,
                                bits: 1,
                                description: ""),

                    new SignalItem(
                                name: SignalCollection.SIG_MCEL_UPTIME,
                                msg: Messages.FirstOrDefault(n=>n.Name == MessageCollection.MSG_MCEL_LIVE),
                                defaultValue: "0",
                                type: "UNSIGNED",
                                startBit: 0,
                                bits: 32,
                                description: ""),

                    new SignalItem(
                                name: SignalCollection.SIG_MCEL_VERSION,
                                msg: Messages.FirstOrDefault(n=>n.Name == MessageCollection.MSG_MCEL_LIVE),
                                defaultValue: "0",
                                type: "UNSIGNED",
                                startBit: 32,
                                bits: 32,
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
                                bits: 32,
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
        public static CanMsg MakeMessage(byte nodeTypeId, byte nodeAddress, bool broadcast, SignalItem signal, string value)
        {
            uint arbId = (uint)(nodeTypeId << 24 | nodeAddress << 16 | signal.Message.Id << 8);
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

        public static byte GetNodeTypeId(uint arbId)
        {
            return (byte)((arbId & 0x0F000000) >> 24);
        }

        public static byte GetNodeAddress(uint arbId)
        {
            return (byte)((arbId & 0x00FF0000) >> 16);
        }

        public static byte GetMsgId(uint arbId)
        {
            return (byte)((arbId & 0x0000FF00) >> 8);
        }


        public static bool GetBool(SignalItem signal, byte[] data)
        {
            ulong v64 = BitConverter.ToUInt64(data, 0);
            ulong mask = (ulong)1 << signal.StartBit;
            return (v64 & mask) == mask;
        }

        public static byte GetUInt8(SignalItem signal, byte[] data)
        {
            ulong v64 = BitConverter.ToUInt64(data, 0);
            return (byte)(v64 >> signal.StartBit);
        }

        public static float GetSingle(SignalItem signal, byte[] data)
        {
            return BitConverter.ToSingle(data, signal.StartBit / 8);
        }

        public static uint GetUInt32(SignalItem signal, byte[] data)
        {
            ulong v64 = BitConverter.ToUInt64(data, 0);
            return (uint) (v64 >> signal.StartBit);
        }

        public static ulong GetUInt64(SignalItem signal, byte[] data)
        {
            return BitConverter.ToUInt64(data, 0);
        }

    }
}
