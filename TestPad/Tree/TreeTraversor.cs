using System.Collections.Generic;

namespace TestPad.Tree
{

    public class TreeTraversor
    {
        public void LevelTraversal(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            TreeNode current = root;
            TreeNode first = current.left != null ? current.left : current.right;

            while (current != null)
            {
                Utility.Write("{0} ", current.val);

                current = current.next;
                if (current == null)
                {
                    if (first == null)
                    {
                        break;
                    }

                    current = first;
                    var temp = current;
                    if (temp != null)
                    {
                        first = null;
                        while (first == null && temp != null)
                        {
                            if (temp.left != null)
                            {
                                first = temp.left;
                                continue;
                            }
                            if (temp.right != null)
                            {
                                first = temp.right;
                                continue;
                            }
                            temp = temp.next;
                        }
                    }
                }
            }
        }

        public void IterativeInorderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            Stack<TreeNode> nodes = new Stack<TreeNode>();
            TreeNode node = root;

            while (nodes.Count > 0 || node != null)
            {
                while (node != null)
                {
                    nodes.Push(node);
                    node = node.left;
                }
                if (node == null)
                {
                    node = nodes.Pop();
                }
                if (node != null)
                {
                    Utility.Write("{0} ", node.val);
                    node = node.right;
                }
            }
        }

        public void IterativeInorderTraversal2(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            Stack<TreeNode> nodes = new Stack<TreeNode>();
            TreeNode node = root;
            while (node != null)
            {
                nodes.Push(node);
                node = node.left;
            }

            while(nodes.Count > 0)
            {
                node = nodes.Pop();
                Utility.Write("{0} ", node.val);

                if (node.right != null)
                {
                    node = node.right;

                    while (node != null)
                    {
                        nodes.Push(node);
                        node = node.left;
                    }
                }
            }
        }

        public void RecursiveInorderTraversal(TreeNode node)
        {
            if (node.left != null)
            {
                RecursiveInorderTraversal(node.left);
            }
            Utility.Write("{0} ", node.val);
            if (node.right != null)
            {
                RecursiveInorderTraversal(node.right);
            }
        }
    }
}
