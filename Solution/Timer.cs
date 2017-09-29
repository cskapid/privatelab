using System;
using System.Diagnostics;

namespace Solution
{
    public class FuncResult<T>
    {
        public TimeSpan TimeSpan { get; set; }
        public T Result { get; set; }

        public FuncResult(TimeSpan ts, T result)
        {
            this.TimeSpan = ts;
            this.Result = result;
        }
    }

    public static class Timer
    {
        public static TimeSpan TimedAction(Action action)
        {
            Stopwatch sw = new Stopwatch();
            try
            {
                sw.Restart();
                action();
            }
            finally
            {
                sw.Stop();
            }
            return sw.Elapsed;
        }

        public static FuncResult<T> TimedFunc<T>(Func<T> func)
        {
            Stopwatch sw = new Stopwatch();
            var ret = default(T);
            try
            {
                sw.Restart();
                ret = func();
            }
            finally
            {
                sw.Stop();
            }
            return new FuncResult<T>(sw.Elapsed, ret);
        }
    }
}
