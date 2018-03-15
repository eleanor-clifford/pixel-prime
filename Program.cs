﻿using System;
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
			//int width = Convert.ToInt32(Console.ReadLine());
			//int height = Convert.ToInt32(Console.ReadLine());
			//Python.PgmToNumber();
			
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
			try { File.Delete("possiblePrimes.txt"); }
			catch (DirectoryNotFoundException) { } 
			int solutions = 0;
			/*foreach (BigInteger i in Fluctuate(perfect,max:log/2, repeats:100)) 
			{ 
				
				if (RabinMiller.isPrime(i,1)) 
				{
					if (solutions == 0) File.WriteAllText("possiblePrimes.txt",String.Format("{0}\n",i));
					else File.AppendAllText("possiblePrimes.txt",String.Format("{0}\n",i));

					Console.WriteLine("Possible prime found");
					solutions++;
				}
			}*/
			BigInteger prime;
			BigInteger.TryParse("777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777777877777066666666668777777777777770077770770007700000070000077777777777777777777777777777777746666666666666667777777777770007700770707777007770777777777777777777777777777777777777770000000000000007777777777770707707700700777077770007777777777777777777777777777777777770777777777777707777777777700700707707770777077777700177777777777777777777777777777777770777777777777707777777777707770007000000770077777776077777777777777777777777777777777770777777777777707777777777007770077077770070077000000777777777777777777777777777777777770777777777777707777777777777777777777777777777777777777777777777777777777777777777777770000000000000007777777777777777777777777777777777777777777777777773777777777777777773700000000000000007777777777777777777777777777777777777777777777777777777777777777777777766666666666666666777111111111111111111111111111111111111111111111111111111111111111116666666666666666666611111111111111111111111111111111111111111111111111111111111111111116666666666666666666661111111111111111111111111111111111111111111111111111111111111111144484444444444444444466111111111111111111111111111111111111111111111111111111111111111114444444444444444444411111111111111111111111111111111111111111111111111111111111111111114444444444444444444411111111111111111111111111111111111111111111111111111111111111111144444444444444444444444111111111111111111191111111111111111111111111111111111111111111146888888888888888888841611111111111111111111111111111111000000011111111111111111111111111888888888888888888611111111111111111111111111111111008000000000011111111111111111111111866666666666666688111111111111111111111111111111110000000000000000111111111111111111111666666666666666666611111111111111111111111111111800000000000000000811111111111111111111666666666666666666111111111111111111111111111110000000000000000000081111111111111111111166666666666666663111111111111111111111111111180000000000000040000000111111111111111111166666666666666661111111111111111111111111111800000000000000001000000811111111111111111116666666666666611111111111111111111111111111800000000000000000000000001111111111111111116666666666666611111222222222222222222222220000000000000000000000000002222222222222222222888444444488222222222222222222222222222220000000000000000000000000000222222222222222222888444444488222222222222222222222222222200000000000000000000000000000222222222222222222888444444488222222222222222222222222222200000000000000000000000000000222222222222222222888444444488222222222222222222222222222200000000000000000000000000000822222222222222222888444444488222222222222222222222222222200000000000000000000000000000822222222222222222888444444488222222222222222222222222222000000000000000000000000000000822222222232222222888444444488222222222222222222222222222000000000000000000000000000000822222222222222222888444444488222222222222222222222222222850000000000000000000000000040822222622222222222888444444488222222222222222222222222222280000000000000000000000000000822222222222222222888444444488222222322222222222222222222280000000000000000000000000000822222222222222222888444444488222222222222222222222222222280000000000000000000000000000222222222222222222888444444488222222222222222222222222222280000000000000000000000000000222222222222222222888444444488222222222222222222222222222220000000000000000000000000000222222222222222222888444444488222222222222222222222222222220000000000000000000000000002222222222222222222888444444488222222444444444444444444444444444444444444444444444444444444444444444444444888444444488444444444444444444444444444444444444444044444444444444444444444444444444444888444444488444444444446444444444444444444444444444044444444444444444444444444444444444888444444488444444444444444444444444444444444444444044444444444444444444444444444444484888444444488444444444444444444444444444444444444444044444444444444444444444444444444444888444444488444444444444444444444444444444444444444044444444444444444444444444444444444888444444488444444444444444444444444444444444444444044444444444444444444444444444444444888444444488444444444444444444444444444444444444440004444444444444444444444444444444444888444444488447444444444444444444444444444444444400000444444444444444444444444444444444888444444488444444444444444444444444444444444444000000044444444444444444444444444444444888444444488444444000044444444444444444444444444044044044444444444444444484444444400004888444444488444444444400000000004444444444400000000000000000444444444440000000000044444888444444488444444444444400400000000000000004440006000004440000000000000000400444444444888444444488444444444440000044444444000000000000000000000000000000044444444000044444444888444444488444444444444000044444444000004000000000000000000040000044444444000044444444888444444488444444444444400044444444000044444440000000084444444000044444444000444444444888444444488444444444444444444444444000044444444000900044444444000044444444444444444444888444444488444444444444444444444444000044444444400000444444444000044444444444444444444888444444488444447",out prime);
			Console.WriteLine("Overall: {0}",RabinMiller.isPrime(prime,128));
			

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
