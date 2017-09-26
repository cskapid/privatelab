import random
import sys
import os

# Single line comment
'''
Multi line comment
'''

print("hello python")

name = "Barry"
print(name)
name = 15
print(name)

# Numbers, Strings, Lists, Tuples, Dictionaries
# + - * / % ** //
print(5+2)
print(5-2)
print(5*2)
print(5/2)
print(5%2)
print(5**2)
print(5//2)

quote = "\"Escapes quote.\""
print(quote)

multilinequote=''' blah hla blah
blah blah blah'''
print(multilinequote)

print("\n" * 5)
print("%s %s %s" %('I like the quote', quote, multilinequote))

print("I don't want new line", end="")
print("newlines")