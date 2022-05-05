// https://leetcode.com/problems/nearest-exit-from-entrance-in-maze/

public class Solution
{
    int[][] dirs ={
        new int[]{1,0},
        new int[]{-1,0},
        new int[]{0,1},
        new int[]{0,-1}
    };
    public int NearestExit(char[][] maze, int[] entrance)
    {
        int r = maze.Length;
        int c = maze[0].Length;

        Queue<(int x, int y)> q = new Queue<(int, int)>();
        q.Enqueue((entrance[0], entrance[1]));
        maze[entrance[0]][entrance[1]] = '+';
        int step = 1;
        while (q.Count > 0)
        {
            int size = q.Count;
            for (int i = 0; i < size; i++)
            {
                var point = q.Dequeue();

                foreach (var dir in dirs)
                {
                    int x1 = point.x + dir[0];
                    int y1 = point.y + dir[1];
                    if (x1 >= 0 && x1 < r && y1 >= 0 && y1 < c && maze[x1][y1] != '+')
                    {
                        if (x1 == 0 || x1 == (r - 1) || y1 == 0 || y1 == (c - 1))
                        {
                            return step;
                        }
                        maze[x1][y1] = '+';
                        q.Enqueue((x1, y1));
                    }
                }
            }
            step++;
        }
        return -1;
    }
}