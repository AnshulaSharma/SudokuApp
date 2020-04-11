using System;

namespace SudokuApp.Model
{
    public static class Extension
    {
        public static bool AreEqual(this int[][] a, int[][] b)
        {
            if (a == null && b == null)
                return true;
            if (a.Length != b.Length)
                return false;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(0); j++)
                {
                    if (a[i][j] != b[i][j])
                        return false;
                }
            }
            return true;
        }
    }
}
