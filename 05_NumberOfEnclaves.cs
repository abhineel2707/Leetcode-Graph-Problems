// https://leetcode.com/problems/number-of-enclaves/

public class Solution
{
    public int NumEnclaves(int[][] grid)
    {
        int r = grid.Length;
        int c = grid[0].Length;

        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (i == 0 || j == 0 || i == (r - 1) || j == (c - 1))
                {
                    DFSNumEnclaves(grid, i, j, r, c);
                }
            }
        }

        int count = 0;
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (grid[i][j] == 1)
                {
                    count++;
                }
            }
        }

        return count;
    }

    private void DFSNumEnclaves(int[][] grid, int i, int j, int r, int c)
    {
        if (i < 0 || i >= r || j < 0 || j >= c || grid[i][j] == 0)
        {
            return;
        }

        grid[i][j] = 0;
        DFSNumEnclaves(grid, i + 1, j, r, c);
        DFSNumEnclaves(grid, i, j + 1, r, c);
        DFSNumEnclaves(grid, i - 1, j, r, c);
        DFSNumEnclaves(grid, i, j - 1, r, c);
    }
}