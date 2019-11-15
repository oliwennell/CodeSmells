namespace TicTacToe
{
    public class Board
    {
       private readonly Symbol[][] _plays2 = new []
       {
           new [] { Symbol.Empty, Symbol.Empty, Symbol.Empty },
           new [] { Symbol.Empty, Symbol.Empty, Symbol.Empty },
           new [] { Symbol.Empty, Symbol.Empty, Symbol.Empty }
       };

        public Symbol TileAt(int x, int y) => _plays2[y][x];

        public bool IsEmptyTile(int x, int y) => TileAt(x, y) == Symbol.Empty;

        public void AddTileAt(Symbol symbol, int x, int y) => _plays2[y][x] = symbol;
    }
}