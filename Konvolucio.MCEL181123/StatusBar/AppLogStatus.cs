

namespace Konvolucio.MCEL181123.StatusBar
{
    using System;
    using System.Windows.Forms;

    class AppLogStatus : ToolStripStatusLabel
    { 
        public AppLogStatus()
        {
            BorderSides = ToolStripStatusLabelBorderSides.Left;
            BorderStyle = Border3DStyle.Etched;
            Size = new System.Drawing.Size(58, 19);
            Text = AppConstants.ValueNotAvailable2;

            TimerService.Instance.Tick += (s, e) =>
            {
                if (AppLog.Instance.GetRecodsCount.HasValue)
                    Text = "AppLog" + @": " + AppLog.Instance.GetRecodsCount;
                else
                    Text = "AppLog" + @": " + AppConstants.ValueNotAvailable2;
            };
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            AppLog.Instance.FileOpenProces();
        }
    }
}
