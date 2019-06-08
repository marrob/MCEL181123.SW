
namespace Konvolucio.MCEL181123
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using View;
    using Database;


    public interface IMainForm
    {

        event EventHandler Shown;
        event FormClosedEventHandler FormClosed;
        event FormClosingEventHandler FormClosing;
        event EventHandler Disposed;

        string Text { get; set; }
        ToolStripItem[] MenuBar { set; }
        ISignalSendView SendView {get;}
        TreeView Tree { get; }
        DataGridView DataGrid { get; }
        ToolStripItem[] StatusBar { set; }
        bool AlwaysOnTop { get; set; }


        //event KeyEventHandler KeyUp;
        //event HelpEventHandler HelpRequested; /*????*/

        //void CursorWait();
        //void CursorDefault();
    }



    public partial class MainForm : Form, IMainForm
    {
        public ToolStripItem[] MenuBar
        {
            set { menuStrip1.Items.AddRange(value); }
        }

        public ISignalSendView SendView { get => signalSendViewControl1; }

        public TreeView Tree { get { return treeView1; } }

        public DataGridView DataGrid { get { return dataGridView1; } }

        public ToolStripItem[] StatusBar
        {
            set { statusStrip1.Items.AddRange(value); }
        }

        public bool AlwaysOnTop
        {
            get { return this.TopMost; }
            set { this.TopMost = value; }
        }

        public MainForm()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            columnVmeas.ToolTipText = CanDb.Instance.Signals.FirstOrDefault(n => n.Name == SignalCollection.SIG_MCEL_V_MEAS).Description;
        }

        private void powerControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
