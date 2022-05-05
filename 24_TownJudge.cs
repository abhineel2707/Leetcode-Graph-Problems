// https://leetcode.com/problems/find-the-town-judge/

public class Solution
{
    public int FindJudge(int n, int[][] trust)
    {
        int[] indegree = new int[n + 1];
        int[] outdegree = new int[n + 1];

        if (trust.Length < n - 1)
        {
            return -1;
        }

        if (n == 1 && trust.Length == 0)
        {
            return 1;
        }
        foreach (var item in trust)
        {
            outdegree[item[0]]++;
            indegree[item[1]]++;
        }
        for (int i = 0; i <= n; i++)
        {
            if (indegree[i] == (n - 1) && outdegree[i] == 0)
            {
                return i;
            }
        }
        return -1;
    }
}