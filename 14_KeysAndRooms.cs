// https://leetcode.com/problems/keys-and-rooms/

public class Solution
{
    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        List<List<int>> g = new List<List<int>>();
        for (int i = 0; i < rooms.Count; i++)
        {
            g.Add(new List<int>());
        }
        for (int i = 0; i < rooms.Count; i++)
        {
            for (int j = 0; j < rooms[i].Count; j++)
            {
                g[i].Add(rooms[i][j]);
            }
        }

        bool[] visited = new bool[rooms.Count];
        visited[0] = true;
        DFSCanVisitAllRooms(g, 0, visited);
        for (int i = 0; i < visited.Length; i++)
        {
            if (visited[i] == false)
            {
                return false;
            }
        }
        return true;
    }
    private void DFSCanVisitAllRooms(List<List<int>> g, int st, bool[] visited)
    {
        foreach (var item in g[st])
        {
            if (!visited[item])
            {
                visited[item] = true;
                DFSCanVisitAllRooms(g, item, visited);
            }
        }
    }
}