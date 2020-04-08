using System;
using Spire.Xls;
using SudokuApp.Model;

namespace SudokuApp.Repository
{
    public class PuzzleRepository : IPuzzleRepository
    {
        public Puzzle GetPuzzleById(int id)
        {
            Puzzle puzzle = new Puzzle();
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(@"Sudoku 6X6.xlsx");
            Worksheet sheet = workbook.Worksheets[id];
            for (int i = 1; i <= 6; i++)
            {
                puzzle.arrSudoku[i - 1] = new int[6];
                for (int j = 1; j <= 6; j++)
                {
                    puzzle.arrSudoku[i - 1][j - 1] = Convert.ToInt32(sheet.Range[i, j].Value);
                }
            }
            return puzzle;
        }


    }
}
