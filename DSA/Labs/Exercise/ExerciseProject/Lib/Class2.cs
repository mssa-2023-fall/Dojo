using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Class2
    {
        public static void Main()
        {

        }
    }

    public class Tree
    {
        public TreeNode Root { get; }
        public Tree(int[] inputArr)
        {
            if (inputArr == null || inputArr.Length == 0) throw new ArgumentException("Input array out of range.");
            this.Root = BuildTree(inputArr, 0, inputArr.Length - 1);
        }

        public TreeNode BuildTree(int[] inputArr, int start = 0, int end = 0)
        {
            int mid = (start + end) / 2;
            TreeNode node = new TreeNode(inputArr[mid]);
            if (end == start)
            {
                mid = start;
            } // i dont understand this

            if (mid != end) //right
            {
                node.Right = BuildTree(inputArr, mid + 1, end);
            }
            if(mid != start)
            {
                node.Left = BuildTree(inputArr, start, mid - 1);
            }
            return node;
        }
    }
    public class TreeNode
    {
        public TreeNode Right { get; set; }
        public TreeNode Left { get; set; }
        public int Value { get; set; }

        public TreeNode(int value)
        {
            Value = value;
        }
    }
}
