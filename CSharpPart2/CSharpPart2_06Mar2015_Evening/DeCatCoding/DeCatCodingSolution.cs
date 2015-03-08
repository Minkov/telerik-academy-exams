using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DeCatCoding
{
    class DeCatCodingSolution
    {
        private static string testInput = @"sgfcg bdgaj fbo
";

        static BigInteger ConvertFromBase21ToBase10(string numberInBase21)
        {
            int b = 21;
            BigInteger numberInBase10 = 0;
            BigInteger power = 1;
            for (int i = numberInBase21.Length - 1; i >= 0; i--)
            {
                numberInBase10 += power * (numberInBase21[i] - 'a');
                power *= b;
            }
            return numberInBase10;
        }

        static string ConvertFromBase10ToBase26(BigInteger numberInBase10)
        {
            string numberInBase26 = string.Empty;
            int b = 26;

            while (numberInBase10 > 0)
            {
                numberInBase26 = ((char)((numberInBase10 % b) + 'a')) + numberInBase26;
                numberInBase10 /= b;
            }
            return numberInBase26;
        }

        private static void Solve()
        {
            string[] numbersInBase21 = Console.ReadLine()
                .Split(' ');

            foreach (string numberInBase21 in numbersInBase21)
            {
                BigInteger numberInBase10 = ConvertFromBase21ToBase10(numberInBase21);
                string numberInBase26 = ConvertFromBase10ToBase26(numberInBase10);
                Console.Write("{0} ", numberInBase26);
            }
            Console.WriteLine();
        }

        static void Main()
        {
            //StringReader reader = new StringReader(testInput);
            //Console.SetIn(reader);
            Solve();
        }

    }
}
