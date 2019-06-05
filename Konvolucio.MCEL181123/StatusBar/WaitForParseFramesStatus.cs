

namespace Konvolucio.MCEL181123.StatusBar
{
    using System.Windows.Forms;

    class WaitForParseFramesStatus : ToolStripStatusLabel
    {
        private readonly IIoService _ioService;

        public WaitForParseFramesStatus(IIoService ioService)
        {
            _ioService = ioService;
            BorderSides = ToolStripStatusLabelBorderSides.Left;
            BorderStyle = Border3DStyle.Etched;
            Size = new System.Drawing.Size(58, 19);
            Text = AppConstants.ValueNotAvailable2;


            TimerService.Instance.Tick += (s, e) =>
            {
                if (_ioService.GetWaitForParseFrames.HasValue)
                    Text = "Wait For Parse Frames" + @": " + _ioService.GetWaitForParseFrames;
                else
                    Text = "Wait For Parse Frames" + @": " + AppConstants.ValueNotAvailable2;

            };
        }
    }
}
