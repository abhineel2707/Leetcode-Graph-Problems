// https://leetcode.com/problems/shortest-path-in-binary-matrix/


public class Solution
{
    int[][] dirs ={
        new int[]{-1,-1},
        new int[]{-1,0},
        new int[]{-1,1},
        new int[]{0,-1},
        new int[]{0,1},
        new int[]{1,-1},
        new int[]{1,0},
        new int[]{1,1}
    };
    int r;
    int c;
    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        r = grid.Length;
        c = grid[0].Length;

        if (grid[0][0] != 0 || grid[r - 1][c - 1] != 0)
        {
            return -1;
        }

        Queue<(int x, int y)> q = new Queue<(int, int)>();
        q.Enqueue((0, 0));
        grid[0][0] = 1;

        while (q.Count > 0)
        {
            int size = q.Count;
            for (int i = 0; i < size; i++)
            {
                var point = q.Dequeue();
                int distance = grid[point.x][point.y];
                if (point.x == (r - 1) && point.y == (c - 1))
                {
                    return distance;
                }

                foreach (var dir in dirs)
                {
                    int x1 = point.x + dir[0];
                    int y1 = point.y + dir[1];
                    if (x1 >= 0 && x1 < r && y1 >= 0 && y1 < c && grid[x1][y1] == 0)
                    {
                        grid[x1][y1] = distance + 1;
                        q.Enqueue((x1, y1));
                    }
                }
            }
        }
        return -1;
    }
}