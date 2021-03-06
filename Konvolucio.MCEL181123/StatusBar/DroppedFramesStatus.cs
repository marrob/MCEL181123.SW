﻿

namespace Konvolucio.MCEL181123.StatusBar
{
    using System.Windows.Forms;

    class DroppedFramesStatus : ToolStripStatusLabel
    {
        private readonly IIoService _ioService;

        public DroppedFramesStatus(IIoService ioService)
        {
            _ioService = ioService;
            BorderSides = ToolStripStatusLabelBorderSides.Left;
            BorderStyle = Border3DStyle.Etched;
            Size = new System.Drawing.Size(58, 19);
            Text = AppConstants.ValueNotAvailable2;

            TimerService.Instance.Tick += (s, e) =>
            {
                if (_ioService.GetDroppedFrames.HasValue)
                    Text = "Dropped Frames" + @": " + _ioService.GetDroppedFrames;
                else
                    Text = "Dropped Frames" + @": " + AppConstants.ValueNotAvailable2;
            };
        }
    }
}
