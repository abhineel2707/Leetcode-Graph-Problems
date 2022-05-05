public class Solution
{
    int r;
    int c;
    int[][] dirs ={
        new int[]{0,1},
        new int[]{0,-1},
        new int[]{1,0},
        new int[]{-1,0}
    };
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        List<IList<int>> res = new List<IList<int>>();
        r = heights.Length;
        c = heights[0].Length;
        if (r == 0 || c == 0)
        {
            return res;
        }

        Queue<(int, int)> pacificQ = new Queue<(int, int)>();
        Queue<(int, int)> atlanticQ = new Queue<(int, int)>();

        for (int i = 0; i < r; i++)
        {
            pacificQ.Enqueue((i, 0));
            atlanticQ.Enqueue((i, c - 1));
        }

        for (int j = 0; j < c; j++)
        {
            pacificQ.Enqueue((0, j));
            atlanticQ.Enqueue((r - 1, j));
        }

        bool[,] pacificReachable = BFSPacificAtlantic(pacificQ, heights);
        bool[,] atlanticReachable = BFSPacificAtlantic(atlanticQ, heights);

        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (pacificReachable[i, j] && atlanticReachable[i, j])
                {
                    res.Add(new List<int>(new int[] { i, j }));
                }
            }
        }

        return res;
    }

    private bool[,] BFSPacificAtlantic(Queue<(int, int)> q, int[][] heights)
    {
        bool[,] reachable = new bool[r, c];
        while (q.Count > 0)
        {
            int size = q.Count;
            for (int i = 0; i < size; i++)
            {
                var point = q.Dequeue();
                reachable[point.Item1, point.Item2] = true;
                foreach (int[] dir in dirs)
                {
                    int x = point.Item1 + dir[0];
                    int y = point.Item2 + dir[1];
                    if (x < 0 || x >= r || y < 0 || y >= c || reachable[x, y] || heights[x][y] < heights[point.Item1][point.Item2])
                    {
                        continue;
                    }
                    q.Enqueue((x, y));
                }
            }
        }

        return reachable;
    }
}