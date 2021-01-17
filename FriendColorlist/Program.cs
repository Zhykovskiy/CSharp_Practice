using System;

namespace FriendColorlist
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] names = new string[6] { "Настя", "Назар", "Дима", "Эрвин", "Исмаил", "Влад" };
            string[] colors = new string[6] { "Белый", "Чёрный", "Фиолетовый", "unknown", "Оранжевый", "Зелёный" };

            Console.WriteLine("Чей любимый цвет вам интересно узнать?");
            Console.WriteLine("Введите число под которым находится этот человек.");

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {names[i]}");
            }


            int number;
            
            while (true)
            {
                string answer = Console.ReadLine();

                if (int.TryParse(answer, out int a) && a <= names.Length + 1)
                {
                    number = a;
                    break;
                }

                Console.WriteLine("Что-то пошло не так, попробуйте ещё раз.");
            }

            Console.WriteLine($"\nЛюбимый цвет этого пользователя - {colors[number - 1]}");

            Console.ReadKey();
        }
    }
}
