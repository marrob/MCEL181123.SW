
namespace Konvolucio.MCEL181123.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class ResetAppEvent : IApplicationEvent
    {
        public ResetAppEvent()
        {

        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
