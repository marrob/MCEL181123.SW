
namespace Konvolucio.MCEL181123.View.Commands
{
    using System;
    using System.Windows.Forms;
    using Properties;
    using Events;
    using TreeNodes;
    using System.Diagnostics;

    internal sealed class OpenCanIOLogFileCommand : ToolStripMenuItem
    {
        public OpenCanIOLogFileCommand()
        {
            //Image = Resources.Folder_48x48;
            Text = "Open";
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
            myProcess.StartInfo.Arguments = "\"" + IoLog.Instance.FilePath + "\"";
            myProcess.StartInfo.FileName = "Notepad++";
            try
            {
                myProcess.Start();
            }
            catch (Exception)
            {
                myProcess.StartInfo.FileName = "Notepad";
                myProcess.Start();
            }
        }
    }
}
