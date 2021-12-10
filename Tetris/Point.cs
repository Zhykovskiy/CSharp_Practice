using System;

namespace Tetris
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char C { get; set; }

        public Point(int x, int y, char c)
        {
            X = x;
            Y = y;
            C = c;
        }

        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
            C = p.C;
        }
        internal void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.RIGHT:
                    X += 1;
                    break;
                case Direction.LEFT:
                    X -= 1;
                    break;
                case Direction.DOWN:
                    Y += 1;
                    break;
            }
        }

        internal void Hide()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(C);
            Console.SetCursorPosition(0, 0);
        }
    }
}
