using System;
using System.Collections.Generic;
using System.Linq;
using TestProject.Util;

namespace TestProject.Exercises
{
    #region Task
    /// https://leetcode.com/problems/3sum-closest/

    /* 
        You are given an integer array nums of length n and an integer target.

        Find three integers at distinct indices in nums such that the sum is closest to target.

        Return the sum of the three integers.

        You may assume that each input would have exactly one solution.

 

        Example 1:

        Input: nums = [-1,2,1,-4], target = 1
        Output: 2
        Explanation: The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).
        Example 2:

        Input: nums = [0,0,0], target = 1
        Output: 0
        Explanation: The sum that is closest to the target is 0. (0 + 0 + 0 = 0).
 

        Constraints:

        3 <= nums.length <= 500
        -1000 <= nums[i] <= 1000
        -104 <= target <= 104
     */
    #endregion

    class Closest3Sum
    {
        public void testMethod()
        {
            ThreeSumClosest([-1, 0, 1, 2, -1, -4], 2);
            ThreeSumClosest([0, 1, 1], 0);
        }
        public int ThreeSumClosest(int[] nums, int target)
        {
            nums = nums.OrderBy(x => x).ToArray();
            var closest = nums[0] + nums[1] + nums[2];
            for (int i = 0; i < nums.Length - 2; i++)
            {
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {
                        var sum = nums[i] + nums[j] + nums[k];
                        if (sum == target)
                        {
                            return target;
                        }
                        if (Math.Abs(sum - target) < Math.Abs(closest - target)) closest = sum;
                        if (sum - target > 0) break;
                    }
                }
            }

            return closest;
        }
    }
}
