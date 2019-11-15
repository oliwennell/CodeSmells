namespace TicTacToe
{
    public class Board
    {
        private readonly Symbol[][] _plays = new []
        {
            new [] { Symbol.Empty, Symbol.Empty, Symbol.Empty },
            new [] { Symbol.Empty, Symbol.Empty, Symbol.Empty },
            new [] { Symbol.Empty, Symbol.Empty, Symbol.Empty }
        };

        public Symbol TileAt(int x, int y) => _plays[y][x];

        public bool IsEmptyTile(int x, int y) => TileAt(x, y) == Symbol.Empty;

        public void AddTileAt(Symbol symbol, int x, int y) => _plays[y][x] = symbol;


        public Symbol Winner()
        {
            for (var column = 0; column < 3; ++column)
            {
                if (CheckWinningRow(column))
                {
                    return TileAt(column, 0);
                }
            }

            return Symbol.Empty;
        }

        private bool CheckWinningRow(int rowNumber)
        {
            var firstSymbol = TileAt(rowNumber, 0);
            var secondSymbol = TileAt(rowNumber, 1);
            var thirdSymbol = TileAt(rowNumber, 2);

            if (firstSymbol != Symbol.Empty)
            {
                return firstSymbol == secondSymbol &&
                       thirdSymbol == secondSymbol;
            }

            return false;
        }
    }
}