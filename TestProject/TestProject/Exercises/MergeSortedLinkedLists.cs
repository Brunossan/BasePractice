using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Util;

namespace TestProject.Exercises
{
    #region Task
    /// https://leetcode.com/problems/merge-two-sorted-lists/

    /* 
        You are given the heads of two sorted linked lists list1 and list2.

        Merge the two lists into one sorted list. The list should be made by splicing together the nodes of the first two lists.

        Return the head of the merged linked list.

 

        Example 1:


        Input: list1 = [1,2,4], list2 = [1,3,4]
        Output: [1,1,2,3,4,4]
        Example 2:

        Input: list1 = [], list2 = []
        Output: []
        Example 3:

        Input: list1 = [], list2 = [0]
        Output: [0]
 

        Constraints:

        The number of nodes in both lists is in the range [0, 50].
        -100 <= Node.val <= 100
        Both list1 and list2 are sorted in non-decreasing order.
    */

    #endregion


    /**
 * Definition for singly-linked list. (Already somewhere in this solution :D )
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
    public class MergeSortedLinkedLists
    {
        public void testMethod()
        {
            Console.WriteLine(MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }));
            Console.WriteLine(MaxArea(new int[] { 1, 1 }));
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode newList;

            var next1 = list1;
            var next2 = list2;

            if (next1 == null)
            {
                newList = next2;
                return newList;
            }
            if (next2 == null)
            {
                newList = next1;
                return newList;
            }

            // Start the list
            if (next1.val < next2.val)
            {
                newList = next1;
                next1 = next1.next;
            }
            else
            {
                newList = next2;
                next2 = next2.next;
            }

            var pointer = newList;
            while (true)
            {
                if (next1 == null)
                {
                    pointer.next = next2;
                    return newList;
                }
                if (next2 == null)
                {
                    pointer.next = next1;
                    return newList;
                }

                if (next1.val < next2.val)
                {
                    pointer.next = next1;
                    next1 = next1.next;
                }
                else
                {
                    pointer.next = next2;
                    next2 = next2.next;
                }

                pointer = pointer.next;
            }

        }
    }
}
