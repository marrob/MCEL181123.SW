namespace Konvolucio.MCEL181123.Events
{
    class PlayAppEvent : IApplicationEvent
    {
        public IIoService IoService;

        public PlayAppEvent(IIoService ioService)
        {
            IoService = ioService;
        }
    }
}
