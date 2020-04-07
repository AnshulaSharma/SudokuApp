using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SudokuApp.Controllers;
using SudokuApp.Model;
using SudokuApp.Utility;

namespace SudokuApp.Tests
{
    [TestClass]
    public class TestSudokuController
    {
        [TestMethod]
        public void Solution_ShouldReturnPuzzleResponseObject()
        {

            var mock = new Mock<ILogger<SudokuController>>();
            ILogger<SudokuController> logger = mock.Object;
            var controller = new SudokuController(logger);
            var testPuzzle = GetPuzzleInputCorrect();
            var result = controller.Solution(testPuzzle);
            Assert.IsInstanceOfType(result, typeof(ActionResult<PuzzleResponse>));
        }

        [TestMethod]
        public void Solution_ShouldReturnCorrectSolution()
        {

            var mock = new Mock<ILogger<SudokuController>>();
            ILogger<SudokuController> logger = mock.Object;
            var controller = new SudokuController(logger);
            var testPuzzle = GetPuzzleInputCorrect();
            var result = controller.Solution(testPuzzle);
            var actualResult = new PuzzleResponse(Constants.OK,
                                                   Constants.SuccessMessage,
                                                    new int[][] { new int[] { 3, 4, 1, 2, 5, 6 },
                                                    new int[] { 6, 5, 2, 1, 3, 4 },
                                                    new int[] { 5, 2, 3, 4, 6, 1 },
                                                    new int[] { 4, 1, 6, 5, 2, 3 },
                                                    new int[] { 2, 3, 4, 6, 1, 5 },
                                                    new int[] { 1, 6, 5, 3, 4, 2 }
                                                    });

            Assert.AreEqual(actualResult.Equals(result.Value), true);
        }


        [TestMethod]
        public void Solution_ShouldReturnNoSolution()
        {
            var mock = new Mock<ILogger<SudokuController>>();
            ILogger<SudokuController> logger = mock.Object;
            var controller = new SudokuController(logger);
            var testPuzzle = GetPuzzleInputIncorrect();
            var result = controller.Solution(testPuzzle);
            var actualResult = new PuzzleResponse(Constants.OK,
                                                  Constants.FailureMessage,
                                                  testPuzzle.arrSudoku);  

            Assert.AreEqual(actualResult.Equals(result.Value), true);

        }

        private Puzzle GetPuzzleInputCorrect()
        {
            var testPuzzle = new Puzzle();
            testPuzzle.arrSudoku = new int[][]{
                new int[] { 0, 0, 0, 0, 5, 6 },
                new int[] { 0, 0, 2, 0, 3, 0 },
                new int[] { 0, 0, 0, 0, 6, 1 },
                new int[] { 4, 1, 0, 0, 0, 0 },
                new int[] { 0, 3, 0, 6, 0, 0 },
                new int[] { 1, 6, 0, 0, 0, 0 }
            };
            return testPuzzle;
        }
        private Puzzle GetPuzzleInputIncorrect()
        {
            var testPuzzle = new Puzzle();
            testPuzzle.arrSudoku = new int[][]{
                new int[] { 6, 0, 0, 0, 5, 6 },
                new int[] { 0, 0, 2, 0, 3, 0 },
                new int[] { 0, 0, 0, 0, 6, 1 },
                new int[] { 4, 1, 0, 0, 0, 0 },
                new int[] { 0, 3, 0, 6, 0, 0 },
                new int[] { 1, 6, 0, 0, 0, 0 }
            };
            return testPuzzle;
        }

    }
}
