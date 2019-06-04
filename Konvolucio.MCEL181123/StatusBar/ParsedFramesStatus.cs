

namespace Konvolucio.MCEL181123.StatusBar
{
    using System.Windows.Forms;

    class ParsedFramesStatus : ToolStripStatusLabel
    {
        private readonly IIoService _ioService;

        public ParsedFramesStatus(IIoService ioService)
        {
            _ioService = ioService;
            BorderSides = ToolStripStatusLabelBorderSides.Left;
            BorderStyle = Border3DStyle.Etched;
            Size = new System.Drawing.Size(58, 19);
            Text = AppConstants.ValueNotAvailable2;

            TimerService.Instance.Tick += (s, e) => 
            {
                if (_ioService.GetParsedFrames.HasValue)
                    Text = "Parsed Frames" + @": " + _ioService.GetParsedFrames;
                else
                    Text = "Parsed Frames" + @": " + AppConstants.ValueNotAvailable2;

            };
        }
    }
}
