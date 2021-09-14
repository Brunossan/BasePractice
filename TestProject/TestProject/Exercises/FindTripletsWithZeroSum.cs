using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Util;

namespace TestProject.Exercises
{
    #region Task
    /// https://practice.geeksforgeeks.org/problems/find-triplets-with-zero-sum/1
     
    /* 
        Given an array arr[] of n integers. Check whether it contains a triplet that sums up to zero.
        Your Task:
            You don't need to read input or print anything. Your task is to complete the boolean function findTriplets() 
            which takes the array arr[] and the size of the array (n) as inputs and print 1 if the function returns true 
            else print false if the function return false. 
    /*
    /*
        Example 1:
            Input: n = 5, arr[] = {0, -1, 2, -3, 1}
            Output: 1
            Explanation: 0, -1 and 1 forms a triplet
            with sum equal to 0.
     */

    /*
        Example 2:
            Input: n = 3, arr[] = {1, 2, 3}
            Output: 0
            Explanation: No triplet with zero sum exists. 
     */
    #endregion
    
    class FindTripletsWithZeroSum
    {
        public void testMethod()
        {
            var res1 = findTriplets(new int[]{0, -1, 2, -3, 1}, 5);
            Console.WriteLine(res1);
            
            var res2 = findTriplets(new int[]{1, 2, 3}, 3);
            Console.WriteLine(res2);
        }


        public bool findTriplets(int[] arr, int n)
        {
            Array.Sort(arr);

            int sum;
            
            // As we need to find three values first for only needs to go to n-3 
            for (int i = 0; i < n-2; i++)
            {
                int lower = i+1;
                int higher = n-1;

                sum = arr[i] + arr[lower] + arr[higher];

                while (lower < higher)
                {
                    if (sum == 0) 
                        return true;
                    else if(sum < 0)
                    {
                        sum -= arr[lower];
                        lower ++;
                        sum += arr[lower];
                    }
                    else 
                    {
                        sum -= arr[higher];
                        higher --;
                        sum += arr[higher];
                    }
                }
            }
            
            return false;
        }
    }
}
