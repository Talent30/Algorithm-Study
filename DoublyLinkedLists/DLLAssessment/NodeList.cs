using System;

namespace DLLAssessment
{
    public class NodeList
    {
        public Node Head;
        public Node Tail;

        //NodeList constructor
        public NodeList()
        {
            Head = null;
            Tail = null;
        }
        //end of NodeList constructor


        /// <summary>
        /// //add value to the tail
        /// </summary>
        /// <param name="value"></param>
        public void AddValue(int value)
        {
            //use value to create a new node
            Node item = new Node(value);
            //check the list is empty
            if (Head == null)
            {
                Head = item;
                Tail = Head;
            }
            //else add to the tail of the list
            else
            {
                Tail.Next = item;
                item.Prev = Tail;
                Tail = item;
            }
        }
        //end of AddValue method

        /// <summary>
        /// Print node value from head to the tail
        /// </summary>
        public void Display()
        {
            //initialise temp pointing to the head of the list
            Node temp = Head;
            //go through the list print every node value until the tail
            while (temp != null)
            {
                Console.Write(temp.Value + " ");
                //pointing to the next node
                temp = temp.Next;
            }

            //for formatting 
            Console.WriteLine();
        }

        /// <summary>
        /// go through the list, increment counter after node
        /// </summary>
        /// <returns>counter</returns>
        public int CountSize()
        {
            //initialise counter
            int counter = 0;
            //initialise temp pointing to the head of the list
            Node temp = Head;
            while (temp != null)
            {
                //increase counter
                counter++;
                //pointing to next node
                temp = temp.Next;
            }

            //return the counter value
            return counter;
        }
        //end of CountSize method

        /// <summary>
        /// Get the median value of the list
        /// The idea is that use fast pointer and slow pointer
        /// The fast pointer will go through two nodes for each iteration
        /// When fast pointer reach to the end the slow pointer will stop on the middle node of the list
        /// </summary>
        public double Median()
        {
            //for median sort the list first
            Sort();
            //initialise median 
            double median = 0;
            //prepare two pointers 
            Node fast = Head;
            Node slow = Head;
            //condition for break the while loop
            bool b = true;

            while (b)
            {
                //if fast pointer reach the end of the list
                if (fast.Next == null)
                {
                    //the position of the slow pointer will be the median 
                    median = slow.Value;
                    //break loop
                    b = false;
                }
                //if the length of the list is even number, slow pointer will stop at the lower middle node
                else if (fast.Next != null && fast.Next.Next == null)
                {
                    //add lower and upper middle nodes and do division 
                    median = (Convert.ToDouble(slow.Value) + Convert.ToDouble(slow.Next.Value)) / 2;
                    b = false;
                }
                else
                {
                    //pointing pointer to next
                    slow = slow.Next;
                    fast = fast.Next.Next;
                }
            }

            return median;
        }
        //end of Median method

        /// <summary>
        /// This method will use QuickSort method to sort the list
        /// </summary>
        public void Sort()
        {
            //Node head = Head;
            Node first = Head;
            Node last = Tail;
            //Node last = GetLast(head);
            QuickSort(first, last);
        }
        //end of Sort method

        /// <summary>
        /// QuickSort on Doubly Linked List
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        private void QuickSort(Node low, Node high)
        {
            /* 
            - high is not out of boundary and
            - low not equal high means list has more than one element
            */
            if (high != null && low != high && low != high.Next)
            {
                //get pivot position
                Node pivot = Partition(low, high);
                //Recursive sorting the left side and right side of the pivot
                QuickSort(low, pivot.Prev);
                QuickSort(pivot.Next, high);
            }
        }

        /// <summary>
        /// This method will
        /// i is element less than pivot
        /// j is element greater than pivot 
        ///   * |-------i-----| pivot |---------j-------|
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        private Node Partition(Node low, Node high)
        {
            //default pivot is the last element of the partition
            Node i = null, j = low, pivot = high;
            int temp;
            for (; j != high; j = j.Next)
            {
                if (pivot.Value > j.Value)
                {
                    if (i == null) i = low;
                    else i = i.Next;

                    temp = i.Value;
                    i.Value = j.Value;
                    j.Value = temp;
                }
            }

            if (i == null) i = low;
            else i = i.Next;

            temp = i.Value;
            i.Value = pivot.Value;
            pivot.Value = temp;

            return i;
        }
        //end of Partition method

        /*
        public Node GetLast(Node node)
        {
            while (node.Next != null)
            {
                node = node.Next;
            }

            return node;
        }
        */

        /// <summary>
        /// Using IsPrime to print prime number(5 elements a line)
        /// </summary>
        public void PrintPrime()
        {
            //counter elements
            int counter = 0;
            Node temp = Head;
            while (temp != null)
            {
                if (IsPrime(temp.Value))
                {
                    Console.Write(temp.Value + " ");
                    //increase after print
                    counter++;
                    //after 5 element print next line
                    if (counter % 5 == 0)
                    {
                        Console.WriteLine();
                    }
                }


                temp = temp.Next;
            }

            Console.WriteLine();
        }
        //end of PrintPrime method

        /// <summary>
        /// ignore all the even number expect 2 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
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
        //end of IsPrime method

        /// <summary>
        /// print the list from tail to head
        /// </summary>
        public void ReverseDisplay()
        {
            Node temp = Tail;
            while (temp != null)
            {
                Console.Write(temp.Value + " ");
                temp = temp.Prev;
            }

            Console.WriteLine();
        }

        //end of ReverseDisplay method
    }
}