using System;

namespace SudokuApp.Model
{
    public class PuzzleException : Exception
    {     
        public string Code { get; set; }
        public PuzzleException() : base() { }
        public PuzzleException(string message) : base(message)
        {
        }
        public PuzzleException(string message, string code) : base(message)
        {
            Code = code;
        }
    }
}
