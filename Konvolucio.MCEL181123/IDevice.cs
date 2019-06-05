namespace Konvolucio.MCEL181123
{
    using System;

    public interface IDevice
    {
        byte Address { get; }
        void Update(byte msgId, byte[] data);
        DateTime LastRx { get; }
    }
}