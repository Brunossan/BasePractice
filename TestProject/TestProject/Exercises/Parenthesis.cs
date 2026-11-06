using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject.Exercises
{
    #region Task
    /// https://leetcode.com/problems/generate-parentheses/description/

    /* 
        Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

 

        Example 1:

        Input: n = 3
        Output: ["((()))","(()())","(())()","()(())","()()()"]
        Example 2:

        Input: n = 1
        Output: ["()"]
 

        Constraints:

        1 <= n <= 8
     */
    #endregion

    class Parenthesis
    {
        public void testMethod()
        {
            Console.WriteLine(GenerateParenthesis(3));
            Console.WriteLine(GenerateParenthesis(4));

        }
        public IList<string> GenerateParenthesis(int n)
        {
            List<string> combinations = new List<string>();
            void parentheses(StringBuilder sb, int openLeft, int closeLeft)
            {
                if (sb.Length == n * 2)
                {
                    combinations.Add(sb.ToString());
                    return;
                }
                if (openLeft > 0)
                {
                    sb.Append("(");
                    parentheses(sb, openLeft - 1, closeLeft);
                    sb.Length--;
                }
                if (closeLeft > openLeft)
                {
                    sb.Append(")");
                    parentheses(sb, openLeft, closeLeft - 1);
                    sb.Length--;
                }
                return;
            }
            parentheses(new StringBuilder(), n, n);
            return combinations;
        }
    }
}
