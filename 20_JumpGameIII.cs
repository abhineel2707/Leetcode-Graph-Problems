// https://leetcode.com/problems/jump-game-iii/

public class Solution
{
    public bool CanReach(int[] arr, int start)
    {
        return CanReachHelper(arr, start);
    }

    private bool CanReachHelper(int[] arr, int si)
    {
        if (si < 0 || si >= arr.Length || arr[si] < 0)
        {
            return false;
        }
        if (arr[si] == 0)
        {
            return true;
        }
        arr[si] = -arr[si];
        bool d1 = CanReachHelper(arr, si + arr[si]);
        bool d2 = CanReachHelper(arr, si - arr[si]);

        return d1 || d2;
    }
}