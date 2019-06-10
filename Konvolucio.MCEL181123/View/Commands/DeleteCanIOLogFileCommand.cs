
namespace Konvolucio.MCEL181123.View.Commands
{
    using System;
    using System.Windows.Forms;
    using Properties;
    using Events;
    using TreeNodes;
    using System.IO;

    internal sealed class DeleteCanIOLogFileCommand : ToolStripMenuItem
    {
        public DeleteCanIOLogFileCommand()
        {
            //Image = Resources.Folder_48x48;
            Text = "Delete";
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            ToolTipText = @"Ctrl + D";
            ShortcutKeys = Keys.Control | Keys.O;

            EventAggregator.Instance.Subscribe<TreeNodeChangedAppEvent>(e =>
            {
                Visible = (e.SelectedNode is IoLogTreeNode);
            });
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (File.Exists(IoLog.Instance.Path))
            {
                File.Delete(IoLog.Instance.Path);
                EventAggregator.Instance.Publish(new RefreshAppEvent(this));
            }
        }
    }
}
