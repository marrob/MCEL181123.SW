

namespace Konvolucio.MCEL181123
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MCEL;

    public class DeviceExplorer
    {
        public EventHandler NewDeviceArrived;

        public MCEL181123DeviceCollection Devices;

        public DeviceExplorer()
        {
            Devices = new MCEL181123DeviceCollection();
        }

        public bool ParseFrame(uint arbId, byte[] data)
        {
            /*DeviceType is MCEL*/
            if ((arbId & 0x0F000000) == MCEL181123Device.TpyeCode << 24)
            {
                byte address = (byte)((arbId & 0x00FF0000) >> 16);
                byte msgId = (byte)((arbId & 0x0000FF00) >> 8);

                if ((Devices.FirstOrDefault(n => n.DeviceAddress == address)) is MCEL181123Device item)
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
