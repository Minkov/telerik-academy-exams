using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncreasingAbsoluteDifferences
{
    class IncreasingAbsoluteDifferences
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++)
            {
                var numbers = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                int[] diffs = new int[numbers.Length - 1];

                bool isIncreasingSequence = true;

                for (int j = 1; j < numbers.Length; j++)
                {
                    int prev = numbers[j - 1];
                    int next = numbers[j];
                    int diff = next - prev;
                    if (diff < 0)
                    {
                        diff *= -1;
                    }
                    diffs[j - 1] = diff;
                }
                for (int j = 1; j < diffs.Length; j++)
                {
                    int prev = diffs[j - 1];
                    int next = diffs[j];
                    int dif = next - prev;

                    if (dif < 0 || dif > 1)
                    {
                        isIncreasingSequence = false;
                        break;
                    }
                }
                Console.WriteLine(isIncreasingSequence);
            }
        }
    }
}
