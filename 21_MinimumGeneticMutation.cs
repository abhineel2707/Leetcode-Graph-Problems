public class Solution
{
    public int MinMutation(string start, string end, string[] bank)
    {
        HashSet<string> bankSet = new HashSet<string>();
        for (int i = 0; i < bank.Length; i++)
        {
            bankSet.Add(bank[i]);
        }

        char[] geneSet = new char[] { 'A', 'C', 'G', 'T' };
        int level = 0;
        HashSet<string> visited = new HashSet<string>();
        Queue<string> q = new Queue<string>();
        q.Enqueue(start);
        visited.Add(start);

        while (q.Count > 0)
        {
            int size = q.Count;
            for (int i = 0; i < size; i++)
            {
                string cur = q.Dequeue();
                if (cur == end)
                {
                    return level;
                }
                char[] curArr = cur.ToCharArray();
                for (int j = 0; j < curArr.Length; j++)
                {
                    char oldChar = curArr[j];
                    foreach (var gene in geneSet)
                    {
                        curArr[j] = gene;
                        string next = new String(curArr);
                        if (!visited.Contains(next) && bankSet.Contains(next))
                        {
                            visited.Add(next);
                            q.Enqueue(next);
                        }
                    }
                    curArr[j] = oldChar;
                }
            }
            level++;
        }
        return -1;
    }
}