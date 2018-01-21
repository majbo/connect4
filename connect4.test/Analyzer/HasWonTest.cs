using connect4.lib;
using System.Collections.Generic;
using Xunit;

namespace connect4.test
{
    public class HasWonTest
    {
        private static readonly BoardCellState WinnerColor = BoardCellState.Blue;

        public static IEnumerable<object[]> GetHorizontallyWinnerBoards()
        {
            var board1 = new Board();
            board1.SetHorizontally(WinnerColor, 37, 4);
            yield return new object[] { board1 };

            var board2 = new Board();
            board2.SetHorizontally(WinnerColor, 1, 5);
            yield return new object[] { board2 };

            var board3 = new Board();
            board3.SetVertically(WinnerColor, 10, 4);
            board3.SetHorizontally(WinnerColor, 22, 5);
            yield return new object[] { board3 };
        }

        [Theory]
        [MemberData(nameof(GetHorizontallyWinnerBoards))]
        public void Should_BeWon_When_FourInARowHorizontally(Board board)
        {
            //Arrange
            var analyzer = new Analyzer(board);

            //Act
            bool isWon = analyzer.HasWon(WinnerColor);

            //Assert
            Assert.True(isWon);
        }

        [Fact]
        public void Should_NotBeWon_When_Empty()
        {
            //Arrange
            var analyzer = new Analyzer(new Board());

            //Act
            bool isWon = analyzer.HasWon(WinnerColor);

            //Assert
            Assert.False(isWon);
        }

        [Fact]
        public void Should_NotBeWon_When_FourSideBySideInTwoRows()
        {
            //Arrange
            var board = new Board();
            board.SetHorizontally(WinnerColor, 12, 4);
            var analyzer = new Analyzer(board);

            //Act
            bool isWon = analyzer.HasWon(WinnerColor);

            //Assert
            Assert.False(isWon);
        }

        public static IEnumerable<object[]> GetVerticallyWinnerBoards()
        {
            var board1 = new Board();
            board1.SetVertically(WinnerColor, 1, 4);
            yield return new object[] { board1 };

            var board2 = new Board();
            board2.SetVertically(WinnerColor, 1, 5);
            yield return new object[] { board2 };
        }

        [Theory]
        [MemberData(nameof(GetVerticallyWinnerBoards))]
        public void Should_BeWon_When_FourInARowVertically(Board board)
        {
            //Arrange
            var analyzer = new Analyzer(board);

            //Act
            bool isWon = analyzer.HasWon(WinnerColor);

            //Assert
            Assert.True(isWon);
        }

        public static IEnumerable<object[]> GetDiagonallyWinnerBoards()
        {
            var board1 = new Board();
            board1.Set(WinnerColor, new int[] { 0, 8, 16, 24 });
            yield return new object[] { board1 };

            var board2 = new Board();
            board2.Set(WinnerColor, new int[] { 9, 17, 25, 33, 41 });
            yield return new object[] { board2 };

            var board3 = new Board();
            board3.Set(WinnerColor, new int[] { 3, 9, 15, 21 });
            yield return new object[] { board3 };

            var board4 = new Board();
            board4.Set(WinnerColor, new int[] { 6, 12, 18, 24, 30, 36 });
            yield return new object[] { board4 };
        }

        [Theory]
        [MemberData(nameof(GetDiagonallyWinnerBoards))]
        public void Should_BeWon_When_FourAdjacentADiagonally(Board board)
        {
            //Arrange
            var analyzer = new Analyzer(board);

            //Act
            bool isWon = analyzer.HasWon(WinnerColor);

            //Assert
            Assert.True(isWon);
        }
    }
}
