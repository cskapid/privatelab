using System.Collections.Generic;

namespace Solution
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class TreeBuilder
    {
        public static TreeNode BuildTree(int?[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return null;

            if (numbers[0] == null)
                return null;

            TreeNode root = new TreeNode(numbers[0].Value);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            for (var i = 1; i < numbers.Length; i = i + 2)
            {
                var node = queue.Dequeue();
                if (numbers[i] != null)
                {
                    node.left = new TreeNode(numbers[i].Value);
                    queue.Enqueue(node.left);
                }
                if ((i + 1) < numbers.Length && numbers[i + 1] != null)
                {
                    node.right = new TreeNode(numbers[i + 1].Value);
                    queue.Enqueue(node.right);
                }
            }

            return root;
        }
    }

}
