using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public int solution(int M, int[] A)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        bool[] seen = new bool[M + 1]; // from 0 to M 
                                             // Arrays.fill(seen, false); // note: "false" by default

        int leftEnd = 0;
        int rightEnd = 0;
        int numSlice = 0;

        // key point: move the "leftEnd" and "rightEnd" of a slice
        while (leftEnd < A.Length && rightEnd < A.Length)
        {

            // case 1: distinct (rightEnd)
            if (seen[A[rightEnd]] == false)
            {
                // note: not just +1 
                // there could be (rightEnd - leftEnd + 1) combinations (be careful)
                numSlice = numSlice + (rightEnd - leftEnd + 1);
                if (numSlice >= 1000000000)
                    return 1000000000;

                // increase the slice to right by "1" (important)
                seen[A[rightEnd]] = true;
                rightEnd++;
            }
            // case 2: not distinct
            else
            {
                // increase the slice from left by "1" (important)
                // remove A[leftEnd] from "seen" (be careful)
                seen[A[leftEnd]] = false;
                leftEnd++;
            }
        }

        return numSlice;
    }
}