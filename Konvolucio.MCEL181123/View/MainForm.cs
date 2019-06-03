
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
        string Version { get; set; }
        string LastModified { get; set; }
        string LoadTime { get; set; }
        string RowCoulmn { get; set; }
        void StatusClear();

        IMainViewControl MainView { get; }

        ToolStripItem[] MenuBar { set; }

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

        public string Version
        {
            get { return toolStripStatusLabelVersion.Text; }
            set { toolStripStatusLabelVersion.Text = value; }
        }

        public string LastModified
        {
            get { return toolStripStatusLabelLastModify.Text; }
            set { toolStripStatusLabelLastModify.Text = value; }
        }

        public string LoadTime
        {
            get { return toolStripStatusLoadTime.Text; }
            set { toolStripStatusLoadTime.Text = value; }
        }

        public string RowCoulmn
        {
            get { return toolStripStatusLabelRowColumn.Text; }
            set { toolStripStatusLabelRowColumn.Text = value; }
        }

        public bool AlwaysOnTop
        {
            get { return this.TopMost; }
            set { this.TopMost = value; }
        }

        public void StatusClear()
        {
            LastModified = "-";
            LoadTime = "-";
            RowCoulmn = "-";
        }

        public MainForm()
        {
            InitializeComponent();
        }

    }
}
