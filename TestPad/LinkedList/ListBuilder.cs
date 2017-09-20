namespace TestPad.LinkedList
{
    public class ListBuilder
    {
        public Node BuildList(int[] items)
        {
            if (items == null || items.Length == 0) return null;

            Node root = new Node(items[0]);
            Node node = root;
            for(int i=1;i<items.Length;i++)
            {
                node.next = new Node(items[i]);
                node = node.next;
            }

            return root;
        }
    }
}
