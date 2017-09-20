using System;

namespace TestPad.Tree
{
    public static class TreeTester
    {
        public static void RunTests()
        {
            var trees = TestableTrees.BuildTestTrees();
            var convertor = new TreeConvertor();
            var validator = new TreeValidator();
            var traversor = new TreeTraversor();
            foreach (var tree in trees)
            { 
                if (tree != null)
                {
                    tree.Print(traversor.IterativeInorderTraversal);
                    Utility.WriteLine(string.Empty);
                    //var convertedTree = tree.Convert(convertor.ConvertBST, validator.IsValidBSTIterative);
                    //var convertedTree = tree.Convert(convertor.PopulateNext, null);
                    //convertedTree.Print(traversor.LevelTraversal);
                    Utility.WriteLine("Diameter: {0}", tree.GetDiameter());
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            /*
            var traversor = new TreeTraversor();
            foreach (var tree in trees)
            {
                if (tree == null)
                {
                    continue;
                }
                tree.Traverse(traversor.IterativeInorderTraversal);
                Utility.WriteLine(string.Empty);
                Console.ReadKey();
                Console.Clear();
            }
            */
            /*
            foreach (var tree in trees)
            {
                if (tree == null)
                {
                    continue;
                }
                tree.Traverse(traversor.RecursiveInorderTraversal);
                Utility.WriteLine(string.Empty);
                Console.ReadKey();
                Console.Clear();
            }
            */
            /*
            var validator = new TreeValidator();
            foreach (var tree in trees)
            {
                if (tree == null)
                {
                    Utility.WriteLine(true);
                    continue;
                }

                var isValid = tree.Validate(validator.IsValidBSTIterative);
                Utility.WriteLine(isValid);
            }
            Console.ReadKey();
            */
            /*
            foreach (var tree in trees)
            {
                if (tree == null)
                {
                    continue;
                }

                var isValid = tree.Validate(validator.IsValidBSTRecursive);
                Utility.WriteLine(isValid);
                Console.ReadKey();
            }
            */
        }
    }
}
