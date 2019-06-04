namespace Konvolucio.MCEL181123.Commands
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Properties;
    using Events;

    internal sealed class ResetCommand : ToolStripMenuItem
    {
        public ResetCommand()
        {
            Image = Resources.Stop_48x48;
            Text = "Reset";
            Enabled = false;
            DisplayStyle = ToolStripItemDisplayStyle.Text;
            ToolTipText = @"Shift + F5";
            ShortcutKeys = Keys.Shift | Keys.F6;
            EventAggregator.Instance.Subscribe<PlayAppEvent>(n => Enabled = false);
            EventAggregator.Instance.Subscribe<StopAppEvent>(n => Enabled = true);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Debug.WriteLine(this.GetType().Namespace + "." + this.GetType().Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
            if (Enabled)
            {
                EventAggregator.Instance.Publish(new ResetAppEvent()); 
            }
        }
    }
}
