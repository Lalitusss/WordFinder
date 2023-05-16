using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ProjectFinder
{
    public class WordFinder
    {
        private readonly IEnumerable<string> matrix; 
        public WordFinder(IEnumerable<string> matrix) 
        {
            this.matrix = matrix;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var result = new List<string>();
            var transposedMatrix = GetTransposedMatrix();
            result.AddRange(GetResults(wordstream, matrix));
            result.AddRange(GetResults(wordstream, transposedMatrix));

            return result.Distinct();

        }

        private IEnumerable<string> GetTransposedMatrix()
        {
            var matrixAux = new char[matrix.Count(), matrix.First().Length];
            var result = new List<string>();
            for (int i = 0; i < matrixAux.GetLength(0); i++)
            {
                for (int j = 0; j < matrixAux.GetLength(1); j++)
                {
                    matrixAux[i, j] = matrix.ElementAt(i)[j];
                }
            }

            for (int i = 0; i < matrixAux.GetLength(1); i++)
            {
                var row = string.Empty;
                for (int j = 0; j < matrixAux.GetLength(0); j++)
                {
                    row += matrixAux[j, i];
                }
                result.Add(row);
            }

            return result;
        }

        private List<string> GetResults(IEnumerable<string> wordstream, IEnumerable<string> matrix)
        {
            var result = new List<string>();

            foreach (var row in matrix)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    if (wordstream.Select(x => x[0]).Contains(row[i]))
                        result = GetWords(row, i, wordstream, result);
                }
            }
            return result;
        }

        private List<string> GetWords(string row, int index, IEnumerable<string> words, List<string> result)
        {
            var wordAux = string.Empty; 
            foreach (var word in words)
            {
                wordAux = GetWord(row, index, word);
                if (words.Contains(wordAux) && !result.Contains(wordAux))
                    result.Add(wordAux);
            }

            return result;
        }

        private string GetWord(string row, int index, string word)
        {
            var result = string.Empty;
            foreach (var letter in word)
            {
                if (index < row.Length && letter == row[index])
                {
                    result += letter;
                    index++;
                }
                else
                    break;
            }

            return result;
        }
    }
}
