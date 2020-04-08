using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuApp.Model
{
    public class Puzzle
    {
        public Puzzle()
        {
            arrSudoku = new int[6][];
        }
       public int[][] arrSudoku { get; set; }
    }
}
