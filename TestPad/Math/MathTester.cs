namespace TestPad.Math
{
    public static class MathTester
    {
        public static void RunTests()
        {
            var exercises = new Exercises();
            Utility.WriteLine(exercises.ComplexNumberMultiply("1+2i", "2+3i"));
            Utility.WriteLine("{0} is {1} number", 100000000, exercises.CheckPerfectNumber(100000000) ? "is a perfect": "is not a perfect");
            Utility.WriteLine("{0} is {1} number", 28, exercises.CheckPerfectNumber(28) ? "is a perfect" : "is not a perfect");
            Utility.WriteLine("{0} is {1} number", 328, exercises.CheckPerfectNumber(328) ? "is a perfect" : "is not a perfect");
            /*
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Utility.Write("{0} is happy? ", 100);
            Utility.WriteLine(" {0}", exercises.IsHappyWithSet(100));
            Utility.Write("{0} is happy? ", 200);
            Utility.WriteLine(" {0}", exercises.IsHappyWithSet(200));
            Utility.Write("{0} is happy? ", 19);
            Utility.WriteLine(" {0}", exercises.IsHappyWithSet(19));
            Utility.Write("{0} is happy? ", 681);
            Utility.WriteLine("{0}", exercises.IsHappyWithSet(681));
            Utility.Write("{0} is happy? ", 123);
            Utility.WriteLine(" {0}", exercises.IsHappyWithSet(123));
            sw.Stop();
            Utility.WriteLine("Elapsed time: {0}ms", sw.ElapsedMilliseconds);
            sw.Reset();

            sw.Start();
            Utility.Write("{0} is happy? ", 100);
            Utility.WriteLine(" {0}", exercises.IsHappy(100));
            Utility.Write("{0} is happy? ", 200);
            Utility.WriteLine(" {0}", exercises.IsHappy(200));
            Utility.Write("{0} is happy? ", 19);
            Utility.WriteLine(" {0}", exercises.IsHappy(19));
            Utility.Write("{0} is happy? ", 681);
            Utility.WriteLine("{0}", exercises.IsHappy(681));
            Utility.Write("{0} is happy? ", 123);
            Utility.WriteLine(" {0}", exercises.IsHappy(123));
            sw.Stop();
            Utility.WriteLine("Elapsed time: {0}ms", sw.ElapsedMilliseconds);
            sw.Reset();
            */
        }
    }

}
