// https://leetcode.com/problems/time-needed-to-inform-all-employees/

public class Solution
{
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
    {
        Dictionary<int, List<int>> g = new Dictionary<int, List<int>>();
        for (int i = 0; i < manager.Length; i++)
        {
            int j = manager[i];
            if (!g.ContainsKey(j))
            {
                g.Add(j, new List<int>());
            }
            g[j].Add(i);
        }

        return DFSNumOfMinutes(g, informTime, headID);
    }
    private int DFSNumOfMinutes(Dictionary<int, List<int>> g, int[] informTime, int cur)
    {
        int max = 0;
        if (!g.ContainsKey(cur))
        {
            return max;
        }
        foreach (var node in g[cur])
        {
            max = Math.Max(max, DFSNumOfMinutes(g, informTime, node));
        }

        return max + informTime[cur];
    }
}