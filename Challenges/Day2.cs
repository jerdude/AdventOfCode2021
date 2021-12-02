using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2021
{
    class Day2
    {
        public (long solution, long bonus) GetSolution()
        {
            return (GetPart1(),GetPart2());
        }

        private int GetPart1()
        {
            var _inputs = File.ReadLines("Inputs\\Day2.txt").ToList();

            int depth = 0;
            int position = 0;

            foreach(string input in _inputs)
            {
                var i = input.Split(' ', 2);

                switch(i[0])
                {
                    case "forward":
                        position += int.Parse(i[1]);
                        break;
                    
                    case "up":
                        depth -= int.Parse(i[1]);
                        break;

                    case "down":
                        depth += int.Parse(i[1]);
                        break;
                }
            }
            
            return depth * position;
        }

        private int GetPart2()
        {
            var _inputs = File.ReadLines("Inputs\\Day2.txt").ToList();

            int depth = 0;
            int position = 0;
            int aim = 0;

            foreach(string input in _inputs)
            {
                var i = input.Split(' ', 2);
                var x = int.Parse(i[1]);

                switch(i[0])
                {
                    case "forward":
                        position += x;
                        depth += aim * x;
                        break;
                    
                    case "up":
                        aim -= x;
                        break;

                    case "down":
                        aim += x;
                        break;
                }
            }
            
            return depth * position;
        }

    }

}