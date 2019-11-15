using System;

namespace TicTacToe
{
    public class Play
    {
        private readonly Symbol symbol;
        private readonly int x;
        private readonly int y;

        public Play(Symbol symbol, int x, int y)
        {
            this.symbol = symbol;
            this.x = x;
            this.y = y;
        }

        public void Validate(Symbol lastSymbol, Board board)
        {
            ValidateFirstPlayer(lastSymbol);
            ValidateNextPlayer(lastSymbol);
            ValidatePosition(board);
        }

        private void ValidateFirstPlayer(Symbol lastSymbol)
        {
            var isFirstMove = lastSymbol == Symbol.Empty;
            var isPlayerX = symbol == Symbol.O;
            if(isFirstMove && isPlayerX)
            {
                throw new Exception("Invalid first player");
            }
        }

        private void ValidateNextPlayer(Symbol lastSymbol)
        {
            var isPlayerRepeated = symbol == lastSymbol;
            if (isPlayerRepeated)
            {
                throw new Exception("Invalid next player");
            }
        }

        private void ValidatePosition(Board board)
        {
            var isOnAlreadyPlayedTile = !board.IsEmptyTile(x, y);
            if (isOnAlreadyPlayedTile)
            {
                throw new Exception("Invalid position");
            }
        }
    }
}