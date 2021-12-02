using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2021
{
    class Day1
    {
        public (long solution, long bonus) GetSolution()
        {
            return (GetPart1(),GetPart2());
        }

        private int GetPart1()
        {
            var inputs = File.ReadLines("Inputs\\Day1.txt")
                        .Select(x => int.Parse(x))
                        .ToArray();

            return Enumerable.Range(1, inputs.Length -1)
                    .Where(i => inputs[i] > inputs[i-1])
                    .Count();
        }
        private int GetPart2()
        {
            var inputs = File.ReadLines("Inputs\\Day1.txt").Select(x => int.Parse(x)).ToArray();

            return Enumerable.Range(3, inputs.Length - 3)
                        .Where(i => inputs.Skip(i-1).Take(3).Sum() > inputs.Skip(i-2).Take(3).Sum() )
                        .Count();
        }



    }

}