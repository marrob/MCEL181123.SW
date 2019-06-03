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
        void Play();
        void Stop();
    }

    class IoService : IIoService
    {
        public string GetDefaultDeviceName => throw new NotImplementedException();

        public event EventHandler Stopped;
        public event EventHandler Started;
        public event EventHandler Reset;



        string CanInterface = "CAN0";
        uint Baudrate = 500000;


        private AutoResetEvent _shutdownEvent = new AutoResetEvent(false);
        private AutoResetEvent _readyToDisposeEvent = new AutoResetEvent(false);
        
        private bool _isRunning;
        private bool _disposed;
        uint _handle = 0;
        public IoService()
        {
            
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
                _handle = NiCanOpen(CanInterface);

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
        /// Ütemesen nézzük mi a helyzet az adapterrel
        /// </summary>
        private void DoWork()
        {
            _isRunning = true;
            Exception loopException = null;

            #region Thread Started Publishing
            Action doMehtod = () => OnStarted();
            if (App.SyncContext != null)
                App.SyncContext.Post((e1) => { doMehtod(); }, null);
            else
                doMehtod();
            #endregion

            do
            {
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
            status = NiCan.ncAction(_handle, NiCan.NC_OP_START, 0);

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
    }
}
