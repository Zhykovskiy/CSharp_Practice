namespace Mazes
{
	public static class SnakeMazeTask
	{
		public static void MoveRight(Robot robot, int width)
		{
            for (int i = 0; i < width - 3; i++)
            {
				robot.MoveTo(Direction.Right);
            }
		}

		public static void MoveLeft(Robot robot, int width)
		{
			for (int i = 0; i < width - 3; i++)
			{
				robot.MoveTo(Direction.Left);
			}
		}
		
		public static void MoveOut(Robot robot, int width, int height)
		{
			int i = 0;
            while (true)
            {
				if (i % 2 == 0) MoveRight(robot, width);
				else MoveLeft(robot, width);
                if (robot.Finished) break;
				robot.MoveTo(Direction.Down);
				robot.MoveTo(Direction.Down);
				i++;
            }
		}
	}
}