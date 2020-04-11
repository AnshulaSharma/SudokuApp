using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SudokuApp.Controllers;
using SudokuApp.Model;
using SudokuApp.Repository;
using SudokuApp.Service;
using SudokuApp.Utility;

namespace SudokuApp.Tests
{
    [TestClass]
    public class TestSudokuController
    {
        SudokuController sut;
        ILogger<SudokuController> logger;
        IPuzzleService service;
        IPuzzleRepository repository;
        Mock<ILogger<SudokuController>> mockLogger;
        Mock<IPuzzleService> mockService;
        Mock<IPuzzleRepository> mockRepository;
        readonly TestData testData = new TestData();

        [TestMethod]
        public void CreatePuzzle_ShouldReturnNotNullObject()
        {
            mockLogger = new Mock<ILogger<SudokuController>>();
            logger = mockLogger.Object;
            mockService = new Mock<IPuzzleService>();
            service = mockService.Object;
            mockRepository = new Mock<IPuzzleRepository>();
            mockRepository.Setup(x => x.GetPuzzleById(0))
                .Returns(new Puzzle(testData.GetValidPuzzle0()
            ));
            repository = mockRepository.Object;
            sut = new SudokuController(logger, service, repository);
            var actualResult = sut.CreatePuzzle(0);
            Assert.IsNotNull(actualResult);
        }

        [TestMethod]
        public void CreatePuzzle_ShouldReturnPuzzleResponseObject()
        {
            mockLogger = new Mock<ILogger<SudokuController>>();
            logger = mockLogger.Object;
            mockService = new Mock<IPuzzleService>();
            service = mockService.Object;
            mockRepository = new Mock<IPuzzleRepository>();
            repository = mockRepository.Object;
            sut = new SudokuController(logger, service, repository);
            var actualResult = sut.CreatePuzzle(0);
            Assert.IsInstanceOfType(actualResult, typeof(ActionResult<PuzzleResponse>));
        }

        [TestMethod]
        public void CreatePuzzle_ShouldReturnPuzzleForId0()
        {
            mockLogger = new Mock<ILogger<SudokuController>>();
            logger = mockLogger.Object;
            mockService = new Mock<IPuzzleService>();
            service = mockService.Object;
            mockRepository = new Mock<IPuzzleRepository>();
            mockRepository.Setup(x => x.GetPuzzleById(0))
                .Returns(new Puzzle(testData.GetValidPuzzle0()
            ));
            repository = mockRepository.Object;
            sut = new SudokuController(logger, service, repository);
            var actualResult = sut.CreatePuzzle(0);
            var expectedResult = new PuzzleResponse(Constants.Code.OK, Constants.Message.Success, testData.GetValidPuzzle0());
            Assert.AreEqual(expectedResult.Equals(actualResult.Value), true);
        }

        [TestMethod]
        public void Solution_ShouldReturnNotNullObject()
        {
            mockLogger = new Mock<ILogger<SudokuController>>();
            logger = mockLogger.Object;
            mockService = new Mock<IPuzzleService>();
            mockService.Setup(x => x.GetSolvedSudoku6x6(testData.GetValidPuzzle1()))
              .Returns(testData.GetValidPuzzle1Solution());
            service = mockService.Object;
            mockRepository = new Mock<IPuzzleRepository>();
            repository = mockRepository.Object;
            sut = new SudokuController(logger, service, repository);
            var actualResult = sut.Solution(new Puzzle(testData.GetValidPuzzle1Solution()));
            Assert.IsNotNull(actualResult);
        }

        [TestMethod]
        public void Solution_ShouldReturnPuzzleResponseObject()
        {
            mockLogger = new Mock<ILogger<SudokuController>>();
            logger = mockLogger.Object;
            mockService = new Mock<IPuzzleService>();
            mockService.Setup(x => x.GetSolvedSudoku6x6(testData.GetValidPuzzle1()))
              .Returns(testData.GetValidPuzzle1Solution());
            service = mockService.Object;
            mockRepository = new Mock<IPuzzleRepository>();
            repository = mockRepository.Object;
            sut = new SudokuController(logger, service, repository);
            var actualResult = sut.Solution(new Puzzle(testData.GetValidPuzzle1()));
            Assert.IsInstanceOfType(actualResult, typeof(ActionResult<PuzzleResponse>));
        }

        [TestMethod]
        public void Solution_ShouldReturnCorrectPuzzleForId0()
        {
            mockLogger = new Mock<ILogger<SudokuController>>();
            logger = mockLogger.Object;
            var puzzle = testData.GetValidPuzzle0();
            mockService = new Mock<IPuzzleService>();
            mockService.Setup(x => x.GetSolvedSudoku6x6(puzzle))
              .Returns(testData.GetValidPuzzle0Solution());
            service = mockService.Object;
            mockRepository = new Mock<IPuzzleRepository>();
            repository = mockRepository.Object;
            sut = new SudokuController(logger, service, repository);
            var actualResult = sut.Solution(new Puzzle(puzzle));
            var expectedResult = new PuzzleResponse(Constants.Code.OK, Constants.Message.Success, testData.GetValidPuzzle0Solution()); 
            Assert.AreEqual(expectedResult.Equals(actualResult.Value), true);
        }

        [TestMethod]
        public void Solution_ShouldReturnNoSolutionForInvalidPuzzle()
        {
            mockLogger = new Mock<ILogger<SudokuController>>();
            logger = mockLogger.Object;
            var puzzle = testData.GetInvalidPuzzle();
            mockService = new Mock<IPuzzleService>();
            mockService.Setup(x => x.GetSolvedSudoku6x6(puzzle))
              .Returns((int[][])null);
            service = mockService.Object;
            mockRepository = new Mock<IPuzzleRepository>();
            repository = mockRepository.Object;
            sut = new SudokuController(logger, service, repository);
            var actualResult = sut.Solution(new Puzzle(puzzle));
            var expectedResult = new PuzzleResponse(Constants.Code.OK, Constants.Message.SolutionNotFound, null); 
            Assert.AreEqual(expectedResult.Equals(actualResult.Value), true);
        }
    }
}
