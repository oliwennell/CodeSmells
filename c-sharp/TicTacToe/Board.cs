using System.Linq;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Board
    {
       private List<Tile> _plays = new List<Tile>();

        public Board()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _plays.Add(new Tile{ X = i, Y = j, Symbol = Symbol.Empty});
                }  
            }       
        }

       public Tile TileAt(int x, int y)
       {
           return _plays.Single(tile => tile.X == x && tile.Y == y);
       }

       public bool IsEmptyTile(int x, int y)
       {
           return TileAt(x,y).Symbol == Symbol.Empty;
       }

       public void AddTileAt(Tile tile)
       {
           TileAt(tile.X, tile.Y).Symbol = tile.Symbol;
       }
    }
}