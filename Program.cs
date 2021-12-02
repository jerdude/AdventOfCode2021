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
