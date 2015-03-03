using System;

namespace HorseInMatrix
{
	public class HorseInMatrixSolution
	{
		static bool InRange (int value, int max)
		{
			return 0 <= value && value <= max;
		}

		static void PrintMatrix (int[,] matrix)
		{
			for (int row = 0; row < matrix.GetLength (0); row++) {
				for (int col = 0; col < matrix.GetLength (1); col++) {
					Console.Write ("{0} ", matrix [row, col]);
				}
			}
		}

		public static void Solve ()
		{
			int[] dRows = { -2, -2, -1, -1, +1, +1, +2, +2 };
			int[] dCols = { -1, +1, -2, +2, -2, +2, -1, +1 };

			int n = int.Parse (Console.ReadLine ());
			int row = 0;
			int col = 0;

			int lastStartRow = row;
			int lastStartCol = col;

			int[,] matrix = new int[n, n];

			for (int count = 1; count <= n * n; count++) {
				matrix [row, col] = count;
				bool isMoveMade = false;
				for (int dir = 0; dir < dRows.Length; dir++) {
					int newRow = row + dRows [dir];
					int newCol = col + dCols [dir];
					if (InRange (newRow, n - 1) &&
					    InRange (newCol, n - 1) &&
					    matrix [newRow, newCol] == 0) {
						row = newRow;
						col = newCol;
						isMoveMade = true;
						break;
					}
				}

				if (!isMoveMade) {
					bool isPositionFound = false;
					for (int r = lastStartRow; r < n; r++) {
						if (isPositionFound) {
							break;
						}
						for (int c = lastStartCol; c < n; c++) {
							if (matrix [r, c] == 0) {
								row = r;
								col = c;
								isPositionFound = true;
								break;
							}
						}
					}
				}
			}
			PrintMatrix (matrix);
		}

		public static void Main (string[] args)
		{
			Solve ();
		}
	}
}
