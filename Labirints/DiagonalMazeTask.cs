namespace Mazes
{
	public static class DiagonalMazeTask
	{
        public static void MoveDown(Robot robot, int stepsDown)
        {
            for (int i = 0; i < stepsDown; i++)
            {
                robot.MoveTo(Direction.Down);
            }
        }

        public static void MoveRight(Robot robot, int stepsRight)
        {
            for (int i = 0; i < stepsRight; i++)
            {
                robot.MoveTo(Direction.Right);
            }
        }

        public static void MoveOut(Robot robot, int width, int height)
		{
            int stepsRight, stepsDown;
            if(width > height)
            {
                stepsRight = (width - 3) / (height - 2);
                stepsDown = 1;
            }
            else
            {
                stepsDown = (height - 3) / (width - 2);
                stepsRight = 1;
            }

            while (true)
            {
                if(width > height)
                {
                    MoveRight(robot, stepsRight);
                    if (robot.Finished) break;
                    MoveDown(robot, stepsDown);
                }
                else
                {
                    MoveDown(robot, stepsDown);
                    if (robot.Finished) break;
                    MoveRight(robot, stepsRight);
                }
            }
        }
	}
}