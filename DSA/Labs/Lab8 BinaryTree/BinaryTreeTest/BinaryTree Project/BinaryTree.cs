using System;

namespace BinaryTree_Project
{
    public class BinaryTree
    {
        Node root;

        // ------------ Insert Method --------------//
        public void Insert(int nodeNum)
        {
            Node node = new Node(nodeNum);            
            root = insertHelper(root, node);
        }
        private Node insertHelper(Node root, Node node)
        {
            int data = node.data;

            if(root == null)
            {
                root = node;
                return root;
            }
            //recursion :D
            else if (data < root.data)
            {
                root.left = insertHelper(root.left, node);
            }
            else 
            {
                root.right = insertHelper(root.right, node);
            }

            return root;
        }
        // ------------ Display Method -------------- //
        public void Display() { }
        private void displayHelper(Node root)
        {

        }
        // ------------ Search Method --------------//
        public bool Search(int data)
        {
            return false;
        }
        private bool searchHelper(Node root, int data)
        {
            return false;
        }
        // ------------ Remove Method --------------//
        public void Remove(int data)
        {

        }
        public Node removeHelper(Node root, int data)
        {
            return null;
        }
        // ------------ Successor/Predecessor Methods --------------//
        private int Successor(Node root)
        {
            return 0;
        }
        private int Predecessor(Node root)
        {
            return 0;
        }
    }
}