using System;
using System.Linq;

namespace TestProject.Exercises
{
    #region Task
    /// https://leetcode.com/problems/median-of-two-sorted-arrays/description/

    /* 
        Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.

        The overall run time complexity should be O(log (m+n)).

        Example 1:

        Input: nums1 = [1,3], nums2 = [2]
        Output: 2.00000
        Explanation: merged array = [1,2,3] and median is 2.
        Example 2:

        Input: nums1 = [1,2], nums2 = [3,4]
        Output: 2.50000
        Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
 

        Constraints:

        nums1.length == m
        nums2.length == n
        0 <= m <= 1000
        0 <= n <= 1000
        1 <= m + n <= 2000
        -106 <= nums1[i], nums2[i] <= 106
     */
    #endregion

    class MedianOfTwoSortedArrays
    {
        public void testMethod()
        {
            Console.WriteLine(FindMedianSortedArrays(new int[] { 1, 3 }, new int[] { 2 }));
            Console.WriteLine(FindMedianSortedArrays(new int[] { 1, 2 }, new int[] { 3, 4 }));
            //Console.WriteLine(FindMedianSortedArrays(new int[] { }, new int[] { 4 }));
            //Console.WriteLine(FindMedianSortedArrays(new int[] { 20 }, new int[] { }));
            Console.WriteLine(FindMedianSortedArrays(new int[] { 0, 0, 0, 0, 0 }, new int[] { -1, 0, 0, 0, 0, 0, 1 }));
            Console.WriteLine(FindMedianSortedArrays(new int[] { 1, 2, 3, 4, 5 }, new int[] { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }));
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            // Edge cases
            if(nums1.Length == 0)
                return FindMean(nums2);
            if(nums2.Length == 0)
                return FindMean(nums1);

            var middleLen = (nums1.Length + nums2.Length) / 2;
            var even = (nums1.Length + nums2.Length) % 2 == 0;
            if (!even) middleLen++;

            Tuple<int, int> lastElement = new Tuple<int, int>(-1, -1);

            var pointer1 = 0;
            var pointer2 = 0;

            var end1 = false;
            var end2 = false;
            // Find new mean
            for (int i = 0; i < middleLen; i++)
            {
                if ((nums1[pointer1] < nums2[pointer2] && !end1) || end2)
                {
                    lastElement = new Tuple<int, int>(pointer1, 1);
                    if (pointer1 < nums1.Length - 1) pointer1++;
                    else end1 = true;
                }
                else
                {
                    lastElement = new Tuple<int, int>(pointer2, 2);
                    if (pointer2 < nums2.Length - 1) pointer2++;
                    else end2 = true;
                }
            }

            var middleBoy = lastElement.Item2 == 1 ? nums1[lastElement.Item1] : nums2[lastElement.Item1];

            // Even number of elements
            if (even)
            {
                if (end1)
                {
                    middleBoy += nums2[pointer2];
                }
                else if(end2)
                {
                    middleBoy += nums1[pointer1];
                }
                else if (nums1[pointer1] < nums2[pointer2])
                {
                    middleBoy += nums1[pointer1];
                }
                else
                {
                    middleBoy += nums2[pointer2];
                }

                return (double)middleBoy / 2;
            }

            return (double)middleBoy;
        }

        static double FindMean(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                throw new ArgumentException("Array cannot be null or empty.");
            }

            if(arr.Length % 2 == 0)
            {
                var mid = arr.Length / 2;
                return (arr[mid - 1] + arr[mid]) / 2.0;
            }

            return arr[arr.Length / 2];
        }
    }
}
