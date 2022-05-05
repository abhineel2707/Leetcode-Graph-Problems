// https://leetcode.com/problems/shortest-bridge/

public class Solution
{
    int r;
    int c;
    int[][] dirs ={
        new int[]{1,0},
        new int[]{-1,0},
        new int[]{0,1},
        new int[]{0,-1}
    };
    public int ShortestBridge(int[][] grid)
    {
        r = grid.Length;
        c = grid[0].Length;
        Queue<(int x, int y)> q = new Queue<(int, int)>();
        bool flag = false;

        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (grid[i][j] == 1)
                {
                    DFSFillFirstIsland(grid, i, j, q);
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                break;
            }
        }

        int step = 0;
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

                    if (x1 >= 0 && x1 < r && y1 >= 0 && y1 < c && grid[x1][y1] != 2)
                    {
                        if (grid[x1][y1] == 1)
                        {
                            return step;
                        }
                        grid[x1][y1] = 2;
                        q.Enqueue((x1, y1));
                    }
                }
            }

            step++;
        }

        return -1;
    }

    private void DFSFillFirstIsland(int[][] grid, int i, int j, Queue<(int, int)> q)
    {
        if (i < 0 || i >= r || j < 0 || j >= c || grid[i][j] != 1)
        {
            return;
        }
        grid[i][j] = 2;
        q.Enqueue((i, j));
        DFSFillFirstIsland(grid, i + 1, j, q);
        DFSFillFirstIsland(grid, i, j + 1, q);
        DFSFillFirstIsland(grid, i - 1, j, q);
        DFSFillFirstIsland(grid, i, j - 1, q);
    }
}