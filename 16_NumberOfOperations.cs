// https://leetcode.com/problems/number-of-operations-to-make-network-connected/

public class Solution
{
    public int MakeConnected(int n, int[][] connections)
    {
        if (connections.Length < n - 1)
        {
            return -1;
        }
        List<List<int>> g = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            g.Add(new List<int>());
        }

        foreach (var uv in connections)
        {
            g[uv[0]].Add(uv[1]);
            g[uv[1]].Add(uv[0]);
        }

        int count = 0;
        bool[] visited = new bool[n];
        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                DFSMakeConnected(g, visited, i);
                count++;
            }
        }
        return count - 1;
    }
    private void DFSMakeConnected(List<List<int>> g, bool[] visited, int src)
    {
        visited[src] = true;
        foreach (var item in g[src])
        {
            if (!visited[item])
            {
                DFSMakeConnected(g, visited, item);
            }
        }
    }
}