// https://leetcode.com/problems/reorder-routes-to-make-all-paths-lead-to-the-city-zero/

public class Solution
{
    public int MinReorder(int n, int[][] connections)
    {
        List<List<int>> g = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            g.Add(new List<int>());
        }

        for (int i = 0; i < connections.Length; i++)
        {
            int src = connections[i][0];
            int dest = connections[i][1];
            g[src].Add(dest);
            g[dest].Add(-src);
        }
        bool[] visited = new bool[n];
        return DFSMinReorder(g, visited, 0);
    }

    private int DFSMinReorder(List<List<int>> g, bool[] visited, int from)
    {
        int changes = 0;
        visited[from] = true;
        foreach (var to in g[from])
        {
            if (!visited[Math.Abs(to)])
            {
                changes += DFSMinReorder(g, visited, Math.Abs(to)) + (to > 0 ? 1 : 0);
            }
        }
        return changes;
    }
}