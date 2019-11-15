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

        public char Winner()
        {
            return Steve.ConvertSymbol(_board.Winner());
        }
    }
}