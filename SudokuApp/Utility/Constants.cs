using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuApp.Utility
{
    public class Constants
    {
        public class Code
        {
            public const string OK = "2000";
            public const string Error = "5000";
        }
        public class Message
        {
            public const string Success = "Success";
            public const string SolutionNotFound = "Solution not found";
            public const string InternalServerError = "Please try after some time";
        }
    }
}
