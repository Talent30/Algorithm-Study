namespace SLLProgram
{
    public class Node
    {
        //Element inside of your list


        public Node(int value)
        {
            this.value = value;
        }

//type prop the press tab twice
        public int value { get; set; }
        public Node next { get; set; }
    }
}