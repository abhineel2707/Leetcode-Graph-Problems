// https://leetcode.com/problems/01-matrix/

public class Solution
{
    int[][] dirs ={
        new int[]{1,0},
        new int[]{-1,0},
        new int[]{0,1},
        new int[]{0,-1}
    };
    public int[][] UpdateMatrix(int[][] mat)
    {
        int r = mat.Length;
        int c = mat[0].Length;

        Queue<(int x, int y)> q = new Queue<(int, int)>();

        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (mat[i][j] == 0)
                {
                    q.Enqueue((i, j));
                }
                else
                {
                    mat[i][j] = -1;
                }
            }
        }

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
                    if (x1 >= 0 && x1 < r && y1 >= 0 && y1 < c && mat[x1][y1] == -1)
                    {
                        mat[x1][y1] = mat[point.x][point.y] + 1;
                        q.Enqueue((x1, y1));
                    }
                }
            }
        }

        return mat;
    }
}