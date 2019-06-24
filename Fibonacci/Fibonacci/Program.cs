using System;

namespace Fibonacci
{
    class GFG 
    { 
        // A simple recursive 
        // program to find n'th 
        // fibonacci number 
        static int Fib(int n) 
        { 
            if (n <= 1) 
                return n; 
            return Fib(n - 1) +  
                   Fib(n - 2); 
        } 
      
        // Returns number of ways 
        // to reach s'th stair 
        static int CountWays(int s) 
        { 
            return Fib(s + 1); 
        } 
  
        // Driver Code 
        static public void Main () 
        { 
            int s = 4; 
            Console.WriteLine("Number of ways = " +  
                              CountWays(s)); 
        } 
    } 
}