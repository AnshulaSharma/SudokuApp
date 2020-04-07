using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SudokuApp.Model;
using SudokuApp.Service;
using SudokuApp.Utility;
using System;

namespace SudokuApp.Controllers
{
    [Route("[controller]")]
    public class SudokuController : Controller
    {
        private readonly ILogger<SudokuController> _logger;
        public SudokuController(ILogger<SudokuController> logger)
        {
            _logger = logger;
        }

        [Route("solution")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PuzzleResponse> Solution([FromBody] Puzzle sudokuPuzzle)
        {

            PuzzleResponse response;
            SudokuService serviceObj = new SudokuService(sudokuPuzzle, _logger);
            if (serviceObj.SolveSudoku())
            {
                response = new PuzzleResponse(Constants.OK, Constants.SuccessMessage, serviceObj.Board);

            }
            else
            {
                response = new PuzzleResponse(Constants.OK, Constants.FailureMessage, serviceObj.Board);
            }
            return response;


        }

    }
}