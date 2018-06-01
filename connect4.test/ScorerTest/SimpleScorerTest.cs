using connect4.lib;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace connect4.test.ScorerTest
{
    public class SimpleScorerTest
    {
        [Fact]
        public void Should_BeMax_WhenWon()
        {
            BoardCellState winningColor = BoardCellState.Blue;
            var analyzerMock = new Mock<IAnalyzer>();
            analyzerMock.Setup(a => a.HasWon(winningColor)).Returns(true);
            analyzerMock.Setup(a => a.HasWon(winningColor.Invert())).Returns(false);
            var simpleScorer = new SimpleScorer();

            int score = simpleScorer.GetScore(analyzerMock.Object, winningColor);

            Assert.Equal(SimpleScorer.Maximum, score);
        }

        [Fact]
        public void Should_BeMin_WhenLost()
        {
            BoardCellState winningColor = BoardCellState.Blue;
            var analyzerMock = new Mock<IAnalyzer>();
            analyzerMock.Setup(a => a.HasWon(winningColor)).Returns(false);
            analyzerMock.Setup(a => a.HasWon(winningColor.Invert())).Returns(true);
            var simpleScorer = new SimpleScorer();

            int score = simpleScorer.GetScore(analyzerMock.Object, winningColor);

            Assert.Equal(SimpleScorer.Minimum, score);
        }

        [Fact]
        public void Should_BeZero_WhenNobodyWon()
        {
            BoardCellState winningColor = BoardCellState.Blue;
            var analyzerMock = new Mock<IAnalyzer>();
            analyzerMock.Setup(a => a.HasWon(winningColor)).Returns(false);
            analyzerMock.Setup(a => a.HasWon(winningColor.Invert())).Returns(false);
            var simpleScorer = new SimpleScorer();

            int score = simpleScorer.GetScore(analyzerMock.Object, winningColor);

            Assert.Equal(0, score);
        }
    }
}
