namespace StackTesting
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void PushTest()
        {
            //arrange
            Stack<string> myAnimalStack = new Stack<string>();
            myAnimalStack.Push("Giraffe");
            //act
            var pushVal = myAnimalStack.First();

            //assert
            Assert.AreEqual("Giraffe", pushVal);
        }
        [TestMethod]
        public void PopTest()
        {
            //arrange
            Stack<string> myAnimalStack = new Stack<string>();
            myAnimalStack.Push("Giraffe");
            myAnimalStack.Push("Zebra");
            myAnimalStack.Push("Tiger");
            //act
            var popVal = myAnimalStack.Pop();

            //assert
            Assert.AreEqual("Tiger", popVal);
        }
        [TestMethod]
        public void PeekTest()
        {
            //arrange
            Stack<string> myAnimalStack = new Stack<string>();
            myAnimalStack.Push("Giraffe");
            myAnimalStack.Push("Zebra");
            myAnimalStack.Push("Tiger");
            //act
            var peekVal = myAnimalStack.Peek();

            //assert
            Assert.AreEqual("Tiger", peekVal);
            Assert.AreEqual(myAnimalStack.First(), peekVal);
        }
    }
}