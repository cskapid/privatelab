import sys
import os

def Say(msg, priority):
    if (priority == 1):
        print(msg.title())
    else:
        print(msg.lower())

def PrettyPrint(*msg):
    print(msg, 'is aweslome')


Say('hello world', 1)
Say(priority=1, msg="watever")
PrettyPrint('Python', 'Java', 'C#')

numbers = [1, 3, 6]
nn = map(lambda x: x, numbers)
print(nn)

language = ['P', 'y', 't', 'h', 'o', 'n']
print(language[:-4])