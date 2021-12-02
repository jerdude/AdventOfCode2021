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
            var _inputs = File.ReadLines("Inputs\\Day1.txt")
                        .Select(x => int.Parse(x))
                        .ToArray();

            int last = int.MaxValue;
            int total = 0;
            foreach(int i in _inputs)
            {
                if(i > last)
                    total++;

                last = i;
            }

            return total;
        }

        private int GetPart1Short()
        {
            var _inputs = File.ReadLines("Inputs\\Day1.txt")
                        .Select(x => int.Parse(x))
                        .ToArray();

            int last = int.MaxValue;
            int total = 0;
            foreach(int i in _inputs)
            {
                if(i > last)
                    total++;

                last = i;
            }

            return _inputs.Skip(1).Where(i => _inputs[i] > _inputs[i-1]).Count();
        }

        private int GetPart2()
        {
            var _inputs = File.ReadLines("Inputs\\Day1.txt")
                        .Select(x => int.Parse(x))
                        .ToArray();

            int last = int.MaxValue;
            int total = 0;

            for(int i = 2; i < _inputs.Length; i++)
            {
                int current = _inputs[i] + _inputs[i-1] + _inputs[i-2];
                
                if(current > last)
                    total++;

                last = current;
            }

            return total;
        }

    }

}