using connect4.lib;
using System;

namespace connect4.app
{
    class Program
    {
        static void Main(string[] args)
        {
            var board1 = new Board();
            board1.States[37] = BoardCellState.Blue;
            board1.States[38] = BoardCellState.Red;
            board1.States[41] = BoardCellState.Blue;

            Console.WriteLine(board1);


            Console.ReadLine();
        }
    }
}
