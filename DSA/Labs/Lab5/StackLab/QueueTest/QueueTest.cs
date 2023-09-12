namespace QueueTest
{
    [TestClass]
    public class QueueTest
    {
        [TestMethod]
        public void TestEnqueue()
        {
            //arrange
            Queue<string> myAnimalQueue = new Queue<string>();
            //act
            myAnimalQueue.Enqueue("Zebra");
            myAnimalQueue.Enqueue("Monkey");
            myAnimalQueue.Enqueue("Elephant");
            //assert
            Assert.AreEqual(3, myAnimalQueue.Count());
        }
        [TestMethod]
        public void TestDequeueAndFIFO()
        {
            //arrange
            Queue<string> myAnimalQueue = new Queue<string>();
            myAnimalQueue.Enqueue("Zebra");
            myAnimalQueue.Enqueue("Monkey");
            myAnimalQueue.Enqueue("Elephant");
            //act
            var deqVal = myAnimalQueue.Dequeue();
            //assert
            Assert.AreEqual(2, myAnimalQueue.Count());
            Assert.AreEqual("Zebra", deqVal);
        }
        [TestMethod]
        public void TestQueueEnumerate()
        {
            //arrange
            Queue<string> myAnimalQueue = new Queue<string>();
            myAnimalQueue.Enqueue("Zebra");
            myAnimalQueue.Enqueue("Monkey");
            myAnimalQueue.Enqueue("Elephant");
            //arrange pt 2. FIFO 
            string[] myAnimalArr = { "Zebra", "Monkey", "Elephant" };
            int i = 0;
            //act iterate
            foreach (var item in myAnimalQueue) //not a for loop on purpose. Testing iterating through the queue.
            {
                //assert dequeue & FIFO
                Assert.AreEqual(item.ToString(), myAnimalQueue.ElementAt(i));
                i++;
            }
        }
    }
}
//Lab 2
//create queue obj
//test enqueue
// call x times
// confirm queue count should match

//test dequeue
//call dequeue x times
// confirm items returned in FIFO manner


// Test Queue can be iterated through & return items in FIFO order

//DONE AT 1456