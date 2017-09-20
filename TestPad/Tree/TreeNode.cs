using System;

namespace TestPad.Tree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode next;

        public TreeNode() { }
        public TreeNode(int x) { val = x; }

        public void Traverse(Action<TreeNode> traversor)
        {
            traversor(this);
        }

        public bool Validate(Func<TreeNode, bool> validator)
        {
            return validator(this);
        }

        public TreeNode Convert(Func<TreeNode, Func<TreeNode, bool>, TreeNode> convertor, Func<TreeNode, bool> validator)
        {
            return convertor(this, validator);
        }

        public void Print(Action<TreeNode> printer)
        {
            printer(this);
        }

        public int GetDiameter()
        {
            return GetDiameter(this)[1];
        }

        public int[] GetDiameter(TreeNode root)
        {
            int[] data = { 0, 0 };

            if (root == null)
            {
                return data;
            }
            int[] left = GetDiameter(root.left);
            int[] right = GetDiameter(root.right);

            int h = System.Math.Max(left[0], right[0]) + 1;
            int ld = left[1];
            int rd = right[1];
            int td = left[0] + right[0];
            int d = System.Math.Max(ld, System.Math.Max(rd, td));

            data[0] = h;
            data[1] = d;
            return data;
        }

        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null || t == null)
            {
                return false;
            }
            if (s.val == t.val && AreTheySame(s, t))
            {
                return true;
            }
            return IsSubtree(s.left, t) || IsSubtree(s.right, t);
        }

        private bool AreTheySame(TreeNode s, TreeNode t)
        {
            if (s == null && t == null)
            {
                return true;
            }
            if (s == null || t == null || s.val != t.val)
            {
                return false;
            }
            return AreTheySame(s.left, t.left) && AreTheySame(s.right, t.right);
        }
    }
}
