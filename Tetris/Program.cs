﻿using System;
using System.Threading;
using System.Timers;

namespace Tetris
{
    class Program
    {
        const int TIMER_INTERVAL = 500;
        private static System.Timers.Timer timer;
        static private Object _lockedObject = new object();

        static FigureGenerator generator;
        static Figure currentFigure;
        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.Width, Field.Height);
            Console.SetBufferSize(Field.Width, Field.Height);

            generator = new FigureGenerator(Field.Width / 2, 0, Drawer.DEFAULT_SYMBOL);
            currentFigure = generator.GetNewFigure();
            SetTimer();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    Monitor.Enter(_lockedObject); 
                    var result = HandleKey(currentFigure, key.Key);
                    ProcessResult(result, ref currentFigure);
                    Monitor.Exit(_lockedObject);
                }
            }
        }

        private static void SetTimer()
        {
            timer = new System.Timers.Timer(TIMER_INTERVAL);
            timer.Elapsed += FallingFigure;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void FallingFigure(object sender, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockedObject);
            var result = currentFigure.TryMove(Direction.DOWN);
            ProcessResult(result, ref currentFigure);
            Monitor.Exit(_lockedObject);
        }

        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(currentFigure);
                Field.TryDeleteLines();

                if (currentFigure.IsOnTop())
                {
                    WriteGameOver();
                    timer.Elapsed -= FallingFigure;
                    return true;
                }
                else
                {
                    currentFigure = generator.GetNewFigure();
                    return true;
                }
            }  
            else
                return false;
        }

        private static void WriteGameOver()
        {
            Console.SetCursorPosition(Field.Width / 2 - 8, Field.Height / 2);
            Console.WriteLine("G A M E   OVER");
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
