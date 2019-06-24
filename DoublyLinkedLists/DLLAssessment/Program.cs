using System;
using System.IO;

namespace DLLAssessment
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello! Welcome to my program ASSESSMENT ONE-Lists");

            /*
             * 1. Reads the integers in file1.txt, file2.txt and file3.txt and inserts them
             * into doubly linked lists list1, list2 and list3 respectively.
             * Add the integers to the tail of the list.
             */
            NodeList list1 = new NodeList();
            NodeList list2 = new NodeList();
            NodeList list3 = new NodeList();

            /*
             * /Users/jonsun/Desktop/QUICKfile1.txt
             * /Users/jonsun/Desktop/QUICKfile2.txt
             * /Users/jonsun/Desktop/QUICKfile3.txt
             */

            bool done = false;
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
                    ReadFile(path1, list1);
                    ReadFile(path2, list2);
                    ReadFile(path3, list3);
                    done = true;
                }

                catch (Exception)
                {
                    Console.WriteLine("Error please check your file or file path, it has to have and only int number");
                }
            }

            //2. Prints to the screen the size of each list.
            Console.WriteLine("The size of list1 is " + list1.CountSize() + "\n");
            Console.WriteLine("The size of list2 is " + list2.CountSize() + "\n");
            Console.WriteLine("The size of list3 is " + list3.CountSize() + "\n");
            Console.WriteLine();

            //3. Print to the screen the “Middle” number of each list.
            Console.WriteLine("The median number of list1 is " + list1.Median() + "\n");
            Console.WriteLine("The median number of list2 is " + list2.Median() + "\n");
            Console.WriteLine("The median number of list3 is " + list3.Median() + "\n");
            Console.WriteLine();

            //4. Prints to the screen the prime numbers in each list (five numbers each line).
            Console.WriteLine("Printing prime numbers for list1");
            list1.PrintPrime();
            Console.WriteLine("Printing prime numbers for list2");
            list2.PrintPrime();
            Console.WriteLine("Printing prime numbers for list3");
            list3.PrintPrime();
            Console.WriteLine();

            //5. Prints to the screen the numbers in each list in reverse order.
            Console.WriteLine("Printing the reverse order for list1");
            list1.ReverseDisplay();
            Console.WriteLine("Printing the reverse order for list2");
            list2.ReverseDisplay();
            Console.WriteLine("Printing the reverse order for list3");
            list3.ReverseDisplay();
            Console.WriteLine();

            //6. Prints to the screen all the numbers that appear in the three lists (intersection).
            Console.WriteLine("Printing the intersection set for three lists");
            PrintIntersection(list1, list2, list3);
        }
        //end of Main method

        /// <summary>
        /// This method use File.IO read all text and split unnecessary information convert and add elements to list
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="numList"></param>
        /// <returns></returns>
        private static void ReadFile(string filepath, NodeList numList)
        {
            //read all lines in the file
            string fileContent = File.ReadAllText(@"" + filepath);
            //split
            NodeList num = SplitString1(fileContent, ',');
            Node temp = num.Head;
            while (temp != null)
            {
                numList.AddValue(temp.Value);
                temp = temp.Next;
            }

            /*
            string[] aFileContent = fileContent.Split(',');
            //convert to int
            int[] numArray = Array.ConvertAll(aFileContent, int.Parse);
            foreach (int num in numArray)
            {
                numList.AddValue(num);
            }
            */
        }
        //end of ReadFile method

        /// <summary>
        /// Receive a string split elements and return a list
        /// </summary>
        /// <param name="content"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        private static NodeList SplitString1(string content, char sp)
        {
            string temp = "";
            NodeList num = new NodeList();
            int strLen = content.Length;
            for (int i = 0; i < strLen; i++)
            {
                if (content[i] == sp)
                {
                    num.AddValue(int.Parse(temp));
                    temp = "";
                }
                else
                {
                    temp += content[i];
                }
            }

            num.AddValue(int.Parse(temp));

            return num;
        }
        //end of SplitString1 method

        /*
        /// <summary>
        /// This program is my own split method, read and create a substring add to list
        /// </summary>
        /// <param name="content"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        private static NodeList SplitString(string content, string sp)
        {
            NodeList num = new NodeList();
            int strLen = content.Length;
            int found = 0;
            for (int i = 0; i < strLen; i++)
            {
                found = content.IndexOf(sp, i, StringComparison.Ordinal);
                if (found >= 0)
                {
                    string temp = content.Substring(i, found - i);
                    num.AddValue(Convert.ToInt32(temp));
                    i = found;
                }
                else
                {
                    string temp = content.Substring(i);
                    if (temp != "")
                        num.AddValue(Convert.ToInt32(temp));
                    break;
                }
            }

            return num;
        }
        */


        /// <summary>
        /// The purpose of this method is to skip the duplicate elements and print the return intersection list
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <param name="list3"></param>
        private static void PrintIntersection(NodeList list1, NodeList list2, NodeList list3)
        {
            NodeList set = new NodeList();
            Intersection(set, list1, list2, list3);
            Node temp = set.Head;
            while (temp != null)
            {
                //make sure the node is not the last one then compare, if same do nothing
                if (temp.Next != null && temp.Next.Value == temp.Value)
                {
                }

                else
                {
                    Console.Write(temp.Value + " ");
                }

                temp = temp.Next;
            }
        }
        //end of PrintIntersection method

        /// <summary>
        /// This method will receive three lists 
        /// add all the intersection number into list set
        /// </summary>
        /// <param name="set"></param>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <param name="list3"></param>
        private static void Intersection(NodeList set, NodeList list1, NodeList list2, NodeList list3)
        {
            //for this method we need to sort lists first
            list1.Sort();
            list2.Sort();
            list3.Sort();
            //start from first node
            Node temp1 = list1.Head;
            Node temp2 = list2.Head;
            Node temp3 = list3.Head;

            while (temp1 != null && temp2 != null && temp3 != null)
            {
                //if a value appears in three lists add the value
                if (temp1.Value == temp2.Value && temp2.Value == temp3.Value)
                {
                    int temp = temp1.Value;
                    set.AddValue(temp);
                    temp1 = temp1.Next;
                    temp2 = temp2.Next;
                    temp3 = temp3.Next;
                }
                //if list1 current value smaller than list2 go to next 
                else if (temp1.Value < temp2.Value)
                {
                    temp1 = temp1.Next;
                }
                //if list2 current value smaller than list3 go to next 
                else if (temp2.Value < temp3.Value)
                {
                    temp2 = temp2.Next;
                }
                //if list3 current value smaller go to next
                else
                {
                    temp3 = temp3.Next;
                }
            }
        }

        //end of Intersection method
    }
}