#!/bin/env python3
WIDTH = int(input("File width? "))
HEIGHT = int(input("Picture Height? "))
#WIDTH, HEIGHT = 87,61
outputFile = open("perfectNumber.txt","w")
ORDER = [0,8,6,4,3,2,1,7]
# I calculated (in pixels per 160, in the order above, for Menlo) 81,79,73,67,65,64,63,60,53,49
try:
    with open("input.pgm", "rb") as imageFile:
        f = imageFile.read()
        b = bytearray(f)
except FileNotFoundError: 
    print("Please ensure there is a PGM input file named input.pgm")
    raise SystemExit
b = b[len(b)-(WIDTH*HEIGHT):]
new = []
for i in b:
    linear = int((i * 8)/256)
    new.append(ORDER[linear])
output = 0
for i,digit in enumerate(new[::-1]):
    output += digit*(10**i)
output = str(output)
output = "0"*((WIDTH*HEIGHT)-len(output)) + output
print(output,file=outputFile)
