// https://leetcode.com/problems/pacific-atlantic-water-flow/

public class Solution
{
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        int r = heights.Length;
        int c = heights[0].Length;

        bool[,] pacific = new bool[r, c];
        bool[,] atlantic = new bool[r, c];

        for (int i = 0; i < r; i++)
        {
            DFSPacificAtlantic(heights, pacific, Int32.MinValue, i, 0, r, c);
            DFSPacificAtlantic(heights, atlantic, Int32.MinValue, i, c - 1, r, c);
        }

        for (int j = 0; j < c; j++)
        {
            DFSPacificAtlantic(heights, pacific, Int32.MinValue, 0, j, r, c);
            DFSPacificAtlantic(heights, atlantic, Int32.MinValue, r - 1, j, r, c);
        }

        List<IList<int>> res = new List<IList<int>>();
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (pacific[i, j] && atlantic[i, j])
                {
                    res.Add(new List<int>(new int[] { i, j }));
                }
            }
        }
        return res;
    }

    private void DFSPacificAtlantic(int[][] heights, bool[,] visited, int height, int i, int j, int r, int c)
    {
        // Check if the new cell's height is higher, only then water can flow from new cell to old cell
        if (i < 0 || i >= r || j < 0 || j >= c || visited[i, j] || heights[i][j] < height)
        {
            return;
        }
        visited[i, j] = true;
        DFSPacificAtlantic(heights, visited, heights[i][j], i + 1, j, r, c);
        DFSPacificAtlantic(heights, visited, heights[i][j], i, j + 1, r, c);
        DFSPacificAtlantic(heights, visited, heights[i][j], i - 1, j, r, c);
        DFSPacificAtlantic(heights, visited, heights[i][j], i, j - 1, r, c);
    }
}