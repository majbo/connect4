using System;
using System.Collections.Generic;

namespace connect4.lib
{
    public class Board
    {
        public const int Size = 42;
        public const int Columns = 7;
        public const int Rows = 6;

        private BoardCellState[] _states = new BoardCellState[42];

        public BoardCellState[] States { get => _states; }

        public IEnumerable<IEnumerable<BoardCellState>> GetRows()
        {
            for (int i = 0; i < Rows; i++)
            {
                yield return new BoardCellState[] { _states[i * 7], _states[1 + i * 7], _states[2 + i * 7], _states[3 + i * 7], _states[4 + i * 7], _states[5 + i * 7], _states[6 + i * 7] };
            }
        }

        public bool PutCoint(BoardCellState state, int columnToPut)
        {
            for (int i = columnToPut + 35; i >= columnToPut; i -= 7)
            {
                if (_states[i] == BoardCellState.Empty)
                {
                    _states[i] = state;
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<IEnumerable<BoardCellState>> GetColumns()
        {
            for (int i = 0; i < Columns; i++)
            {
                yield return new BoardCellState[] { _states[i], _states[i + 7], _states[i + 14], _states[i + 21], _states[i + 28], _states[i + 35] };
            }
        }

        public IEnumerable<IEnumerable<BoardCellState>> GetRightDiagonals()
        {
            yield return new BoardCellState[] { _states[0], _states[8], _states[16], _states[24], _states[32], _states[40] };
            yield return new BoardCellState[] { _states[1], _states[9], _states[17], _states[25], _states[33], _states[41] };
            yield return new BoardCellState[] { _states[2], _states[10], _states[18], _states[26], _states[34] };
            yield return new BoardCellState[] { _states[3], _states[11], _states[19], _states[27] };
            yield return new BoardCellState[] { _states[7], _states[15], _states[23], _states[31], _states[39] };
            yield return new BoardCellState[] { _states[14], _states[22], _states[30], _states[38] };
        }

        public IEnumerable<IEnumerable<BoardCellState>> GetLeftDiagonals()
        {
            yield return new BoardCellState[] { _states[3], _states[9], _states[15], _states[21] };
            yield return new BoardCellState[] { _states[4], _states[10], _states[16], _states[22], _states[28], };
            yield return new BoardCellState[] { _states[5], _states[11], _states[17], _states[23], _states[29], _states[35] };
            yield return new BoardCellState[] { _states[6], _states[12], _states[18], _states[24], _states[30], _states[36] };
            yield return new BoardCellState[] { _states[13], _states[19], _states[25], _states[31], _states[37] };
            yield return new BoardCellState[] { _states[20], _states[26], _states[32], _states[38] };
        }

        public override string ToString()
        {
            string s = "";
            int index;
            for (int row = 0; row < Rows; row++)
            {
                s += Environment.NewLine;
                s += "---------------";
                s += Environment.NewLine;
                for (int col = 0; col < Columns; col++)
                {
                    index = row * 7 + col;
                    switch (_states[index])
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
                s += "|";
            }
            s += Environment.NewLine;
            s += "---------------";

            return s;
        }
    }
}
