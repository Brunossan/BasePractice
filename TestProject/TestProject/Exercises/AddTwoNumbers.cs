using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Util;

namespace TestProject.Exercises
{
    #region Task
    /// https://leetcode.com/problems/add-two-numbers/description/

    /* 
        You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

        You may assume the two numbers do not contain any leading zero, except the number 0 itself.

 

        Example 1:


        Input: l1 = [2,4,3], l2 = [5,6,4]
        Output: [7,0,8]
        Explanation: 342 + 465 = 807.
        Example 2:

        Input: l1 = [0], l2 = [0]
        Output: [0]
        Example 3:

        Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
        Output: [8,9,9,9,0,0,0,1]
 

        Constraints:

        The number of nodes in each linked list is in the range [1, 100].
        0 <= Node.val <= 9
        It is guaranteed that the list represents a number that does not have leading zeros.
     */
    #endregion

    class AddTwoNumbersSol
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode response = AddTwoNodes(l1, l2, 0);

            return response;
        }

        private ListNode AddTwoNodes(ListNode l1, ListNode l2, short carry)
        {
            ListNode newNode = new ListNode();
            newNode.val = carry + l1.val + l2.val;
            short newCary = 0;
            
            if (newNode.val > 9)
            {
                newCary = 1;
                newNode.val -= 10;
            } else newCary = 0;

            if(l1.next != null && l2.next != null)
                newNode.next = AddTwoNodes(l1.next, l2.next, newCary);
            else if(l1.next != null)
            {
                newNode.next = InsertWithCarry(l1.next, newCary);
            } 
            else if(l2.next != null)
            {
                newNode.next = InsertWithCarry(l2.next, newCary);
            } else if (newCary == 1)
            {
                newNode.next = new ListNode() { val = newCary };
            }

            return newNode;
        }

        private ListNode InsertWithCarry(ListNode l1, short carry)
        {
            var l1i = l1;

            while (l1i.next != null && l1i.val + carry > 9)
            {
                l1i.val = 0;
                l1i = l1i.next;
            }

            if (l1i.val + carry > 9)
            {
                l1i.val = 0;
                l1i.next = new ListNode() { val = 1 };
            }
            else 
                l1i.val += carry;

            return l1;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
}
