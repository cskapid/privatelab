import java.util.ArrayList;
import java.util.HashMap;

public class AllOne {
    private HashMap<String, Integer> _hashMap;
    private Heap _maxHeap;
    private Heap _minHeap;

    public static void main(String[] args)
    {
        {
            AllOne all1 = new AllOne();
            all1.inc("hello");
            all1.print();
        }
        System.out.println("---------------------------------------------------");
        {
            AllOne all1 = new AllOne();
            all1.inc("hello");
            all1.inc("hello");
            all1.print();
            all1.inc("leet");
            all1.print();
        }
        System.out.println("---------------------------------------------------");
        {
            AllOne all1 = new AllOne();
            all1.dec("hello");
            all1.print();
        }
        System.out.println("---------------------------------------------------");
        {
            AllOne all1 = new AllOne();
            all1.inc("a");
            all1.inc("b");
            all1.inc("b");
            all1.inc("c");
            all1.inc("c");
            all1.inc("c");
            all1.dec("b");
            all1.dec("b");
            all1.print();
            all1.dec("a");
            all1.print();
        }
        */
        System.out.println("---------------------------------------------------");
        {
            AllOne all1 = new AllOne();
            all1.setValue("C", 3);
            all1.setValue("B", 2);
            all1.setValue("D", 4);
            all1.setValue("E", 5);
            all1.setValue("A", 1);
            all1.print();
            all1.inc("D");
            all1.dec("B");
            all1.print();
            all1.inc("D");
            all1.dec("B");
            all1.print();
            all1.remove(all1.getMaxKey());
            all1.print();
            all1.remove(all1.getMinKey());
            all1.print();
        }
    }
    
    public AllOne() {
        _hashMap = new HashMap<String, Integer>();
        _maxHeap = new AllOne.Heap((k1, k2) -> { return _hashMap.get(k1) < _hashMap.get(k2); });
        _minHeap = new AllOne.Heap((k1, k2) -> { return _hashMap.get(k1) > _hashMap.get(k2); });
        // _maxHeap = new AllOne.Heap(new HeapComparer(_hashMap, true));
        // _minHeap = new AllOne.Heap(new HeapComparer(_hashMap, false));
        // _maxHeap = new AllOne.Heap(true, this);
        // _minHeap = new AllOne.Heap(false, this);
    }

    public HashMap<String, Integer> getHashMap()    {
        return _hashMap;
    }

    public Integer getValue(String key) {
        return _hashMap.get(key);
    }

    public void setValue(String key, Integer value) {
        setUpdateValue(key, value);
    }

    public String getMinKey() {
        return _minHeap.Peek();
    }

    public String getMaxKey() {
        return _maxHeap.Peek();
    }

    private void setUpdateValue(String key, Integer value) {
        _hashMap.put(key, value);
        _maxHeap.insert(key);
        _minHeap.insert(key);
    }

    public void inc(String key) {
        Integer value = 1;
        if (_hashMap.containsKey(key)) {
            value = _hashMap.get(key);
            ++value;
        }
        setUpdateValue(key, value);
    }

    public void dec(String key) {
        if (_hashMap.containsKey(key)){
            Integer value = _hashMap.get(key);
            if (value == 1) {
                remove(key);
            }
            else {
                setUpdateValue(key, --value);
            }
        }
    }

    public void remove(String key)  {
        _maxHeap.remove(key);
        _minHeap.remove(key);
        _hashMap.remove(key);
    }

    public void print() {
        System.out.println();
        _hashMap.forEach((k,v) -> {
            System.out.format("%s: %d\n", k, v);
        });
        System.out.format("MaxKey: %s, MinKey: %s\n", getMaxKey(), getMinKey());
    }

    /*
    private class HeapComparer implements ComparerFunc {
        private HashMap<String, Integer> _hashMap;
        private boolean _maxMin;

        public HeapComparer(HashMap<String, Integer> hashMap, boolean maxMin)
        {
            _hashMap = hashMap;
        }

        @Override
        public boolean compare(String k1, String k2)
        {
            if (_maxMin)
            {
                return _hashMap.get(k1) < _hashMap.get(k2);
            }

            return _hashMap.get(k1) > _hashMap.get(k2);
        }
    }
    */
    private class Heap {
        private ArrayList<String> data = new ArrayList<String>();
        private ComparerFunc _comparer;
        // private boolean _maxOrMin;
        // private AllOne _allOne;

        public Heap(ComparerFunc comparer/*boolean maxOrMin, AllOne allOne*/) {
            _comparer = comparer;
            // _maxOrMin = maxOrMin;
            // _allOne = allOne;
        }

        public void insert(String o) {
            Integer i = data.indexOf(o);
            if (i == -1) {
                data.add(o);
                i = data.size() - 1;
            }
            heapify(i);
        }

        public void remove(String o) {
            Integer i = data.indexOf(o);
            if (i != -1) {
                data.remove(o);
                heapify(i);
            }
        }

        public String Pop() {
            if (data.size() > 0) {
                String val = data.get(0);
                data.remove(0);
                heapify(0);
                return val;
            }
        
            return null;
        }

        public void heapify(Integer i) {
            if (i < 0 || i >= data.size())
            {
                return;
            }

            Integer l = (i * 2) + 1;
            Integer r = (i * 2) + 2;
            Integer t = i;
            if (l < data.size() && _comparer.compare(data.get(t), data.get(l)))
            {
                t = l;
            }
            if (r < data.size() && _comparer.compare(data.get(t), data.get(r)))
            {
                t = r;
            }
            if (t != i)
            {
                String tmp = data.get(i);
                data.set(i, data.get(t));
                data.set(t, tmp);
            }
            
            Integer p = ((i + 1) / 2) - 1;
            if (p >= 0 && p < data.size())
            {
                heapify(p);
            }
            /*
            // System.out.println("In heapify");
            for(Integer i=0;i<=data.size()/2;i++)
            {
                Integer l = (i * 2) + 1;
                Integer r = (i * 2) + 2;
                Integer t = i;

                if (l < data.size()) {
                    // System.out.println("In left check");
                    Integer top = _hashMap.get(data.get(t));
                    // System.out.format("Top: %d\n", top);
                    Integer left = _hashMap.get(data.get(l));
                    // System.out.format("Left: %d\n", left);
                    // if ((_maxOrMin && top < left) || (!_maxOrMin && top > left)) {
                    if (_comparer.compare(data.get(t), data.get(l))) {
                        t = l;
                    }
                } 
                if (r < data.size()) {
                    // System.out.println("In right check");
                    Integer top = _hashMap.get(data.get(t));
                    // System.out.format("Top: %d\n", top);
                    Integer right = _hashMap.get(data.get(r));
                    // System.out.format("Right: %d\n", right);
                    // if ((_maxOrMin && top < right) || (!_maxOrMin && top > right)) {
                    if (_comparer.compare(data.get(t), data.get(r))) {
                        t = r;
                    }
                } 
                // {
                //     t = r;
                // }
                if (t != i) {
                    // System.out.println("In swap");
                    String tmp = data.get(i);
                    data.set(i, data.get(t));
                    data.set(t, tmp);

                    Integer c = i;
                    while (c > 0) {
                        // System.out.println("In parent check");
                        Integer p = ((c + 1) / 2) - 1;
                        Integer parent = _hashMap.get(data.get(p));
                        Integer current = _hashMap.get(data.get(c));
                        // System.out.format("Parent: %d\n", parent);
                        // System.out.format("Current: %d\n", current);
                        // if ((p < 0) || !((_maxOrMin && parent < current) || (!_maxOrMin && parent > current))) {
                        if (p < 0 || !_comparer.compare(data.get(p), data.get(c))) {
                            break;
                        }

                        tmp = data.get(p);
                        data.set(p, data.get(c));
                        data.set(c, tmp);
                        c = p;
                    }
                }
            }
            */
        }

        public String Peek() {
            if (data.size() > 0)
            {
                return data.get(0);
            }

            return "";
        }

        public Integer getCount() {
            return data.size();
        }
    }

    @FunctionalInterface
    interface ComparerFunc {
        boolean compare(String k1, String k2);
    }

}
