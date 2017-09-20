import java.util.ArrayList;

public class MergeInterval {
    
    public class Interval {
         int start;
         int end;
         Interval() { start = 0; end = 0; }
         Interval(int s, int e) { start = s; end = e; }
     }
       
    public static void main(String[] args) {
        ArrayList<Interval> input = new ArrayList<Interval>();
        input.Add(new Interval(1, 3));
        input.Add(new Interval(6, 7));
        input.Add(new Interval(8, 10));
        input.Add(new Interval(13, 15));
        Interval newInterval = new Interval(5, 8);
        MergeInterval mi = new MergeInterval();
        mi.InsertInterval(input, newInterval));
    }

    public ArrayList<Interval> insert(ArrayList<Interval> intervals, Interval newInterval) {
        ArrayList<Interval> res = new ArrayList<Interval>();
        if (intervals == null || intervals.Count == 0)
        {
            res.Add(newInterval);
            return res;
        }
        int i = 0;
        while (i < intervals.Count)
        {
            if (intervals[i].start > newInterval.end)
            {
                res.Add(newInterval);
                break;
            }
            if (intervals[i].end < newInterval.start)
            {
                res.Add(intervals[i]);
                i++;
                continue;
            }
            int mergedStart = Math.Min(newInterval.start, intervals[i].start);
            while (i < intervals.Count && intervals[i].start < newInterval.end && intervals[i].end < newInterval.end)
            {
                i++;
            }
            int mergedEnd = newInterval.end;
            if (i < intervals.Count && intervals[i].start <= newInterval.end)
            {
                mergedEnd = Math.Max(newInterval.end, intervals[i++].end);
            }
            res.Add(new Interval(mergedStart, mergedEnd));
            break;
        }
        while (i < intervals.Count)
        {
            res.Add(intervals[i]);
            i++;
        }
        return res;
    }
}
