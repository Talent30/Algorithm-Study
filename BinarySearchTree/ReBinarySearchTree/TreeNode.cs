namespace ReBinarySearchTree
{
    public class TreeNode
    {
        //left node
        public TreeNode LeftNode { get; set; }
        //right node
        public TreeNode RightNode { get; set; }
        //value in the node
        public int Value { get; set; }

        public TreeNode(int value)
        {
            Value = value;
            RightNode = null;
            LeftNode = null;
        }
        
    }
}