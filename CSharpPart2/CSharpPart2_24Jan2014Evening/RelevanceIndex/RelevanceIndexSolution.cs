using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace RelevanceIndex
{
	class RelevanceIndexSolution
	{
		static string[] SortByOccurance (string[] paragraphs, string searchedWord)
		{
			char[] separators = { ' ', ',', '.', '(', ')', ';', '-', '!', '?' };
			List<int> occurances = new List<int> ();
			List<string> fixedParagraphs = new List<string> ();

			for (int i = 0; i < paragraphs.Length; i++) {
				string paragraph = paragraphs [i];
				List<string> words = new List<string> ();
				StringBuilder wordBuilder = new StringBuilder ();
				occurances.Add (0);
				foreach (char ch in paragraph) {
					if (separators.Contains (ch)) {
						if (wordBuilder.Length == 0) {
							continue;
						}
						string word = wordBuilder.ToString ();
						if (word.ToLower () == searchedWord) {
							++occurances [i];
							word = word.ToUpper ();
						}
						words.Add (word);
						wordBuilder.Clear ();
					} else {
						wordBuilder.Append (ch);
					}
				}
				if (wordBuilder.Length > 0) {
					string word = wordBuilder.ToString ();
					if (word.ToLower () == searchedWord) {
						++occurances [i];
						word = word.ToUpper ();
					}
					words.Add (word);
					wordBuilder.Clear ();
				}
				fixedParagraphs.Add (string.Join (" ", words));
			}

			var sorted = fixedParagraphs.OrderBy (paragraph => -occurances [fixedParagraphs.IndexOf (paragraph)]);

			return sorted.ToArray ();
		}

		public static void Solve ()
		{
			string word = Console.ReadLine ().ToLower ();
			int l = int.Parse (Console.ReadLine ());
			string[] paragraphs = new string[l];

			for (int i = 0; i < l; i++) {
				paragraphs [i] = Console.ReadLine ();
			}

			string[] sortedParagraphs = SortByOccurance (paragraphs, word);
			Console.WriteLine (string.Join (Environment.NewLine, sortedParagraphs));
		}

		public static void Main ()
		{
			string inputString = @"text
5
if you have someone to text
but the text is more than text to text
and you need a better text to text
try to text what the text would want to text another text with text
cause this text is too much about text, and a text will never teach you how to text
";
//			StringReader reader = new StringReader (inputString);
//			Console.SetIn (reader);

			Solve ();
		}
	}
}
