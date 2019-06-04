
namespace Konvolucio.MCEL181123.View.TreeNodes
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Events;

    internal sealed class  DropFrameTreeNode : TreeNode
    {
        private readonly IIoService _ioService;


        public DropFrameTreeNode(IIoService ioService)
        {
            _ioService = ioService;
            Text = "Dropped" + @": " + AppConstants.ValueNotAvailable2;

            TimerService.Instance.Tick += new EventHandler(Timer_Tick);

            EventAggregator.Instance.Subscribe<Events.StopAppEvent>(e =>
            {
                Timer_Tick(this, EventArgs.Empty);  /*Leállás után még rá frissít, ez KELL!*/
            });

            EventAggregator.Instance.Subscribe<PlayAppEvent>(e =>
            {
                Timer_Tick(null, EventArgs.Empty);   /*Ajánlott!*/
            });

            EventAggregator.Instance.Subscribe<ResetAppEvent>(e =>
            {
                Timer_Tick(null, EventArgs.Empty);   
            });

            void Timer_Tick(object sender, EventArgs e)
            {
                if(_ioService.GetDroppedFrames.HasValue)
                   Text = "Dropped" + @": " + _ioService.GetDroppedFrames;
                else
                   Text = "Dropped" + @": " + AppConstants.ValueNotAvailable2;
            }
        }
    }
}
