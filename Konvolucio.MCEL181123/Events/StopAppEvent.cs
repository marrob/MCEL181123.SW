

namespace Konvolucio.MCEL181123.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    /// <summary>
    /// 
    /// </summary>
    class StopAppEvent : IApplicationEvent
    {
        public IIoService IoService;

        public StopAppEvent(IIoService service)
        {
            IoService = service;
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
