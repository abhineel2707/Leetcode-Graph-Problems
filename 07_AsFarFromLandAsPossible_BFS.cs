// https://leetcode.com/problems/as-far-from-land-as-possible/

public class Solution
{
    public int MaxDistance(int[][] grid)
    {
        int r = grid.Length;
        int c = grid[0].Length;

        Queue<(int, int)> q = new Queue<(int, int)>();

        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (grid[i][j] == 1)
                {
                    q.Enqueue((i, j));
                }
            }
        }

        if (q.Count == 0 || q.Count == (r * c))
        {
            return -1;
        }

        int[][] dirs =
            {
                new int[]{ 0, 1 },
                new int[]{ 0, -1 },
                new int[]{ 1, 0 },
                new int[]{ -1, 0 }
            };

        int max = 0;
        while (q.Count > 0)
        {
            int size = q.Count;
            for (int i = 0; i < size; i++)
            {
                var point = q.Dequeue();
                foreach (int[] dir in dirs)
                {
                    int x = point.Item1 + dir[0];
                    int y = point.Item2 + dir[1];
                    if (x >= 0 && y >= 0 && x < r && y < c && grid[x][y] == 0)
                    {
                        grid[x][y] = 1;
                        q.Enqueue((x, y));
                    }
                }
            }
            max++;
        }

        return max - 1;
    }
}