namespace TicTacToe
{
    public static class Steve
    {
        public static Symbol ConvertSymbol(char c) => (Symbol)c;

        public static char ConvertSymbol(Symbol symbol) => (char)symbol;
    }
}