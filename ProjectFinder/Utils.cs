using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFinder
{
    public class Utils
    {
        public IEnumerable<string> GenerateMatrix(int rows, int columns)
        {
            var matrix = new List<string>();
            for (int i = 0; i < rows; i++)
            {
                var row = string.Empty;
                for (int j = 0; j < columns; j++)
                {
                    row += GetRandomWord();
                }
                matrix.Add(row);
            }
            return matrix;
        }

        public void DrawMatrix(IEnumerable<string> matrix)
        {
            foreach (var row in matrix)
            {
                for (int j = 0; j < row.Length; j++)
                {
                    Console.Write("{0} ", row[j]);
                }
                Console.WriteLine();
            }

        }

        private char GetRandomWord()
        {
            var random = new Random();
            var randomNumber = random.Next(0, 26);
            return (char)('A' + randomNumber);
        }

    }
}
