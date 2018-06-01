using System;
using System.Collections.Generic;
using System.Text;

namespace connect4.lib
{
    public class SimpleScorer
    {
        public const int Minimum = -10;
        public const int Maximum = 10;

        public int GetScore(IAnalyzer analyzer, BoardCellState color)
        {
            if (analyzer.HasWon(color))
            {
                return Maximum;
            }
            else if (analyzer.HasWon(color.Invert()))
            {
                return Minimum;
            }
            return 0;
        }
    }
}
