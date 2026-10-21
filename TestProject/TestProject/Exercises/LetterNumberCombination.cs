using System;
using System.Collections.Generic;

namespace TestProject.Exercises
{
    #region Task
    /// https://leetcode.com/problems/letter-combinations-of-a-phone-number/description/

    /* 
        Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent. Return the answer in any order.

        A mapping of digits to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.


 

        Example 1:

        Input: digits = "23"
        Output: ["ad","ae","af","bd","be","bf","cd","ce","cf"]
        Example 2:

        Input: digits = "2"
        Output: ["a","b","c"]
 

        Constraints:

        1 <= digits.length <= 4
        digits[i] is a digit in the range ['2', '9'].
     */
    #endregion

    class LetterNumberCombination
    {
        public void testMethod()
        {
            Console.WriteLine(LetterCombinations("23"));
            Console.WriteLine(LetterCombinations("2"));
        }

        public IList<string> LetterCombinations(string digits)
        {
            var responses = new List<string>();
            AddBoy(responses, "", digits, 0);
            return responses;
        }

        public void AddBoy(List<string> responses, string response, string digits, int chrId)
        {
            if (chrId == digits.Length)
            {
                responses.Add(response);
                return;
            }


            switch (digits[chrId])
            {
                case '2':
                    AddBoy(responses, response + 'a', digits, chrId + 1);
                    AddBoy(responses, response + 'b', digits, chrId + 1);
                    AddBoy(responses, response + 'c', digits, chrId + 1);
                    break;
                case '3':
                    AddBoy(responses, response + 'd', digits, chrId + 1);
                    AddBoy(responses, response + 'e', digits, chrId + 1);
                    AddBoy(responses, response + 'f', digits, chrId + 1);
                    break;
                case '4':
                    AddBoy(responses, response + 'g', digits, chrId + 1);
                    AddBoy(responses, response + 'h', digits, chrId + 1);
                    AddBoy(responses, response + 'i', digits, chrId + 1);
                    break;
                case '5':
                    AddBoy(responses, response + 'j', digits, chrId + 1);
                    AddBoy(responses, response + 'k', digits, chrId + 1);
                    AddBoy(responses, response + 'l', digits, chrId + 1);
                    break;
                case '6':
                    AddBoy(responses, response + 'm', digits, chrId + 1);
                    AddBoy(responses, response + 'n', digits, chrId + 1);
                    AddBoy(responses, response + 'o', digits, chrId + 1);
                    break;
                case '7':
                    AddBoy(responses, response + 'p', digits, chrId + 1);
                    AddBoy(responses, response + 'q', digits, chrId + 1);
                    AddBoy(responses, response + 'r', digits, chrId + 1);
                    AddBoy(responses, response + 's', digits, chrId + 1);
                    break;
                case '8':
                    AddBoy(responses, response + 't', digits, chrId + 1);
                    AddBoy(responses, response + 'u', digits, chrId + 1);
                    AddBoy(responses, response + 'v', digits, chrId + 1);
                    break;
                case '9':
                    AddBoy(responses, response + 'w', digits, chrId + 1);
                    AddBoy(responses, response + 'x', digits, chrId + 1);
                    AddBoy(responses, response + 'y', digits, chrId + 1);
                    AddBoy(responses, response + 'z', digits, chrId + 1);
                    break;
                case '0':
                    AddBoy(responses, response + ' ', digits, chrId + 1);
                    break;
            }
        }
    }
}
