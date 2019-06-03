
namespace Konvolucio.MCEL181123
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface IDevice
    {
        int DeviceAddress { get; }
        void Update(byte msgId, byte[] data);
    }

    public class MCEL181123Device : IDevice
    {
        const byte MSG_MCEL_LIVE = 0xFF;
        const byte MSG_MCEL_MONITOR = 0x01;

        public static byte TpyeCode = 0x05;

        public int DeviceAddress { get; private set; }
        public float Vmon { get; private set; }
        public float Cmon { get; private set; }
        public Int64 UpTime { get; private set; }



        public MCEL181123Device( )
        {

        }

        public MCEL181123Device(byte deviceAddress, byte msgId, byte[] data)
        {
            DeviceAddress = deviceAddress;
            Update(msgId, data);
        }

        public void Update(byte msgId, byte[] data)
        {
            switch (msgId)
            {
                case MSG_MCEL_LIVE:
                    {
                        UpTime = BitConverter.ToInt64(data, 0);
                        break;
                    }

                case MSG_MCEL_MONITOR:
                    {   
                        Vmon = BitConverter.ToSingle(data, 0);
                        Cmon = BitConverter.ToSingle(data, 4);                       
                        break;
                    }

                default:
                    {
                        break;
                    };
            }
        }
    }

    public class DeviceExplorer
    {
        public EventHandler NewDeviceArrived;

        public List<IDevice> Devices;

        public DeviceExplorer()
        {
            Devices = new List<IDevice>();
        }

        public bool ParseFrame(uint arbId, byte[] data)
        {
            /*DeviceType is MCEL*/
            if ((arbId & 0x0F000000) == MCEL181123Device.TpyeCode << 24)
            {
                byte address = (byte)((arbId & 0x00FF0000) >> 16);
                byte msgId = (byte)((arbId & 0x0000FF00) >> 8);

                if ((Devices.FirstOrDefault(n => n.DeviceAddress == address)) is IDevice item)
                {
                    item.Update(msgId, data);
                }
                else
                {
                    item = new MCEL181123Device(address, msgId, data);
                    Devices.Add(item);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
