using System.Collections.Generic;

namespace TestPad.LinkedList
{
    public static class TestableLists
    {
        public static IList<Node> BuildTestLists()
        {
            var builder = new ListBuilder();

            return new List<Node> {
                builder.BuildList(new int[] { 1 }),
                builder.BuildList(new int[] { 1, 2, 3 }),
                builder.BuildList(new int[] { 1, 2, 9 }),
                builder.BuildList(new int[] { 9, 2, 1 }),
                builder.BuildList(new int[] { 9, 9, 9 }),
                builder.BuildList(new int[] { 1, 9, 9, 9 })
            };
        }
    }
}
