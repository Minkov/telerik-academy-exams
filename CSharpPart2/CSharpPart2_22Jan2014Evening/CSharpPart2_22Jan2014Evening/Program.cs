using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using System.IO;

namespace BunnyFactory
{
	class BunnyFactorySolution
	{
		static string testInput = @"3
2
5
5
4
8
4
9
5
6
3
4
END";


		static List<int> ReadInput ()
		{
			List<int> rabits = new List<int> ();
			string line = Console.ReadLine ();
			while (line != "END") {
				rabits.Add (int.Parse (line));
				line = Console.ReadLine ();
			}
			rabits.Reverse ();
			return rabits;
		}

		static int Sum (List<int> rabits, int from, int to)
		{
			int sum = 0;
			for (int i = from; i <= to; i++) {
				sum += rabits [i];
			}
			return sum;
		}

		static List<int> GetDigits (BigInteger number)
		{
			List<int> digits = new List<int> ();
			while (number > 0) {
				int digit = (int)(number % 10);
				number /= 10;
				if (digit != 0 && digit != 1) {
					digits.Add (digit);
				}
			}
			return digits;
		}

		static bool PerformMultiplication (List<int> numbers, int count)
		{
			if (numbers.Count < count) {
				return false;
			}

			int s = Sum (numbers, numbers.Count - count, numbers.Count - 1);


			if (numbers.Count < s + count) {
				return false;
			}
				
			BigInteger sum = 0;
		
			BigInteger product = 1;

			int from = numbers.Count - s - count;
			int to = numbers.Count - count - 1;

			for (int i = from; i <= to; i++) {
				int number = numbers [i];
				sum += number;
				product *= number;
			}

			numbers.RemoveRange (numbers.Count - count, count);
			numbers.RemoveRange (numbers.Count - s, s);

			numbers.AddRange (GetDigits (product));
			numbers.AddRange (GetDigits (sum));

			return true;	
		}

		static List<int> SplitDigitsAndRemoveZeroesAndOnes (List<int> rabits)
		{
			List<int> numbers = new List<int> ();
			for (int i = 0; i < rabits.Count; i++) {
				int rabit = rabits [i];
				numbers.AddRange (GetDigits (rabit));
			}
			return numbers;
		}

		public static void Main (string[] args)
		{
//			StringReader reader = new StringReader (testInput);
//			Console.SetIn (reader);

			List<int> rabits = ReadInput ();

			int index = 1;

			bool isInitial = true;
			while (PerformMultiplication (rabits, index)) {
				if (isInitial) {
					isInitial = false;
					rabits = SplitDigitsAndRemoveZeroesAndOnes (rabits);
				}
				index++;
			}
			rabits.Reverse ();
			string actual = string.Join (" ", rabits);
			Console.WriteLine (actual);
		}
	}
}
