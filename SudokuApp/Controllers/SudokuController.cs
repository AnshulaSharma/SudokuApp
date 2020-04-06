using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SudokuApp.Model;

namespace SudokuApp.Controllers
{
    [Route("[controller]")]
    public class SudokuController : Controller
    {
      
        [Route("solution")]
        [HttpPost]
        public void Solution([FromBody] Puzzle sudokuPuzzle)
        {
            try
            {
              
            }
            catch
            {
        
            }
        }

    }
}