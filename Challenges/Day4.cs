using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2021
{
    class Day4
    {
        public (long solution, long bonus) GetSolution()
        {
            return (GetPart1(),GetPart2());
        }

        private int GetPart1()
        {
            int lineNumber = 1;
            var numbersToCall = new List<int>();

            var bingoBoards = new List<int[,]>();
            var matches = new List<bool[,]>();

            int[,] boardInProgress = new int[5,5];
            int boardInProgressLine = 0;
            
            //build our bingo boards
            foreach(string line in File.ReadLines("Inputs\\Day4.txt"))
            {
                if(lineNumber == 1)
                {
                    numbersToCall = line.Split(",").Select(x => int.Parse(x)).ToList();
                    lineNumber++;
                    continue;
                }
                
                if(lineNumber == 2)
                {
                    lineNumber++;
                    continue;
                }
                
                if(line == "")
                {
                    bingoBoards.Add(boardInProgress);
                    matches.Add(new bool[5,5]);

                    boardInProgress = new int[5,5];
                    boardInProgressLine = 0;
                }
                else
                {
                    var newLine = line.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                    for(int i = 0; i < newLine.Length; i++)
                    {
                        boardInProgress[boardInProgressLine, i] = newLine[i];
                    }

                    boardInProgressLine++;
                }

                lineNumber = lineNumber + 1;
            }

            //start calling numbers
            foreach(int called in numbersToCall)
            {
                //update boards
                for(int boardNumber = 0; boardNumber < bingoBoards.Count(); boardNumber++)
                {
                    for(int row = 0; row < 5; row++)
                    {
                        for(int column = 0; column < 5; column++)
                        {
                            if(bingoBoards[boardNumber][row,column] == called)
                                matches[boardNumber][row,column] = true;
                        }
                    }
                }

                //check for matches
                for(int boardNumber = 0; boardNumber < bingoBoards.Count(); boardNumber++)
                {

                    bool winnerWinnerChickenDinner = false;

                    //check row bingos
                    for(int row = 0; row < 5; row++)
                    {
                        int matchesInRow = 0;

                        for(int column = 0; column < 5; column++)
                        {
                            if(matches[boardNumber][row,column] == true)
                                matchesInRow++;
                        }

                        if(matchesInRow == 5)
                            winnerWinnerChickenDinner = true;
                    }

                    //check column bingos
                    for(int column = 0; column < 5; column++)
                    {
                        int matchesInRow = 0;

                        for(int row = 0; row < 5; row++)
                        {
                            if(matches[boardNumber][row,column] == true)
                                matchesInRow++;
                        }

                        if(matchesInRow == 5)
                            winnerWinnerChickenDinner = true;
                    }

                    if(winnerWinnerChickenDinner)
                    {
                        int unmatchedSum = 0;

                        //get the big ugly number to return
                        for(int row = 0; row < 5; row++)
                        {
                            for(int column = 0; column < 5; column++)
                            {
                                if(matches[boardNumber][row,column] == false)
                                    unmatchedSum += bingoBoards[boardNumber][row,column];
                            }
                        }

                        return unmatchedSum * called;
                    }
                    
                }
            }

            return 0;
        }

        private int GetPart2()
        {

            int lineNumber = 1;
            var numbersToCall = new List<int>();

            var bingoBoards = new List<int[,]>();
            var matches = new List<bool[,]>();

            int[,] boardInProgress = new int[5,5];
            int boardInProgressLine = 0;
            
            //build our bingo boards
            foreach(string line in File.ReadLines("Inputs\\Day4.txt"))
            {
                if(lineNumber == 1)
                {
                    numbersToCall = line.Split(",").Select(x => int.Parse(x)).ToList();
                    lineNumber++;
                    continue;
                }
                
                if(lineNumber == 2)
                {
                    lineNumber++;
                    continue;
                }
                
                if(line == "")
                {
                    bingoBoards.Add(boardInProgress);
                    matches.Add(new bool[5,5]);

                    boardInProgress = new int[5,5];
                    boardInProgressLine = 0;
                }
                else
                {
                    var newLine = line.Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                    for(int i = 0; i < newLine.Length; i++)
                    {
                        boardInProgress[boardInProgressLine, i] = newLine[i];
                    }

                    boardInProgressLine++;
                }

                lineNumber = lineNumber + 1;
            }

            var winningValues = new List<int>();
            var winningBoards = new List<int>();

            //start calling numbers
            foreach(int called in numbersToCall)
            {
                //update boards
                for(int boardNumber = 0; boardNumber < bingoBoards.Count(); boardNumber++)
                {
                    for(int row = 0; row < 5; row++)
                    {
                        for(int column = 0; column < 5; column++)
                        {
                            if(bingoBoards[boardNumber][row,column] == called)
                                matches[boardNumber][row,column] = true;
                        }
                    }
                }

                //check for matches
                for(int boardNumber = 0; boardNumber < bingoBoards.Count(); boardNumber++)
                {

                    bool winnerWinnerChickenDinner = false;

                    //check row bingos
                    for(int row = 0; row < 5; row++)
                    {
                        int matchesInRow = 0;

                        for(int column = 0; column < 5; column++)
                        {
                            if(matches[boardNumber][row,column] == true)
                                matchesInRow++;
                        }

                        if(matchesInRow == 5)
                            winnerWinnerChickenDinner = true;
                    }

                    //check column bingos
                    for(int column = 0; column < 5; column++)
                    {
                        int matchesInRow = 0;

                        for(int row = 0; row < 5; row++)
                        {
                            if(matches[boardNumber][row,column] == true)
                                matchesInRow++;
                        }

                        if(matchesInRow == 5)
                            winnerWinnerChickenDinner = true;
                    }

                    if(winnerWinnerChickenDinner && !winningBoards.Contains(boardNumber))
                    {
                        int unmatchedSum = 0;

                        //get the big ugly number to return
                        for(int row = 0; row < 5; row++)
                        {
                            for(int column = 0; column < 5; column++)
                            {
                                if(matches[boardNumber][row,column] == false)
                                    unmatchedSum += bingoBoards[boardNumber][row,column];
                            }
                        }

                        winningValues.Add(unmatchedSum * called);
                        winningBoards.Add(boardNumber);
                    }
                    
                }
            }

            return winningValues.Last();
        }

    }

}