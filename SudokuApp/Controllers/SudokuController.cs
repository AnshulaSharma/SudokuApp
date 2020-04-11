using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SudokuApp.Model;
using SudokuApp.Repository;
using SudokuApp.Service;
using SudokuApp.Utility;

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

        [HttpGet]
        public ViewResult Startup()
        {
            return View();
        }

        [Route("puzzle/{id}")]
        [HttpGet]
        public ActionResult<PuzzleResponse> CreatePuzzle(int id)
        {
            PuzzleResponse response;
            try
            {
                Puzzle puzzle = _puzzlerepository.GetPuzzleById(id);
                if (puzzle != null)
                {
                    response = new PuzzleResponse(Constants.Code.OK, Constants.Message.Success, puzzle.arrSudoku);
                    return response;
                }
                else
                {
                    throw new PuzzleException(Constants.Message.InternalServerError, Constants.Code.Error);
                }
            }
            catch (PuzzleException ex)
            {
                _logger.LogError("ERROR " + ex.Message);
                response = new PuzzleResponse(ex.Code, ex.Message, null);
                return response;
            }
        }

        [Route("solution")]
        [HttpPost]
        public ActionResult<PuzzleResponse> Solution([FromBody]Puzzle sudokuPuzzle)
        {
            PuzzleResponse response;
            try
            {
                if (sudokuPuzzle != null)
                {
                    int[][] result = _sudokuService.GetSolvedSudoku6x6(sudokuPuzzle.arrSudoku);
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
                else
                    throw new PuzzleException(Constants.Message.IncorrectInput, Constants.Code.Error);
            }
            catch (PuzzleException ex)
            {
                _logger.LogInformation("ERROR " + ex.Message);
                response = new PuzzleResponse(ex.Code, ex.Message, null);
                return response;
            }
        }

    }
}