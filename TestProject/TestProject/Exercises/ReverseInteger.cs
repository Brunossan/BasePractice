using System;
using System.Linq;

namespace TestProject.Exercises
{
    #region Task
    /// https://leetcode.com/problems/reverse-integer/

    /* 
        Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.

        Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

 

        Example 1:

        Input: x = 123
        Output: 321
        Example 2:

        Input: x = -123
        Output: -321
        Example 3:

        Input: x = 120
        Output: 21
 

        Constraints:

        -231 <= x <= 231 - 1
     */
    #endregion

    class ReverseInteger
    {
        public void testMethod()
        {
            //Console.WriteLine(Reverse(123) + " " + 321);
            //Console.WriteLine(Reverse(-123) + " " + -321);
            //Console.WriteLine(Reverse(120) + " " + 21);
            Console.WriteLine(Reverse(1534236469) + " " + 0);
        }

        public int Reverse(int x)
        {
            var isNegative = x < 0;
            double reversed = 0;

            if (isNegative)
            {
                x = -x;
            }

            while (x != 0)
            {
                reversed = reversed * 10 + x % 10;
                x /= 10;
            }

            if (reversed > Int32.MaxValue || reversed < Int32.MinValue)
            {
                return 0;
            }

            if (isNegative)
            {
                reversed = -reversed;
            }

            return (int)reversed;
        }
    }
}
