using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Util
{
    static class ArrayExtension
    {
        public static void PrintArray(this int[] arr)
        {
            Array.ForEach(arr, x => Console.Write(x + " "));
            Console.WriteLine("");
        }
    }
}
