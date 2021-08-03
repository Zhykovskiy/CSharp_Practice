using System;
using System.IO;

namespace Hangman_game
{
    class Program
    {
        static void Main(string[] args)
        {
            HangmanGame game = new HangmanGame();

            string word = game.GenerateWord();

            Console.WriteLine($"The word consist of {word.Length} letters");
            Console.WriteLine("Try to guess the word");

            while (game.GameStatus == GameStatus.InProgress)
            {
                Console.WriteLine("Pick a letter");
                char c = Console.ReadLine().ToCharArray()[0];

                string curState = game.GuessLetter(c);
                Console.WriteLine(curState);

                Console.WriteLine($"Remaining tries = {game.RemaingTries}");
                Console.WriteLine($"Tried letter: {game.TriedLetters}");

                if (game.GameStatus == GameStatus.Lost)
                {
                    Console.WriteLine("You're hanged.");
                    Console.WriteLine($"The word was: {game.Word}");
                }
                else if (game.GameStatus == GameStatus.Won)
                {
                    Console.WriteLine("You won!");
                }
            }
            Console.ReadLine();
        }
    }
}
