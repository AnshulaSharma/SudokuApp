using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SudokuApp.Model;
using SudokuApp.Repository;
using SudokuApp.Service;
using System;

namespace SudokuApp.Controllers
{
    [Route("[controller]")]
    public class SudokuController : Controller
    {
        private ILogger<SudokuController> _logger;
        private IPuzzleService sudokuService;
        private IPuzzleRepository puzzlerepository;
        public SudokuController(ILogger<SudokuController> logger, IPuzzleService service, IPuzzleRepository repository)
        {
            _logger = logger;
            sudokuService = service;
            puzzlerepository = repository;
        }

        [Route("create")]
        [HttpGet]
        public ActionResult<Puzzle> Create()
        {
            Random random = new Random();
            Puzzle puzzle = puzzlerepository.GetPuzzleById(random.Next(1, 10));
            return puzzle;

        }

        [Route("solution")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PuzzleResponse> Solution([FromBody]Puzzle sudokuPuzzle)
        {
            PuzzleResponse response;
            int[][] result = sudokuService.GetSolvedSudoku(sudokuPuzzle.arrSudoku);
            if (result != null)
            {
                response = new PuzzleResponse(Utility.Constants.OK, Utility.Constants.SuccessMessage, result);
            }
            else
            {
                response = new PuzzleResponse(Utility.Constants.OK, Utility.Constants.FailureMessage, result);
            }
            return response;
        }

    }
}