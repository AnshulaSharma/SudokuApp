﻿using Microsoft.Extensions.Logging;
using SudokuApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuApp.Service
{
    public class SudokuService
    {
        private int[][] board;
        private ILogger logger;
        public int[][] Board
        {
            get
            {
                return board;
            }
        }
        public SudokuService(Puzzle puzzle, ILogger _logger)
        {
            board = puzzle.arrSudoku;
            logger = _logger;

        }
        public bool SolveSudoku()
        {
            try
            {
                int len = board.GetLength(0);
                int row = -1;
                int col = -1;
                bool isEmpty = true;
                for (int i = 0; i < len; i++)
                {
                    for (int j = 0; j < len; j++)
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
                logger.LogError("ERROR Publishing Sudoku Puzzle Solution " + ex.Message);
                return false;

            }
        }
        public bool IsSafe(int row, int col, int num)
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
                logger.LogError("ERROR Validating Number Already Exists in Puzzle " + ex.Message);
                throw;
            }
        }
    }
}
