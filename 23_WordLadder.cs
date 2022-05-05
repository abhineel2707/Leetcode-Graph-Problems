// https://leetcode.com/problems/word-ladder/

public class Solution
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        HashSet<string> wordSet = new HashSet<string>();
        foreach (var word in wordList)
        {
            wordSet.Add(word);
        }

        if (!wordSet.Contains(endWord))
        {
            return 0;
        }

        HashSet<string> visited = new HashSet<string>();
        Queue<string> q = new Queue<string>();
        q.Enqueue(beginWord);
        visited.Add(beginWord);

        int changes = 1;
        while (q.Count > 0)
        {
            int size = q.Count;
            for (int i = 0; i < size; i++)
            {
                string cur = q.Dequeue();
                if (cur == endWord)
                {
                    return changes;
                }
                char[] curArr = cur.ToCharArray();
                for (int j = 0; j < curArr.Length; j++)
                {
                    char oldChar = curArr[j];
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        curArr[j] = c;
                        string next = new string(curArr);
                        if (!visited.Contains(next) && wordSet.Contains(next))
                        {
                            visited.Add(next);
                            q.Enqueue(next);
                        }
                    }
                    curArr[j] = oldChar;
                }
            }
            changes++;
        }
        return 0;
    }
}