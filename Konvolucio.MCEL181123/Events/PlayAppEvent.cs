
namespace Konvolucio.MCEL181123.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class PlayAppEvent : IApplicationEvent
    {
        public IIoService IoService;

        public PlayAppEvent(IIoService ioService)
        {
            IoService = ioService;
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
