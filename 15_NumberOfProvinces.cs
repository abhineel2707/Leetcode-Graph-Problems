// https://leetcode.com/problems/number-of-provinces/

public class Solution
{
    public int FindCircleNum(int[][] isConnected)
    {
        bool[] visited = new bool[isConnected.Length];
        int count = 0;
        for (int i = 0; i < isConnected.Length; i++)
        {
            if (!visited[i])
            {
                DFSFindCircleNum(isConnected, visited, i);
                count++;
            }
        }
        return count;
    }
    private void DFSFindCircleNum(int[][] isConnected, bool[] visited, int i)
    {
        for (int j = 0; j < isConnected.Length; j++)
        {
            if (isConnected[i][j] == 1 && !visited[j])
            {
                visited[j] = true;
                DFSFindCircleNum(isConnected, visited, j);
            }
        }
    }
}