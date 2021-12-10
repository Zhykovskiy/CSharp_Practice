using System;

namespace Tetris
{
    static class Field
    {
        private static int _width = 20;
        private static int _height = 20;
        public static int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                Console.SetWindowSize(value, Height);
                Console.SetBufferSize(value, Height);
            }
        }
        public static int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                Console.SetWindowSize(Width, value);
                Console.SetBufferSize(Width, value);
            }
        }

        private static bool[][] _heap;

        static Field()
        {
            _heap = new bool[Height][];
            for (int i = 0; i < Height; i++)
            {
                _heap[i] = new bool[Width];
            }
        }

        internal static void TryDeleteLines()
        {
            for (int i = 0; i < Height; i++)
            {
                int counter = 0;

                for (int j = 0; j < Width; j++)
                {
                    if (_heap[i][j])
                        counter++;
                    if (counter == Width)
                    {
                        DeleteLine(i);
                        Redraw();
                    }

                }
            }
        }

        private static void Redraw()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (_heap[i][j])
                        Drawer.DrawPoint(j, i);
                    else
                        Drawer.HidePoint(j, i);
                }
            }
        }

        private static void DeleteLine(int line)
        {
            for (int i = line; i >= 0; i--)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (i == 0)
                        _heap[i][j] = false;
                    else
                        _heap[i][j] = _heap[i - 1][j];
                }
            }
        }

        public static bool CheckStrike(Point p)
        {
            return _heap[p.Y][p.X];
        }

        public static void AddFigure(Figure fig)
        {
            foreach (var p in fig.Points)
            {
                _heap[p.Y][p.X] = true;
            }
        }
    }
}
