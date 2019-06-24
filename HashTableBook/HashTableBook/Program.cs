using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace HashTableBook
{
    class Program
    {
        static void Main()
        {
            Dic();
        }

        /// <summary>
        /// Read my book from a txt file and then add to a strign 
        /// </summary>
        /// <returns></returns>
        private static string Read()
        {
            //read the book into a string
            string line = File.ReadAllText(@"/Users/jonsun/Desktop/pg7370.txt");

            return line;
        }


        private static void Dic()
        {
            //initialise dictionary this step will take O(1), this is the best case and the worse case
            Dictionary<string, int> openWith = new Dictionary<string, int>();

            //Replace, tries to match the expression starting at any index of the string, giving an O(m²), the best case is O(n)
            string line2 = Regex.Replace(Read(), @"\w+@\w+.\w+\w+\w|http+\W+\w+\W+\w+\W\w+|\ [[:upper:]]\.|\w\.\w\.",
                "@");
            //same as above O(m²), the best case is O(n)
            MatchCollection matches = Regex.Matches(line2.ToLower(), @"['A-Za-z']+");

            //a foreach loop go through every element in the dictionary
            foreach (var item in matches)
            {
                //if cannot find the key(words) in the dictionary, if can the value will be out in the 'value' variable
                if (!openWith.TryGetValue(item.ToString(), out int value))
                {
                    //create a all key value pair 
                    openWith.Add(item.ToString(), 1);
                }

                else
                {
                    //if found the key increase the value counter
                    openWith[item.ToString()] = value + 1;
                }
            }

            //a foreach loop go through every element in the dictionary, linear search finding the pair constants the biggest value 
            //This step is O(n)
            KeyValuePair<string, int> temp = new KeyValuePair<string, int>("key", 0);
            foreach (KeyValuePair<string, int> i in openWith)
            {
                if (i.Value > temp.Value)
                {
                    temp = i;
                }
            }

            //The step will take O(1), this is the best case and the worse case
            Console.WriteLine("The most frequent word is: " + temp.Key + ", it appears " + temp.Value +
                              " times in this book");
        }
    }
}