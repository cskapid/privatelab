using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class Misc
    {
        public void ContestValidator()
        {
            #region GetAllCombinations
            var combinator = new Combinator();
            var result = combinator.GetAllCombinations("12", 2);
            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
            #endregion //GetAllCombinations
        }

        private class Combinator
        {
            IList<string> combinations = new List<string>();

            public IEnumerable<string> GetAllCombinations(string str, int length)
            {
                //BuildCombinationsRecursively(str, length);
                BuildCombinationsIteratively(str, length);
                return this.combinations;
            }

            private void BuildCombinationsRecursively(string str, int length, string prefix = "")
            {
                if (length <= 0)
                {
                    //Console.WriteLine(prefix);
                    this.combinations.Add(prefix);
                    return;
                }

                for (var i = 0; i < str.Length; i++)
                {
                    var newPrefix = prefix + str[i];
                    BuildCombinationsRecursively(str, length - 1, newPrefix);
                }
            }

            private void BuildCombinationsIteratively(string str, int length)
            {
                int[] pos = new int[length];
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < length; i++)
                {
                    sb.Append(str[0]);
                }

                while (true)
                {
                    // output the current combination:
                    this.combinations.Add(sb.ToString());

                    // move on to the next combination:
                    int place = length - 1;
                    while (place >= 0)
                    {
                        if (++pos[place] == str.Length)
                        {
                            // overflow, reset to zero
                            pos[place] = 0;
                            sb[place] = str[0];
                            place--; // and carry across to the next value
                        }
                        else
                        {
                            // no overflow, just set the char value and we're done
                            sb[place] = str[pos[place]];
                            break;
                        }
                    }
                    if (place < 0)
                        break;  // overflowed the last position, no more combinations
                }
            }
        }
    }
}
