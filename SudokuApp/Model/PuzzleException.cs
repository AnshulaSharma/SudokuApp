using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuApp.Model
{
    public class PuzzleException: Exception
    {
        public string Code;
        public PuzzleException(string message, string code) : base(message)
        {
            Code = code;
        }
    }
}
