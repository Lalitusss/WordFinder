using System;
using System.Collections.Generic;

namespace ProjectFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var utils = new Utils();
            var matrix = utils.GenerateMatrix(64, 64);
            utils.DrawMatrix(matrix);
            var wordFinder = new WordFinder(matrix);
            var listFind = new List<string> { "OSO","PO","JE", "JA", "JU", "JI", "JA", "PA", "PE", "RAIN", "SNOW", "GOAL", "VERO", "PI", "DI" };
            var result = wordFinder.Find(listFind);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
