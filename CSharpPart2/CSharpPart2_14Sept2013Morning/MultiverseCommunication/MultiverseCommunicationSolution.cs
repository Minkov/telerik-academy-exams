using System;
using System.Numerics;

namespace MultiverseCommunication
{
	class MultiverseCommunicationSolution
	{

		const int MultiverseSystemBase = 13;

		static int GetDigitValue (string digit)
		{
			switch (digit) {
			case "CHU":
				return 0;
			case "TEL":
				return 1;
			case "OFT":
				return 2;
			case "IVA":
				return 3;
			case "EMY":
				return 4;
			case "VNB":
				return 5;
			case "POQ":
				return 6;
			case "ERI":
				return 7;
			case "CAD":
				return 8;
			case "K-A":
				return 9;
			case "IIA":
				return 10;
			case "YLO":
				return 11;
			case "PLA":
				return 12;
			default:
				throw new ArgumentOutOfRangeException ("Invalid digit");
			}
		}


		public static void Main ()
		{
			string multiverseNumber = Console.ReadLine ();
			BigInteger decNumber = 0;
			BigInteger power = 1;
			for (int i = multiverseNumber.Length - 3; i >= 0; i -= 3) {
				string digit = multiverseNumber.Substring (i, 3);
				int digitValue = GetDigitValue (digit);
				decNumber += power * digitValue;
				power *= MultiverseSystemBase;
			}
			Console.WriteLine (decNumber);
		}
	}
}
