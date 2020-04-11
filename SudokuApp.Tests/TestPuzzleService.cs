using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SudokuApp.Model;
using SudokuApp.Service;
using System;
using System.Linq;

namespace SudokuApp.Tests
{
    [TestClass]
    public class TestPuzzleService
    {
        PuzzleService sut;
        ILogger<PuzzleService> logger;
        Mock<ILogger<PuzzleService>> mockLogger;
        readonly TestData testData = new TestData();

        [TestMethod]
        public void WhenPuzzleIsSmaller_ShouldReturnNoSolution()
        {
            mockLogger = new Mock<ILogger<PuzzleService>>();
            logger = mockLogger.Object;
            sut = new PuzzleService(logger);
            var actualResult = sut.GetSolvedSudoku6x6(testData.GetSmallerPuzzle5x6());
            var expectedResult = (int[][])null;
            Assert.AreEqual(expectedResult,actualResult);
        }
        [TestMethod]
        public void WhenPuzzleIsGreater_ShouldReturnNoSolution()
        {
            mockLogger = new Mock<ILogger<PuzzleService>>();
            logger = mockLogger.Object;
            sut = new PuzzleService(logger);
            var actualResult = sut.GetSolvedSudoku6x6(testData.GetGreaterPuzzle6x7());
            var expectedResult = (int[][])null;
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void WhenPuzzleIsInvalid_ShouldReturnNoSolution()
        {
            mockLogger = new Mock<ILogger<PuzzleService>>();
            logger = mockLogger.Object;
            sut = new PuzzleService(logger);
            var actualResult = sut.GetSolvedSudoku6x6(testData.GetInvalidPuzzle());
            var expectedResult = (int[][])null;
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void WhenPuzzleIsValid_ShouldReturnCorrectSolution()
        {
            mockLogger = new Mock<ILogger<PuzzleService>>();
            logger = mockLogger.Object;
            sut = new PuzzleService(logger);
            Int32[][] actualResult = sut.GetSolvedSudoku6x6(testData.GetValidPuzzle0());
            Int32[][] expectedResult = testData.GetValidPuzzle0Solution();
            Assert.IsTrue(actualResult.AreEqual(expectedResult));

        }
    }
   
}
