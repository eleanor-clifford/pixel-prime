#!/bin/env python3
WIDTH = int(input("File width? "))
HEIGHT = int(input("Picture Height? "))
#WIDTH, HEIGHT = 126,71
outputFile = open("perfectNumber.txt","w")
ORDER = [0,8,6,9,4,5,2,3,1,7]
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
    float = i * (10/max(b))
    if float < 0.5: new.append(ORDER[0])
    else: new.append(ORDER[round(float)-1])
output = 0
for i,digit in enumerate(new[::-1]):
    output += digit*(10**i)
print(output,file=outputFile)
