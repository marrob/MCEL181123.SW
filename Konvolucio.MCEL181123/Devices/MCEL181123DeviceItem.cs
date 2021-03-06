﻿
namespace Konvolucio.MCEL181123.Devices
{
    using System;
    using System.ComponentModel;
    using Common;
    using System.Collections;
    using Database;
    using System.Linq;
    using System.Diagnostics;

    public class MCEL181123DeviceItem : IDevice, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public byte Address { get; private set; }
        public byte Rack { get { return (byte)(Address & 0xF0); } }
        public byte Modul { get { return (byte)(Address & 0x0F); } }

        public float SIG_MCEL_V_MEAS { get; private set; }
        public int SIG_MCEL_C_RANGE { get; private set; }
        public float SIG_MCEL_C_MEAS { get; private set; }
        public bool SIG_MCEL_OE_STATUS { get; private set; }
        public bool SIG_MCEL_CC_STATUS { get; private set; }
        public bool SIG_MCEL_CV_STATUS { get; private set; }
        public float SIG_MCEL_UC_TEMP { get; private set; }
        public float SIG_MCEL_TR_TEMP { get; private set; }

        public int SIG_MCEL_RXERRCNT { get; private set; }
        public int SIG_MCEL_TXERRCNT { get; private set; }
        public int SIG_MCEL_RXTESTCNT { get; private set; }

        public uint SIG_MCEL_RUN_TIME_TICK { get; private set; }
        public uint SIG_MCEL_VERSION { get; private set; }
        public DateTime LastRxTimeStamp { get; private set; }

        public MCEL181123DeviceItem() { }

        /// <summary>
        /// Constructor
        /// </summary>
        public MCEL181123DeviceItem(byte deviceAddress, byte msgId, byte[] data)
        {
            Address = deviceAddress;
            Update(msgId, data); 
        }

        public void Update(byte msgId, byte[] data)
        {
            LastRxTimeStamp = DateTime.Now;
            var mcelSingals = CanDb.Instance.Signals.Where(n => n.Message.NodeType.Name == NodeCollection.NODE_MCEL).Select(n => n);

            //Debug.WriteLine(string.Join("\r\n", mcelSingals.Select(n => n.Name)));

            switch (msgId)
            {
                    case MessageCollection.MSG_MCEL_V_MEAS_ID:
                    {
                        var signal = mcelSingals.FirstOrDefault(n => n.Name == Tools.GetPropertyName(() => SIG_MCEL_V_MEAS));
                        SIG_MCEL_V_MEAS = CanDb.GetSingle(signal, data);
                        OnProppertyChanged(Tools.GetPropertyName(() => SIG_MCEL_V_MEAS));
                        break;
                    }

                case MessageCollection.MSG_MCEL_C_MEAS_ID:
                    {
                        var signal = mcelSingals.FirstOrDefault(n => n.Name == Tools.GetPropertyName(() => SIG_MCEL_C_RANGE));
                        SIG_MCEL_C_RANGE = CanDb.GetUInt8(signal, data);
                        OnProppertyChanged(Tools.GetPropertyName(() => SIG_MCEL_C_RANGE));

                        signal = mcelSingals.FirstOrDefault(n => n.Name == Tools.GetPropertyName(() => SIG_MCEL_C_MEAS));
                        SIG_MCEL_C_MEAS = CanDb.GetSingle(signal, data);
                        OnProppertyChanged(Tools.GetPropertyName(() => SIG_MCEL_C_MEAS));
                        break;
                    }

                case MessageCollection.MSG_MCEL_STATUS_ID:
                    {
                        var signal = mcelSingals.FirstOrDefault(n => n.Name == Tools.GetPropertyName(() => SIG_MCEL_CC_STATUS));
                        SIG_MCEL_CC_STATUS = CanDb.GetBool(signal, data);
                        OnProppertyChanged(Tools.GetPropertyName(() => SIG_MCEL_CC_STATUS));

                        signal = mcelSingals.FirstOrDefault(n => n.Name == Tools.GetPropertyName(() => SIG_MCEL_CV_STATUS));
                        SIG_MCEL_CV_STATUS = CanDb.GetBool(signal, data);
                        OnProppertyChanged(Tools.GetPropertyName(() => SIG_MCEL_CV_STATUS));

                        signal = mcelSingals.FirstOrDefault(n => n.Name == Tools.GetPropertyName(() => SIG_MCEL_OE_STATUS));
                        SIG_MCEL_OE_STATUS = CanDb.GetBool(signal, data);
                        OnProppertyChanged(Tools.GetPropertyName(() => SIG_MCEL_OE_STATUS));
                        break;
                    }
                case MessageCollection.MSG_MCEL_TEMPS_ID:
                    {
                        var signal = mcelSingals.FirstOrDefault(n => n.Name == Tools.GetPropertyName(() => SIG_MCEL_UC_TEMP));
                        SIG_MCEL_UC_TEMP = CanDb.GetSingle(signal, data);
                        OnProppertyChanged(Tools.GetPropertyName(() => SIG_MCEL_UC_TEMP));

                        signal = mcelSingals.FirstOrDefault(n => n.Name == Tools.GetPropertyName(() => SIG_MCEL_TR_TEMP));
                        SIG_MCEL_TR_TEMP = CanDb.GetSingle(signal, data);
                        OnProppertyChanged(Tools.GetPropertyName(() => SIG_MCEL_TR_TEMP));

                        break;
                    }

                case MessageCollection.MSG_MCEL_LIVE_ID:
                    {
                        var signal = mcelSingals.FirstOrDefault(n => n.Name == Tools.GetPropertyName(() => SIG_MCEL_RUN_TIME_TICK));
                        SIG_MCEL_RUN_TIME_TICK = CanDb.GetUInt32(signal, data);
                        OnProppertyChanged(Tools.GetPropertyName(() => SIG_MCEL_RUN_TIME_TICK));

                        signal = mcelSingals.FirstOrDefault(n => n.Name == Tools.GetPropertyName(() => SIG_MCEL_VERSION));
                        SIG_MCEL_VERSION = CanDb.GetUInt32(signal, data);
                        OnProppertyChanged(Tools.GetPropertyName(() => SIG_MCEL_VERSION));
                        break;
                    }

                case MessageCollection.MSG_MCEL_NET_MON_ID:
                    {
                        var signal = mcelSingals.FirstOrDefault(n => n.Name == Tools.GetPropertyName(() => SIG_MCEL_RXERRCNT));
                        SIG_MCEL_RXERRCNT = CanDb.GetUInt8(signal, data);
                        OnProppertyChanged(Tools.GetPropertyName(() => SIG_MCEL_RXERRCNT));

                        signal = mcelSingals.FirstOrDefault(n => n.Name == Tools.GetPropertyName(() => SIG_MCEL_TXERRCNT));
                        SIG_MCEL_TXERRCNT = CanDb.GetUInt8(signal, data);
                        OnProppertyChanged(Tools.GetPropertyName(() => SIG_MCEL_TXERRCNT));

                        signal = mcelSingals.FirstOrDefault(n => n.Name == Tools.GetPropertyName(() => SIG_MCEL_RXTESTCNT));
                        SIG_MCEL_RXTESTCNT = CanDb.GetUInt8(signal, data);
                        OnProppertyChanged(Tools.GetPropertyName(() => SIG_MCEL_RXTESTCNT));
                        break;
                    }



                default:
                    {
                        //throw new ApplicationException("Unknown message Id");
                        break;
                    };

            }
        }

        private void OnProppertyChanged(string propertyName)
        {
              PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
