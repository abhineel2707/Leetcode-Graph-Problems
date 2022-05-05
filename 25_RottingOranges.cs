// https://leetcode.com/problems/rotting-oranges/

public class Solution
{
    int[][] dirs ={
        new int[]{1,0},
        new int[]{0,1},
        new int[]{-1,0},
        new int[]{0,-1}
    };
    public int OrangesRotting(int[][] grid)
    {
        int goodOranges = 0;
        Queue<(int x, int y)> q = new Queue<(int, int)>();
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 2)
                {
                    q.Enqueue((i, j));
                }
                else if (grid[i][j] == 1)
                {
                    goodOranges++;
                }
            }
        }

        if (goodOranges == 0)
        {
            return 0;
        }
        int timeTaken = 0;
        while (q.Count > 0 && goodOranges > 0)
        {
            int size = q.Count;
            for (int i = 0; i < size; i++)
            {
                var point = q.Dequeue();
                foreach (var dir in dirs)
                {
                    int x1 = point.x + dir[0];
                    int y1 = point.y + dir[1];
                    if (x1 >= 0 && x1 < grid.Length && y1 >= 0 && y1 < grid[0].Length && grid[x1][y1] == 1)
                    {
                        grid[x1][y1] = 2;
                        q.Enqueue((x1, y1));
                        goodOranges--;
                    }
                }
            }
            timeTaken++;
        }

        if (goodOranges > 0)
        {
            return -1;
        }
        return timeTaken;
    }
}