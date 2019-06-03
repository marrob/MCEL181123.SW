
namespace Konvolucio.MCEL181123
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Text;
    using System.Threading;
    using System.Diagnostics;
    using Properties;
    using Events;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new App();
        }
    }

    public interface IApp
    {
        void CanConfig();
    }

    public class App : IApp
    {
        public static SynchronizationContext SyncContext = null;

        IMainForm _mainForm = new MainForm();
        IIoService _ioService = new IoService();


        public App()
        {
            /* Main Form */
            _mainForm.Text = AppConstants.SoftwareTitle + " - " + Application.ProductVersion;
            _mainForm.Shown += MainForm_Shown;
            _mainForm.FormClosing += MainForm_FormClosing;
            _mainForm.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);

            /* IoService */
            _ioService.Started += IoService_Started;
            _ioService.Stopped += IoService_Stopped;

            /*TimerService*/
            TimerService.Instance.Interval = 1000;

            #region MenuBar    
            /* Menu Bar */
            var configMenu = new ToolStripMenuItem("Config");
            configMenu.DropDown.Items.AddRange(
                new ToolStripItem[]
                {
                    new Commands.OptionsCommand(this)
                });

            var helpMenu = new ToolStripMenuItem("Help");
            helpMenu.DropDown.Items.AddRange(
                 new ToolStripItem[]
                 {
                     new Commands.HowIsWorkingCommand(),
                    // new Commands.UpdatesCommands(),
                 });

            var runMenu = new ToolStripMenuItem("Run");
            runMenu.DropDown.Items.AddRange(
            new ToolStripItem[]
               {
                     new Commands.PlayCommand(_ioService),
                     new Commands.StopCommand(_ioService),
               });

            _mainForm.MenuBar = new ToolStripItem[]
                {
                    configMenu,
                    runMenu,
                    //viewMenu,
                    helpMenu,
                };
            #endregion

            #region StatusBar

            /* StatusBar */
            _mainForm.StatusBar = new ToolStripItem[]
            {
                new StatusBar.PendingFramesStatus(_ioService),
                new StatusBar.ParsedFramesStatus(_ioService),
                new StatusBar.DroppedFramesStatus(_ioService),
                new StatusBar.EmptyStatus(),
                new StatusBar.VersionStatus(),
                new StatusBar.LogoStatus(),
            };

            #endregion

            /* Run */
            Application.Run((MainForm)_mainForm);
        }


        /// <summary>
        /// Started
        /// </summary>
        private void IoService_Started(object sender, EventArgs e)
        {
            EventAggregator.Instance.Publish(new PlayAppEvent(_ioService));
            TimerService.Instance.Start();
        }

        /// <summary>
        /// Stopped
        /// </summary>
        private void IoService_Stopped(object sender, EventArgs e)
        {
            EventAggregator.Instance.Publish(new StopAppEvent(_ioService));
            TimerService.Instance.Stop();
        }


        /// <summary>
        /// Stopped
        /// </summary>
        public void CanConfig()
        {

        }

        /// <summary>
        /// MainFrom megjelnt 
        /// Innentől él s SyncContext!
        /// User felé a default állapot, ami nem kerül soha mentésre...
        /// Betölti a GUI paramtéereket.
        /// </summary>
        void MainForm_Shown(object sender, EventArgs e)
        {
#if TRACE
            Debug.WriteLine(this.GetType().Namespace + "." + this.GetType().Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
#endif

            SyncContext = SynchronizationContext.Current;
            //_mainForm.LayoutRestore();
            /*Ö tölti be a projectet*/
            Start(Environment.GetCommandLineArgs());
            /*Kezdő Node Legyen az Adapter node*/
            //EventAggregator.Instance.Publish<TreeViewSelectionChangedAppEvent>(new TreeViewSelectionChangedAppEvent(_startTreeNode));
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">A fájl - hoz tartozó argumentumok.</param>
        public void Start(string[] args)
        {
#if TRACE
            Debug.WriteLine(this.GetType().Namespace + "." + this.GetType().Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + ": " + string.Join("\r\n -", args));
#endif
        }
        /// <summary>
        /// Az alaklamzás bezárását kérte a felhasználó, ez még megszakítható
        /// </summary>
        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
#if TRACE
            Debug.WriteLine(this.GetType().Namespace + "." + this.GetType().Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
#endif
        }
        /// <summary>
        /// MainFrom bezárult 
        /// Itt ment mindent amit kell.
        /// </summary>
        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
#if TRACE
            Debug.WriteLine(this.GetType().Namespace + "." + this.GetType().Name + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + "()");
#endif
            _ioService.Dispose();
            EventAggregator.Instance.Dispose();
            Settings.Default.Save();

        }

    }
}