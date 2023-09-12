namespace BinarySearchTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ReturnValueOnRightSideOfArrayShouldEqualTarget()
        {
            //arrange
            int[] dataSet = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            //act
            //assert
            Assert.AreEqual(12, BinarySearcher.Search(12, dataSet));
        }
        [TestMethod]
        public void ReturnValueOnLeftSideOfArrayShouldEqualTarget()
        {
            //arrange
            int[] dataSet = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            //assert
            Assert.AreEqual(5, BinarySearcher.Search(5, dataSet));
        }
        [TestMethod]
        public void TestOutOfBoundsValue()
        {
            //arrange
            int[] dataSet = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            //assert
            Assert.AreEqual(-1, BinarySearcher.Search(20, dataSet));
        }
        [TestMethod]
        public void TestValueIsNotFound()
        {
            //arrange (missing 10 on purpose)
            int[] dataSet = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 13, 14, 15, 16 };
            //assert
            Assert.AreEqual(-1, BinarySearcher.Search(10, dataSet));
        }
    }
}

//test sorted
 