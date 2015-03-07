using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.IO;

namespace MathProblem
{
	class MathProblemSolution
	{
		static  int catSystemBase = 19;

		static int GetDecimalDigit (char catDigit)
		{
			return catDigit - 'a';
		}

		static char GetCatDigit (int decDigit)
		{
			return (char)('a' + decDigit);
		}

		static BigInteger CatToDecimal (string catNumber)
		{
			BigInteger power = 1;
			BigInteger decNumber = 0;
			for (int i = catNumber.Length - 1; i >= 0; i--) {
				int digit = GetDecimalDigit (catNumber [i]);
				decNumber += digit * power;
				power *= catSystemBase;
			}
			return decNumber;
		}

		static string DecimalToCat (BigInteger decNumber)
		{
			StringBuilder catNumber = new StringBuilder ();
			while (decNumber > 0) {
				int digit = (int)(decNumber % catSystemBase);
				char catDigit = GetCatDigit (digit);
				catNumber.Append (catDigit);
				decNumber /= catSystemBase;
			}
			return string.Join ("", catNumber.ToString ().Reverse ());
		}

		public static void Main ()
		{
//			StringReader reader = new StringReader ("grrrr miao miao");
//			Console.SetIn (reader);

			string[] catNumbers = Console.ReadLine ().Split (' ');
			BigInteger sum = 0;
			foreach (var catNumber in catNumbers) {
				var decNumber = CatToDecimal (catNumber);
				sum += decNumber;
			}

			string sumAsCatNumber = DecimalToCat (sum);
			Console.WriteLine ("{0} = {1}", sumAsCatNumber, sum);
		}
	}
}
