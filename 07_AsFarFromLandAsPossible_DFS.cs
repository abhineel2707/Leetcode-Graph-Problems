// https://leetcode.com/problems/as-far-from-land-as-possible/

public class Solution
{
    public int MaxDistance(int[][] grid)
    {
        int r = grid.Length;
        int c = grid[0].Length;

        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (grid[i][j] == 1)
                {
                    grid[i][j] = 0;
                    DFSMaxDistance(grid, i, j, r, c, 1);
                }
            }
        }

        int max = Int32.MinValue;

        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (grid[i][j] != 1)
                {
                    max = Math.Max(max, grid[i][j]);
                }
            }
        }

        return max == Int32.MinValue ? -1 : max - 1;
    }

    private void DFSMaxDistance(int[][] grid, int i, int j, int r, int c, int dist)
    {
        if (i < 0 || i >= r || j < 0 || j >= c || (grid[i][j] != 0 && grid[i][j] <= dist))
        {
            return;
        }

        grid[i][j] = dist;
        DFSMaxDistance(grid, i + 1, j, r, c, dist + 1);
        DFSMaxDistance(grid, i, j + 1, r, c, dist + 1);
        DFSMaxDistance(grid, i - 1, j, r, c, dist + 1);
        DFSMaxDistance(grid, i, j - 1, r, c, dist + 1);
    }
}