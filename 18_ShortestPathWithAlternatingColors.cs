// https://leetcode.com/problems/shortest-path-with-alternating-colors/

public class Solution
{
    public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges)
    {
        List<List<int>> g = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            g.Add(new List<int>(new int[n]));
        }
        for (int i = 0; i < g.Count; i++)
        {
            for (int j = 0; j < g[i].Count; j++)
            {
                g[i][j] = -n;
            }
        }

        BuildGraph(g, redEdges, blueEdges);

        Queue<(int node, int color)> q = new Queue<(int, int)>();
        q.Enqueue((0, 1));
        q.Enqueue((0, -1));
        int len = 0;
        int[] res = new int[n];
        Array.Fill(res, int.MaxValue);
        res[0] = 0;
        HashSet<string> visited = new HashSet<string>();

        while (q.Count > 0)
        {
            int size = q.Count;
            len++;
            for (int i = 0; i < size; i++)
            {
                var item = q.Dequeue();
                int node = item.node;
                int color = item.color;
                int oppColor = -color;
                for (int j = 1; j < n; j++)
                {
                    if (g[node][j] == oppColor || g[node][j] == 0)
                    {
                        if (visited.Contains(j + "" + oppColor))
                        {
                            continue;
                        }
                        visited.Add(j + "" + oppColor);
                        q.Enqueue((j, oppColor));
                        res[j] = Math.Min(res[j], len);
                    }
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (res[i] == int.MaxValue)
            {
                res[i] = -1;
            }
        }
        return res;
    }

    private void BuildGraph(List<List<int>> g, int[][] redEdges, int[][] blueEdges)
    {
        for (int i = 0; i < redEdges.Length; i++)
        {
            int src = redEdges[i][0];
            int dest = redEdges[i][1];
            g[src][dest] = 1;
        }
        for (int i = 0; i < blueEdges.Length; i++)
        {
            int src = blueEdges[i][0];
            int dest = blueEdges[i][1];
            if (g[src][dest] == 1)
            {
                g[src][dest] = 0;
            }
            else
            {
                g[src][dest] = -1;
            }
        }
    }
}