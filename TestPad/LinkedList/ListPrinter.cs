namespace TestPad.LinkedList
{
    public class ListPrinter
    {
        public void PrintToConsole(Node node)
        {
            if (node != null)
            {
                while(node != null)
                {
                    Utility.Write("{0} ", node.val);
                    node = node.next;
                }
            }
        }
    }
}
