using System.Collections.Generic;

namespace connect4.lib
{
    public class Analyzer
    {
        private Board _board;

        public Analyzer(Board board)
        {
            _board = board;
        }

        public bool HasWon(BoardCellState winnerColor)
        {
            return HasWon(winnerColor, _board.GetRows())
                || HasWon(winnerColor, _board.GetColumns())
                || HasWon(winnerColor, _board.GetLeftDiagonals())
                || HasWon(winnerColor, _board.GetRightDiagonals());
        }

        private bool HasWon(BoardCellState winnerColor, IEnumerable<IEnumerable<BoardCellState>> collection)
        {
            int adjacent = 0;
            foreach (var outer in collection)
            {
                foreach (var inner in outer)
                {
                    if (inner == winnerColor)
                    {
                        adjacent++;
                        if (adjacent == 4)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        adjacent = 0;
                    }
                }
                adjacent = 0;
            }
            return false;
        }
    }
}