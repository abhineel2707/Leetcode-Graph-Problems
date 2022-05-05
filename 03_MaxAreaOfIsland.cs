// https://leetcode.com/problems/max-area-of-island/

public class Solution
{
    int r;
    int c;
    public int MaxAreaOfIsland(int[][] grid)
    {
        int res = 0;
        r = grid.Length;
        c = grid[0].Length;

        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (grid[i][j] == 1)
                {
                    int maxArea = 0;
                    DFSMaxAreaOfIsland(grid, i, j, ref maxArea);
                    res = Math.Max(res, maxArea);
                }
            }
        }
        return res;
    }

    private void DFSMaxAreaOfIsland(int[][] grid, int i, int j, ref int maxArea)
    {
        if (i < 0 || i >= r || j < 0 || j >= c || grid[i][j] == 0)
        {
            return;
        }
        grid[i][j] = 0;
        maxArea++;
        DFSMaxAreaOfIsland(grid, i + 1, j, ref maxArea);
        DFSMaxAreaOfIsland(grid, i, j + 1, ref maxArea);
        DFSMaxAreaOfIsland(grid, i - 1, j, ref maxArea);
        DFSMaxAreaOfIsland(grid, i, j - 1, ref maxArea);
    }
}