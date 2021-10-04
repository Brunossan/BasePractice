using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Util;

namespace TestProject.Exercises
{
    #region Task
    /// https://leetcode.com/problems/island-perimeter/
     
    /* 
        You are given row x col grid representing a map where grid[i][j] = 1 represents land and grid[i][j] = 0 represents water.

        Grid cells are connected horizontally/vertically (not diagonally). The grid is completely surrounded by water, and there is exactly one island (i.e., one or more connected land cells).

        The island doesn't have "lakes", meaning the water inside isn't connected to the water around the island. One cell is a square with side length 1. The grid is rectangular, width and height don't exceed 100. Determine the perimeter of the island.


    Constraints:

        row == grid.length
        col == grid[i].length
        1 <= row, col <= 100
        grid[i][j] is 0 or 1.
        There is exactly one island in grid. Constraints:
    */
    
    #endregion
    
    public class IslandPerimeter
    {
        int gridLenght = 0;
        int gridHeight = 0;

        
        public int FindIslandPerimeter(int[][] grid) {
            int perimeter = 0;
            this.gridLenght = grid.Length;
            this.gridHeight = grid[0].Length;

            for(int i = 0; i < this.gridLenght; i++)
            {
                for(int j = 0; j < this.gridHeight; j++)
                {
                    if(grid[i][j] == 1)
                    {
                        perimeter += this.IsWater(grid, i+1 , j)
                            + this.IsWater(grid, i-1 , j)
                            + this.IsWater(grid, i , j+1)
                            + this.IsWater(grid, i , j-1);
                    }
                }
            }
            
            return perimeter;
        }
        
        public int IsWater(int[][] grid, int i, int j)
        {
            if(i < 0 || j < 0 || i >= this.gridLenght || j >= this.gridHeight)
                return 1;
            
            return grid[i][j] == 0 ? 1 : 0;   
        }
    }
}
