
namespace Konvolucio.MCEL181123.View.Commands
{
    using System;
    using System.Windows.Forms;
    using Properties;
    using Events;
    using TreeNodes;
    using System.Diagnostics;
    using System.IO;

    internal sealed class OpenExplorerCanIOLogFileCommand : ToolStripMenuItem
    {
        public OpenExplorerCanIOLogFileCommand()
        {
            //Image = Resources.Folder_48x48;
            Text = "Open Log in File Explorer";
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            ToolTipText = @"Ctrl + O";
            ShortcutKeys = Keys.Control | Keys.O;

            EventAggregator.Instance.Subscribe<TreeNodeChangedAppEvent>(e =>
            {
                Visible = (e.SelectedNode is IoLogTreeNode);
            });
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            var myProcess = new Process();
            myProcess.StartInfo.Arguments = "\"" + Path.GetDirectoryName(Path.GetFullPath(IoLog.Instance.FilePath)) + "\"";
            myProcess.StartInfo.FileName = "explorer";
            myProcess.Start();
        }
    }
}
