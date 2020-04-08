using SudokuApp.Model;

namespace SudokuApp.Repository
{
    public interface IPuzzleRepository
    {
        public Puzzle GetPuzzleById(int id);
    }
}
