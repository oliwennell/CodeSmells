using System;

namespace TicTacToe
{
    public class Game
    {
        private Symbol _lastSymbol = Symbol.Empty;
        private Board _board = new Board();

        public void Play(char symbol, int x, int y)
        {
            var symbolAsEnum = CharToSymbol(symbol);

            ValidatePlay(symbolAsEnum, x, y);

            UpdateGameState(symbolAsEnum, x, y);
        }

        private void ValidatePlay(Symbol symbol, int x, int y)
        {
            ValidateFirstPlayer(symbol);
            ValidateNextPlayer(symbol);
            ValidatePosition(x, y);
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

        private void ValidatePosition(int x, int y)
        {
            var isOnAlreadyPlayedTile = !_board.IsEmptyTile(x, y);
            if (isOnAlreadyPlayedTile)
            {
                throw new Exception("Invalid position");
            }
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
                    return SymbolToChar(_board.TileAt(column, 0));
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