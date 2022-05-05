// https://leetcode.com/problems/open-the-lock/

public class Solution
{
    public int OpenLock(string[] deadends, string target)
    {
        string start = "0000";
        HashSet<string> deadSet = new HashSet<string>();
        for (int i = 0; i < deadends.Length; i++)
        {
            deadSet.Add(deadends[i]);
        }
        if (deadSet.Contains(start))
        {
            return -1;
        }
        Queue<string> q = new Queue<string>();
        int level = 0;

        q.Enqueue(start);
        while (q.Count > 0)
        {
            int size = q.Count;
            for (int i = 0; i < size; i++)
            {
                string cur = q.Dequeue();
                if (cur == target)
                {
                    return level;
                }
                foreach (var nei in Neighbors(cur))
                {
                    if (deadSet.Contains(nei))
                    {
                        continue;
                    }
                    deadSet.Add(nei);
                    q.Enqueue(nei);
                }
            }
            level++;
        }
        return -1;
    }

    private List<string> Neighbors(string code)
    {
        List<string> res = new List<string>();
        for (int i = 0; i < 4; i++)
        {
            for (int diff = -1; diff <= 1; diff += 2)
            {
                char[] nei = code.ToCharArray();
                nei[i] = (char)(((nei[i] - '0') + diff + 10) % 10 + '0');
                res.Add(new string(nei));
            }
        }
        return res;
    }
}