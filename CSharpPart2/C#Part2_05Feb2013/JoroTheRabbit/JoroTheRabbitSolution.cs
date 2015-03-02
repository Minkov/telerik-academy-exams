using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace JoroTheRabbit
{
	class JoroTheRabbitSolution
	{
		public static void Main ()
		{
			Solve ();
		}

		public static void Solve ()
		{
			int[] terrain = Console.ReadLine ()
								    .Split (new char[]{ ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
									.Select (int.Parse)
									.ToArray ();
			int max = 0;
			for (int startPos = 0; startPos < terrain.Length; startPos++) {
				for (int step = 1; step <= terrain.Length; step++) {
					int lenght = 1;
					int pos = startPos;
					int prev = terrain [pos];
					bool[] isVisited = new bool[terrain.Length];

					while (true) {
						pos += step;
						pos %= terrain.Length;
						int next = terrain [pos];

						if (next <= prev || isVisited [pos])
						if (next <= prev) {
							break;
						}

						isVisited [pos] = true;
						prev = next;
						++lenght;
					}
					if (max < lenght) {
						max = lenght;
					}
				}
			}
			Console.WriteLine (max);
		}
	}
}
