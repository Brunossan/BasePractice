using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Util;

namespace TestProject.Exercises
{
    #region Task
    /// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/638/week-3-september-15th-september-21st/3976/
    /// Longest Turbulent Subarray
     
    /* 
        Given an integer array arr, return the length of a maximum size turbulent subarray of arr.
        
        A subarray is turbulent if the comparison sign flips between each adjacent pair of elements in the subarray.
        
        More formally, a subarray [arr[i], arr[i + 1], ..., arr[j]] of arr is said to be turbulent if and only if:
        
        For i <= k < j:
            arr[k] > arr[k + 1] when k is odd, and
            arr[k] < arr[k + 1] when k is even.
        Or, for i <= k < j:
            arr[k] > arr[k + 1] when k is even, and
            arr[k] < arr[k + 1] when k is odd.

        Constraints:
            1 <= arr.length <= 4 * 104
            0 <= arr[i] <= 109
    /*

    /*
     Example 1:
        Input: arr = [9,4,2,10,7,8,8,1,9]
        Output: 5
        Explanation: arr[1] > arr[2] < arr[3] > arr[4] < arr[5]
     */

    /*
     Example 2:
        Input: arr = [4,8,12,16]
        Output: 2
     */

    /*
     Example 2:
        Input: arr = [100]
        Output: 1
     */
    #endregion
    
    class LongestTurbulentSubarray
    {
        public void testMethod()
        {
            Console.WriteLine(MaxTurbulenceSize(new int[]{9,4,2,10,7,8,8,1,9}));
            Console.WriteLine(MaxTurbulenceSize(new int[]{4,8,12,16}));
            Console.WriteLine(MaxTurbulenceSize(new int[]{100}));
        }

        public int MaxTurbulenceSize(int[] arr) 
        {
            // For some reason leetcode does not accept Lenght, in the website Count() function was used
            var n = arr.Length;
            
            // Althought constrights say arr must have at least one value, added this just to be safe
            if(n == 0) return 0;
            
            var currentCount = 0;
            var maxCount = 1;
            
            var i = 0;
            
            while (i+1 < n)
            {   
                if(arr[i] > arr[i+1])
                    currentCount = zig(i, arr, n);
                else
                    currentCount = zag(i, arr, n);
                
                if(currentCount > maxCount)
                    maxCount = currentCount;
                
                i += currentCount > 1? currentCount-1 : 1;
            }  
            
            return maxCount;
        }
        
        // check if it is higher then next number
        private int zig(int j, int[] arr, int size)
        {
            if(j+1 == size) return 1;
            
            if(arr[j] > arr[j+1])
                return 1+zag(j+1,arr,size);
            else
                return 1;
        }
        
        // Check if if lower than next number
        private int zag(int j, int[] arr, int size)
        {
            if(j+1 == size) return 1;
            
            if(arr[j] < arr[j+1])
                return 1 + zig(j+1,arr,size);
            else
                return 1;
                
        }
    }
}
