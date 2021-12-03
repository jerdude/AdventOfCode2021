using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2021
{
    class Day3
    {
        public (long solution, long bonus) GetSolution()
        {
            return (GetPart1(),GetPart2());
        }

        private int GetPart1()
        {
            var inputs = File.ReadLines("Inputs\\Day3.txt").ToArray();

            var zeroCounts = new List<int>();
            var oneCounts = new List<int>();

            foreach(string input in inputs)
            {
                var chars = input.ToCharArray();

                for(int i = 0; i < chars.Length; i++)
                {
                    if(zeroCounts.Count() <= i)
                        zeroCounts.Add(0);

                    if(oneCounts.Count() <= i)
                        oneCounts.Add(0);

                    if(chars[i] == '1')
                        zeroCounts[i] += 1;
                    else if(chars[i] == '0')
                        oneCounts[i] += 1;
                }
            }

            var leastBinary = "";
            var mostBinary = "";

            for(int i = 0; i < zeroCounts.Count(); i++)
            {
                if(zeroCounts[i] > oneCounts[i])
                {
                    leastBinary += "1";
                    mostBinary += "0";
                }
                else
                {
                    mostBinary += "1";
                    leastBinary += "0";
                }
            }

            var gamma = Convert.ToInt32(mostBinary, 2);
            var epsilon = Convert.ToInt32(leastBinary, 2);

            return gamma * epsilon;
        }

        private int GetPart2()
        {
            var inputs = File.ReadLines("Inputs\\Day3.txt").ToArray();

            var most = (string[])inputs.Clone();
            var least = (string[])inputs.Clone();

            int oxygen = 0;
            int co2 = 0;

            for(int i = 0; i < 12; i++)
            {
                int zeroes = most.Where(x => x.ToCharArray()[i] == '0').Count();
                int ones = most.Where(x => x.ToCharArray()[i] == '1').Count();

                most = ones >= zeroes 
                    ? most.Where(x => x.Substring(i, 1) == "1").ToArray() 
                    : most.Where(x => x.Substring(i, 1) == "0").ToArray();

                if(most.Length == 1)
                    oxygen = Convert.ToInt32(most.First(), 2);
            }

            for(int i = 0; i < 12; i++)
            {
                int zeroes = least.Where(x => x.ToCharArray()[i] == '0').Count();
                int ones = least.Where(x => x.ToCharArray()[i] == '1').Count();

                least = zeroes <= ones
                    ? least.Where(x => x.Substring(i, 1) == "0").ToArray()
                    : least = least.Where(x => x.Substring(i, 1) == "1").ToArray();

                if(least.Length == 1)
                    co2 = Convert.ToInt32(least.First(), 2);
            }

            return co2 * oxygen;
        }



    }

}