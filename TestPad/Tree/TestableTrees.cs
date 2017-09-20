using System.Collections.Generic;

namespace TestPad.Tree
{
    public static class TestableTrees
    {
        public static IList<TreeNode> BuildTestTrees()
        {
            var treeBuilder = new TreeBuilder();
            var trees = new List<TreeNode>();
            trees.Add(treeBuilder.BuildTree(new int?[] { }));
            trees.Add(treeBuilder.BuildTree(new int?[] { 10 }));
            trees.Add(treeBuilder.BuildTree(new int?[] { 10, 5, 20 }));
            trees.Add(treeBuilder.BuildTree(new int?[] { 10, null, 5 }));
            trees.Add(treeBuilder.BuildTree(new int?[] { 10, 5, 15, null, null, 6, 20 }));
            trees.Add(treeBuilder.BuildTree(new int?[] { 10, null, 5, null, 15, null, 20 }));
            trees.Add(treeBuilder.BuildTree(new int?[] { 2, 3, 4, 5 }));
            trees.Add(treeBuilder.BuildTree(new int?[] { 123, 34, 123, 345, 21 }));
            trees.Add(treeBuilder.BuildTree(new int?[] { 50, 25, 75, 13, 37, 63, 87, 6, 19, 31, 43, 57, 70, 80, 94 }));
            return trees;
        }
    }
}
