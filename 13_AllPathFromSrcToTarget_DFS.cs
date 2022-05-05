// https://leetcode.com/problems/all-paths-from-source-to-target/

public class Solution
{
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        List<List<int>> g = new List<List<int>>();
        for (int i = 0; i < graph.Length; i++)
        {
            g.Add(new List<int>());
        }

        for (int i = 0; i < graph.Length; i++)
        {
            for (int j = 0; j < graph[i].Length; j++)
            {
                g[i].Add(graph[i][j]);
            }
        }
        int src = 0;
        int dest = graph.Length - 1;
        List<IList<int>> res = new List<IList<int>>();
        List<int> path = new List<int>();
        path.Add(src);
        DFSAllPathsSourceTarget(g, res, path, src, dest);
        return res;
    }

    private void DFSAllPathsSourceTarget(List<List<int>> g, List<IList<int>> res, List<int> path, int src, int dest)
    {
        if (src == dest)
        {
            res.Add(new List<int>(path));
            return;
        }
        foreach (var item in g[src])
        {
            path.Add(item);
            DFSAllPathsSourceTarget(g, res, path, item, dest);
            path.RemoveAt(path.Count - 1);
        }
    }
}