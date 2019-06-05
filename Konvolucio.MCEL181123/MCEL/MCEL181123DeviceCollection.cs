
namespace Konvolucio.MCEL181123.MCEL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;

    public class MCEL181123DeviceCollection : BindingList<MCEL181123DeviceItem>
    {

        /// <summary>
        /// Egy Tool tábla beszúrása a listába.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        protected override void InsertItem(int index, MCEL181123DeviceItem item)
        {
            base.InsertItem(index, item);
        }

        /// <summary>
        /// Egy tábla törlése
        /// </summary>
        /// <param name="item"></param>
        public new void Remove(MCEL181123DeviceItem item)
        {
            base.Remove(item);
        }
    }
}
