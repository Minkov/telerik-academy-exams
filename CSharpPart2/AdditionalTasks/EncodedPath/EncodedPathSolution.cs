using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace EncodedPath
{
	class EncodedPathSolution
	{
		static bool[,] isVisited;

		static int[] dRows = { -1, -1, 0, +1, +1, +1, 0, -1 };
		static int[] dCols = { 0, +1, +1, +1, 0, -1, -1, -1 };

		static BigInteger GetValueAt (int row, int col)
		{
			if (isVisited [row, col]) {
				return 0;
			}

			BigInteger result = ((BigInteger)1) << 2 * (row + col);
			return result;
		}

		static int[] GetDirections ()
		{
			StringBuilder builder = new StringBuilder ();
			for (char i = '0'; i <= '9'; i++) {
				builder.Append (i);
			}
			for (char i = 'a'; i <= 'z'; i++) {
				builder.Append (i);
			}
			builder.Append (" !,.");

			string dirNames = builder.ToString ();
			int[] dirs = new int[dirNames.Max (dirname => (int)dirname) + 1];
		
			for (int i = 0; i < dirNames.Length; i++) {
				dirs [dirNames [i]] = i % 8;
				dirs [char.ToUpper (dirNames [i])] = i % 8;
			}

			return dirs;
		}

		static bool InRange (int value, int max)
		{
			return 0 <= value && value <= max;
		}

		public static void Solve ()
		{
			int n = 100;
			int m = 100;
			string path = new string ('3', 50) + " Abe, Gosho e pi4!";

			isVisited = new bool[n, m];
			int[] dirs = GetDirections ();

			int row = 0;
			int col = 0;
			isVisited [row, col] = true;

			BigInteger sum = 1;

			foreach (var move in path) {
				int dir = dirs [move];
				row += dRows [dir];
				col += dCols [dir];
				if (!InRange (row, n - 1) || !InRange (col, m - 1)) {
					break;
				}
				var value = GetValueAt (row, col);
				sum += value;

				isVisited [row, col] = true;
			}
			Console.WriteLine (sum);
			Console.WriteLine (sum % 1000007);
		}

		public static void Main ()
		{
			Solve ();
		}
	}
}
