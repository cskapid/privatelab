using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestPad.String
{
    public class Exercises
    {
        private class QItem
        {
            public string Word { get; set; }
            public int Distance { get; set; }
        }

        public IList<IList<string>> FindAllPathsToTargetWord(string source, string target, IList<string> dictionary)
        {
            var paths = new List<IList<string>>();
            Queue<string> queue = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();
            Dictionary<string, string> map = new Dictionary<string, string>();

            queue.Enqueue(source);
            visited.Add(source);
            int? shortestLength = null;

            while (queue.Count > 0)
            {
                var word = queue.Dequeue();
                var wordOptions = GetPossibleOptions(word, dictionary);
                foreach(var option in wordOptions)
                {
                    if (string.CompareOrdinal(option, target) == 0)
                    {
                        var revList = new List<string>();
                        while (word != null)
                        {
                            revList.Add(word);
                            if (shortestLength.HasValue && shortestLength.Value < revList.Count + 1)
                            {
                                break;
                            }
                            word = map.ContainsKey(word) ? map[word] : null;
                        }
                        if (!shortestLength.HasValue || shortestLength.Value >= revList.Count + 1)
                        {
                            var list = new List<string>();
                            for (var i = revList.Count - 1; i >= 0; i--)
                            {
                                list.Add(revList[i]);
                            }
                            list.Add(option);
                            if (!shortestLength.HasValue || shortestLength.Value > list.Count)
                            {
                                paths.Clear();
                                paths.Add(list);
                                shortestLength = list.Count;
                            }
                            else if (shortestLength.GetValueOrDefault() >= list.Count)
                            {
                                paths.Add(list);
                                shortestLength = list.Count;
                            }
                        }
                    }
                    else if (!visited.Contains(option))
                    {
                        queue.Enqueue(option);
                        visited.Add(option);
                        map[option] = word;
                    }
                }
            }

            return paths;
        }

        private IList<string> GetPossibleOptions(string word, IList<string> dictionary)
        {
            var list = new List<string>();
            foreach (var item in dictionary)
            {
                var ret = CheckWord(word, item);
                if (ret == 1)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public int FindLengthToReachTargetWord(string source, string target, IList<string> dictionary)
        {
            if (string.CompareOrdinal(source, target) == 0)
            {
                return 0;
            }

            if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(target) || dictionary == null || dictionary.Count == 0)
            {
                return -1;
            }

            Queue<QItem> queue = new Queue<QItem>();
            queue.Enqueue(new QItem { Word = source, Distance = 0 });
            while (queue.Count > 0)
            {
                var qitem = queue.Dequeue();
                var word = qitem.Word;
                var distance = qitem.Distance+1;

                for (var i = dictionary.Count - 1; i >= 0; i--)
                {
                    var ret = CheckWord(word, dictionary[i]);
                    if (ret == 1)
                    {
                        if (string.CompareOrdinal(target, dictionary[i]) == 0)
                        {
                            return distance;
                        }
                        queue.Enqueue(new QItem { Word = dictionary[i], Distance = distance });
                        dictionary.Remove(dictionary[i]);
                    }
                }
            }

            return 0;
        }
                
        public int CheckWord(string source, string word)
        {
            if (source.Length != word.Length)
            {
                return 0;
            }

            int diff = 0;
            for(var i=0;i<source.Length;i++)
            {
                if (source[i] != word[i]) diff++;
                if (diff > 1)
                {
                    return diff;
                }
            }

            return diff;
        }
        public string NearestPalindromic(string n)
        {
            if (string.IsNullOrWhiteSpace(n))
            {
                return string.Empty;
            }

            var cs = n.ToCharArray();
            if (cs.Length == 1)
            {
                if (n.Equals("0")) return "1";
                cs[0]--;
                return new string(cs);
            }
            if (n.Length > 1 && n[0] == '1' && long.Parse(n.Substring(1)) == 0)
            {
                var s = new System.Text.StringBuilder(n.Length - 1);
                for (var i = 0; i < n.Length - 1; i++)
                {
                    s.Append("9");
                }
                return s.ToString();
            }

            var mid = cs.Length / 2;
            for (var i = 0; i < mid; i++)
            {
                cs[cs.Length - 1 - i] = cs[i];
            }

            var ret = new string(cs);
            if (!ret.Equals(n))
            {
                return ret;
            }

            var res = ret.ToString();
            if ((n.Length % 2) == 0)
            {
                //if (n.Equals("11")) return "9";
                //cs[0]--;
                //cs[1]--;
                //return new string(cs);
                //if (mid == 1)
                //{
                //    return "9";
                //}
                if (n[mid] == '0' && n[mid - 1] == '0')
                {
                    var s = new System.Text.StringBuilder(n.Length - 1);
                    for (var i = 0; i < n.Length - 1; i++)
                    {
                        s.Append("9");
                    }
                    return s.ToString();
                }
                else
                {
                    cs[mid]--;
                    cs[mid - 1]--;
                    ret = new string(cs);
                    if (long.Parse(ret) == 0)
                    {
                        var s = new System.Text.StringBuilder(n.Length - 1);
                        for (var i = 0; i < n.Length - 1; i++)
                        {
                            s.Append("9");
                        }
                        return s.ToString();
                    }
                    else
                        return ret;
                }
            }
            else
            {
                if (n[mid] == '0')
                {
                    var s = new System.Text.StringBuilder(n.Length - 1);
                    for (var i = 0; i < n.Length - 1; i++)
                    {
                        s.Append("9");
                    }
                    return s.ToString();
                }
                //if (n.Equals("101")) return "99";
                //cs[1]--;
                //return new string(cs);
                else
                {
                    cs[mid]--;
                    return new string(cs);
                }
            }

            //return ret;
        }

        public bool IsValid(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }

            Stack<char> stack = new Stack<char>();
            foreach (var c in s)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                    continue;
                }

                if (stack.Count == 0)
                {
                    return false;
                }
                var top = stack.Peek();
                if ((c == ')' && top != '(') || (c == '}' && top != '{') || (c == ']' && top != '['))
                {
                    return false;
                }
                stack.Pop();
            }

            return stack.Count == 0;
        }

        public int LongestValidParentheses(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }
            int n = s.Length, longest = 0;
            Stack<int> st = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                if (s[i] == '(')
                {
                    st.Push(i);
                }
                else
                {
                    if (st.Count > 0)
                    {
                        if (s[st.Peek()] == '(')
                        {
                            st.Pop();
                        }
                        else
                        {
                            st.Push(i);
                        }
                    }
                    else
                    {
                        st.Push(i);
                    }
                }
            }
            if (st.Count == 0)
            {
                longest = n;
            }
            else
            {
                int a = n, b = 0;
                while (st.Count != 0)
                {
                    b = st.Peek(); st.Pop();
                    longest = System.Math.Max(longest, a - b - 1);
                    a = b;
                }
                longest = System.Math.Max(longest, a);
            }
            return longest;
            /*
            Stack<int> stack = new Stack<int>();
            int max=0;
            int left = -1;
            for(int j=0;j<s.Length;j++)
            {
                if(s[j]=='(') 
                {
                    stack.Push(j);            
                }
                else {
                    if (stack.Count == 0) 
                    {
                        left=j;
                    }
                    else{
                        stack.Pop();
                        if(stack.Count == 0)
                        {
                            max=System.Math.Max(max,j-left);
                        }
                        else 
                        {
                            max=System.Math.Max(max,j-stack.Peek());
                        }
                    }
                }
            }
            return max;
            */
            /*
            var lastMaxString = string.Empty;
            var longString = new StringBuilder();
            Stack<char> stack = new Stack<char>();
            foreach (var c in s)
            {
                if (c == '(')
                {
                    stack.Push(c);
                    continue;
                }

                if (stack.Count == 0)
                {
                    if (longString.Length > lastMaxString.Length)
                    {
                        lastMaxString = longString.ToString();
                    }
                    longString.Clear();
                    continue;
                }

                var top = stack.Peek();
                if (top != '(')
                {
                    if (longString.Length > lastMaxString.Length)
                    {
                        lastMaxString = longString.ToString();
                    }
                    longString.Clear();
                    continue;
                }
                top = stack.Pop();
                longString.Insert(0, top);
                longString.Append(c);
            }

            if (longString.Length > lastMaxString.Length)
            {
                lastMaxString = longString.ToString();
            }
            return lastMaxString.Length;
            */
        }

        public IList<string> GenerateParentheses(int n)
        {
            var lists = new List<List<string>>();
            lists.Add(new List<string>() { "" } );

            for (int i = 1; i <= n; ++i)
            {
                var list = new List<string>();

                for (int j = 0; j < i; ++j)
                {
                    foreach (var item1 in lists[j])
                    {
                        foreach(var item2 in lists[i - 1 - j])
                        {
                            var text = new System.Text.StringBuilder();
                            text.AppendFormat("({0}){1}", item1, item2);
                            list.Add(text.ToString());
                        }
                    }
                }

                lists.Add(list);
            }

            return lists[lists.Count - 1];
        }

        public IList<string> GenerateParenthesesRecursive(int n)
        {
            IList<string> list = new List<string>();
            if (n == 0)
            {
                return list;
            }
            GenerateParenthesesRecursive(n, n, string.Empty, list);
            return list;
        }

        public void GenerateParenthesesRecursive(int open, int close, string s, IList<string> list)
        {
            if (open == 0 && close == 0)
            {
                list.Add(s);
            }

            if (open > close)
            {
                return;
            }

            if (open > 0)
            {
                GenerateParenthesesRecursive(open - 1, close, s + "(", list);
            }

            if (close > 0)
            {
                GenerateParenthesesRecursive(open, close - 1, s + ")", list);
            }
        }


        public bool CheckInclusion(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2) || s2.Length < s1.Length)
            {
                return false;
            }

            for (int i = 0; i <= s2.Length - s1.Length; i++)
            {
                var substr = s2.Substring(i, s1.Length);
                if (IsPermutation(s1, substr))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsPermutation(string s1, string s2)
        {
            int?[] charTable = new int?[26];
            foreach (var c in s2)
            {
                charTable[c - 'a'] = charTable[c - 'a'].GetValueOrDefault() + 1;
            }
            foreach (var c in s1)
            {
                if (charTable[c - 'a'].HasValue)
                {
                    charTable[c - 'a'] = charTable[c - 'a'].Value - 1;
                }
            }
            return charTable.FirstOrDefault(v => v.HasValue && v.Value != 0) == null;
        }

        public IList<string> RemoveInvalidParentheses(string s)
        {
            IList<string> res = new List<string>();
            if (string.IsNullOrEmpty(s))
            {
                return res;
            }

            RemoveInvalidParentheses(s, res);
            return res;
        }

        private void RemoveInvalidParentheses(string s, IList<string> res)
        {
 
        }

        public bool IsValidParentheses(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }

            Stack<char> stack = new Stack<char>();
            foreach (var c in s)
            {
                if (c == '(')
                {
                    stack.Push(c);
                    continue;
                }

                if (stack.Count == 0)
                {
                    return false;
                }
                var top = stack.Peek();
                if (c == ')' && top != '(')
                {
                    return false;
                }
                stack.Pop();
            }

            return stack.Count == 0;
        }

        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            IList<string> res = new List<string>();
            if (string.IsNullOrEmpty(s) || wordDict == null || wordDict.Count == 0)
            {
                return res;
            }

            BuildSentence(s, 0, wordDict, new StringBuilder(), res);

            return res;
        }

        private void BuildSentence(string s, int sIndex, IList<string> dictionary, StringBuilder sb, IList<string> res)
        {
            if (sIndex >= s.Length)
            {
                res.Add(sb.ToString(0, sb.Length - 1));
                return;
            }

            for(var i=0;i<dictionary.Count;i++)
            {
                var word = dictionary[i];
                if (s.IndexOf(word, sIndex) == sIndex)
                {
                    int l = sb.Length;
                    sb.AppendFormat("{0} ", word);
                    BuildSentence(s, sIndex + word.Length, dictionary, sb, res);
                    sb.Remove(l, word.Length + 1);
                }
            }
        }

        public IList<string> Permutations(string s)
        {
            IList<string> permutations = new List<string>();
            if (string.IsNullOrEmpty(s))
            {
                return permutations;
            }

            Permutations(s, 0, new StringBuilder(), permutations);

            return permutations;
        }

        private void Permutations(string s, int i, StringBuilder sb, IList<string> perms)
        {
            if (i == s.Length)
            {
                perms.Add(sb.ToString());
                //sb.Clear();
                return;
            }

            for(int j=0;j<=i;j++)
            {
                sb.Insert(j, s[i]);
                //sb.Append(s[i]);
                Permutations(s, i + 1, sb, perms);
                sb.Remove(j, 1);
            }
        }

        /*
        List<List<Integer>> list;

        public List<List<Integer>> permute(int[] nums) {
    
            list = new ArrayList<>();
            ArrayList<Integer> perm = new ArrayList<Integer>();
            backTrack(perm,0,nums);
            return list;
        }

        void backTrack (ArrayList<Integer> perm,int i,int[] nums){
    
            //Permutation completes
            if(i==nums.length){
                list.add(new ArrayList(perm));
                return;
            }
    
            ArrayList<Integer> newPerm = new ArrayList<Integer>(perm);
    
           //Insert elements in the array by increasing index
            for(int j=0;j<=i;j++){
                newPerm.add(j,nums[i]);
                backTrack(newPerm,i+1,nums);
                newPerm.remove(j);
            }
    
        }
        */
    }

    public class Solution
    {
        Dictionary<string, List<string>> map;
        List<IList<string>> results;
        public IList<IList<string>> FindLadders(string start, string end, IList<string> dict)
        {
            results = new List<IList<string>>();
            if (dict.Count == 0)
                return results;

            int min = int.MaxValue;

            Queue<string> queue = new Queue<string>();
            queue.Enqueue(start);

            map = new Dictionary<string, List<string>>();

            Dictionary<string, int> ladder = new Dictionary<string, int>();
            foreach(var item in dict)
                ladder[item] = int.MaxValue;
            ladder[start] = 0;

            //BFS: Dijisktra search
            while (queue.Count > 0)
            {

                string word = queue.Dequeue();

                int step = ladder[word] + 1;//'step' indicates how many steps are needed to travel to one word. 

                if (step > min) break;

                for (int i = 0; i < word.Length; i++)
                {
                    var builder = new StringBuilder(word);
                    for (char ch = 'a'; ch <= 'z'; ch++)
                    {
                        builder[i] = ch;
                        string new_word = builder.ToString();
                        if (ladder.ContainsKey(new_word))
                        {

                            if (step > ladder[new_word])//Check if it is the shortest path to one word.
                                continue;
                            else if (step < ladder[new_word])
                            {
                                queue.Enqueue(new_word);
                                ladder[new_word] = step;
                            }
                            else
                            {
                            }// It is a KEY line. If one word already appeared in one ladder,
                                 // Do not insert the same word inside the queue twice. Otherwise it gets TLE.

                            if (map.ContainsKey(new_word)) //Build adjacent Graph
                                map[new_word].Add(word);
                            else
                            {
                                List<string> list = new List<string>();
                                list.Add(word);
                                map[new_word] = list;
                                //It is possible to write three lines in one:
                                //map.put(new_word,new LinkedList<string>(Arrays.asList(new string[]{word})));
                                //Which one is better?
                            }

                            if (string.CompareOrdinal(new_word, end) == 0)
                                min = step;

                        }//End if dict contains new_word
                    }//End:Iteration from 'a' to 'z'
                }//End:Iteration from the first to the last
            }//End While

            //BackTracking
            List<string> result = new List<string>();
            BackTrace(end, start, result);

            return results;
        }
        private void BackTrace(string word, string start, List<string> list)
        {
            if (string.CompareOrdinal(word, start) == 0)
            {
                list.Insert(0, start);
                results.Add(new List<string>(list));
                list.RemoveAt(0);
                return;
            }
            list.Insert(0, word);
            if (map.ContainsKey(word) && map[word] != null)
                foreach (var item in map[word])
                    BackTrace(item, start, list);
            list.RemoveAt(0);
        }
    }
}
