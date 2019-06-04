
namespace Konvolucio.MCEL181123
{
    using System;
    using System.ComponentModel;

    public class MCEL181123Device : IDevice, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        const byte MSG_MCEL_LIVE = 0xFF;
        const byte MSG_MCEL_MONITOR = 0x01;

        public static byte TpyeCode = 0x05;

        public int DeviceAddress { get; private set; }

        public int Rack { get { return DeviceAddress & 0xF0; } }
        public int Modul { get { return DeviceAddress & 0x0F; } }

        public float VSet
        {
            get { return _vSet; }
            set
            {
                if (value != _vSet)
                {
                    _vSet = value;
                    OnProppertyChanged(Common.GetPropertyName(() => VSet));
                }
            }
        }
        private float _vSet;

        public float CSet
        {
            get { return _cSet; }
            set
            {
                if (value != _cSet)
                {
                    _cSet = value;
                    OnProppertyChanged(Common.GetPropertyName(() => CSet));
                }
            }
        }
        private float _cSet;

        public bool OeSet
        {
            get { return _oeSet; }
            set
            {
                if (value != _oeSet)
                {
                    _oeSet = value;
                    OnProppertyChanged(Common.GetPropertyName(() => OeSet));
                }
            }
        }
        private bool _oeSet;


        public float VMon { get; private set; }
        public float CMon { get; private set; }

        public bool CcMode { get; private set; }
        public bool CvMOde { get; private set; }

        public Int64 UpTime { get; private set; }

        public int LastUpdate { get; private set; }


        public MCEL181123Device( )
        {

        }

        public MCEL181123Device(byte deviceAddress, byte msgId, byte[] data)
        {
            DeviceAddress = deviceAddress;
            Update(msgId, data);
           
        }

        public void Update(byte msgId, byte[] data)
        {
            switch (msgId)
            {
                case MSG_MCEL_LIVE:
                    {
                        UpTime = BitConverter.ToInt64(data, 0);
                        OnProppertyChanged(Common.GetPropertyName(() => UpTime));
                        break;
                    }

                case MSG_MCEL_MONITOR:
                    {   
                        VMon = BitConverter.ToSingle(data, 0);
                        OnProppertyChanged(Common.GetPropertyName(() => VMon));
                        CMon = BitConverter.ToSingle(data, 4);
                        OnProppertyChanged(Common.GetPropertyName(() => CMon));
                        break;
                    }

                default:
                    {
                        break;
                    };

               
            }
        }

        /// <summary>
        /// Tulajdonság változott
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnProppertyChanged(string propertyName)
        {
              PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



 
}
