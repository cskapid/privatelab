from datetime import *

class Solution():
    def nextClosesTime(self, time):
        digits = set(time)
        while(True):
            time = (datetime.strptime(time, '%H:%M') + timedelta(minutes=1)).strftime('%H:%M')
            s = set(time)
            if (s <= digits):
                return time

sln = Solution()
t = sln.nextClosesTime("23:59")
print(t);