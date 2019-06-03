

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
            Text = "-";

            TimerService.Instance.Tick += (s, e) => { Text = "Parsed:" + ioService.GetParsedFrames.ToString() + " "; };
        }
    }
}
