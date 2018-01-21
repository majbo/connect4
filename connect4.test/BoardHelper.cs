using connect4.lib;
using System.Collections.Generic;

namespace connect4.test
{
    public static class BoardHelper
    {
        public static void SetHorizontally(this Board board, BoardCellState state, int startIndex, int count)
        {
            for (int i = startIndex; i< startIndex + count; i++)
            {
                board.States[i] = state;
            }
        }

        public static void SetVertically(this Board board, BoardCellState state, int startIndex, int count)
        {
            for (int i = 0; i < count; i++)
            {
                board.States[startIndex+i*Board.Columns] = state;
            }
        }

        public static void Set(this Board board, BoardCellState state, IEnumerable<int> indices)
        {
            foreach (int index in indices)
            {
                board.States[index] = state;
            }
        }
    }
}
