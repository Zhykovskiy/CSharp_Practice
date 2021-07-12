using System;

namespace Guess_the_number_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите кто загадает число:\n" +
                "1. Человек\n" +
                "2. Машина");
            int choise = int.Parse(Console.ReadLine());
            int number, lives = 5;

            IPlayer player1, player2;

            if (choise == 1)
            {
                player1 = new Human();
            }
            else
            {
                player1 = new Computer();
            }
            Console.Clear();

            Console.WriteLine("Выберите кто отгадывает число:\n" +
                "1. Человек\n" +
                "2. Машина");
            choise = int.Parse(Console.ReadLine());

            if (choise == 1)
            {
                player2 = new Human();
            }
            else
            {
                player2 = new Computer();
            }

            number = player1.MakeAGuess();
            player2.Guess(number, lives);
        }
    }
}