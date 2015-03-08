using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaCat
{
    class EnigmaCatSolution
    {
        static void Main()
        {
            string[] numbersInBase17 = Console.ReadLine()
                .Split(' ');
            foreach (string numberInBase17 in numbersInBase17)
            {
                BigInteger numberInBase10 = ConvertToBase10(numberInBase17, 17);
                string numberInBase26 = ConvertoToBase26(numberInBase10);
                Console.Write("{0} ", numberInBase26);
            }
            Console.WriteLine();
        }

        private static string ConvertoToBase26(BigInteger numberInBase10)
        {
            string numberInBase26 = string.Empty;
            int b = 26;
            while (numberInBase10 > 0)
            {
                char digit = (char)((numberInBase10 % b) + 'a');
                numberInBase26 = digit + numberInBase26;
                numberInBase10 /= b;
            }
            return numberInBase26;
        }

        private static BigInteger ConvertToBase10(string numberInBase, int b)
        {
            BigInteger numberIn10 = 0;
            BigInteger power = 1;
            for (int i = numberInBase.Length - 1; i >= 0; i--)
            {
                numberIn10 += power * (numberInBase[i] - 'a');
                power *= b;
            }
            return numberIn10;
        }
    }
}
