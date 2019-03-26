using System;

namespace ProductOfArrayExceptSelf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] a = new[] {1, 2, 3, 4};
            OutPut(a);
        }

        public static void OutPut(int[] a)
        {
            int[] product = new int[a.Length];
            for (int i = 0; i < product.Length; i++)
            {
                product[i] = 1;
            }

            for (int i = 1; i < a.Length; i++)
            {
                product[i] = a[i - 1] * product[i - 1];
            }

            int temp = 1;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                product[i] = product[i] * temp;
                temp *= a[i];
            }

            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(product[i]);
            }
        }
    }
}