// https://leetcode.com/problems/number-of-islands/

public class Solution
{
    int r;
    int c;
    public int NumIslands(char[][] grid)
    {
        r = grid.Length;
        c = grid[0].Length;

        int numOfIslands = 0;

        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (grid[i][j] == '1')
                {
                    numOfIslands++;
                    DFSNumIslands(grid, i, j);
                }
            }
        }

        return numOfIslands;
    }
    private void DFSNumIslands(char[][] grid, int i, int j)
    {
        if (i < 0 || i >= r || j < 0 || j >= c || grid[i][j] == '0')
            return;
        grid[i][j] = '0';
        DFSNumIslands(grid, i + 1, j);
        DFSNumIslands(grid, i, j + 1);
        DFSNumIslands(grid, i - 1, j);
        DFSNumIslands(grid, i, j - 1);
    }
}