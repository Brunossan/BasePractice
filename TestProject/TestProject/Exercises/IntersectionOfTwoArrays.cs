using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Util;

namespace TestProject.Exercises
{
    #region Task
    /// https://leetcode.com/problems/intersection-of-two-arrays-ii/
     
    /* 
        Given two integer arrays nums1 and nums2, return an array of their intersection. 
        Each element in the result must appear as many times as it shows in both arrays and you may return the result in any order.

        Constraints:
            1 <= nums1.length, nums2.length <= 1000
            0 <= nums1[i], nums2[i] <= 1000
    /*
    /*
     Example 1:
        Input:
            Input: nums1 = [1,2,2,1], nums2 = [2,2]
            Output: [2,2]
     */
    
    /*
     Example 2:
        Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
        Output: [4,9]
        Explanation: [9,4] is also accepted.
     */
    #endregion
    
    class IntersectionOfTwoArrays
    {
        public void testMethod()
        {
            var res1 = Intersect(new int[]{1,2,2,1}, new int[]{2,2});
            
            res1.PrintArray();
            
            var res2 = Intersect(new int[]{4,9,5}, new int[]{9,4,9,8,4});
            res2.PrintArray();
        }

        public int[] Intersect(int[] nums1, int[] nums2) {
            var auxCounter = new int[1001];
            var contNums1 = nums1.Length;
            var contNums2 = nums2.Length;
            
            var responseList = new List<int>(); 
            
            for (int i = 0; i < contNums1; i++ )
                auxCounter[nums1[i]]++;
            
            for (int i = 0; i < contNums2; i++ )
                if(auxCounter[nums2[i]] > 0)
                {
                    responseList.Add(nums2[i]);
                    auxCounter[nums2[i]] --;
                }
                    
            return responseList.ToArray();
        }
    }
}
