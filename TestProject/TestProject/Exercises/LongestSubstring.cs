using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Util;

namespace TestProject.Exercises
{
    #region Task
    /// https://leetcode.com/problems/longest-substring-without-repeating-characters/description/

    /* 
        Given a string s, find the length of the longest substring without duplicate characters.

 

        Example 1:

        Input: s = "abcabcbb"
        Output: 3
        Explanation: The answer is "abc", with the length of 3. Note that "bca" and "cab" are also correct answers.
        Example 2:

        Input: s = "bbbbb"
        Output: 1
        Explanation: The answer is "b", with the length of 1.
        Example 3:

        Input: s = "pwwkew"
        Output: 3
        Explanation: The answer is "wke", with the length of 3.
        Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 

        Constraints:

        0 <= s.length <= 105
        s consists of English letters, digits, symbols and spaces
     */
    #endregion

    class LongestSubstring
    {
        public void testMethod()
        {
            Console.WriteLine(LengthOfLongestSubstring("abcabcbb"));
            Console.WriteLine(LengthOfLongestSubstring("bbbbb"));
            Console.WriteLine(LengthOfLongestSubstring("pwwkew"));
        }
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0) return 0;
            int longSubstr = 1;
            for (int i = 0; i < s.Length - longSubstr; i++)
            {
                var charactersOnSubString = new HashSet<char>();
                var currentSubSize = 0;
                for (int j = i; j < s.Length; j++)
                {
                    if (charactersOnSubString.Contains(s[j])) break;

                    charactersOnSubString.Add(s[j]);
                    currentSubSize++;
                }
                if (longSubstr < currentSubSize) longSubstr = currentSubSize;
            }
            return longSubstr;
        }
    }
}
