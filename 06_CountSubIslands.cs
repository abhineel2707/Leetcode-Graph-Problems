// https://leetcode.com/problems/count-sub-islands/

public class Solution
{
    public int CountSubIslands(int[][] grid1, int[][] grid2)
    {
        int r = grid1.Length;
        int c = grid1[0].Length;

        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (grid1[i][j] == 0)
                {
                    DFSCountSubIslands(grid2, i, j, r, c);
                }
            }
        }

        int count = 0;
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (grid2[i][j] == 1)
                {
                    count++;
                    DFSCountSubIslands(grid2, i, j, r, c);
                }
            }
        }

        return count;
    }

    private void DFSCountSubIslands(int[][] grid, int i, int j, int r, int c)
    {
        if (i < 0 || i >= r || j < 0 || j >= c || grid[i][j] == 0)
        {
            return;
        }

        grid[i][j] = 0;
        DFSCountSubIslands(grid, i + 1, j, r, c);
        DFSCountSubIslands(grid, i, j + 1, r, c);
        DFSCountSubIslands(grid, i - 1, j, r, c);
        DFSCountSubIslands(grid, i, j - 1, r, c);
    }
}