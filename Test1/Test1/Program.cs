using System;
using System.IO;
using System.Linq;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Welcome to my program.  the program that takes dice rolls and checks that the fairness of each die, then reports it back to Aaron");
            //Prevent the program from automatically closing.
            Console.ReadKey();

            Console.WriteLine("Great! Please input the path of the file:");
            // /Users/jonsun/Desktop/example.txt
            //get user path input
            string path = Console.ReadLine();
            //pass to method
            ReadDiceFile(path);
        }

        //end of main

        static void ReadDiceFile(string filePath)
        {
            //read all lines in the file
            string[] fileContent = File.ReadAllLines(@"" + filePath);

            foreach (string line in fileContent)
            {
                //split unnecessary value 
                string[] diceDetails = line.Split(',');
                //skip unnecessary value convert the array to int
                int[] diceRolls = Array.ConvertAll(diceDetails.Skip(2).ToArray(), int.Parse);

                bool fairDice = CalculateFairDie(diceRolls, Convert.ToInt32(diceDetails[1]));
                //bool greatDice = CalculateGreatDie(diceRolls);
                Console.ReadKey();
                Console.WriteLine("-----");
                //call all the methods and print the result
                PrintDieResult(fairDice, diceDetails[0]);
                Reverse(diceRolls);
                Console.WriteLine();
                IsSorted(diceRolls);
                SearchValue(diceRolls, 201);
            }
        }
        //end of ReadDiceFile


        static bool CalculateFairDie(int[] diceOfRolls, int facesOfDie)
        {
            /*int[] diceRolls = new int[diceOfRolls.Length - 2];
            for (int i = 2; i <= diceOfRolls.Length - 1; i++)
            {
                diceRolls[i - 2] = Convert.ToInt32(diceOfRolls[i]);
            }*/

            int result = 0;
            //get the expect value
            int sub = 100 / facesOfDie;
            //create a array store int counts
            int[] tempCount = new int[facesOfDie];
            foreach (int element in diceOfRolls)
            {
                int index = element - 1;
                tempCount[index]++;
            }

            //for each of the tempCounts,subtract (100/max face value) from the total square the result and sum the squares
            for (int i = 0; i < tempCount.Length; i++)
            {
                tempCount[i] = tempCount[i] - sub;
                tempCount[i] *= tempCount[i];
                result += tempCount[i];
            }

            /*
            foreach (int count in tempCount)
            {
                int temp = count - sub;
                result += temp * temp;
            }
            */

            //freedom is 2
            if (result <= 2 * facesOfDie)
            {
                return true;
            }

            return false;
        }
        //end of CalculateFairDie
/*
        static bool CalculateGreatDie(string[] diceOfRolls)
        {
            int counter = 0;
            for (int i = 0; i < diceOfRolls.Length; i++)
            {
                if (diceOfRolls[1] == diceOfRolls[i])
                {
                    counter++;
                }
            }

            // ReSharper disable once PossibleLossOfFraction
            int great = counter / (diceOfRolls.Length - 2);
            if (great >= 25)
            {
                return true;
            }

            return false;
        }
*/

        static void PrintDieResult(bool fairness, string diceName)
        {
            //print the dice name
            Console.Write(diceName);
            if (fairness)
            {
                Console.WriteLine(" The dice is fair!");
            }
            else
            {
                Console.WriteLine(" The dice is not fair");
            }
        }
        //end of PrintDieResult


        static void Reverse(int[] diceOfRolls)
        {
            int lower = 0;
            int upper = diceOfRolls.Length - 1;
            int temp = 0;

            while (lower < upper)
            {
                //swap numbers
                temp = diceOfRolls[lower];
                diceOfRolls[lower] = diceOfRolls[upper];
                diceOfRolls[upper] = temp;

                //next one
                lower++;
                upper--;
            } //end of reverse

            //print the result
            Console.WriteLine("Printing the reversed array");
            foreach (int diceFace in diceOfRolls)
            {
                Console.Write(diceFace + " ");
            }
        }
        //end of Reverse

        static void IsSorted(int[] diceOfRolls)
        {
            bool b = true;
            //start check
            for (int i = 0; i < diceOfRolls.Length - 1; i++)
            {
                if (diceOfRolls[i] > diceOfRolls[i + 1])
                {
                    b = false;
                    break;
                }
            }
            //end of check

            //print the result
            if (b)
            {
                Console.WriteLine("The array is sorted");
            }
            else
            {
                Console.WriteLine("The array is not sorted");
            }
        } //end of IsSorted

        static void SearchValue(int[] diceOfRolls, int x)
        {
            bool b = false;
            //start search
            foreach (int d in diceOfRolls)
            {
                if (d == x)
                {
                    b = true;
                }
            }
            //end of search

            //print the result
            if (b == false)
            {
                Console.WriteLine("Value " + x + " is not in the array");
            }
            else
            {
                Console.WriteLine("Value " + x + " is in the array");
            }
        }
        

        //end of SearchValue
    }
}