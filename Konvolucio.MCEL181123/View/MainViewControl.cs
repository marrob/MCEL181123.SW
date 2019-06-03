
namespace Konvolucio.MCEL181123
{
    using System;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;

    public interface IMainViewControl
    {
        void FillContent(string[,] table, int row, int column);
        void UpdateContent(string[,] table, int row, int column);
    }

    public partial class MainViewControl : UserControl, IMainViewControl
    {


        /// <summary>
        /// Constructor
        /// </summary>
        public MainViewControl()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Fill Content
        /// </summary>
        public void FillContent(string[,] table, int row, int column)
        {



        }

        /// <summary>
        /// Update Content
        /// </summary>
        public void UpdateContent(string[,] table, int row, int column)
        {


        }
    }
}
