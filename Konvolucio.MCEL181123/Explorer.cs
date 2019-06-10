

namespace Konvolucio.MCEL181123
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using Devices;
    using Database;
    using System.IO;
    using Events;

    public class Explorer
    {
        public event EventHandler<IDevice> NewDeviceArrived;
        public event EventHandler<IDevice> DeviceUpdated;
        public DateTime StartTimeSamp { get; set; }
        public MCEL181123DeviceCollection Devices;

        public Explorer()
        {
            Devices = new MCEL181123DeviceCollection();

            TimerService.Instance.Tick += (s, e) =>
            {
                Log();
            };

        }

        public bool UpdateTask(CanMsg msg)
        {
            if (CanDb.GetNodeTypeId(msg.ArbId) == CanDb.Instance.Nodes.FirstOrDefault(n => n.Name == NodeCollection.NODE_MCEL).NodeTypeId)
            {
                byte node = CanDb.GetNodeAddress(msg.ArbId);
                byte msgId = CanDb.GetMsgId(msg.ArbId);

                if (Devices.FirstOrDefault(n => n.Address == node) is IDevice item)
                {
                    item.Update(msgId, msg.Data);
                    DeviceUpdated?.Invoke(this, item);
                }
                else
                {
                    var newitem = new MCEL181123DeviceItem(node, msgId, msg.Data);
                    Devices.Add(newitem);
                    NewDeviceArrived?.Invoke(this, newitem);
                }
                return true;
            }
            else
            {
                return false;
            }
        }


        public void Log()
        {
            string sep = ",";

            foreach (MCEL181123DeviceItem dev in Devices)
            {
                string path = "MCEL_" + dev.Address.ToString("X2") + "_" + StartTimeSamp.ToString(AppConstants.FileNameTimestampFormat)+".csv";

                string line = dev.LastRxTimeStamp.ToString(AppConstants.GenericTimestampFormat);
                line += AppConstants.CsvFileSeparator;
                line += dev.SIG_MCEL_V_MEAS.ToString("N4");
                line += AppConstants.CsvFileSeparator;
                line += dev.SIG_MCEL_C_MEAS.ToString("N4");
                line += AppConstants.CsvFileSeparator;
                line += dev.SIG_MCEL_CC_STATUS.ToString();
                line += AppConstants.NewLine; 

                if (!File.Exists(path))
                {
                    string header = "Timestamp";
                    header += AppConstants.CsvFileSeparator;
                    header += SignalCollection.SIG_MCEL_V_MEAS;
                    header += AppConstants.CsvFileSeparator;
                    header += SignalCollection.SIG_MCEL_C_MEAS;
                    header += AppConstants.CsvFileSeparator;
                    header += SignalCollection.SIG_MCEL_CC_STATUS;
                    header += AppConstants.NewLine;
                    File.WriteAllLines(path, new string[] { header.Trim(), line.Trim() });
                }
                else
                    File.AppendAllText(path, line);
            }
        }

    }
}
