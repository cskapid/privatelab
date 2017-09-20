namespace TestPad.Misc
{
    public class MiscTester
    {
        public static void RunTests()
        {
            var exercises = new Exercises();
            int[] p1 = new int[] { 1, 0 };
            int[] p2 = new int[] { -1, 0 };
            int[] p3 = new int[] { 0, 1 };
            int[] p4 = new int[] { 0, -1 };

            Utility.WriteLine(exercises.ValidSquare(p1, p2, p3, p4));

            /*
            var all1 = new AllInOne();
            //all1.Increment("hello");
            //all1.Increment("hello");
            //all1.Print();
            //all1.Increment("leet");
            //all1.Print();

            //all1.Decrement("hello");
            //all1.Print();

            //all1.Increment("a");
            //all1.Increment("b");
            //all1.Increment("b");
            //all1.Increment("c");
            //all1.Increment("c");
            //all1.Increment("c");
            //all1.Decrement("b");
            //all1.Decrement("b");
            //all1.Print();
            //all1.Decrement("a");
            //all1.Print();

            all1["C"] = 3;
            all1["B"] = 2;
            all1["D"] = 4;
            all1["E"] = 5;
            all1["A"] = 1;
            all1.Print();
            all1.Inc("D");
            all1.Dec("B");
            all1.Print();
            all1.Inc("D");
            all1.Dec("B");
            all1.Print();
            all1.Delete(all1.MaxKey);
            all1.Print();
            all1.Delete(all1.MinKey);
            all1.Print();
            */
        }
    }
}
