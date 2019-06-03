
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


    public interface IMainForm
    {
        event FormClosedEventHandler FormClosed;
        event FormClosingEventHandler FormClosing;
        event EventHandler Disposed;

        event EventHandler Shown;
        //event KeyEventHandler KeyUp;
        //event HelpEventHandler HelpRequested; /*????*/
       

        string Text { get; set; }
        //string Status { get; set; }

        //void ProgressBarUpdate(ProgressChangedEventArgs arg);
        //void Close();

        IMainViewControl MainView { get; }

        ToolStripItem[] MenuBar { set; }
        ToolStripItem[] StatusBar { set; }

        bool AlwaysOnTop { get; set; }

        //void CursorWait();
        //void CursorDefault();
    }



    public partial class MainForm : Form, IMainForm
    {

        public IMainViewControl MainView { get { return mainViewControl1; } }

        public ToolStripItem[] MenuBar
        {
            set { menuStrip1.Items.AddRange(value); }
        }

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
        }

    }
}
