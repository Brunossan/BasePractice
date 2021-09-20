using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Util;

namespace TestProject.Exercises
{
    #region Task
    /// https://leetcode.com/explore/challenge/card/september-leetcoding-challenge-2021/638/week-3-september-15th-september-21st/3981/
     
    /* 
     Tic-tac-toe is played by two players A and B on a 3 x 3 grid.

     Here are the rules of Tic-Tac-Toe:
         Players take turns placing characters into empty squares (" ").
         The first player A always places "X" characters, while the second player B always places "O" characters.
         "X" and "O" characters are always placed into empty squares, never on filled ones.
         The game ends when there are 3 of the same (non-empty) character filling any row, column, or diagonal.
         The game also ends if all squares are non-empty.
         No more moves can be played if the game is over.
         Given an array moves where each element is another array of size 2 corresponding to the row and column of the grid where they mark their respective character in the order in which A and B play.

     Return the winner of the game if it exists (A or B), in case the game ends in a draw return "Draw", if there are still movements to play return "Pending".

     You can assume that moves is valid (It follows the rules of Tic-Tac-Toe), the grid is initially empty and A will play first.

     Constraints:
         1 <= moves.length <= 9
         moves[i].length == 2
         0 <= moves[i][j] <= 2
         There are no repeated elements on moves.
         moves follow the rules of tic tac toe.
    /*
    /*
     Example 1:
        Input: moves = [[0,0],[2,0],[1,1],[2,1],[2,2]]
        Output: "A"
        Explanation: "A" wins, he always plays first.
     */
    
    /*
     Example 2:
        Input: moves = [[0,0],[1,1],[0,1],[0,2],[1,0],[2,0]]
        Output: "B"
        Explanation: "B" wins.
     */

    /*
     Example 3:
        Input: moves = [[0,0],[1,1],[2,0],[1,0],[1,2],[2,1],[0,1],[0,2],[2,2]]
        Output: "Draw"
        Explanation: The game ends in a draw since there are no moves to make.
     */
    
    /*
     Example 4:
        Input: moves = [[0,0],[1,1]]
        Output: "Pending"
        Explanation: The game has not finished yet.
     */

    #endregion
    
    class FindWinnerOnATicTacToeGame
    {
        public void testMethod()
        {
            //[[0,0],[2,0],[1,1],[2,1],[2,2]]
            Console.WriteLine(Tictactoe(new int[5][]{
                new int[2] {0,0},
                new int[2] {2,0},
                new int[2] {1,1},
                new int[2] {2,1},
                new int[2] {2,2}    
            }));

            //[[0,0],[1,1],[0,1],[0,2],[1,0],[2,0]]
            Console.WriteLine(Tictactoe(new int[6][]{
                new int[2] {0,0},
                new int[2] {1,1},
                new int[2] {0,1},
                new int[2] {0,2},
                new int[2] {1,0},
                new int[2] {2,0}    
            }));

            //[[0,0],[1,1],[2,0],[1,0],[1,2],[2,1],[0,1],[0,2],[2,2]]
            Console.WriteLine(Tictactoe(new int[9][]{
                new int[2] {0,0},
                new int[2] {1,1},
                new int[2] {2,0},
                new int[2] {1,0},
                new int[2] {1,2},
                new int[2] {2,1},
                new int[2] {0,1},
                new int[2] {0,2},
                new int[2] {2,2}    
            }));

            //[[0,0],[1,1]]
            Console.WriteLine(Tictactoe(new int[2][]{
                new int[2] {0,0},
                new int[2] {1,1}   
            }));
        }

        public string Tictactoe(int[][] moves) {
            int nMoves = moves.Length;
            int[][] board = MakeMoves(moves, nMoves);
            int gameWinner = GetGameWinner(board);
            
            if(gameWinner == 0)
            {
                if(nMoves == 9)
                    return "Draw";
                else
                   return "Pending";
            } 
            
            if(gameWinner == 1)
                return "A";
            
            return "B";
        }
        
        public int[][] MakeMoves(int[][] moves, int nMoves)
        {
            int[][] board = new int[3][]
            {
                new int[3],
                new int[3],
                new int[3]    
            };
            
            var playerToMove = 1;
            
            for(int i = 0; i < nMoves; i++)
            {
                board[moves[i][0]][moves[i][1]] = playerToMove;
                playerToMove = playerToMove == 2? 1 : 2;
            }
            
            return board;
        }
        
        public int GetGameWinner(int[][] board)
        {
            // Check for lines and columns
            for(int i = 0; i < 3; i++)
            {
                //Console.WriteLine(board[0][i] + " " + board[0][i] +" "+ board[0][i]);
                if(board[0][i] == board[1][i] && board[0][i] == board[2][i] && board[0][i] != 0)
                    return board[0][i];
                
                //Console.WriteLine(board[i][0] + " " + board[i][1] +" "+ board[i][2]);
                if(board[i][0] == board[i][1] && board[i][0] == board[i][2] && board[i][0] != 0)
                    return board[i][0];
            }
                
            //Main diagonal
            if(board[0][0] == board[1][1] && board[0][0] == board[2][2] && board[0][0] != 0)
                return board[0][0];
            
            //Secondary diagolnal
            if(board[0][2] == board[1][1] && board[0][2] == board[2][0] && board[0][2] != 0)
                return board[0][2];
            
            // No conditions met - return Draw
            return 0;
        }
    }
}
