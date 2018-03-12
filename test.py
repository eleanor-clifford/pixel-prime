with open("possiblePrimes.txt") as primeFile, open("perfectNumber.txt") as perfectFile:
	diff = [(i,a,b) for i,(a,b) in enumerate(zip(primeFile.readline(),perfectFile.readline())) if a != b]
print(len(diff))
