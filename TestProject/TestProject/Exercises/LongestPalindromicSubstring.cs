using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Util;

namespace TestProject.Exercises
{
    #region Task
    /// https://leetcode.com/problems/longest-palindromic-substring/
     
    /* 
        Given a string s, return the longest palindromic substring in s.

        Constraints:
            1 <= s.length <= 1000
            s consist of only digits and English letters.
    /*
    /*
     Example 1:
        Input:
            Input: s = "babad"
            Output: "bab"
            Note: "aba" is also a valid answer.
     */
    
    /*
     Example 2:
        Input: s = "cbbd"
        Output: "bb"
     */

    /*
     Example 3:
        Input: s = "a"
        Output: "a"
     */
    
    /*
     Example 4:
        Input: s = "ac"
        Output: "a"
     */
    #endregion
    
    class LongestPalindromicSubstring
    {
        public void testMethod()
        {
            Console.WriteLine("word:  " + "babad" + " >> LP: " + LongestPalindrome("babad"));
            Console.WriteLine("word:  " + "cbbd" + " >> LP: " + LongestPalindrome("cbbd"));
            Console.WriteLine("word:  " + "a" + " >> LP: " + LongestPalindrome("a"));
            Console.WriteLine("word:  " + "ac" + " >> LP: " + LongestPalindrome("ac"));
            Console.WriteLine("word:  "+"bb"+ " >> LP: "+ LongestPalindrome("bb"));
            Console.WriteLine("word:  "+"ccc"+ " >> LP: "+ LongestPalindrome("ccc"));
        }

        public string LongestPalindrome(string s)
        {
            string response = s[0].ToString();

            for(int i = 0; i < s.Length-1; i ++)
            {
                var palidrome = GetLargestPalindrome(s, i);
                if(palidrome.Length > response.Length)
                    response = palidrome;
            }

            return response;    
        }

        private string GetLargestPalindrome(string s, int index)
        {
            var p1 = recursivelyPalidromeFinder3000(s, index, index);
            var p2 = recursivelyPalidromeFinder3000(s, index, index+1);

            return p1.Length > p2.Length? p1 : p2;
        }
        
        private string recursivelyPalidromeFinder3000(string s, int init, int end)
        {
             if(s[init] != s[end])
                if(init == end)
                    return "";
                else
                    return s.Substring(init+1, end-init-1);

             if(end == s.Length-1 || init == 0 )
                if(init == end)
                    return "";
                else
                    return s.Substring(init, end-init+1);

            return recursivelyPalidromeFinder3000(s, init-1, end+1);
        }

    }
}
