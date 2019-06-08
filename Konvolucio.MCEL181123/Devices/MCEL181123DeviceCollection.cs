
namespace Konvolucio.MCEL181123.Devices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using System.IO;


    public class MCEL181123DeviceCollection : BindingList<MCEL181123DeviceItem>
    {

        public static byte TpyeCode = 0x05;

        protected override void InsertItem(int index, MCEL181123DeviceItem item)
        {
            base.InsertItem(index, item);
        }

        public new void Remove(MCEL181123DeviceItem item)
        {
            base.Remove(item);
        }
    }
}
