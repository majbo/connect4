using connect4.lib;
using System;
using System.Linq;
using Xunit;

namespace connect4.test.BoardTest
{
    public class PutCoinTest
    {
        Board _board;

        public PutCoinTest()
        {
            _board = new Board();
            _board.Set(BoardCellState.Red, 0);
            _board.SetHorizontally(BoardCellState.Red, 7, 2);
            _board.SetHorizontally(BoardCellState.Red, 14, 3);
            _board.SetHorizontally(BoardCellState.Red, 21, 4);
            _board.SetHorizontally(BoardCellState.Red, 28, 5);
            _board.SetHorizontally(BoardCellState.Red, 35, 6);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 9)]
        [InlineData(3, 17)]
        [InlineData(4, 25)]
        [InlineData(5, 33)]
        [InlineData(6, 41)]
        public void Should_BePut_WhenNotFull(int columnToPut, int expectedIndex)
        {
            bool coinPut = _board.PutCoint(BoardCellState.Blue, columnToPut);

            Assert.True(coinPut);
            Assert.Equal(BoardCellState.Blue, _board.States[expectedIndex]);
            Assert.Equal(1, _board.States.Count(s => s == BoardCellState.Blue));
            Assert.Equal(21, _board.States.Count(s => s == BoardCellState.Red));
        }

        [Fact]
        public void Should_NotBePut_WhenFull()
        {
            bool coinPut = _board.PutCoint(BoardCellState.Blue, 0);

            Assert.False(coinPut);
            Assert.Equal(0, _board.States.Count(s => s == BoardCellState.Blue));
            Assert.Equal(21, _board.States.Count(s => s == BoardCellState.Red));
        }
    }
}
