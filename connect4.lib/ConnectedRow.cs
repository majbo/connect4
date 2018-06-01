using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace connect4.lib
{
    public class ConnectedRow
    {
        public BoardCellState BoardCellState { get; set; }

        public IEnumerable<int> Indices { get; set; }

        public override bool Equals(object obj)
        {
            var compary = obj as ConnectedRow;
            if (compary == null
                || compary.BoardCellState != BoardCellState
                || (compary.Indices == null && Indices != null)
                || (compary.Indices != null && Indices == null)) return false;

            if (compary.Indices == null) return true;

            var comparyArray = compary.Indices.ToArray();
            var array = Indices.ToArray();
            if (comparyArray.Length != array.Length) return false;

            for (int i=0; i<array.Length; i++)
            {
                if (comparyArray[i] != array[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
