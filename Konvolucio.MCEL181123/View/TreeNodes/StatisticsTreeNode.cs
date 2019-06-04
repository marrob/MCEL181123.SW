
namespace Konvolucio.MCEL181123.View.TreeNodes
{
    using System.Windows.Forms;

    internal sealed class StatisticsTreeNode : TreeNode
    {
        public StatisticsTreeNode(TreeNode[] subNodes)
        {
            Nodes.AddRange(subNodes);
            Text = @"Statistics";
            SelectedImageKey = ImageKey = @"Statistics16";
        }
    }
}
