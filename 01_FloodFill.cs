// https://leetcode.com/problems/flood-fill/

public class Solution
{
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
    {
        int color = image[sr][sc];
        DFSFloodFill(image, sr, sc, color, newColor);
        return image;
    }

    private void DFSFloodFill(int[][] image, int r, int c, int color, int newColor)
    {
        if (r < 0 || r >= image.Length || c < 0 || c >= image[0].Length || image[r][c] == newColor)
        {
            return;
        }
        if (image[r][c] == color)
        {
            image[r][c] = newColor;
            DFSFloodFill(image, r + 1, c, color, newColor);
            DFSFloodFill(image, r, c + 1, color, newColor);
            DFSFloodFill(image, r - 1, c, color, newColor);
            DFSFloodFill(image, r, c - 1, color, newColor);
        }
    }
}