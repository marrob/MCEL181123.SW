

namespace Konvolucio.MCEL181123
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Devices;
    using CanDatabase;

    public class Explorer
    {
        public EventHandler NewDeviceArrived;
        public MCEL181123DeviceCollection Devices;

        public Explorer()
        {
            Devices = new MCEL181123DeviceCollection();
        }


        public bool UpdateTask(CanMsg msg)
        {

            if (CanDb.GetNodeId(msg.ArbId) == CanDb.Instance.Nodes.FirstOrDefault(n => n.Name == "MCEL181123").Id)
            {
                byte node = CanDb.GetNodeAddress(msg.ArbId);
                byte msgId = CanDb.GetMsgId(msg.ArbId);

                if (Devices.FirstOrDefault(n => n.Address == node) is IDevice item)
                {
                    item.Update(msgId, msg.Data);
                }
                else
                {
                    Devices.Add(new MCEL181123DeviceItem(node, msgId, msg.Data));
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
