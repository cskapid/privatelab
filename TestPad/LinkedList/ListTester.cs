namespace TestPad.LinkedList
{
    public static class ListTester
    {
        public static void RunTests()
        {
            var nodes = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var exercises = new Exercises();
            var printer = new ListPrinter();
            var builder = new ListBuilder();
            var list = builder.BuildList(nodes);
            list.Print(printer.PrintToConsole);
            Utility.WriteLine(string.Empty);
            var temp = exercises.ReverseList(list);
            //var temp = exercises.ReverseKNodesInList(list, 5);
            temp.Print(printer.PrintToConsole);
            Utility.WriteLine(string.Empty);
            for (var i = 1; i <= 10; i++)
            {
                list = builder.BuildList(nodes);
                temp = exercises.ReverseKGroup(list, i);
                temp.Print(printer.PrintToConsole);
                Utility.WriteLine(string.Empty);
            }
            //var temp = exercises.ReverseKNodesInList(list, 5);
            //temp.Print(printer.PrintToConsole);
            Utility.WriteLine(string.Empty);
            /*
            Stopwatch sw = new Stopwatch();
            {
                var lists = TestableLists.BuildTestLists();
                foreach (var list in lists)
                {
                    if (list != null)
                    {
                        list.Print(printer.PrintToConsole);
                        Utility.WriteLine(string.Empty);
                        sw.Restart();
                        //var temp = exercises.ReverseList(list);
                        var temp = exercises.IncrementByOneWithStack(list);
                        temp.Print(printer.PrintToConsole);
                        sw.Stop();
                        Utility.WriteLine(string.Empty);
                        Utility.WriteLine("With stack, time consumed: {0}ticks", sw.ElapsedTicks);
                        Utility.WriteLine(string.Empty);
                    }
                }
            }
            {
                var lists = TestableLists.BuildTestLists();
                foreach (var list in lists)
                {
                    if (list != null)
                    {
                        list.Print(printer.PrintToConsole);
                        Utility.WriteLine(string.Empty);
                        sw.Restart();
                        var temp = exercises.IncrementByOneInPlace(list);
                        temp.Print(printer.PrintToConsole);
                        sw.Stop();
                        Utility.WriteLine(string.Empty);
                        Utility.WriteLine("In place, time consumed: {0}ticks", sw.ElapsedTicks);
                        Utility.WriteLine(string.Empty);
                    }
                }
            }
            */
        }
    }
}
