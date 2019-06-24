using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input a int number for FizzBuzz game!");
            int input = Convert.ToInt32(Console.ReadLine());
            if (input % 3 == 0 || input % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (input % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (input % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine("No FizzBuzz");
            }
        }
    }
}