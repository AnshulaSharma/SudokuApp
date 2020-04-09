﻿using System;

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
            if (Result == null && other.Result == null)
                return true;
            if (Result.Length != other.Result.Length)
                return false;
            for (int i = 0; i < Result.Length; i++)
            {
                for (int j = 0; j < Result.Length; j++)
                {
                    if (Result[i][j] != other.Result[i][j])
                        return false;
                }
            }
            return Status == other.Status && Message == other.Message;
        }

    }
}
