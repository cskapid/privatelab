using System;
using System.Collections.Generic;
using System.Linq;

namespace TestPad.Misc
{
    public class Exercises
    {
        public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            if (p1 == null || p1.Length != 2 || p2 == null || p2.Length != 2 || p3 == null || p3.Length != 2 || p4 == null || p4.Length != 2)
            {
                return false;
            }

            int?[] lengths = new int?[2];
            int sides = 0;
            int diags = 0;
            AnalyzePoints(p1, p2, ref sides, ref diags, ref lengths);
            AnalyzePoints(p1, p3, ref sides, ref diags, ref lengths);
            AnalyzePoints(p1, p4, ref sides, ref diags, ref lengths);
            AnalyzePoints(p3, p2, ref sides, ref diags, ref lengths);
            AnalyzePoints(p4, p2, ref sides, ref diags, ref lengths);
            AnalyzePoints(p3, p4, ref sides, ref diags, ref lengths);

            return (((sides + diags) == 6) && sides % 2 == 0 && diags % 2 == 0);
        }

        private void AnalyzePoints(int[] p1, int[] p2, ref int sides, ref int diags, ref int?[] lengths)
        {
            var length = System.Math.Abs(p1[0] - p2[0]) + System.Math.Abs(p1[1] - p2[1]);
            if (length == 0)
            {
                return;
            }
            if (!lengths[0].HasValue)
            {
                lengths[0] = length;
                sides++;
            }
            else if (lengths[0] == length)
            {
                sides++;
            }
            else if (!lengths[1].HasValue)
            {
                lengths[1] = length;
                diags++;
            }
            else if(lengths[1] == length)
            {
                diags++;
            }
        }
    }

    public class AllInOne
    {
        private IDictionary<string, int> dictionary;
        private Heap maxHeap;
        private Heap minHeap;

        public AllInOne()
        {
            this.dictionary = new Dictionary<string, int>();
            this.maxHeap = new Misc.AllInOne.Heap((k1, k2) => { return this.dictionary[k1] < this.dictionary[k2]; });
            this.minHeap = new Misc.AllInOne.Heap((k1, k2) => { return this.dictionary[k1] > this.dictionary[k2]; });
        }

        public int this[string key]
        {
            get
            {
                return this.dictionary[key];
            }
            set
            {
                SetUpdateValue(key, value);
            }
        }

        public string MinKey
        {
            get
            {
                return this.minHeap.Peek();
            }
        }

        public string MaxKey
        {
            get
            {
                return this.maxHeap.Peek();
            }
        }

        private void SetUpdateValue(string key, int value)
        {
            this.dictionary[key] = value;
            this.maxHeap.Insert(key);
            this.minHeap.Insert(key);
        }

        public void Inc(string key)
        {
            var value = 0;
            if (!this.dictionary.TryGetValue(key, out value))
            {
                value = 1;
            }
            else
            {
                ++value;             
            }
            this[key] = value;
        }

        public void Dec(string key)
        {
            if (this.dictionary.ContainsKey(key))
            {
                var value = this.dictionary[key];
                if (value == 1)
                {
                    this.Delete(key);
                }
                else
                {
                    this[key] = --value;
                }
            }
        }

        public void Delete(string key)
        {
            this.maxHeap.Delete(key);
            this.minHeap.Delete(key);
            this.dictionary.Remove(key);
        }

        public void Print()
        {
            Utility.WriteLine(string.Empty);
            foreach(var item in this.dictionary)
            {
                Utility.WriteLine("{0}: {1}", item.Key, item.Value);
            }
            Utility.WriteLine("MaxKey: {0}, MinKey: {1}", this.MaxKey, this.MinKey);
        }

        private class Heap
        {
            private List<string> data = new List<string>();
            private Func<string, string, bool> comparer;

            public Heap(Func<string, string, bool> comparer)
            {
                this.comparer = comparer;
            }

            public void Insert(string o)
            {
                var index = data.IndexOf(o);
                if (index == -1)
                {
                    data.Add(o);
                    index = data.Count - 1;
                }

                this.Heapify(index);
            }

            public void Delete(string o)
            {
                var index = data.IndexOf(o);
                if (index != -1)
                {
                    data.RemoveAt(index);
                    this.Heapify(index);
                }
            }

            public string Pop()
            {
                if (data.Count < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                var val = this.data.First();
                data.RemoveAt(0);
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
                if (l < data.Count && this.comparer(data[t], data[l]))
                {
                    t = l;
                }
                if (r < data.Count && this.comparer(data[t], data[r]))
                {
                    t = r;
                }
                if (t != i)
                {
                    var tmp = data[i];
                    data[i] = data[t];
                    data[t] = tmp;
                }

                var p = ((i + 1) / 2) - 1;
                if (p >= 0 && p < data.Count)
                {
                    Heapify(p);
                }
            }

            public string Peek()
            {
                if (data.Count > 0)
                {
                    return data[0];
                }

                return string.Empty;
            }

            public int Count
            {
                get { return data.Count; }
            }
        }
    }
}
