using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Util;

namespace TestProject.Exercises
{
    #region Task
    /// https://leetcode.com/problems/edit-distance/
     
    /* 
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        
        You have the following three operations permitted on a word:
            Insert a character
            Delete a character
            Replace a character

     

        Constraints:
            0 <= word1.length, word2.length <= 500
            word1 and word2 consist of lowercase English letters.
    /*
    /*
     Example 1:
        Input: word1 = "horse", word2 = "ros"
            Output: 3

        Explanation: 
            horse -> rorse (replace 'h' with 'r')
            rorse -> rose (remove 'r')
            rose -> ros (remove 'e')
     */

    /*
     Example 2:
        Input: word1 = "intention", word2 = "execution"
            Output: 5

        Explanation: 
            intention -> inention (remove 't')
            inention -> enention (replace 'i' with 'e')
            enention -> exention (replace 'n' with 'x')
            exention -> exection (replace 'n' with 'c')
            exection -> execution (insert 'u')
     */
    #endregion
    
    public class EditDistance
    {
        public void testMethod()
        {
            Console.WriteLine("Min between: 'horse' and 'ros' = " + MinDistance("horse", "ros"));
            Console.WriteLine("Min between: 'intention' and 'execution' = " + MinDistance("intention", "execution"));
        }

        public int MinDistance(string word1, string word2) {
            var size1 = word1.Length;
            var size2 = word2.Length;
            int[,] subProblemMatrix = new int[size1+1, size2+1];
        
            if(size1 == 0)
                return size2;
            if(size2 == 0)
                return size1;
        
            for (int i = 0; i <= size1; i++)
                subProblemMatrix[i,0] = i;
        
            for (int i = 0; i <= size2; i++)
                subProblemMatrix[0,i] = i;
        
            for(int i = 1; i <= size1; i++)
             for(int j = 1; j <= size2; j++)
             {
                 //Console.WriteLine("i:" + i+" j:"+ j);
                 //Console.WriteLine("min:" + subProblemMatrix[i-1,j]+" "+ subProblemMatrix[i,j-1] +" "+ subProblemMatrix[i-1,j-1] +" "+ minVal);
             
                 //Console.WriteLine("w1 letter: "+ word1[i-1] + " w2 letter: "+ word2[j-1]);
                 if(word1[i-1] == word2[j-1])
                     subProblemMatrix[i,j] = subProblemMatrix[i-1,j-1];
                 else 
                     subProblemMatrix[i,j] = this.getMin(subProblemMatrix[i-1,j], subProblemMatrix[i,j-1], subProblemMatrix[i-1,j-1])+1;
             
                 //Console.WriteLine("Final value: "+subProblemMatrix[i,j]);
             }
        
            return subProblemMatrix[size1, size2];
        }
    
        public int getMin(int v1, int v2, int v3)
        {
            if(v1 <= v2 && v1 <= v3)
                return v1;
        
            if(v2 <= v3)
                return v2;
        
            return v3;
        }
    }
}
