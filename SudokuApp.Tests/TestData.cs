using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuApp.Tests
{
    public class TestData
    {
        public int[][] GetValidPuzzle0()
        {
            return new int[][]
            {
                new int[] { 0, 0, 0, 0, 5, 6 },
                new int[] { 0, 0, 2, 0, 3, 0 },
                new int[] { 0, 0, 0, 0, 6, 1 },
                new int[] { 4, 1, 0, 0, 0, 0 },
                new int[] { 0, 3, 0, 6, 0, 0 },
                new int[] { 1, 6, 0, 0, 0, 0 }
            };
        }
        public int[][] GetValidPuzzle1()
        {
            return new int[][]
           {
                new int[] { 3, 6, 0, 0, 0, 5 },
                new int[] { 0, 0, 0, 2, 0, 3 },
                new int[] { 2, 3, 0, 4, 5, 1 },
                new int[] { 5, 0, 0, 3, 2, 0 },
                new int[] { 0, 0, 3, 5, 0, 4 },
                new int[] { 0, 0, 1, 0, 3, 2 }
           };
        }
        public int[][] GetInvalidPuzzle()
        {
            return new int[][]
             {
                new int[] { 6, 0, 0, 0, 5, 6 },
                new int[] { 0, 0, 2, 0, 3, 0 },
                new int[] { 0, 0, 0, 0, 6, 1 },
                new int[] { 4, 1, 0, 0, 0, 0 },
                new int[] { 0, 3, 0, 6, 0, 0 },
                new int[] { 1, 6, 0, 0, 0, 0 }
             };
        }
        public int[][] GetValidPuzzle0Solution()
        {
            return new int[][]
            {
               new int[] { 3, 4, 1, 2, 5, 6 },
               new int[] { 6, 5, 2, 1, 3, 4 },
               new int[] { 5, 2, 3, 4, 6, 1 },
               new int[] { 4, 1, 6, 5, 2, 3 },
               new int[] { 2, 3, 4, 6, 1, 5 },
               new int[] { 1, 6, 5, 3, 4, 2 }
            };
        }
        public int[][] GetValidPuzzle1Solution()
        {
            return new int[][]
            {
               new int[] { 3, 6, 2, 1, 4, 5 },
               new int[] { 1, 4, 5, 2, 6, 3 },
               new int[] { 2, 3, 6, 4, 5, 1 },
               new int[] { 5, 1, 4, 3, 2, 6 },
               new int[] { 6, 2, 3, 5, 1, 4 },
               new int[] { 4, 5, 1, 6, 3, 2 }
            };
        }
        public int[][] GetSmallerPuzzle5x6()
        {
            return new int[][]
          {
                new int[] { 0, 0, 0, 0, 5, 6 },
                new int[] { 0, 0, 2, 0, 3, 0 },
                new int[] { 0, 0, 0, 0, 6, 1 },
                new int[] { 4, 1, 0, 0, 0, 0 },
                new int[] { 0, 3, 0, 6, 0, 0 }
          };
        }
        public int[][] GetGreaterPuzzle6x7()
        {
            return new int[][]
          {
                new int[] { 0, 0, 0, 0, 5, 6, 1 },
                new int[] { 0, 0, 2, 0, 3, 0, 0 },
                new int[] { 0, 0, 0, 0, 6, 1, 2 },
                new int[] { 4, 1, 0, 0, 0, 0, 0 },
                new int[] { 0, 3, 0, 6, 0, 0, 4 },
                new int[] { 1, 6, 0, 0, 0, 0, 0 }
          };
        }
    }
}
