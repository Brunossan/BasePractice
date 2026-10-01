using System;
using System.Linq;

namespace TestProject.Exercises
{
    #region Task
    /// https://leetcode.com/problems/longest-common-prefix/description/

    /* 
        Write a function to find the longest common prefix string amongst an array of strings.

        If there is no common prefix, return an empty string "".

 

        Example 1:

        Input: strs = ["flower","flow","flight"]
        Output: "fl"
        Example 2:

        Input: strs = ["dog","racecar","car"]
        Output: ""
        Explanation: There is no common prefix among the input strings.
 

        Constraints:

        1 <= strs.length <= 200
        0 <= strs[i].length <= 200
        strs[i] consists of only lowercase English letters if it is non-empty.
     */
    #endregion

    class LongestCommonPrefixFinder
    {
        public void testMethod()
        {
            Console.WriteLine(LongestCommonPrefix(new string[] { "flower", "flow", "flight" }) + " " + "fl");
            Console.WriteLine(LongestCommonPrefix(new string[] { "dog", "racecar", "car" }) + " " + "");

        }

        public string LongestCommonPrefix(string[] strs)
        {
            if (strs[0] == "") return "";
            var prefix = string.Empty;
            int index = 0;
            char nextChar = strs[0][0];
            while (strs.All(s => s.Length > index && s[index] == nextChar))
            {
                prefix += strs[0][index];
                index++;
                if (index < strs[0].Length)
                {
                    nextChar = strs[0][index];
                }
            }

            return prefix;
        }
    }
}
