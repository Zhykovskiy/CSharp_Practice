using System;
using System.Timers;

namespace Tetris
{
    class Program
    {
        static FigureGenerator generator;
        static Figure currentFigure;
        private static System.Timers.Timer aTimer;
        static void Main(string[] args)
        {
            SetTimer();

            Console.SetWindowSize(Field.Width, Field.Height);
            Console.SetBufferSize(Field.Width, Field.Height);

            generator = new FigureGenerator(Field.Width / 2, 0, Drawer.DEFAULT_SYMBOL);
            currentFigure = generator.GetNewFigure();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    var result = HandleKey(currentFigure, key.Key);
                    ProcessResult(result, ref currentFigure);
                }
            }
        }

        private static void SetTimer()
        {
            aTimer = new System.Timers.Timer(400);
            aTimer.Elapsed += FallingFigure;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void FallingFigure(object sender, ElapsedEventArgs e)
        {
            var result = currentFigure.TryMove(Direction.DOWN);
            ProcessResult(result, ref currentFigure);
        }

        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(currentFigure);
                Field.TryDeleteLines();
                currentFigure = generator.GetNewFigure();
                return true;
            }  
            else
                return false;
        }

        private static Result HandleKey(Figure currentFigure, ConsoleKey key)
        {
            Result result = Result.SUCCESS;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    result = currentFigure.TryMove(Direction.LEFT);
                    break;
                case ConsoleKey.RightArrow:
                    result = currentFigure.TryMove(Direction.RIGHT);
                    break;
                case ConsoleKey.DownArrow:
                    result = currentFigure.TryMove(Direction.DOWN);
                    break;
                case ConsoleKey.Spacebar:
                    result = currentFigure.TryRotate();
                    break;
            }
            return result;
        }
    }
}
