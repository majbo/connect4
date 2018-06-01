using System;

namespace connect4.lib
{
    public enum BoardCellState
    {
        Empty,
        Blue,
        Red
    }

    public static class BoardCellStateHelper
    {
        public static BoardCellState Invert(this BoardCellState color)
        {
            if (color == BoardCellState.Red)
            {
                return BoardCellState.Blue;
            }
            else if (color == BoardCellState.Blue)
            {
                return BoardCellState.Red;
            }
            throw new InvalidOperationException($"Can't invert BoardCellState '{color}'");
        }
    }
}
