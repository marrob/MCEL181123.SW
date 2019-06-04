namespace Konvolucio.MCEL181123
{
    public interface IDevice
    {
        int DeviceAddress { get; }
        void Update(byte msgId, byte[] data);
    }
}