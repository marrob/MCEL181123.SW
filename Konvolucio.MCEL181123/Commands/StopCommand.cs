namespace Konvolucio.MCEL181123.Commands
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Properties;
    using Events;

    internal sealed class StopCommand : ToolStripMenuItem
    {
        private readonly IIoService _service;

        public StopCommand(IIoService service)
        {
            _service = service;
            Image = Resources.Stop_48x48;
            Text = "Stop";
            Enabled = false;
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            ToolTipText = @"F6";
            ShortcutKeys = Keys.F6;
            EventAggregator.Instance.Subscribe<PlayAppEvent>(n => Enabled = true);
            EventAggregator.Instance.Subscribe<StopAppEvent>(n => Enabled = false);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Debug.WriteLine(this.GetType().Namespace + "." + this.GetType().Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
            if (Enabled)
            {
                _service.Stop();
                
            }
        }
    }
}
