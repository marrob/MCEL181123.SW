namespace Konvolucio.MCEL181123.Events
{
    class StopAppEvent : IApplicationEvent
    {
        public IIoService IoService;

        public StopAppEvent(IIoService service)
        {
            IoService = service;
        }
    }
}
