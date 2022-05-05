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
        List<IList<int>> res = new List<IList<int>>();
        List<int> path = new List<int>();
        int src = 0;
        int dest = graph.Length - 1;

        Queue<List<int>> q = new Queue<List<int>>();
        path.Add(src);
        q.Enqueue(path);
        while (q.Count > 0)
        {
            int size = q.Count;
            for (int i = 0; i < size; i++)
            {
                List<int> tempPath = q.Dequeue();
                int temp = tempPath[tempPath.Count - 1];
                foreach (var item in g[temp])
                {
                    tempPath.Add(item);
                    if (item == dest)
                    {
                        res.Add(new List<int>(tempPath));
                    }
                    else
                    {
                        q.Enqueue(tempPath);
                    }
                }
            }
        }
        return res;
    }
}