using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace GreedyDrarf
{
	class GreedyDratfSolution
	{
		static string testInput = @"1, 3, -6, 7, 4 ,1, 12
3
1, 2, -3
1, 3, -2
1, -1";

		public static void Main ()
		{
//			StringReader reader = new StringReader (testInput);
//			Console.SetIn (reader);

			char[] separators = { ' ', ',' };
			int[] valley = Console.ReadLine ()
							      .Split (separators, StringSplitOptions.RemoveEmptyEntries)
								  .Select (int.Parse)
							 	  .ToArray ();

			int n = int.Parse (Console.ReadLine ());
			bool isFirstCoins = true;
			int max = 0;

			for (int i = 0; i < n; i++) {
				int[] pattern = Console.ReadLine ()
					.Split (separators, StringSplitOptions.RemoveEmptyEntries)
					.Select (int.Parse)
					.ToArray ();

				int index = 0;
				int coins = 0;
				int patternIndex = 0;

				bool[] isVisited = new bool[valley.Length];
				while (0 <= index && index < valley.Length && !isVisited [index]) {
					isVisited [index] = true;
					coins += valley [index];
					index += pattern [patternIndex];
					patternIndex++;
					patternIndex %= pattern.Length;
				}
				if (isFirstCoins) {
					isFirstCoins = false;
					max = coins;
				} else if (max < coins) {
					max = coins;
				}
			}
			Console.WriteLine (max);
		}
	}
}
