using System;

namespace SticksGame
{
    class Program
    {
        static void Main(string[] args)
        {
            SticksGame game = new SticksGame();

            bool player;

            while(game.Sticks > 0)
            {
                Console.WriteLine($"Current count of sticks: {game.Sticks}");
                player = game.MakeMove();

                if(game.Sticks <= 0)
                {
                    if(player) Console.WriteLine("You won!");
                    else Console.WriteLine("You lost :(");
                }
            }

            Console.ReadLine();
        }
    }
}
