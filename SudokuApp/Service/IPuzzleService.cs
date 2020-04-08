namespace SudokuApp.Service
{
    public interface IPuzzleService
    {
        public int[][] GetSolvedSudoku(int[][] puzzle);
    }
}
