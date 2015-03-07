using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Numerics;

namespace SumOfDifferences
{
	class SumOfDifferencesSolution
	{
		public static void Main ()
		{
//			StringReader reader = new StringReader (@"1 6 8 10 3 1 1
//");
//			Console.SetIn (reader);

			int[] numbers = Console.ReadLine ()
				.Split (' ')
				.Select (int.Parse)
				.ToArray ();
			BigInteger sum = 0;
			for (int i = 1; i < numbers.Length; i++) {
				BigInteger prev = numbers [i - 1];
				BigInteger next = numbers [i];
				BigInteger diff = 0;
				if (prev < next) {
					diff = next - prev;
				} else {
					diff = prev - next;
				}
				if (diff % 2 == 0) {
					i++;
				} else {
					sum += diff;
				}
			}
			Console.WriteLine (sum);
		}
	}
}
