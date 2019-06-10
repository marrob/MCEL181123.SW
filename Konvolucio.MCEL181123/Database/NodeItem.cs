namespace Konvolucio.MCEL181123.Database
{
    public class NodeItem
    {
        public string Name { get; set; }
        public byte NodeTypeId { get; set; }

        public NodeItem(string name, byte nodeTypeId)
        {
            Name = name;
            NodeTypeId = nodeTypeId;
        }
    }
}
