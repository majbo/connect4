using System;

namespace connect4.lib
{
    public enum BoardCellState
    {
        Empty,
        Blue,
        Red
    }

    public class Board
    {
        private BoardCellState[] _states = new BoardCellState[42];

        public BoardCellState[] States { get => _states; }


        public override string ToString()
        {
            string s = "";
            int index;
            for (int row = 0; row < 6; row++)
            {
                s += Environment.NewLine;
                s += "--------------";
                s += Environment.NewLine;
                for (int col = 0; col < 7; col++)
                {
                    index = row * 7 + col;
                    switch(_states[index])
                    {
                        case BoardCellState.Empty:
                            s += "| ";
                            break;
                        case BoardCellState.Blue:
                            s += "|X";
                            break;
                        case BoardCellState.Red:
                            s += "|O";
                            break;
                    }
                }
      

            }
            s += Environment.NewLine;
            s += "--------------";

            return s;
        }
    }
}
