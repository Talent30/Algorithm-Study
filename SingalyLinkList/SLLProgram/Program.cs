using System;

namespace SLLProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Node first = new Node(1);
            SSL list = new SSL(first);

            list.Addstuff(2);
            list.Addstuff(3);
            list.Addstuff(4);
            list.Addstuff(5);
            list.Addstuff(6);
            list.PrintList();
            list.RemoveFirst();
            list.PrintList();

            Console.WriteLine("3 is " + list.FindStuff(3));
            Console.ReadKey();
        }
    }
}