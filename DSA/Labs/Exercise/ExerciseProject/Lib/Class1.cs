using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

namespace Lib
{
    public class Class1
    {

    }
    public class BTree
    {
        public BTree()
        {
            Node Root;
            
        }
        public int[] BuildTree(int[] inputArr)
        {

        }
    }
    public class Node
    {
        public Node Right;
        public Node Left;
        public int Value;
        public Node(int value)
        {
            Value = value;
        }
    }
 }