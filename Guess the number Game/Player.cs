using System;

namespace Guess_the_number_Game
{
    public interface IPlayer
    {
        void Guess(int number, int lives);
        int MakeAGuess();
    }

    public class Human : IPlayer
    {
        public void Guess(int number, int lives)
        {
            bool end = false;

            while (!end)
            {
                int answer = int.Parse(Console.ReadLine());

                if (answer == number)
                {
                    end = true;
                    Console.WriteLine("Поздарвляю, Вы выиграли!");
                }
                else if (lives == 1)
                {
                    end = true;
                    Console.WriteLine("Попытки закончились! Вы проиграли!" +
                        $"Правильный ответ: {number}");
                }
                else
                {
                    Console.WriteLine("Неверно!");
                    Console.WriteLine($"Осталось попыток: {--lives}");
                    if (answer < number)
                    {
                        Console.WriteLine("Загаданное число больше");
                    }
                    else
                    {
                        Console.WriteLine("Загаданное число меньше");
                    }
                }
            }
        }

        public int MakeAGuess()
        {
            Console.WriteLine("Введите число от 0 до 100: ");
            int number = int.Parse(Console.ReadLine());
            Console.Clear();

            return number;
        }
    }

    class Computer : IPlayer
    {
        public void Guess(int number, int lives)
        {
            bool end = false;
            int rangeX = 0, rangeY = 100;

            while (!end)
            {
                int answer = (rangeX + rangeY) / 2;
                Console.WriteLine($"Машина предполагает что это {answer}");
                if (answer == number)
                {
                    end = true;
                    Console.WriteLine("Поздарвляю, Вы выиграли!");
                }
                else if (lives == 1)
                {
                    end = true;
                    Console.WriteLine("Попытки закончились! Вы проиграли!" +
                        $"Правильный ответ: {number}");
                }
                else
                {
                    Console.WriteLine("Неверно!");
                    Console.WriteLine($"Осталось попыток: {--lives}");
                    if (answer < number)
                    {
                        rangeX = answer;
                    }
                    else
                    {
                        rangeY = answer;
                    }
                }
            }
        }

        public int MakeAGuess()
        {
            Random rand = new Random();
            int number = rand.Next(100);

            return number;
        }
    }
}