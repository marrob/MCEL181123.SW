namespace Konvolucio.MCEL181123.View.TreeNodes
{
    using System;
    using System.Windows.Forms; /*TreeNode*/
    using System.Diagnostics;   /*StopWatch*/
    using Events;


    internal sealed class RxFramesTreeNode : TreeNode
    {
        private readonly Stopwatch _watch;
        IIoService _ioService;
        private long _msgCountTemp = 0;
        private string _msgPerMs = string.Empty;
        private long _deltaT = 0;

       
        public RxFramesTreeNode(IIoService ioService)
        {
            _ioService = ioService;
            _watch = new Stopwatch();

            if (ioService.GetRxFrames.HasValue)
                Text = "Rx" + @": " + ioService.GetRxFrames;
            else
                Text = "Rx" + @": " + AppConstants.ValueNotAvailable2;

            SelectedImageKey = ImageKey = @"counter16";

            TimerService.Instance.Tick += new EventHandler(Timer_Tick);

            EventAggregator.Instance.Subscribe<StopAppEvent>(e =>
            {
                _watch.Stop();
                Timer_Tick(this, EventArgs.Empty);          /*Leállás után még rá frissít, ez KELL!*/
            });

            EventAggregator.Instance.Subscribe<PlayAppEvent>(e =>
            {
                Timer_Tick(null, EventArgs.Empty);           /*Ajánlott!*/
            });

            //ioService.Reseted += (o, e) =>
            //{
            //    _msgCountTemp = 0;
            //    _msgPerMs = AppConstants.ValueNotAvailable2;
            //    _deltaT = 0;
            //    Timer_Tick(this, EventArgs.Empty);
            //};
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            if (_ioService.GetRxFrames.HasValue)
            {
                if (!_watch.IsRunning)
                { /*Elindul*/
                    _watch.Start();
                }
                else
                {
                    _deltaT = _watch.ElapsedMilliseconds;
                    _msgPerMs = (((_ioService.GetRxFrames.Value - _msgCountTemp) / (double)_deltaT) * TimerService.Instance.Interval).ToString("N2");
                    _msgCountTemp = _ioService.GetRxFrames.Value;
                    _watch.Restart();
                }
            }

            if (_ioService.GetRxFrames.HasValue)
                Text = "Rx" + @": " + _ioService.GetRxFrames;
            else
                Text = "Rx" + @": " + AppConstants.ValueNotAvailable2;


            Text += @" [ " + _msgPerMs + @" msg/s ]" + @" " + @" [ deltaT: " + (_deltaT / 1000.0).ToString("N3") + @"s ]";
        }
    }
}