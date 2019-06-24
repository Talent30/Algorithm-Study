using System;
using System.Collections.Generic;

namespace ReBinarySearchTree
{
    public class BsTree
    {
        public TreeNode Root { get; set; }

        public BsTree()
        {
            //initialise tree 
            Root = null;
        }

        public void Insert(int x)
        {
            TreeNode temp = new TreeNode(x);
            //backup the parent node
            TreeNode backUp = Root;
            //if empty replace the value
            if (Root == null)
            {
                Root = temp;
                return;
            }

            //if the same return 
            if (x == Root.Value)
            {
                return;
            }

            //if less go left
            if (x < Root.Value)
            {
                Root = backUp.LeftNode;
                Insert(x);
                backUp.LeftNode = Root;
                Root = backUp;
            }
            //if bigger to right
            else
            {
                Root = backUp.RightNode;
                Insert(x);
                backUp.RightNode = Root;
                Root = backUp;
            }
        }


        public int CountNode(TreeNode current)
        {
            //if root null return 0
            if (current == null) return 0;
            //go left and right each node plus 1
            return CountNode(current.LeftNode) + CountNode(current.RightNode) + 1;
        }


        public void PrintDecreased()
        {
            DecreasedOrder(Root);
        }

        private void DecreasedOrder(TreeNode current)
        {
            if (current != null)
            {
                //go very right
                DecreasedOrder(current.RightNode);
                //print
                Console.Write(current.Value + " ");
                //go left
                DecreasedOrder(current.LeftNode);
            }
        }


        public int GetHeight(TreeNode current)
        {
            if (current == null) return 0;
            //go very left
            int left = GetHeight(current.LeftNode);  
            //go very right
            int right = GetHeight(current.RightNode);
            int max = left;
            //compare
            if (right > max) max = right;
            //record level count
            return max + 1;
        }

        public void LeveledPrint()
        {
            //Create a queue to store our nodes for a given level
            Queue<TreeNode> cue = new Queue<TreeNode>();
            //add the root of the tree to our queue
            cue.Enqueue(Root);
            //create a counter to keep track of the level
            int levelCounter = cue.Count;
            //while there is something in our queue
            while (cue.Count > 0)
            {
                //check if the was the last thing on the level
                if (levelCounter == 0)
                {
                    //go to the next level
                    Console.WriteLine();
                    //set our counter to the number of nodes in our queue
                    levelCounter = cue.Count;
                }

                //grab the first thing from our queue
                TreeNode current = cue.Dequeue();
                //print
                Console.Write(current.Value + " ");
                //enqueue left nodes 
                if (current.LeftNode != null)
                {
                    cue.Enqueue(current.LeftNode);
                }
                //enqueue right
                if (current.RightNode != null)
                {
                    cue.Enqueue(current.RightNode);
                }
                levelCounter--;
            }
        }

        public void PrintPrime()
        {
            //Create a queue to store our nodes for a given level
            Queue<TreeNode> cue = new Queue<TreeNode>();
            //add the root of the tree to our queue
            cue.Enqueue(Root);
            //create a counter to keep track of the level
            int levelCounter = cue.Count;
            //while there is something in our queue
            while (cue.Count > 0)
            {
                //check if the was the last thing on the level
                if (levelCounter == 0)
                {
                    //go to the next level
                    //set our counter to the number of nodes in our queue
                    levelCounter = cue.Count;
                }

                //grab the first thing from our queue
                TreeNode current = cue.Dequeue();
                //if prime print
                if (IsPrime(current.Value))
                {
                    Console.Write(current.Value + " ");
                }
                //enqueue left
                if (current.LeftNode != null)
                {
                    cue.Enqueue(current.LeftNode);
                }
                //enqueue right
                if (current.RightNode != null)
                {
                    cue.Enqueue(current.RightNode);
                }

                levelCounter--;
            }
        }

        private bool IsPrime(int num)
        {
            ////check if the number is 1 or less, 1 is not prime
            if (num <= 1) return false;
            //check if the number is 2, 2 is prime
            if (num == 2) return true;
            //check if the number is a even number, if it is a even it will not be a prime number(except 2)
            if (num % 2 == 0) return false;
            //if the number is not a even number check if it can be divide by a odd number, j*j is the square root
            for (int i = 3; i * i <= num; i += 2)
            {
                //if can be divide by a odd number it is not a prime 
                if (num % i == 0) return false;
            }

            return true;
        }

/*
        public TreeNode InsertTree(TreeNode current, int x)
        {
            if (current == null) current = new TreeNode(x);

            else if (x < current.Value) current.LeftNode = InsertTree(current.LeftNode, x);

            else if (x > current.Value) current.RightNode = InsertTree(current.RightNode, x);

            return current;
        }
        */
    }
}