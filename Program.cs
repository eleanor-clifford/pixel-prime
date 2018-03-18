using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace PixelPrime
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length > 0 && args[1] == "--test") {
				BigInteger prime;
				String[] primes;
				using (StreamReader sr = new StreamReader("possiblePrimes.txt"))
				{
					String bigint = sr.ReadToEnd();
					primes = bigint.Split('\n');
				}
				for (int p = 0; p < primes.Length; p++) {
					BigInteger.TryParse(primes[p], out prime);
					for (int i = 0; i < 128; i++) {
						if (RabinMiller.isPrime(prime,1)) {
							Console.WriteLine($"Prime {p}, Iteration {i}: Prime");
						} else {
							Console.WriteLine($"Prime {p}: Not Prime");
						}
					}
				}
			} else {
				BigInteger perfect;
				using (StreamReader sr = new StreamReader("perfectNumber.txt"))
				{
					String bigint = sr.ReadToEnd();
					BigInteger.TryParse(bigint, out perfect);
				}
				if (perfect%2==0) perfect++;
				if (perfect%5==0) perfect += 2;
				List<BigInteger> primes = new List<BigInteger>();
				Random rand = new Random();
				int log = (int)BigInteger.Log10(perfect)+1;
				Console.WriteLine("This number has {0} digits",log);
				try { 
					File.Delete("possiblePrimes.txt"); 
				} catch (DirectoryNotFoundException) { } 
				int solutions = 0;
				foreach (BigInteger i in Fluctuate(perfect,max:log/2, repeats:100)) 
				{ 
					
					if (RabinMiller.isPrime(i,1)) 
					{
						if (solutions == 0) File.WriteAllText("possiblePrimes.txt",String.Format("{0}\n",i));
						else File.AppendAllText("possiblePrimes.txt",String.Format("{0}\n",i));	
						Console.WriteLine("Possible prime found");
						solutions++;
					}
				}
			}
		}
		static IEnumerable<BigInteger> Fluctuate(BigInteger number, int max = 5, int repeats = 3)
		{
			Random random = new Random();
			for (int strength = 1; strength <= max; strength++)
			{
				for (int i = 0; i < repeats; i++)
				{
					List<int> swapped = new List<int>();
					BigInteger fluctuated = number;
					for (int j = 0; j < strength; j++) {

						int n = random.Next(0,10);
						int digit = random.Next(0,(int)(BigInteger.Log10(number)+1));
						// Uncomment this to try swapping digits to similar ones.
						/*
						switch (Digit(number,digit)) {
							case 0:
								n = 8; break;
							case 1:
								switch (random.Next(0,2)) {
									case 1:
										n = 7; break;
									case 0: 
										n = 3; break;
								} break;
							case 2:
								switch (random.Next(0,2)) {
									case 1:
										n = 5; break;
									case 0: 
										n = 3; break;
								} break;
							case 3:
								switch (random.Next(0,2)) {
									case 1:
										n = 2; break;
									case 0: 
										n = 1; break;
								} break;
							case 4:
								switch (random.Next(0,2)) {
									case 1:
										n = 5; break;
									case 0: 
										n = 9; break;
								} break;
							case 5:
								switch (random.Next(0,2)) {
									case 1:
										n = 4; break;
									case 0: 
										n = 2; break;
								} break;
							case 6:
								switch (random.Next(0,2)) {
									case 1:
										n = 8; break;
									case 0: 
										n = 9; break;
								} break;
							case 7:
								n = 1; break;
							case 8:
								switch (random.Next(0,2)) {
									case 1:
										n = 0; break;
									case 0: 
										n = 6; break;
								} break;
							case 9:
								switch (random.Next(0,2)) {
									case 1:
										n = 6; break;
									case 0: 
										n = 4; break;
								} break;
						}
						*/
						if (!swapped.Contains(digit))
						{
							int current = Digit(number,digit);
							fluctuated += (n-current)*BigInteger.Pow(new BigInteger(10),digit);
							swapped.Add(digit);
						}
					}
					yield return fluctuated;
				}
			}
		}
		static byte Digit(BigInteger n, int ord) { return (byte)((n / BigInteger.Pow(new BigInteger(10),ord))%10); }
	}
}
