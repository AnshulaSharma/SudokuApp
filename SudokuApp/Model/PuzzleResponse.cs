using System;

namespace SudokuApp.Model
{
    public class PuzzleResponse : IEquatable<PuzzleResponse>
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public int[][] Result { get; set; }

        public PuzzleResponse(string status, string message, int[][] result)
        {
            Status = status;
            Message = message;
            Result = result;
        }

        public bool Equals(PuzzleResponse other)
        {
            return Status == other.Status && Message == other.Message&& Result.AreEqual(other.Result);
        }

    }
    
}
