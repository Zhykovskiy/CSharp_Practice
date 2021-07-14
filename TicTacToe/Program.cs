using System;

namespace TicTacToe
{
    class Program
    {
        private static TicTacToeGame g = new TicTacToeGame();
        static void Main(string[] args)
        {
            DrawBoard();
            while (g.GetWinner() == Winner.GameIsUnfinished)
            {
                int index = int.Parse(Console.ReadLine());
                g.MakeMove(index);
                Console.Clear();
                DrawBoard();
            }
            Console.WriteLine($"Result: {g.GetWinner()}");
        }

        public static void DrawBoard()
        {
            for (int i = 1; i <= 7; i += 3)
            {
                Console.WriteLine($"{GetPrintableState(i)}\t{GetPrintableState(i + 1)}\t{GetPrintableState(i + 2)}");
            }
        }

        public static string GetPrintableState(int index)
        {
            State state = g.GetState(index);
            if (state == State.Unset)
            {
                return index.ToString();
            }
            return state == State.Cross ? "X" : "O";
        }
    }
}
