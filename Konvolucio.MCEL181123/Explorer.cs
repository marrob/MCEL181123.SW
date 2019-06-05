

namespace Konvolucio.MCEL181123
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using Common;
    using MCEL;

    public class Explorer
    {
        public EventHandler NewDeviceArrived;

        public SafeQueue<CanMsg> TxQueue;

        public MCEL181123DeviceCollection Devices;

        public Explorer()
        {
            Devices = new MCEL181123DeviceCollection();
            TxQueue = new SafeQueue<CanMsg>();
        }


        public bool UpdateTask(CanMsg msg)
        {
             /*DeviceType is MCEL*/
            if ((msg.ArbId & 0x0F000000) == MCEL181123DeviceItem.TpyeCode << 24)
            {
                byte address = (byte)((msg.ArbId & 0x00FF0000) >> 16);
                byte msgType = (byte)((msg.ArbId & 0x0000FF00) >> 8);

                if ((Devices.FirstOrDefault(n => n.Address == address)) is IDevice item)
                {
                    item.Update(msgType, msg.Data);
                }
                else
                {
                    Devices.Add(new MCEL181123DeviceItem(address, msgType, msg.Data));
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
