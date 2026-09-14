using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Util;

namespace TestProject.Exercises
{
    #region Task
    /// https://leetcode.com/problems/valid-palindrome-ii/description/

    /* 
        Given a string s, return true if the s can be palindrome after deleting at most one character from it.

        Example 1:

        Input: s = "aba"
        Output: true
        Example 2:

        Input: s = "abca"
        Output: true
        Explanation: You could delete the character 'c'.
        Example 3:

        Input: s = "abc"
        Output: false
 

        Constraints:

        1 <= s.length <= 105
        s consists of lowercase English letters.
     */
    #endregion

    class ValidPalindromeII
    {
        public void testMethod()
        {
            Console.WriteLine("word:  " + "aba" + " >> true: " + ValidPalindrome("aba"));
            Console.WriteLine("word:  " + "abca" + " >> true: " + ValidPalindrome("abca"));
            Console.WriteLine("word:  " + "abc" + " >> false: " + ValidPalindrome("abc"));
        }
        public bool ValidPalindrome(string s)
        {
            bool isPalindrome = true;

            var sLen = s.Length;
            bool deletedUsed = false;
            bool righDeleteIsPalindrome = true;
            bool leftDeleteIsPalindrome = true;
            for (int i = 0; i < sLen / 2; i++)
            {
                if (!deletedUsed)
                {
                    if (s[i] != s[sLen - i - 1])
                    {
                        deletedUsed = true;
                    }
                }

                if (deletedUsed)
                {
                    if (s[i + 1] != s[sLen - i - 1])
                        leftDeleteIsPalindrome = false;
                    if (s[i] != s[sLen - i - 2])
                        righDeleteIsPalindrome = false;
                }
                if (!righDeleteIsPalindrome && !leftDeleteIsPalindrome) return false;
            }

            return true;
        }
    }
}
