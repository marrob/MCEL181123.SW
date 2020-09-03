﻿
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
    using Database;
    using System.ComponentModel;
    using Common;
    using System.Reflection;
    using System.Text.RegularExpressions;

    static class Program
    {
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

    }

    public class App : IApp
    {
        public static SynchronizationContext SyncContext = null;


        IMainForm _mainForm;
        Explorer _explorer;
        IIoService _ioService;
        TcpService _tcpService;

        private readonly TreeNode _startTreeNode;

        public App()
        {


            /*** Application Settings Upgrade ***/
            if (Settings.Default.ApplictionSettingsSaveCounter == 0)
            {
                Settings.Default.Upgrade();
                Settings.Default.ApplictionSettingsUpgradeCounter++;
            }
            Settings.Default.ApplictionSettingsSaveCounter++;
            Settings.Default.PropertyChanged += new PropertyChangedEventHandler(Settings_PropertyChanged);


            /*** Main Form ***/
            _mainForm = new MainForm();
            _mainForm.Text = AppConstants.SoftwareTitle + " - " + Application.ProductVersion;
            _mainForm.Shown += MainForm_Shown;
            _mainForm.FormClosing += MainForm_FormClosing;
            _mainForm.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);

            /*** Explorer ***/
            _explorer = new Explorer();

            /*** IoService ***/
            _ioService = new IoService(_explorer);
            _ioService.Started += IoService_Started;
            _ioService.Stopped += IoService_Stopped;

            /*** TimerService ***/
            TimerService.Instance.Interval = Settings.Default.GuiRefreshRateMs;

            /*** TcpService ***/
            _tcpService = new TcpService();
            _tcpService.ParserCallback = TcpServiceParser;
            _tcpService.Begin(null);
            _tcpService.Completed += TcpService_Completed;


            /*** Menu Bar ***/
            #region MenuBar      
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
                     new Commands.ResetCommand()
               });

            _mainForm.MenuBar = new ToolStripItem[]
                {
                   // configMenu,
                    runMenu,
                    //viewMenu,
                    helpMenu,
                };
            #endregion

            /*** SendView ***/
            #region SendView
            var sendView = _mainForm.SendView;
            sendView.Signals = CanDb.Instance.Signals.Where(n => n.Message.NodeType.Name == NodeCollection.NODE_PC ).Select(n=>n.Name).ToArray();
            sendView.SelectedSignalChanged += (o, s) =>
            {
                sendView.Value = CanDb.Instance.Signals.FirstOrDefault(n => n.Name == sendView.SelectedSignal).DefaultValue;
            };
            sendView.Send += (o, s) =>
            {
              var msg = CanDb.MakeMessage
                (
                    nodeTypeId: CanDb.Instance.Nodes.FirstOrDefault(n=>n.Name == NodeCollection.NODE_PC).NodeTypeId,
                    nodeAddress: sendView.Address,
                    broadcast: sendView.Broadcast,
                    signal: CanDb.Instance.Signals.FirstOrDefault(n => n.Name == sendView.SelectedSignal),
                    value: sendView.Value
                    
                    
                );

                _ioService.TxQueue.Enqueue(msg);
            };
            #endregion
            
            /*** Tree ***/
            #region Tree
            _mainForm.Tree.AfterSelect += Tree_AfterSelect;
            _mainForm.Tree.Nodes.AddRange(
                new TreeNode[]
                    {
                        new View.TreeNodes.RacksTreeNode(_explorer),
                        new View.TreeNodes.ModulsTree(_explorer),
                        new View.TreeNodes.WaitForParseTreeNode(_ioService),
                        new View.TreeNodes.DropFrameTreeNode(_ioService),
                        new View.TreeNodes.ParsedFrameTreeNode(_ioService),
                        new View.TreeNodes.RxFramesTreeNode(_ioService),
                        new View.TreeNodes.TxFramesTreeNode(_ioService),
                        new View.TreeNodes.WaitForTxTreeNode(_ioService),
                        new View.TreeNodes.IoLogTreeNode()
                    });

            _mainForm.Tree.ContextMenuStrip = new ContextMenuStrip();
            _mainForm.Tree.ContextMenuStrip.Items.AddRange(
                new ToolStripItem[]
                {
                    new View.Commands.OpenCanIOLogFileCommand(),
                    new View.Commands.DeleteCanIOLogFileCommand(),
                    new View.Commands.OpenExplorerCanIOLogFileCommand(),
                });

            #endregion

            /*** DataGrid ***/
            var grid = _mainForm.DataGrid;
            grid.DataSource = _explorer.Devices;
          
            /*** StatusBar ***/    
            #region StatusBar
            _mainForm.StatusBar = new ToolStripItem[]
            {
                new StatusBar.AppLogStatus(),
                new StatusBar.WaitForParseFramesStatus(_ioService),
                new StatusBar.ParsedFramesStatus(_ioService),
                new StatusBar.DroppedFramesStatus(_ioService),                
                new StatusBar.EmptyStatus(),
                new StatusBar.VersionStatus(),
                new StatusBar.LogoStatus(),
            };
            #endregion

            /*** Run ***/
            Application.Run((MainForm)_mainForm);
        }

        /*** TcpService ***/
        private string TcpServiceParser(string line)
        {
            line = Regex.Replace(line, @"\s+", " ");
            var array = line.Trim().Split(' ');
            var addrStr = array[0].Trim();
            var command = array[1].Trim();

            byte address = 0;
            if (!addrStr.Contains("#"))
                return "Emulator address format is invalid. Use this: '#A1 MEAS:VOLT?' (-???)";

            if (!byte.TryParse(addrStr.Substring(1), out address))
                return "Data Type Error (-104)";

            if (_explorer.Devices.Count != 0)
            {    
                switch (command)
                {
                    case "MEAS:CURR?": return _explorer.Devices.FirstOrDefault(n => n.Address == address).SIG_MCEL_C_MEAS.ToString(); 
                    case "MEAS:VOLT?": return _explorer.Devices.FirstOrDefault(n => n.Address == address).SIG_MCEL_V_MEAS.ToString();
                    case "VOLT":
                        {
                            double par;
                            if (string.IsNullOrEmpty(array[2]))
                                return "Missing Paramtert (-109)";
                            else if (!double.TryParse(array[2], out par))
                                return "Data Type Error (-104)";
                            var msg = CanDb.MakeMessage
                             (
                              nodeTypeId: CanDb.Instance.Nodes.FirstOrDefault(n => n.Name == NodeCollection.NODE_PC).NodeTypeId,
                              nodeAddress: address,
                              broadcast: false,
                              signal: CanDb.Instance.Signals.FirstOrDefault(n => n.Name == "SIG_PC_CV_SET"),
                              value: par.ToString()
                             );
                            _ioService.TxQueue.Enqueue(msg);
                            return "OK";
                        }
                }                
            }
            else
            {
                return "Hardware Missing (-241)";
            }

            return "UNKNOWN";
        }

        private void TcpService_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            AppLog.Instance.WriteLine(e.Error.Message);
        }

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            EventAggregator.Instance.Publish(new TreeNodeChangedAppEvent(e.Node));
        }

        private void IoService_Started(object sender, EventArgs e)
        {
            EventAggregator.Instance.Publish(new PlayAppEvent(_ioService));
            _explorer.StartTimeSamp = DateTime.Now;
            TimerService.Instance.Start();
        }

        private void IoService_Stopped(object sender, EventArgs e)
        {
            EventAggregator.Instance.Publish(new StopAppEvent(_ioService));
            TimerService.Instance.Stop();
        }

        void MainForm_Shown(object sender, EventArgs e)
        {
#if TRACE
            Debug.WriteLine(GetType().Namespace + "." + GetType().Name + "." + MethodBase.GetCurrentMethod().Name + "()");
#endif

            SyncContext = SynchronizationContext.Current;
            _mainForm.LayoutRestore();

            /* Megnyitást követően rá áll az Adapter Nódra a TreeView-ban.*/
            _mainForm.Tree.Nodes[0].ExpandAll();
            _mainForm.Tree.SelectedNode = _startTreeNode;

            //_mainForm.LayoutRestore();
            /*Ö tölti be a projectet*/
            Start(Environment.GetCommandLineArgs());
            /*Kezdő Node Legyen az Adapter node*/
            //EventAggregator.Instance.Publish<TreeViewSelectionChangedAppEvent>(new TreeViewSelectionChangedAppEvent(_startTreeNode));

            EventAggregator.Instance.Publish(new ShowAppEvent());

           // if (Settings.Default.PlayAfterStartUp)
                _ioService.Play();
        }

        public void Start(string[] args)
        {
#if TRACE
            Debug.WriteLine(GetType().Namespace + "." + GetType().Name + "." + MethodBase.GetCurrentMethod().Name + ": " + string.Join("\r\n -", args));
#endif
        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
#if TRACE
            Debug.WriteLine(GetType().Namespace + "." + GetType().Name + "." +MethodBase.GetCurrentMethod().Name + "()");
#endif
        }

        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
#if TRACE
            Debug.WriteLine(GetType().Namespace + "." + GetType().Name + "." + MethodBase.GetCurrentMethod().Name + "()");
#endif
            TimerService.Instance.Dispose();
            _ioService.Dispose();
            _mainForm.LayoutSave();
            Settings.Default.Save();
            EventAggregator.Instance.Dispose();
            Settings.Default.Save();
        }

        void Settings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Debug.WriteLine(GetType().Namespace + "." + GetType().Name + "." + MethodBase.GetCurrentMethod().Name + "(): " + e.PropertyName + ", NewValue: " + Settings.Default[e.PropertyName]);

            if (e.PropertyName == Tools.GetPropertyName(() => Settings.Default.GuiRefreshRateMs))
            {
                TimerService.Instance.Interval = Settings.Default.GuiRefreshRateMs;
            }
        }

    }
}