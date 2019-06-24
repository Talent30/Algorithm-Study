using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace MultiThread
{
    class Program
    {
        //dealer global variable 
        public static int[] numArray;
        public static int max1;
        public static int max2;


        static void Main()
        {
            //run 
            ReadIntFile();

            MultiMax();

            SingalMax();
        }

        static void MultiMax()
        {
            //DateTime beforDt = DateTime.Now;
            //count the time 

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            //initialize thread
            for (int i = 0; i < 100; i++)
            {
                ThreadStart threadStart1 = Max1;
                Thread t1 = new Thread(threadStart1);
                ThreadStart threadStart2 = Max2;
                Thread t2 = new Thread(threadStart2);
                //start 
                t1.Start();
                t2.Start();
                //pause other job
                t1.Join();
                t2.Join();
                //compare two numbers 
            }

            if (max1 > max2)
            {
                Console.Write("Max number is: ");
                Console.Write(max1);
            }
            else if (max1 < max2)
            {
                Console.Write("Max number is: ");
                Console.Write(max2);
            }
            else
            {
                Console.Write("Max number is: ");
                Console.Write(max1);
            }


            sw1.Stop();
            //DateTime afterDt = DateTime.Now;
            //TimeSpan ts = afterDt.Subtract(beforDt);

            Console.WriteLine();
            Console.WriteLine("Multi DateTime total spent {0}ms.", sw1.ElapsedMilliseconds);
        }

        static void SingalMax()
        {
            int max3 = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100; i++)
            {
                //DateTime beforDt = DateTime.Now;


                //go through array  
                foreach (int number in numArray)
                {
                    if (number > max3)
                    {
                        //replace max
                        max3 = number;
                    }
                }
            }

            sw.Stop();
            Console.Write("Max number is: " + max3);
            Console.WriteLine();
            Console.WriteLine("DateTime total spent {0}ms.", sw.ElapsedMilliseconds);
        }

        static void ReadIntFile()
        {
            Console.WriteLine("File path");
            string path = Console.ReadLine();
            //read all lines in the file
            string fileContent = File.ReadAllText(@"" + path);
            string[] aFileContent = fileContent.Split(',');
            numArray = Array.ConvertAll(aFileContent, int.Parse);
        }

        static void Max1()
        {
            //go through first half array  
            for (int i = 0; i < (numArray.Length / 2); i++)
            {
                if (numArray[i] > max1)
                {
                    max1 = numArray[i];
                }
            }
        }

        static void Max2()
        {
            //go through second half array  
            for (int i = numArray.Length / 2; i < numArray.Length; i++)
            {
                if (numArray[i] > max2)
                {
                    max2 = numArray[i];
                }
            }
        }
    }
}
// /Users/jonsun/Desktop/Untitled-1.txt