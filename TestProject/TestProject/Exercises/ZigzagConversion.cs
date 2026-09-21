using System;
using System.Linq;

namespace TestProject.Exercises
{
    #region Task
    /// https://leetcode.com/problems/zigzag-conversion/

    /* 
        The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

        P   A   H   N
        A P L S I I G
        Y   I   R
        And then read line by line: "PAHNAPLSIIGYIR"

        Write the code that will take a string and make this conversion given a number of rows:

        string convert(string s, int numRows);
 

        Example 1:

        Input: s = "PAYPALISHIRING", numRows = 3
        Output: "PAHNAPLSIIGYIR"
        Example 2:

        Input: s = "PAYPALISHIRING", numRows = 4
        Output: "PINALSIGYAHRPI"
        Explanation:
        P     I    N
        A   L S  I G
        Y A   H R
        P     I
        Example 3:

        Input: s = "A", numRows = 1
        Output: "A"
 

        Constraints:

        1 <= s.length <= 1000
        s consists of English letters (lower-case and upper-case), ',' and '.'.
        1 <= numRows <= 1000
     */
    #endregion

    class ZigzagConversion
    {
        public void testMethod()
        {
            Console.WriteLine(Convert("PAYPALISHIRING", 3) + " " + "PAHNAPLSIIGYIR");
            Console.WriteLine(Convert("PAYPALISHIRING", 4) + " " + "PINALSIGYAHRPI");

        }

        private string Convert(string s, int numRows)
        {
            if(numRows == 1)
                return s;

            var substr = new string[numRows];
            var zig = true;
            var rowToAdd = 0;

            for (int i = 0; i < s.Length; i++)
            {
                substr[rowToAdd] += s[i];
                if (zig)
                {
                    rowToAdd++;
                    if (rowToAdd == numRows - 1)
                    {
                        zig = false;
                    }
                }
                else
                {
                    rowToAdd--;
                    if (rowToAdd == 0)
                    {
                        zig = true;
                    }
                }
            }

            return substr.Aggregate((a, b) => a + b);
        }
    }
}
