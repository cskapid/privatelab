using System.Collections.Generic;

namespace TestPad.Tree
{
    public class TreeValidator
    {
        private int? seed = null;

        public bool IsValidBSTIterative(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            Stack<TreeNode> nodes = new Stack<TreeNode>();
            TreeNode node = root;
            seed = null;
            while (nodes.Count > 0 || node != null)
            {
                if (node != null)
                {
                    nodes.Push(node);
                    node = node.left;
                }
                if (node == null)
                {
                    node = nodes.Pop();
                    if (seed.HasValue && seed.Value >= node.val)
                    {
                        return false;
                    }
                    seed = node.val;
                    node = node.right;
                }
            }

            return true;
        }

        public bool IsValidBSTRecursive(TreeNode root)
        {
            if (root != null)
            {
                if (!IsValidBSTRecursive(root.left)) return false;
                if (seed.HasValue && seed.Value >= root.val) return false;
                seed = root.val;
                return IsValidBSTRecursive(root.right);
            }

            return true;
        }

        public bool IsValidBSTRecursiveMinMax(TreeNode root)
        {
            return IsValidBSTRecursiveMinMax(root, null, null);
        }

        private bool IsValidBSTRecursiveMinMax(TreeNode root, int? min, int? max)
        {
            if (root == null) return true;
            return ((min == null || root.val > min.Value) && (max == null || root.val < max.Value)) &&
                    ((root.left == null || (root.val > root.left.val && IsValidBSTRecursiveMinMax(root.left, min, root.val))) &&
                     (root.right == null || (root.val < root.right.val && IsValidBSTRecursiveMinMax(root.right, root.val, max))));
        }
    }

}
