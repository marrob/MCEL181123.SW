namespace Konvolucio.MCEL181123.Commands
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Properties;
    using Events;

    internal sealed class PlayCommand : ToolStripMenuItem
    {
        private readonly IIoService _ioService;

        public PlayCommand(IIoService ioService)
        {
            _ioService = ioService;
            Image = Resources.Play_48x48;
            Text = "Run";
            ShortcutKeys = Keys.F5;
            Enabled = true;
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            ToolTipText = @"F5";
            EventAggregator.Instance.Subscribe<StopAppEvent>(e => Enabled = true);
            EventAggregator.Instance.Subscribe<PlayAppEvent>(e => Enabled = false);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Debug.WriteLine(this.GetType().Namespace + "." + this.GetType().Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");

            if (Enabled)
            {
                _ioService.Play();
            }
        }
    }
}
