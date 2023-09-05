namespace LearnImmutableTest
{
    [TestClass]
    public class SampleRecordTest
    {
        SampleRecord record1 = null;
        [TestInitialize]
        public void TestSetup()
        {
            record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5))
            { MutableProperty = "InitialString" };
        }
        [TestMethod]
        public void TestRecordTypeEqualityWithPositionParam()
        {
            //arrange
            SampleRecord record2 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));

            //assert
            Assert.AreEqual(record1, record2);
            Assert.AreNotSame(record1, record2);
        }
        [TestMethod]
        public void TestRecordTypeinEqualityWithPositionParam()
        {
            //arragne
            SampleRecord record1 = new SampleRecord(ParamString: "Test", ParamInt: 1, ParamDate: new DateTime(2023, 9, 5));
            SampleRecord record2 = new SampleRecord(ParamString: "Test", ParamInt: 2, ParamDate: new DateTime(2023, 9, 5));

            //assert
            Assert.AreNotEqual(record1, record2);
            Assert.AreNotSame(record1, record2);
        }
        [TestMethod]
        public void TestRecordTypeSamenessWithPositionParam()
        {
            //arragne
            SampleRecord record2 = record1;

            //assert
            Assert.AreEqual(record1, record2);
            Assert.AreSame(record1, record2);
        }
        [TestMethod]
        public void TestRecordTypeAutoImplementedProperties()
        {
            //Arrange

            //Assert
            Assert.AreEqual("Test", record1.ParamString);
            Assert.AreEqual(1, record1.ParamInt);
            Assert.AreEqual(new DateTime(2023, 9, 5), record1.ParamDate);
        }
        [TestMethod]
        public void TestRecordMutableProperties()
        {
            //Arrange
            string expected = "NewString";
            //Act
            record1.MutableProperty = expected;
            //Assert
            Assert.AreEqual(record1.MutableProperty, expected);
            
        }
        [TestMethod]
        public void TestRecordTypeNonDestructiveMutation()
        {
            //Arrange

            //Act
            SampleRecord record2 = record1 with { ParamInt = 2 };
            //Asserts
            Assert.AreNotEqual(record1, record2); //there are 2 different objects - quality comparison
            Assert.AreNotSame(record1, record2); //record2 points to different instance than record1 - reference comparison
            Assert.AreEqual(record2.ParamInt, 2); //record2 has updated ParamInt
            Assert.AreEqual(record1.ParamInt, 1); //record 1 is immutable
            Assert.AreEqual(record2.ParamString, "Test"); //record2 has the same properties as record1 if the property ahs not been modified
        }
        [TestCleanup]
        public void Cleanup()
        {

        }
    }
}