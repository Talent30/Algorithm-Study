using System;

namespace Swapping
{
    class Program
    {
        public int a;
        public int a1 = 1;
        public int b1 = 2;
        

        static void Ex1(int , int a)
        {
            a1 = 1;
            int temp = a;
            a1 = b1;
            b1 = temp;
            return;
        }

        static void Main(string[] args)
        {
            a1 = 5;
            b1 = 6;
            Ex1(, &b);
            Console.WriteLine(a + " " + b);
        }
    }
}