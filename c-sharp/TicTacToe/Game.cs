namespace TicTacToe
{
    public class Game
    {
        private Symbol _lastSymbol = Symbol.Empty;
        private readonly Board _board = new Board();

        public void Play(char symbol, int x, int y)
        {
            var symbolAsEnum = Steve.ConvertSymbol(symbol);
            var play = new Play(symbolAsEnum, x, y);
            play.Validate(_lastSymbol, _board);

            UpdateGameState(symbolAsEnum, x, y);
        }

        private void UpdateGameState(Symbol symbol, int x, int y)
        {
            _lastSymbol = symbol;
            _board.AddTileAt(symbol, x, y);
        }

        private bool CheckWinningRow(int rowNumber)
        {
            var firstSymbol = _board.TileAt(rowNumber, 0);
            var secondSymbol = _board.TileAt(rowNumber, 1);
            var thirdSymbol = _board.TileAt(rowNumber, 2);

            if (firstSymbol != Symbol.Empty)
            {
                return firstSymbol == secondSymbol &&
                       thirdSymbol == secondSymbol;
            }

            return false;
        }

        public char Winner()
        {
            for (var column = 0; column < 3; ++column)
            {
                if (CheckWinningRow(column))
                {
                    return Steve.ConvertSymbol(_board.TileAt(column, 0));
                }
            }

            return Steve.ConvertSymbol(Symbol.Empty);
        }
    }
}