using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace BishopPathFinder
{
	class BishopPathFinderSolution
	{
		static int[] dRows = {-1, +1, +1, -1};
		static int[] dCols = {+1, +1, -1, -1};
		static bool[,] isVisited;

		static int GetDirection(string directionName)
		{
			switch (directionName) 
			{
			case "UR":
			case "RU":
				return 0;
			case "DR":
			case "RD":
				return 1;
			case "DL":
			case "LD":
				return 2;
			case "UL":
			case "LU":
				return 3;
			}
			return -1;
		}

		static BigInteger GetValue(int row, int col, int rows)
		{
			if (isVisited [row, col]) 
			{
				return 0;
			}
			return 3 * (rows - row - 1 + col);
		}

		static bool InRange(int value, int max)
		{
			return 0 <= value && value <= max;
		}

		public static void Solve()
		{
			int[] rowsCols = Console.ReadLine ()
				.Split (' ')
				.Select (int.Parse)
				.ToArray ();

			int rows = rowsCols [0];
			int cols = rowsCols [1];
			isVisited = new bool[rows, cols];

			int row = rows - 1;
			int col = 0;

			int n = int.Parse (Console.ReadLine ());
			BigInteger sum = 0;

			for (int i = 0; i < n; i++) {
				string[] dirNameAndMoves = Console.ReadLine ().Split (' ');
				string dirName = dirNameAndMoves [0];
				int dir = GetDirection (dirName);
				int moves = int.Parse(dirNameAndMoves [1]);
				for (int j = 0; j < moves-1; j++) 
				{
					int nextRow = row + dRows [dir];
					int nextCol = col + dCols [dir];
					if (!InRange (nextRow, rows - 1) || !InRange (nextCol, cols - 1)) {
						break;
					}
					row = nextRow;
					col = nextCol;
					sum += GetValue (row, col, rows);
					isVisited [row, col] = true;
				}
			}
			Console.WriteLine (sum);
		}

		public static void Main ()
		{
//			StringReader reader = new StringReader (@"6 7
//5
//UR 5
//RD 2
//DL 3
//LU 6
//DR 5
//");
//			Console.SetIn (reader);

			Solve ();
		}
	}
}
