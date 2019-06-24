using System;

namespace SLLProgram
{
    public class SSL
    {
        public Node head { get; set; }
        public Node tail { get; set; }


        public SSL(Node head)
        {
            this.head = head;
            tail = null;
        }


        //class functionality - the things that his list does

        //add stuff
        public void Addstuff(int value)
        {
            Node item = new Node(value);
            if (head == null)
            {
                //no items in list
                //make this the head
                head = item;
                tail = item;
            }
            else
            {
                //add to end of list
                tail.next = item;
                tail = item;
            }
        }

        //remove stuff
        public void RemoveFirst()
        {
            //if there is only one thing in the list
            if (head == null)
            {
                
            }
            else
            {
                if (head.next == null)
                {
                    head = null;
                }
                //else
                else
                {
                    head = head.next;
                }
            }
        }

        //find stuff
        public bool FindStuff(int item)
        {
            //get value from head to keep track of where we are
            Node temp = head;
            while (temp != null)
            {
                //if we have found the thing
                if (temp.value == item)
                {
                    return true;
                    break;
                }

                temp = temp.next;
            }

            return false;
        }


        //print stuff
        public void PrintList()
        {
            Node temp = head;
            Console.WriteLine("Our list");
            while (temp != null)
            {
                Console.Write(temp.value + ", ");
                temp = temp.next;
            }

            Console.WriteLine();
        }
    }
}