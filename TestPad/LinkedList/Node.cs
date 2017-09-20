using System;

namespace TestPad.LinkedList
{
    public class Node
    {
        public int val;
        public Node next;

        public Node() { }
        public Node(int i) { val = i;}

        public void Print(Action<Node> printer)
        {
            printer(this);
        }
    }
}
