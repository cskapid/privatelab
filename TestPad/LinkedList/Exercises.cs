using System.Collections.Generic;
using ListNode = TestPad.LinkedList.Node;

namespace TestPad.LinkedList
{
    public class Exercises
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (k <= 1 || head == null || head.next == null)
            {
                return head;
            }

            var start = head;
            var current = start;
            ListNode first = null;
            while (current != null)
            {
                var pre = new ListNode(-1);
                pre.next = current;
                var node = pre;
                int n = k;
                while (node != null && n > 0)
                {
                    node = node.next;
                    n--;
                }
                if (node == null)
                {
                    return start;
                }
                if (first != null)
                {
                    first.next = node;
                }
                var kthNode = node.next;
                first = current;
                while (current != kthNode)
                {
                    var next = current.next;
                    current.next = node;
                    node = current;
                    current = next;
                }
                first.next = current;
                if (start == head)
                {
                    start = node;
                }
            }

            return start;
        }

        /*public Node ReverseKNodesInList(Node head, int k)
        {
            if (head == null || head.next == null || k < 2) return head;

            Node dummy = new Node();
            dummy.next = head;

            Node tail = dummy, prev = dummy, temp;
            int count;
            while (true)
            {
                count = k;
                while (count > 0 && tail != null)
                {
                    count--;
                    tail = tail.next;
                }
                if (tail == null) break;//Has reached the end


                head = prev.next;//for next cycle
                                 // prev-->temp-->...--->....--->tail-->....
                                 // Delete @temp and insert to the next position of @tail
                                 // prev-->...-->...-->tail-->head-->...
                                 // Assign @temp to the next node of @prev
                                 // prev-->temp-->...-->tail-->...-->...
                                 // Keep doing until @tail is the next node of @prev
                while (prev.next != tail)
                {
                    temp = prev.next;//Assign
                    prev.next = temp.next;//Delete

                    temp.next = tail.next;
                    tail.next = temp;//Insert

                }

                tail = head;
                prev = head;

            }
            return dummy.next;
        }*/

        public Node ReverseList(Node start)
        {
            if (start == null)
            {
                return null;
            }

            Node current = start;
            Node temp = null;
            while (current != null)
            {
                var next = current.next;
                current.next = temp;
                temp = current;
                current = next;
            }
            return temp;
        }

        public Node IncrementByOneInPlace(Node start)
        {
            if (start == null)
            {
                return null;
            }
            Node node = ReverseList(start);
            Node head = node;
            int carry = 1;
            while (node != null)
            {
                if (node.val + carry > 9)
                {
                    node.val = 0;
                    carry = 1;
                }
                else
                {
                    node.val = node.val + carry;
                    carry = 0;
                    break;
                }
                node = node.next;
            }
            Node carryNode = null;
            if (carry == 1)
            {
                carryNode = new Node(carry);
                carryNode.next = ReverseList(head);
            }
            else
            {
                carryNode = ReverseList(head);
            }
            return carryNode;
        }

        public Node IncrementByOneWithStack(Node start)
        {
            if (start == null)
            {
                return null;
            }
            Node node = start;
            var stack = new Stack<Node>();
            while(node != null)
            {
                stack.Push(node);
                node = node.next;
            }
            int carry = 1;
            while (stack.Count > 0)
            {
                var cur = stack.Pop();
                if (cur.val + carry > 9)
                {
                    cur.val = 0;
                    carry = 1;
                }
                else
                {
                    cur.val = cur.val + carry;
                    carry = 0;
                    break;
                }
            }
            Node carryNode = null;
            if (carry == 1)
            {
                carryNode = new Node(carry);
                carryNode.next = start;
            }
            else
            {
                carryNode = start;
            }
            return carryNode;
        }
    }
}
