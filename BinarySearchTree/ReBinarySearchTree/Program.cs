using System;
using System.IO;

namespace ReBinarySearchTree
{
    class Program
    {
        static void Main()
        {
            BsTree bst1 = new BsTree();
            BsTree bst2 = new BsTree();
            BsTree bst3 = new BsTree();
            Console.WriteLine("Hello! Welcome to my program ASSESSMENT ONE-BST");

            /*
             * 1. Reads the integers in file1.txt, file2.txt and file3.txt and inserts them
             * into doubly linked lists list1, list2 and list3 respectively.
             * Add the integers to the tail of the list.
             */

            /*
             * /Users/jonsun/Desktop/QUICKfile1.txt
             * /Users/jonsun/Desktop/QUICKfile2.txt
             * /Users/jonsun/Desktop/QUICKfile3.txt
             */

            bool done = false;
            //before user input correct path keep asking them
            while (done == false)
            {
                Console.WriteLine("Please input the path for file1.txt");
                string path1 = Console.ReadLine();

                Console.WriteLine("Please input the path for file2.txt");
                string path2 = Console.ReadLine();

                Console.WriteLine("Please input the path for file3.txt");
                string path3 = Console.ReadLine();
                Console.WriteLine("Reading file1, file2, file3 into list1, list2 ,list3...");
                try
                {
                    //read files insert into tree
                    ReadFile(path1, bst1);
                    ReadFile(path2, bst2);
                    ReadFile(path3, bst3);
                    done = true;
                }

                catch (Exception)
                {
                    Console.WriteLine("Error please check your file or file path, it has to have and only int number");
                }
            }
            //2.0 Prints to the screen the size of each tree.

            Console.WriteLine("Prints to the screen the size of each tree");
            Console.WriteLine("Size of bst1 is: " + bst1.CountNode(bst1.Root));
            Console.WriteLine("Size of bst2 is: " + bst2.CountNode(bst2.Root));
            Console.WriteLine("Size of bst3 is: " + bst3.CountNode(bst3.Root));

            //3.0 Prints to the screen the numbers in each tree in decreasing order.
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Prints to the screen the numbers in each tree in decreasing order.");
            Console.WriteLine("bst1:");
            bst1.PrintDecreased();
            Console.WriteLine();

            Console.WriteLine("bst2:");
            bst2.PrintDecreased();
            Console.WriteLine();

            Console.WriteLine("bst3:");
            bst3.PrintDecreased();
            Console.WriteLine();
            
            //4.0 Prints the height of each binary search tree.
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Prints the height of each binary search tree.");
            Console.WriteLine("bst1 Height: " + bst1.GetHeight(bst1.Root));
            Console.WriteLine("bst1 Height: " + bst2.GetHeight(bst2.Root));
            Console.WriteLine("bst1 Height: " + bst3.GetHeight(bst3.Root));

            //5.0 Prints the numbers in the binary search tree “level by level.
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Prints the numbers in the binary search tree “level by level.");

            Console.WriteLine("bst1-BFS print:");
            bst1.LeveledPrint();
            Console.WriteLine();

            Console.WriteLine("bst2-BFS print:");
            bst2.LeveledPrint();
            Console.WriteLine();

            Console.WriteLine("bst3-BFS print:");
            bst3.LeveledPrint();
            Console.WriteLine();

            //6.0 Print the number of prime numbers in the second binary search tree
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Print the number of prime numbers in the second binary search tree.");
            
            Console.WriteLine();
            Console.WriteLine("Prime number in bst2:");
            bst2.PrintPrime();


        }

        private static void ReadFile(string filepath, BsTree bsTree)
        {
            //read all lines in the file
            string fileContent = File.ReadAllText(@"" + filepath);
            //split
            string[] aFileContent = fileContent.Split(',');
            //convert to int
            int[] numArray = Array.ConvertAll(aFileContent, int.Parse);
            foreach (int num in numArray)
            {
                //insert to tree
                bsTree.Insert(num);
            }
        }
    }
}