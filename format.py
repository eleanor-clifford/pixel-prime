inputFile = open("possiblePrimes.txt","r")
outputFile = open("output.txt","w")
WIDTH = int(input("File width? "))
HEIGHT = int(input("Picture Height? "))
#WIDTH, HEIGHT = 87,61
for prime in inputFile.readlines():
	for row in range(HEIGHT):
		for column in range(WIDTH):
			try:
				print(prime[0],end="",file=outputFile)
			except:
				pass
			prime = prime[1:]
		print(file=outputFile)
	print(file=outputFile)
