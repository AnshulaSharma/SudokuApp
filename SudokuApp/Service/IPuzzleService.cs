namespace SudokuApp.Service
{
    public interface IPuzzleService
    {
        public int[][] GetSolvedSudoku6x6(int[][] puzzle);
    }
}
