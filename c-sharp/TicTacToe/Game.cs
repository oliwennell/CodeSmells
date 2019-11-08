using System;

namespace TicTacToe
{
    public class Game
    {
        private Symbol _lastSymbol = Symbol.Empty;
        private Board _board = new Board();

        public void Play(char symbol, int x, int y)
        {
            var tile = new Tile
            {
                Symbol = CharToSymbol(symbol),
                X = x,
                Y = y
            };
            Play(tile);
        }

        private void Play(Tile tile)
        {
            ValidatePlay(tile);

            UpdateGameState(tile);
        }

        private void ValidatePlay(Tile tile)
        {
            ValidateFirstPlayer(tile.Symbol);
            ValidateNextPlayer(tile.Symbol);
            ValidatePosition(tile);
        }

        private void ValidateFirstPlayer(Symbol symbol)
        {
            var isFirstMove = _lastSymbol == Symbol.Empty;
            var isPlayerX = symbol == Symbol.O;
            if(isFirstMove && isPlayerX)
            {
                throw new Exception("Invalid first player");
            }
        }

        private void ValidateNextPlayer(Symbol symbol)
        {
            var isPlayerRepeated = symbol == _lastSymbol;
            if (isPlayerRepeated)
            {
                throw new Exception("Invalid next player");
            }
        }

        private void ValidatePosition(Tile tile)
        {
            var isOnAlreadyPlayedTile = !_board.IsEmptyTile(tile.X, tile.Y);
            if (isOnAlreadyPlayedTile)
            {
                throw new Exception("Invalid position");
            }
        }

        private void UpdateGameState(Tile tile)
        {
            _lastSymbol = tile.Symbol;
            _board.AddTileAt(tile);
        }

        private bool CheckWinningRow(int rowNumber)
        {
            var firstSymbol = _board.TileAt(rowNumber, 0).Symbol;
            var secondSymbol = _board.TileAt(rowNumber, 1).Symbol;
            var thirdSymbol = _board.TileAt(rowNumber, 2).Symbol;

            if (firstSymbol != Symbol.Empty)
            {
                return firstSymbol == secondSymbol &&
                       thirdSymbol == secondSymbol;
            }

            return false;
        }

        public char Winner()
        {
            for (var row = 0; row < 3; ++row)
            {
                if (CheckWinningRow(row))
                {
                    return SymbolToChar(_board.TileAt(row, 0).Symbol);
                }
            }

            return SymbolToChar(Symbol.Empty);
        }

        private Symbol CharToSymbol(char c)
        {
            return (Symbol)c;
        }

        private char SymbolToChar(Symbol symbol)
        {
            return (char)symbol;
        }
    }
}