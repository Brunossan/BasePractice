using System;
using System.Linq;

namespace TestProject.Exercises
{
    #region Task
    /// https://leetcode.com/problems/regular-expression-matching

    /* 
        Given an input string s and a pattern p, implement regular expression matching with support for '.' and '*' where:

        '.' Matches any single character.​​​​
        '*' Matches zero or more of the preceding element.
        Return a boolean indicating whether the matching covers the entire input string (not partial).

 

        Example 1:

        Input: s = "aa", p = "a"
        Output: false
        Explanation: "a" does not match the entire string "aa".
        Example 2:

        Input: s = "aa", p = "a*"
        Output: true
        Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
        Example 3:

        Input: s = "ab", p = ".*"
        Output: true
        Explanation: ".*" means "zero or more (*) of any character (.)".
 

        Constraints:

        1 <= s.length <= 20
        1 <= p.length <= 20
        s contains only lowercase English letters.
        p contains only lowercase English letters, '.', and '*'.
        It is guaranteed for each appearance of the character '*', there will be a previous valid character to match.
     */
    #endregion

    class RegexMatching
    {
        public void testMethod()
        {
            //Console.WriteLine(IsMatch("aa", "a") + " " + "aa : a");
            //Console.WriteLine(IsMatch("aa", "a*") + " " + "aa : a*");
            //Console.WriteLine(IsMatch("ab", ".*") + " " + "ab : .*");
            //Console.WriteLine(IsMatch("aab", "c*a*b") + " " + "aab : c*a*b");
            Console.WriteLine(IsMatch("a", "ab*") + " " + "a : ab*");
        }



        public bool IsMatch(string s, string p)
        {
            return CheckPosition(s, 0, p, 0);
        }

        private bool CheckPosition(string s, int sIt, string p, int pIt)
        {
            if (sIt >= s.Length && pIt >= p.Length)
            {
                return true;
            }
            
            var isStar = pIt < p.Length - 1 && p[pIt + 1] == '*';

            if (sIt >= s.Length && isStar)
            {
                return CheckPosition(s, sIt, p, pIt + 2);
            }
            else if (sIt >= s.Length || pIt >= p.Length)
            {
                return false;
            }

            var isMatch = s[sIt] == p[pIt] || p[pIt] == '.';
            /// Check for chr + *
            if (isStar)
            {
                if (isMatch)
                {
                    return CheckPosition(s, sIt, p, pIt + 2) // Check 0 Values 
                        || CheckPosition(s, sIt + 1, p, pIt); // Check next values
                }

                return CheckPosition(s, sIt, p, pIt + 2); // Check 0 Values
            }
            /// Curent position check 
            else if (!isMatch)
            {
                return false;
            }

            return CheckPosition(s, sIt + 1, p, pIt + 1);
        }
    }
}
