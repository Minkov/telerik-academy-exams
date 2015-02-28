using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace MagicWords
{
	class MagicWordsSolution
	{
		static string[] ReadWords(){

			int n = int.Parse(Console.ReadLine());
			string[] words = new string[n];

			for (int i = 0; i < n; i++) {
				words [i] = Console.ReadLine ();
			}
			return words;
		}

		static void MoveWord(List<string> words, int from, int to){
			string word = words [from];
			words.RemoveAt (from);
			words.Insert (to, word);
		}

		static void PrintWords(string[] words){
			int length = words.Max (word => word.Length);
			for (int i = 0; i < length; i++) {
				foreach (var word in words) {
					if (word.Length > i) {
						Console.Write (word[i]);
					}
				}
			}
			Console.WriteLine ();
		}
			
		static string[] ReorderWords(string[] words){
			List<string> reorderedWords = new List<string>(words);
			for (int i = 0; i < words.Length; i++) {
				string word = reorderedWords [i];
				int position = word.Length % (words.Length+1);
				MoveWord (reorderedWords, i, position);
			}
			return reorderedWords.ToArray ();
		}

		public static void Main ()
		{
			StringReader reader = new StringReader (@"3
hi
academy
exam
");
			Console.SetIn (reader);
			string[] words = ReadWords ();
			string[] reorderedWords = ReorderWords (words);
			PrintWords (reorderedWords);
		}
	}
}
