// https://leetcode.com/problems/number-of-closed-islands/

public class Solution
{
    public int ClosedIsland(int[][] grid)
    {
        int r = grid.Length;
        int c = grid[0].Length;
        int numberOfIslands = 0;
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (grid[i][j] == 0)
                {
                    numberOfIslands += DFSClosedIsland(grid, i, j, r, c) ? 1 : 0;
                }
            }
        }

        return numberOfIslands;
    }

    private bool DFSClosedIsland(int[][] grid, int i, int j, int r, int c)
    {
        if (i < 0 || i >= r || j < 0 || j >= c)
        {
            return false;
        }

        if (grid[i][j] == 1)
        {
            return true;
        }

        grid[i][j] = 1;

        bool d1 = DFSClosedIsland(grid, i + 1, j, r, c);
        bool d2 = DFSClosedIsland(grid, i, j + 1, r, c);
        bool d3 = DFSClosedIsland(grid, i - 1, j, r, c);
        bool d4 = DFSClosedIsland(grid, i, j - 1, r, c);

        return d1 && d2 && d3 && d4;
    }
}