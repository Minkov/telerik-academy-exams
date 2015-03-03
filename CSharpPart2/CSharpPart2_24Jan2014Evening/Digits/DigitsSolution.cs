namespace Digits
{
	using System;
	using System.Linq;
	using System.IO;
	using System.Collections.Generic;

	class DigitsSolution
	{
		static string testInput1 = @"5
1 1 1 1 1
1 1 1 1 1
1 1 1 1 1
1 1 1 1 1
1 1 1 1 1";

		static string testInput2 = @"6
9 9 9 2 2 2
9 9 9 2 2 2
9 9 9 2 2 2
9 9 9 2 2 2
9 9 9 2 2 2
9 9 9 2 2 2";

		static string testInput3 = @"8
3 2 1 1 2 3 0 1
2 1 1 9 7 6 4 0
1 4 1 7 7 7 5 1
2 4 1 4 2 7 1 1

3 4 1 4 7 1 3 1
0 4 4 4 7 4 5 1
5 8 2 4 7 3 2 1
1 2 7 4 9 2 1 8";

		static int[][] digitPattenrsRows = {
			new int[]{0, -1, -1, +1, +1, +1, +1},
			new int[]{0, -1, +1, +1, +1, +1, 0, 0},
			new int[]{0, 0, 0, +1, +1, +1, +1, 0, 0, -2},
			new int[]{0, +1, +1, 0, 0, -1, -1, +3, +1},
			new int[]{0, 0, 0, +1, +1, 0, 0, +1, +1, 0, 0},
			new int[]{0, 0, 0, +1, +1, 0, 0, +1, +1, 0, 0, -1},
			new int[]{0, 0, 0, +1, +1, +1, +1},
			new int[]{0, -1, 0, 0, +1, +1, +1, +1, 0, 0, -1},
			new int[]{0, 0, 0, -1, -1, -1, -1, 0, 0, +1, +1}
		};

		static int[][] digitPatternsCols = 
		{
			new int[]{0, +1, +1, 0, 0, 0, 0},
			new int[]{0, +1, +1, 0, -1, -1, +1, +1},
			new int[]{0, +1, +1, 0, 0, 0, 0, -1, -1, +1},
			new int[]{0, 0, 0, +1, +1, 0, 0, 0, 0},
			new int[]{0, -1, -1, 0, 0, +1, +1, 0, 0, -1, -1},
			new int[]{0, -1, -1, 0, 0, +1, +1, 0, 0, -1, -1, 0},
			new int[]{0, +1, +1, 0, -1, 0, 0},
			new int[]{0, 0, +1, +1, 0, -1, -1, 0, +1, +1, 0},
			new int[]{0, +1, +1, 0, 0, 0, 0, -1, -1, 0, +1}
		};

		static int[,] ReadField()
		{
			int n = int.Parse (Console.ReadLine ());
			int[,] field = new int[n, n];

			for (int row = 0; row < n; row++) {
				int[] cells = Console.ReadLine ()
					.Split (' ')
					.Select (int.Parse)
					.ToArray ();
				for (int col = 0; col < cells.Length; col++) {
					field [row, col] = cells [col];
				}
			}

			return field;
		}

		static bool InRange(int value, int max)
		{
			return 0 <= value && value <= max;
		}

		public static void Solve()
		{
			int[,] field = ReadField ();
			int sum = 0;
			for (int row = 0; row < field.GetLength(0); row++) {
				for (int col = 0; col < field.GetLength(1); col++) {
					int digit = field [row, col];
					int r = row;
					int c = col;
					if (digit == 0) {
						continue;
					}
					int[] patternRows = digitPattenrsRows [digit - 1];
					int[] patternCols = digitPatternsCols [digit - 1];
					bool isDigitFound = true;
					for (int i = 0; i < patternCols.Length; i++) {
						int nextRow = r + patternRows [i];
						int nextCol = c + patternCols [i];
						if (!InRange (nextRow, field.GetLength (0) - 1) ||
						   !InRange (nextCol, field.GetLength (1) - 1) || field [nextRow, nextCol] != digit) 
						{
							isDigitFound = false;
							break;
						}
						r = nextRow;
						c = nextCol;
					}
					if (isDigitFound) {
						sum += digit;
					}
				}
			}
			Console.WriteLine (sum);
		}

		public static void Main ()
		{
//			StringReader reader = new StringReader (testInput2);
//			Console.SetIn (reader);

			Solve ();
		}
	}
}
