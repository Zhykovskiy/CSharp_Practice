using System;

namespace SticksGame
{
    class SticksGame
    {
        private bool player = true;

        public int Sticks { get; private set; }

        public SticksGame(int sticks = 10)
        {
            Sticks = sticks;
        }

        public bool MakeMove()
        {
            Sticks -= player ? PlayerMove() : BotMove();
            
            player = !player;
            
            return player;
        }

        private int PlayerMove()
        {
            Console.WriteLine("Make your move between 1 and 3: ");
            int move = int.Parse(Console.ReadLine());

            while (move < 1 || move > 3)
            {
                Console.WriteLine("It should be between 1 and 3!");
                Console.WriteLine("Make your move between 1 and 3: ");
                move = int.Parse(Console.ReadLine());
            }
            
            return move;
        }

        private int BotMove()
        {
            var rand = new Random();
            int move = rand.Next(1, 3);

            Console.WriteLine($"Bot makes a move: {move}");

            return move;
        }
    }
}
