using System;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What day's challenge would you like to run?");
            
            string input;
            
            do
            {
                input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        var day1 = new Day1();
                        var day1Results = day1.GetSolution();
                        Program.PrintSolution(day1Results.solution, day1Results.bonus);
                        break;
                    case "2":
                        var Day2 = new Day2();
                        var Day2Results = Day2.GetSolution();
                        Program.PrintSolution(Day2Results.solution, Day2Results.bonus);
                        break;
                    case "3":
                        var day3 = new Day3();
                        var day3Results = day3.GetSolution();
                        Program.PrintSolution(day3Results.solution, day3Results.bonus);
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Enter q to quit.");
                        break;
                }
            }
            while (input != "q");
        }

        private static void PrintSolution(long solution, long bonus)
        {
            Console.WriteLine("Solution: " + solution);
            Console.WriteLine("Bonus: " + bonus);
        }
    }
}
