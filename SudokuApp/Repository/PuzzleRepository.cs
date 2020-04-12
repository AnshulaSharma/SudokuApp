using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Spire.Xls;
using SudokuApp.Model;
using SudokuApp.Utility;

namespace SudokuApp.Repository
{
    public class PuzzleRepository : IPuzzleRepository
    {
        ILogger<PuzzleRepository> _logger;
        Workbook workbook;
        public PuzzleRepository(ILogger<PuzzleRepository> logger)
        {
            _logger = logger;
            workbook = new Workbook();
        }
        public Puzzle GetPuzzleById(int id)
        {
            try
            {
                Puzzle puzzle = new Puzzle();
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
            catch(Exception ex)
            {
                _logger.LogError("ERROR "+Constants.Message.InternalServerError + ex.Message);
                throw new PuzzleException(Constants.Message.InternalServerError, Constants.Code.Error);
            }
        }
    }
}
