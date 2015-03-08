using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecodeAndDecrypt
{
    class DecodeAndDecryptSolution
    {
        private static int ExtractCypherLength(string encryptedAndEncodedMessage)
        {
            List<char> digits = new List<char>();
            for (int i = encryptedAndEncodedMessage.Length - 1; i >= 0; i--)
            {
                char symbol = encryptedAndEncodedMessage[i];
                if (!char.IsDigit(symbol))
                {
                    break;
                }
                digits.Add(symbol);
            }
            digits.Reverse();
            int cypherLength = int.Parse(string.Join("", digits));
            return cypherLength;
        }

        private static string[] Decode(string encryptedAndEncodedMessage)
        {
            int cypherLength = ExtractCypherLength(encryptedAndEncodedMessage);

            encryptedAndEncodedMessage = encryptedAndEncodedMessage.Substring(0, encryptedAndEncodedMessage.Length - cypherLength.ToString().Length);
            StringBuilder decodedMessageBuilder = new StringBuilder();

            List<char> digits = new List<char>();
            foreach (char symbol in encryptedAndEncodedMessage)
            {
                if (char.IsDigit(symbol))
                {
                    digits.Add(symbol);
                }
                else
                {
                    if (digits.Count == 0)
                    {
                        digits.Add('1');
                    }
                    digits.Reverse();
                    int count = int.Parse(string.Join("", digits));
                    decodedMessageBuilder.Append(symbol, count);
                    digits.Clear();
                }
            }

            string decodedMessage = decodedMessageBuilder.ToString();

            return new string[]
            {
                decodedMessage.Substring(0,decodedMessage.Length - cypherLength),
                decodedMessage.Substring(decodedMessage.Length - cypherLength)
            };
        }

        private static string Decrypt(string encryptedMessage, string cypher)
        {
            StringBuilder message = new StringBuilder(encryptedMessage);
            int len = Math.Max(encryptedMessage.Length, cypher.Length);
            for (int i = 0; i < len; i++)
            {
                int messageChar = message[i % encryptedMessage.Length] - 'A';
                int cypherChar = cypher[i % cypher.Length] - 'A';
                message[i % encryptedMessage.Length] = (char)((messageChar ^ cypherChar) + 'A');
            }
            return message.ToString();
        }

        static void Main()
        {
            string encryptedAndEncodedMessage = Console.ReadLine();
            string[] cypherTextAndCypher = Decode(encryptedAndEncodedMessage);
            string message = Decrypt(cypherTextAndCypher[0], cypherTextAndCypher[1]);
            Console.WriteLine(message);
        }
    }
}
