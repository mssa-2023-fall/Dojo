using Lib;

namespace BInaryTreeTest
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void BinaryTreeRecursion()
        {
            Tree tree = new Tree(GenerateSortedNumber(100));
            Assert.IsNotNull(tree);
            Assert.IsNotNull(tree.Root);
            Assert.AreEqual(tree.Root.Value, 49);

        }

        [TestMethod]
        public void BinaryTreeSearchItem()
        {
            Tree tree = new Tree(GenerateSortedNumber(100));
            int target = 35;
            TreeNode node = tree.Root;
            int opCount = 0;
            while (node.Value != target)
            {
                if (target > node.Value) { node = node.Right; } else { node = node.Left; }
                opCount++;
            }
            Assert.IsNotNull(node);
            Assert.AreEqual(node.Value, target);
            Assert.IsTrue(opCount <= 6);
        }
        public static int[] GenerateSortedNumber(int size)
        {
            var array = new int[size];

            for (int i = 0; i < size; i++)
                array[i] = i;

            return array;
        }
    }
}