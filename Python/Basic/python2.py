import sys
import os

list = ['micky', 'minnie', 'donald', 'daisy']
print(list[0])
print(list[1:33])
print(len(list))
#zip(list))

text = "abcdefghijklmnopqrstuvwxyz"
print(len(text))
print(text[10])
print(text[3:5])

tuple = ('iron man', 'captain america', 'black widow', 'black panther', 'ant man')
print(len(tuple))
print(tuple)


set = {'batman', 'superman', 'wonder women', 'batman'}
print(len(set))
print(set)

map = {'batman':'bruce', 'superman':'clark', 'wonder women':'unknown', 'batman':'wayne'}
print(len(map))
print(map)


for k, v in map.items():
    print(k, v)

i = 0
while i < len(tuple):
    print(tuple[i])
    i += 1

