﻿
namespace Konvolucio.MCEL181123.View.TreeNodes
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Events;

    internal sealed class ModulsTree : TreeNode
    {
        private readonly Explorer _explorer;


        public ModulsTree(Explorer explorer)
        {
            _explorer = explorer;
            Text = "Moduls" + @": " + AppConstants.ValueNotAvailable2;

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
                   Text = "Moduls" + @": " + _explorer.Devices.Select(n=>n.Address).Distinct().Count();

            }
        }
    }
}
