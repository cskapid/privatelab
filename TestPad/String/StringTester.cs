using System.Linq;

namespace TestPad.String
{
    public static class StringTester
    {
        public static void RunTests()
        {
            var exercises = new Exercises();
            var inputArr = new string[] { "()())()", "(a)())()", ")(" };
            foreach (var testStr in inputArr)
            {
                Utility.WriteLine("------------------------");
                Utility.WriteLine("Input: {0}", testStr);
                Utility.WriteLine("------------------------");
                var res = exercises.RemoveInvalidParentheses(testStr);
                Utility.WriteLine("Output: {0}", string.Join(", ", res.ToArray()));
            }
    
            /*
            //var s = "catsanddog";
            //var dict = new List<string> {"cat", "cats", "and", "sand", "dog" };
            var s = "bb";
            var dict = new List<string> { "a", "b", "bbb", "bbbb" };
            var res = exercises.WordBreak(s, dict);
            foreach (var item in res)
            {
                Utility.WriteLine(item);
            }
            */
            /*
            var s = "abc";// "chari";
            Utility.WriteLine("Input: {0}", s);
            var perms = exercises.Permutations(s);
            Utility.WriteLine("Output: {0}", perms.Count);
            foreach (var item in perms)
            {
                Utility.WriteLine(item);
            }
            */
            /*
            var strList = new string[] { "()())()", "(a)())()", ")(" };
            foreach(var s in strList)
            {
                Utility.WriteLine("Input: {0}", s);
                var o = exercises.RemoveInvalidParentheses(s);
                Utility.WriteLine("Output: {0}", o);
                Utility.WriteLine(string.Empty);
            }
            */
            /*
            var s1 = "hello";// "ab";
            var s2 = "ooolleoooleh";// "eidbaooo";
            Utility.WriteLine(s2);
            Utility.WriteLine(s1);
            Utility.WriteLine("IsPermutation: {0}", exercises.CheckInclusion(s1, s2));
            */
            /*
            var testValues = new string[] { "()", "(()", "()()()()(()(", ")()())", "((())(()(()" };
            foreach (var item in testValues)
            {
                Utility.WriteLine("LongestValidParentheses of {0} is {1}", item, exercises.LongestValidParentheses(item));
            }
            */
            /*
            //exercises.PrintParentheses(3);
            var list = exercises.GenerateParentheses(3);
            foreach(var item in list)
            {
                Utility.WriteLine(item);
            }
            */
            /*
            Utility.WriteLine("NearestPalindromic of {0} is {1}", 1, exercises.NearestPalindromic("1"));
            Utility.WriteLine("NearestPalindromic of {0} is {1}", 10, exercises.NearestPalindromic("10"));
            Utility.WriteLine("NearestPalindromic of {0} is {1}", 100, exercises.NearestPalindromic("100"));
            Utility.WriteLine("NearestPalindromic of {0} is {1}", 1000, exercises.NearestPalindromic("1000"));
            Utility.WriteLine("NearestPalindromic of {0} is {1}", 100000, exercises.NearestPalindromic("100000"));
            Utility.WriteLine("NearestPalindromic of {0} is {1}", 11, exercises.NearestPalindromic("11"));
            Utility.WriteLine("NearestPalindromic of {0} is {1}", 0, exercises.NearestPalindromic("0"));
            Utility.WriteLine("NearestPalindromic of {0} is {1}", 87654, exercises.NearestPalindromic("87654"));
            Utility.WriteLine("NearestPalindromic of {0} is {1}", 876, exercises.NearestPalindromic("876"));
            Utility.WriteLine("NearestPalindromic of {0} is {1}", 101, exercises.NearestPalindromic("101"));
            Utility.WriteLine("NearestPalindromic of {0} is {1}", 1001, exercises.NearestPalindromic("1001"));
            Utility.WriteLine("NearestPalindromic of {0} is {1}", 88, exercises.NearestPalindromic("88"));
            Utility.WriteLine("NearestPalindromic of {0} is {1}", 888, exercises.NearestPalindromic("888"));
            */
            /*
            var exercises = new Exercises();
            //Utility.WriteLine("Shortest length {0}", exercises.FindLengthToReachTargetWord("dog", "cat", new List<string> { "dot", "pot", "doe", "fog", "dag", "dat", "dut", "cut", "cat" }));
            //Utility.WriteLine("Shortest length {0}", exercises.FindLengthToReachTargetWord("TOON", "PLEA", new List<string> { "POON", "PLEE", "SAME", "POIE", "PLEA", "PLIE", "POIN" }));
            var sln = new Solution();
            IList<IList<string>> paths;
            //paths = exercises.FindAllPathsToTargetWord("red", "tax", new List<string> { "ted", "tex", "red", "tax", "tad", "den", "rex", "pee" });
            paths = sln.FindLadders("red", "tax", new List<string> { "ted", "tex", "red", "tax", "tad", "den", "rex", "pee" });
            foreach (var path in paths)
            {
                Utility.WriteLine(string.Empty);
                foreach (var word in path)
                {
                    Utility.WriteLine(word);
                }
            }
            */
            /*
            paths = exercises.FindAllPathsToTargetWord("dog", "cat", new List<string> { "dot", "pot", "doe", "fog", "dag", "dat", "dut", "cut", "cat" });
            foreach(var path in paths)
            {
                Utility.WriteLine(string.Empty);
                foreach (var word in path)
                {
                    Utility.WriteLine(word);
                }
            }
            paths = exercises.FindAllPathsToTargetWord("TOON", "PLEA", new List<string> { "POON", "PLEE", "SAME", "POIE", "PLEA", "PLIE", "POIN" });
            foreach (var path in paths)
            {
                Utility.WriteLine(string.Empty);
                foreach (var word in path)
                {
                    Utility.WriteLine(word);
                }
            }
            paths = exercises.FindAllPathsToTargetWord("a", "c", new List<string> { "a", "b", "c" });
            foreach (var path in paths)
            {
                Utility.WriteLine(string.Empty);
                foreach (var word in path)
                {
                    Utility.WriteLine(word);
                }
            }
            paths = exercises.FindAllPathsToTargetWord("hit", "cog", new List<string> { "hot", "dot", "dog", "lot", "log", "cog" });
            foreach (var path in paths)
            {
                Utility.WriteLine(string.Empty);
                foreach (var word in path)
                {
                    Utility.WriteLine(word);
                }
            }
            paths = exercises.FindAllPathsToTargetWord("hot", "dog", new List<string> { "hot", "dog", "cog", "pot", "dot" });
            foreach (var path in paths)
            {
                Utility.WriteLine(string.Empty);
                foreach (var word in path)
                {
                    Utility.WriteLine(word);
                }
            }
            */
        }
    }
}


