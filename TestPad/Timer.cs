using System;
using System.Diagnostics;

namespace TestPad
{
    public class Timer
    {
        Stopwatch sw;

        public Timer()
            : this(new Stopwatch())
        {
        }

        public Timer(Stopwatch sw)
        {
            this.sw = sw;
        }

        public TimeSpan TimedAction(Action action)
        {
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

        public Tuple<TimeSpan, T> TimedFunc<T>(Func<T> func)
        {
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
            return new Tuple<TimeSpan, T>(sw.Elapsed, ret);
        }
    }
}
