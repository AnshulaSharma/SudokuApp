using Microsoft.Extensions.Logging;
using SudokuApp.Model;
using SudokuApp.Utility;
using System;

namespace SudokuApp.Service
{
    public class PuzzleService : IPuzzleService
    {
        private ILogger<PuzzleService> _logger;
        private int[][] board;

        public PuzzleService(ILogger<PuzzleService> logger)
        {
            _logger = logger;
        }
        public int[][] GetSolvedSudoku6x6(int[][] puzzle)
        {
            try
            {
                board = puzzle;
                if (SolveSudoku())
                    return board;
                else
                    return null;
            }
            catch (Exception)
            {
                throw new PuzzleException(Constants.Message.SolutionNotFound, Constants.Code.Error);
            }
        }
        private bool SolveSudoku()
        {
            try
            {
                int len = board.GetLength(0);
                if (len != 6)
                    return false;
                int row = -1;
                int col = -1;
                bool isEmpty = true;
                for (int i = 0; i < len; i++)
                {
                    int arrayLength = board[i].Length;
                    if (arrayLength != 6)
                        return false;
                    for (int j = 0; j < arrayLength; j++)
                    {
                        if (board[i][j] == 0)
                        {
                            row = i;
                            col = j;
                            isEmpty = false;
                            break;
                        }
                    }
                    if (!isEmpty)
                    {
                        break;
                    }
                }

                // no empty space left 
                if (isEmpty)
                {
                    return true;
                }

                // else for each-row backtrack 
                for (int num = 1; num <= len; num++)
                {
                    if (IsSafe(row, col, num))
                    {
                        board[row][col] = num;
                        if (SolveSudoku())
                        {
                            return true;
                        }
                        else
                        {
                            board[row][col] = 0;

                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError("ERROR Publishing Sudoku Puzzle Solution " + ex.Message);
                throw;
            }
        }
        private bool IsSafe(int row, int col, int num)
        {
            try
            {
                for (int c = 0; c < board.GetLength(0); c++)
                {
                    if (board[row][c] == num)
                    {
                        return false;
                    }
                }

                for (int r = 0; r < board.GetLength(0); r++)
                {
                    if (board[r][col] == num)
                    {
                        return false;
                    }
                }

                int boxRowStart = row - row % 2;
                int boxColStart = col - col % 3;

                for (int r = boxRowStart; r < boxRowStart + 2; r++)
                {
                    for (int d = boxColStart; d < boxColStart + 3; d++)
                    {
                        if (board[r][d] == num)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (IndexOutOfRangeException ex)
            {
                _logger.LogError("ERROR Validating Number Already Exists in Puzzle " + ex.Message);
                throw;
            }
        }
    }
}
