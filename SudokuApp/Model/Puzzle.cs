namespace SudokuApp.Model
{
    public class Puzzle
    {
        public Puzzle()
        {
            arrSudoku = new int[6][];
        }
        public Puzzle(int[][] puzzle)
        {
            arrSudoku = puzzle;
        }
       public int[][] arrSudoku { get; set; }
    }
}
