namespace connect4.lib
{
    public interface IAnalyzer
    {
        bool HasWon(BoardCellState winnerColor);
    }
}