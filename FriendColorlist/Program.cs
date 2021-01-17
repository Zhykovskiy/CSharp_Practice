using System;

namespace FriendColorlist
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] names = new string[6] { "Настя", "Назар", "Дима", "Эрвин", "Исмаил", "Влад" };
            string[] colors = new string[6] { "Белый", "Чёрный", "Фиолетовый", "Бирюзовый", "Оранжевый", "Зелёный" };

            Console.WriteLine("Чей любимый цвет вам интересно узнать?");
            Console.WriteLine("Введите число под которым находится этот человек.");
            Console.WriteLine("Если хотите выйти пропишите - exit");

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {names[i]}");
            }
            
            while (true)
            {
                string answer = Console.ReadLine();

                if (answer == "exit")
                {
                    Console.WriteLine("До свидания");
                    break;
                }

                else if (int.TryParse(answer, out int a) && a < names.Length + 1 && a > 0)
                {
                    Console.WriteLine($"Любимый цвет этого пользователя - {colors[a - 1]}");
                }
                else
                {
                    Console.WriteLine("Что-то пошло не так");
                    continue;
                }
            }

            Console.ReadKey();
        }
    }
}
