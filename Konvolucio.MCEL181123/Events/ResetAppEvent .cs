
namespace Konvolucio.MCEL181123.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class ResetAppEvent : IApplicationEvent
    {
        public IIoService _IoService;

        public ResetAppEvent(IIoService ioService)
        {
            _IoService = ioService;
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
