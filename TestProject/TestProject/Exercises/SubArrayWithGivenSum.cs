using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Util;

namespace TestProject.Exercises
{
    #region Task
    /// https://practice.geeksforgeeks.org/problems/subarray-with-given-sum-1587115621/1
     
    /* 
     Given an unsorted array A of size N that contains only non-negative integers, find a continuous sub-array which adds to a given number S.
     Your Task:
        You don't need to read input or print anything. 
        The task is to complete the function subarraySum() which takes arr, N and S as input parameters and returns a 
        list containing the starting and ending positions of the first such occurring subarray from the left where sum equals to S. 
        The two indexes in the list should be according to 1-based indexing. If no such subarray is found, return an array consisting only one element that is -1.
    /*
    /*
     Example 1:
        Input:
        N = 5, S = 12
        A[] = {1,2,3,7,5}
        Output: 2 4
        Explanation: The sum of elements 
        from 2nd position to 4th position 
        is 12.
     */

    /*
     Example 2:
        Input:
        N = 10, S = 15
        A[] = {1,2,3,4,5,6,7,8,9,10}
        Output: 1 5
        Explanation: The sum of elements 
        from 1st position to 5th position
        is 15.
     */
    #endregion
    
    class SubArrayWithGivenSum
    {
        public void testMethod()
        {
            var res1 = subarraySum(new int[]{1,2,3,7,5}, 5, 12);
            
            res1.PrintArray();
            
            var res2 = subarraySum(new int[]{1,2,3,4,5,6,7,8,9,10}, 10, 15);
            res2.PrintArray();
        }

        public int[] subarraySum(int[] arr, int n, int s)
        {
            int init = 0;
            int end = 0;

            var sum = arr[0];

            //Logic goes here
            while (init < n && end < n)
            {
                // If the index 
                if (sum == s)
                    return new int[2] { init + 1 , end + 1 }; // considering vector index starting as 1

                if(sum > s)
                {
                    sum -= arr[init];
                    init ++;
                } 
                else
                {
                    end ++;
                    sum += arr[end];
                }
            }
            
            return new int[1] { -1 };
        }
    }
}
