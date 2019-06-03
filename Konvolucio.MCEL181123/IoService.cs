namespace Konvolucio.MCEL181123
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Reflection;
    using Events;
    using System.Threading;

    public interface IIoService : IDisposable
    {
        event EventHandler Stopped;
        event EventHandler Started;
        string GetDefaultDeviceName { get; }
        int GetPendingFrames { get; }
        int GetDroppedFrames { get; }
        int GetParsedFrames { get; }
        void Play();
        void Stop();
    }

    class IoService : IIoService
    {
        public string GetDefaultDeviceName => throw new NotImplementedException();

        public event EventHandler Stopped;
        public event EventHandler Started;
        public event EventHandler Reset;

        public int GetPendingFrames { get; private set; }
        public int GetDroppedFrames { get; private set; }
        public int GetParsedFrames { get; private set; }

        public DeviceExplorer Explorer; 

        string CanInterface = "CAN0";
        uint Baudrate = 500000;


        private AutoResetEvent _shutdownEvent = new AutoResetEvent(false);
        private AutoResetEvent _readyToDisposeEvent = new AutoResetEvent(false);
        
        private bool _isRunning;
        private bool _disposed;
        
        uint _handle = 0;

        public IoService()
        {
            Explorer = new DeviceExplorer();
        }

        /// <summary>
        /// Play
        /// </summary>
        public void Play()
        {
            Debug.WriteLine(GetType().Namespace + "." + GetType().Name + "." + MethodBase.GetCurrentMethod().Name + "()");
           
            _shutdownEvent = new AutoResetEvent(false);
            _readyToDisposeEvent = new AutoResetEvent(false);
            EventAggregator.Instance.Publish(new PlayAppEvent(this));
            try
            {
                var th = new Thread(new ThreadStart(DoWork))
                {
                    Name = "IoService",
                };
                th.Start();
            }
            catch
            {
                OnStopped();
                throw;
            }
        }


        /// <summary>
        /// Stop
        /// </summary>
        public void Stop()
        {
            Debug.WriteLine(GetType().Namespace + "."+ 
                            GetType().Name + "." +
                            MethodBase.GetCurrentMethod().Name + "()");

            if (_shutdownEvent != null)
            {
                Debug.WriteLine(GetType().Namespace + "." +
                                GetType().Name + "." + 
                                MethodBase.GetCurrentMethod().Name + 
                                "(): Stop is pending.");
                /*Break Thread*/
                _shutdownEvent.Set();
            }

                /*Waiting for resources free*/
            if (_readyToDisposeEvent.WaitOne(5000))
            {
                Debug.WriteLine(GetType().Namespace + "." + 
                                GetType().Name + "." + 
                                MethodBase.GetCurrentMethod().Name + 
                                "(): Stop is ready.");
            }
        }

        /// <summary>
        /// Ütemesen nézzük mi a helyzet a CAN-el
        /// </summary>
        private void DoWork()
        {
            int status = 0;
            var rxMsg = new NiCan.NCTYPE_CAN_STRUCT();
            uint attrValue = 0;
            _isRunning = true;
            Exception loopException = null;

            #region Thread Started Publishing
            Action doMehtod = () => OnStarted();
            if (App.SyncContext != null)
                App.SyncContext.Post((e1) => { doMehtod(); }, null);
            else
                doMehtod();
            #endregion


            _handle = NiCanOpen(CanInterface);


            do
            {

                /*** Get NC_ATTR_READ_PENDING ***/
               if((status = NiCan.ncGetAttribute(_handle, NiCan.NC_ATTR_READ_PENDING, 4, ref attrValue)) != 0)
                {
                    loopException = new NiCanIoException(status);
                    break;
                }
                GetPendingFrames = (int)attrValue;


               // Debug.WriteLine("Timestamp:" + rxMsg.TimeStamp.ToString("X"));

                if (GetPendingFrames != 0)
                {
                    /*** Read ***/
                    if ((status = NiCan.ncRead(_handle, NiCan.CanStructSize, ref rxMsg)) != 0)
                    {
                        loopException = new NiCanIoException(status);
                        break;
                    }
                    if ((rxMsg.ArbitrationId & 0x20000000) == 0x20000000)
                    { /*Message is Extended */
                        /*Mask*/
                        UInt32 arbId = rxMsg.ArbitrationId & 0x1FFFFFFF;

                        byte[] datatemp = new byte[]
                        {   rxMsg.Data0,
                            rxMsg.Data1,
                            rxMsg.Data2,
                            rxMsg.Data3,
                            rxMsg.Data4,
                            rxMsg.Data5,
                            rxMsg.Data6,
                            rxMsg.Data7, };
                        byte[] data = new byte[rxMsg.DataLength];
                        Buffer.BlockCopy(datatemp, 0, data, 0, rxMsg.DataLength);
                 
                        LogService.Instance.WirteLine(arbId.ToString("X8") + " " + Common.ByteArrayLogString(data));

                        if (Explorer.ParseFrame(arbId, data))
                        {
                            GetParsedFrames++;
                        }
                        else
                        {   /*Device is Unknown*/
                            GetDroppedFrames++;
                        }
                    }
                    else
                    {
                        GetDroppedFrames++;
                    }

                }


                if (_shutdownEvent.WaitOne(0))
                {
                    Debug.WriteLine(GetType().Namespace + "." +
                                    GetType().Name + "." + 
                                    MethodBase.GetCurrentMethod().Name + 
                                    "(): DoWork is now shutdown!");
                    break;
                }

            } while (true);
            
            /*Probléma megjelnítése*/
            if (loopException != null)
                throw loopException;

            #region Resource Freeing
            if (_handle != 0)
            {
                NiCanClose(_handle);
                _handle = 0;
            }
            _readyToDisposeEvent.Set();
            _isRunning = false;
            #endregion

            #region Thread Terminate Publishing
            doMehtod = () =>
            {
                try
                {

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    /*Minden áron jelezni kell! hogy megállt.*/
                    OnStopped();
                    Debug.WriteLine(GetType().Namespace + "." + GetType().Name + "." + MethodBase.GetCurrentMethod().Name + "(): Loop is colsed...");
                }
            };
            if (App.SyncContext != null)
                App.SyncContext.Post((e1) => { doMehtod(); }, null);
            else
                doMehtod();
            #endregion
        }

        #region NiCan
        /// <summary>
        /// Open
        /// </summary>
        /// <returns> handle </returns>
        uint NiCanOpen(string canInterface)
        {
            int status = 0;
            uint handle = 0;

            /*** Config ***/
            uint[] AttrIdList = { NiCan.NC_ATTR_BAUD_RATE, NiCan.NC_ATTR_START_ON_OPEN };
            uint[] AttrValueList = { Baudrate, NiCan.NC_FALSE };
            uint NumAttrs = 2;
            status = NiCan.ncConfig(new StringBuilder(canInterface), NumAttrs, AttrIdList, AttrValueList);
            if (status != 0)
                throw new NiCanIoException(status);

            /*** Open Object ***/
            status = NiCan.ncOpenObject(new StringBuilder(canInterface), ref handle);
            if (status != 0)
                 throw new NiCanIoException(status);

            /*** Start ***/
            status = NiCan.ncAction(handle, NiCan.NC_OP_START, 0);
            if (status != 0)
                throw new NiCanIoException(status);
            return handle;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        void NiCanClose(uint handle)
        {
            int status = 0;

            /*** Stop ***/
            status = NiCan.ncAction(handle, NiCan.NC_OP_STOP, 0);
            if (status != 0)
                throw new NiCanIoException(status);

            status = NiCan.ncCloseObject(handle);
            if (status != 0)
                throw new NiCanIoException(status);
        }

        #endregion

        #region OnEvent
        private void OnStopped()
        {
            if (Stopped != null)
            {
                Stopped(this, EventArgs.Empty);
            }
        }

        private void OnStarted()
        {
            if (Started != null)
            {
                Started(this, EventArgs.Empty);
            }
        }

        private void OnReseted()
        {
            if (Reset != null)
            {
                Reset(this, EventArgs.Empty);
            }
        }
        #endregion

        #region Disopse
        /// <summary>
        ///  Public implementation of Dispose pattern callable by consumers. 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Protected implementation of Dispose pattern. 
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                if (_isRunning)
                {
                    Debug.WriteLine(GetType().Namespace + "." +
                                    GetType().Name + "." +
                                    MethodBase.GetCurrentMethod().Name + 
                                    "(): Running-> Stop()");
                    Stop();
                }

                if (_shutdownEvent != null)
                {
                    _shutdownEvent.Dispose();
                    _shutdownEvent = null;
                }

                if (_readyToDisposeEvent != null)
                {
                    _readyToDisposeEvent.Dispose();
                    _readyToDisposeEvent = null;
                }
            }
            _disposed = true;
        }
        #endregion
    }
}
