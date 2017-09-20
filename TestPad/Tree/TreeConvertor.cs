using System;
using System.Collections.Generic;

namespace TestPad.Tree
{
    public class TreeConvertor
    {
        public TreeNode ConvertBST(TreeNode node, Func<TreeNode, bool> validator)
        {
            if (node == null || !validator(node))
            {
                Utility.WriteLine("Invalid BST tree");
                return node;
            }

            Stack<TreeNode> nodes = new Stack<TreeNode>();
            TreeNode root = node;
            int sum = 0;
            while (nodes.Count > 0 || node != null)
            {
                while (node != null)
                {
                    nodes.Push(node);
                    node = node.right;
                }
                if (node == null)
                {
                    node = nodes.Pop();
                }
                if (node != null)
                {
                    //Utility.Write("{0} ", treeNode.val);
                    sum = sum + node.val;
                    node.val = sum;
                    node = node.left;
                }
            }

            return root;
        }

        public TreeNode PopulateNext(TreeNode root, Func<TreeNode, bool> validator)
        {
            if (root == null)
            {
                return root;
            }

            TreeNode first = null;
            TreeNode last = null;
            TreeNode cur = root;

            while (cur != null)
            {
                while (cur != null)
                { 
                    if (cur.left != null)
                    {
                        if (last != null)
                        {
                            last.next = cur.left;
                        }
                        else
                        {
                            first = cur.left;
                        }
                        last = cur.left;
                    }
                    if (cur.right != null)
                    {
                        if (last != null)
                        {
                            last.next = cur.right;
                        }
                        else
                        {
                            first = cur.right;
                        }
                        last = cur.right;
                    }

                    cur = cur.next;
                }

                cur = first;
                first = null;
                last = null;
            }

            return root;
        }
    }
}
