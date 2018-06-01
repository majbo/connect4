using connect4.lib;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace connect4.test
{
    public class ConnectedRowTest
    {
        [Fact]
        public void Should_NotBeEqual_WhenNotAConnectedRow()
        {
            //Arrange
            var connectedRow = new ConnectedRow();
            var someObject = new object();

            //Act
            bool areEqual = connectedRow.Equals(someObject);

            //Assert
            Assert.False(areEqual);
        }

        [Fact]
        public void Should_NotBeEqual_WhenStateAreDifferent()
        {
            //Arrange
            var connectedRow = new ConnectedRow
            {
                BoardCellState = BoardCellState.Blue
            };
            var otherConnectedRow = new ConnectedRow
            {
                BoardCellState = BoardCellState.Red
            };

            //Act
            bool areEqual = connectedRow.Equals(otherConnectedRow);

            //Assert
            Assert.False(areEqual);
        }
    }
}
