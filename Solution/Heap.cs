using System;
using System.Collections.Generic;

namespace Solution
{
    public class Heap<T>
    {
        private List<T> data = new List<T>();
        private Func<T, T, bool> comparer;

        public Heap(Func<T, T, bool> comparer)
        {
            this.comparer = comparer;
        }

        public T this[int i]
        {
            get
            {
                return this.data[i];
            }
            set
            {
                this.data[i] = value;
                this.Heapify(i);
            }
        }

        public int FindItem(Func<List<T>, int> visitor)
        {
            return visitor(this.data);
        }

        public void Insert(T o)
        {
            data.Add(o);
            this.Heapify(data.Count - 1);
        }

        public void Delete(T o)
        {
            var index = data.IndexOf(o);
            if (index != -1)
            {
                data[index] = data[data.Count - 1];
                data.RemoveAt(data.Count - 1);
                this.Heapify(index);
            }
        }

        public T Pop()
        {
            if (data.Count < 0)
            {
                throw new Exception("No more data");
            }

            var val = this.data[0];
            data[0] = this.data[data.Count -1];
            data.RemoveAt(data.Count - 1);
            this.Heapify(0);
            return val;
        }

        private void Heapify(int i)
        {
            if (i < 0 || i >= data.Count)
            {
                return;
            }

            var l = (i * 2) + 1;
            var r = (i * 2) + 2;
            var t = i;
            if (l < data.Count && this.comparer(data[l], data[t]))
            {
                t = l;
            }
            if (r < data.Count && this.comparer(data[r], data[t]))
            {
                t = r;
            }
            if (t != i)
            {
                var tmp = data[i];
                data[i] = data[t];
                data[t] = tmp;
                Heapify(t);
            }
            else
            {
                var p = ((i + 1) / 2) - 1;
                if (p >= 0 && p < data.Count)
                {
                    Heapify(p);
                }
            }
        }

        public T Peek()
        {
            if (data.Count > 0)
            {
                return data[0];
            }

            throw new Exception("No more data");
        }

        public int Count
        {
            get { return data.Count; }
        }
    }
}
