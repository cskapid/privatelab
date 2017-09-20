using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            this.val = x;
            this.next = null;
        }
    }

    public class ListBuilder
    {
        public static ListNode BuildList(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return null;

            ListNode root = new ListNode(numbers[0]);
            var temp = root;
            for(int i=1;i<numbers.Length;i++)
            {
                temp.next = new ListNode(numbers[i]);
                temp = temp.next;
            }
            return root;
        }
    }
}
