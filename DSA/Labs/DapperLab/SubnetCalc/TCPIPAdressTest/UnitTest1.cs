
using System.Net;

namespace TCPIPAdressTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidateIPAddressTest()
        {
        }
        [TestMethod]
        public void IsIPAddressParsedTest()
        {
            //arrange
            IPAddress ipAddress = new IPAddress("123.123.122.0/23");
            byte[] byteArr = new byte[4] { 123, 123, 122, 0 };

            //assert
            Assert.AreEqual(byteArr[0], ipAddress.addressByte[0]);
            Assert.AreEqual(byteArr[1], ipAddress.addressByte[1]);
            Assert.AreEqual(byteArr[2], ipAddress.addressByte[2]); 
            Assert.AreEqual(byteArr[3], ipAddress.addressByte[3]);
        }
        [TestMethod]
        public void ValidateSubnetMaskRawTest()
        {
            IPAddress ipAddress = new IPAddress("123.123.122.0/23");

            int[] intArr = new int[4] { 11111111, 11111111, 11111110, 00000000 };

            Assert.AreEqual(intArr[0], ipAddress.subnetMask[0]);
            Assert.AreEqual(intArr[1], ipAddress.subnetMask[1]);
            Assert.AreEqual(intArr[2], ipAddress.subnetMask[2]);
            Assert.AreEqual(intArr[3], ipAddress.subnetMask[3]);
        }
    }
}


//Could we do something like

// Assert so we dont have to write the 4 test lines?
