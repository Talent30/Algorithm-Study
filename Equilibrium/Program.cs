﻿using System;
using System.Linq;

namespace Equilibrium
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello we will find the balance point of the array");
            int[] a = new[] {-7, 1, 5, 2, -4, 3, 0};
            BalancePointOpt(a);
        }

        public static void BalancePointOpt(int[] a)
        {
            if (a.Length == 0)
            {
                Console.WriteLine("Error!");
            }

            int sum = a.Sum();
            int sumLeft = 0;
            for (int i = 0; i < a.Length; i++)
            {
                int sumRight = sum - sumLeft - a[i];
                if (sumRight == sumLeft)
                {
                    Console.WriteLine("Got it, is " + i + "th number in the array");
                }
            }
        }
    }
}