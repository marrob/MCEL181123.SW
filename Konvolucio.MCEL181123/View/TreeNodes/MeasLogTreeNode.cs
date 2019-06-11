
namespace Konvolucio.MCEL181123.View.TreeNodes
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Events;

    internal sealed class MeasLogTreeNode : TreeNode
    {
        public MeasLogTreeNode()
        {

            Text = "Measurement Logs" + @": " + AppConstants.ValueNotAvailable2;

            TimerService.Instance.Tick += new EventHandler(Timer_Tick);

            EventAggregator.Instance.Subscribe<StopAppEvent>(e => Timer_Tick(this, EventArgs.Empty));
            EventAggregator.Instance.Subscribe<PlayAppEvent>(e => Timer_Tick(null, EventArgs.Empty));
            EventAggregator.Instance.Subscribe<ResetAppEvent>(e => Timer_Tick(null, EventArgs.Empty));
            EventAggregator.Instance.Subscribe<ShowAppEvent>(e => Timer_Tick(null, EventArgs.Empty));
            EventAggregator.Instance.Subscribe<RefreshAppEvent>(e => Timer_Tick(null, EventArgs.Empty));

            void Timer_Tick(object sender, EventArgs e)
            {
                if(IoLog.Instance.GetFileSizeKB.HasValue)
                   Text = "CAN IO Log" + @": " + IoLog.Instance.GetFileSizeKB + "KB";
                else
                   Text = "CAN IO Log" + @": " + AppConstants.ValueNotAvailable2;
            }


        }
    }
}
