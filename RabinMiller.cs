using System;
using System.Numerics;
using System.Security.Cryptography;

static class RabinMiller
{
	// following http://mathworld.wolfram.com/Rabin-MillerStrongPseudoprimeTest.html
	// and https://en.wikipedia.org/wiki/Miller%E2%80%93Rabin_primality_test

	public static bool isPrime(BigInteger n, int iterations)
	{
		for (int i = 0; i < iterations; i++)
		{
			if (n < 2 || n % 2 == 0) return false;
			if (n == 2 || n == 3) return true;
			BigInteger s = n - 1;
			int r = 0;
			do {
				s /= 2;
				r++;
			} while (s % 2 == 0);
			RandomNumberGenerator random = new RNGCryptoServiceProvider();
			byte[] bytes = new byte[n.ToByteArray().LongLength];
			BigInteger a;
			do {
				random.GetBytes(bytes);
				bytes [bytes.Length - 1] &= (byte)0x7F; //force sign bit to positive
				a = new BigInteger(bytes);
			} while (a < 2 || a > n - 2);

			BigInteger x = BigInteger.ModPow(a, s, n);
			if (x == 1 || x == n - 1) continue;
			for (int j = 0; j < r; j++)
			{
				x = BigInteger.ModPow(x, 2, n);
				if (x == 1) return false;
				if (x == n - 1) break;

			}
			if (x != n - 1) return false;
			Console.WriteLine("Iteration {0}: True",i);
		} 
		return true;
	}
}
