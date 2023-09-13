using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree_Project
{
    public class Node
    {
        private int _data;
        Node _left;
        Node _right;

        public int data 
        {
            get { return this.data; }
            set { this.data = value; }
        }
        public Node left
        {
            get { return this.left; }
            set { this.left = value; }
        }
        public Node right
        {
            get { return this.right; }
            set { this.right = value; }
        }


        public Node(int data)
        {
            this.data = data;
        }
    }
}
