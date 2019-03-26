using System;

namespace BuySellStock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] stock = new[] {20, 40, 50, 60, 10};
            MaxProfit(stock);
            MaxDiab(stock);
        }

        public static void MaxProfit(int[] a)
        {
            //Determine whether a valid stock sequence
            if (a.Length ==0)
            {
                return;
            }
            
            int bought = a[0];
            //The variable that stores the maximum value, initialized to 0
            int maxProfit = 0;


            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > bought)
                {
                    if (maxProfit < a[i] - bought)
                    {
                        maxProfit = a[i] - bought;
                    }
                }
                else
                {
                    bought = a[i];
                }
            }

            Console.WriteLine("Max profit is: " + maxProfit);
        }

        public static void MaxDiab(int[] a)
        {
            int idxL = 0;
            int idxU = 0;
            int idxM = 0;
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < a[idxM])
                {
                    idxM = i;
                    continue;
                }

                if (a[i]-a[idxM] >a[idxU] -a[idxL])
                {
                    idxL = idxM;
                    idxU = i;
                }
            }

            int maxProfit = a[idxU] - a[idxL];
            Console.WriteLine(maxProfit);
        }
    }
}