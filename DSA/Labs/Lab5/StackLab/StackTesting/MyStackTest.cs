using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackLib;

namespace StackTesting
{
    [TestClass]
    public class MyStackTest
    {
        [TestMethod]
        public void PushTest()
        {
            //arrange
            GeoffStack<string> myAnimalStack = new GeoffStack<string>();
            myAnimalStack.Push("Giraffe");
            myAnimalStack.Push("Zebra");
            //assert
            Assert.AreEqual(2, myAnimalStack.Count);
        }
        [TestMethod]
        public void PopTest()
        {
            //arrange
            GeoffStack<string> myAnimalStack = new GeoffStack<string>();
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
            GeoffStack<string> myAnimalStack = new GeoffStack<string>();
            myAnimalStack.Push("Giraffe");
            myAnimalStack.Push("Zebra");
            myAnimalStack.Push("Tiger");
            //act...
            Assert.AreEqual("Tiger", myAnimalStack.Peek());
        }
    }
}

