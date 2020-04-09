using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SudokuApp.Model;
using SudokuApp.Repository;
using SudokuApp.Service;
using SudokuApp.Utility;
using System;

namespace SudokuApp.Controllers
{
    [Route("[controller]")]
    public class SudokuController : Controller
    {
        private readonly ILogger<SudokuController> _logger;
        private readonly IPuzzleService _sudokuService;
        private readonly IPuzzleRepository _puzzlerepository;
        public SudokuController(ILogger<SudokuController> logger, IPuzzleService service, IPuzzleRepository repository)
        {
            _logger = logger;
            _sudokuService = service;
            _puzzlerepository = repository;
        }

        [Route("create")]
        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                Random random = new Random();
                Puzzle puzzle = _puzzlerepository.GetPuzzleById(random.Next(1, 10));
                return Ok(puzzle);
            }
            catch (PuzzleException ex)
            {
                PuzzleResponse response = new PuzzleResponse(ex.Code, ex.Message, null);
                return Ok(response);
            }
        }

        [Route("solution")]
        [HttpPost]
        public ActionResult<PuzzleResponse> Solution([FromBody]Puzzle sudokuPuzzle)
        {

            PuzzleResponse response;
            try
            {
                int[][] result = _sudokuService.GetSolvedSudoku(sudokuPuzzle.arrSudoku);
                if (result != null)
                {
                    response = new PuzzleResponse(Constants.Code.OK, Utility.Constants.Message.Success, result);
                }
                else
                {
                    response = new PuzzleResponse(Constants.Code.OK, Utility.Constants.Message.SolutionNotFound, result);
                }
                return response;
            }
            catch (PuzzleException ex)
            {
                response = new PuzzleResponse(ex.Code, ex.Message, null);
                return response;
            }
        }

    }
}