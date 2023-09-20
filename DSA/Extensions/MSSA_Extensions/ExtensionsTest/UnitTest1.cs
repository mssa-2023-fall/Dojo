using MSSA_Extensions;
using MssaExtension;
using System.Linq;
namespace MssaExtensionsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetShaStringExtension()
        {
            var _file = new FileInfo(@"C:\test\oscar_age_male.csv");
            var _file2 = new FileInfo(@"C:\test\a.png");

            Assert.AreEqual("rSSHX5rkP6Y4BrmT3rYYmGmqInc=", _file.GetSHAString(StringFormat.Base64));
            Assert.AreEqual("ad24875f9ae43fa63806b993deb6189869aa2277", _file.GetSHAString(StringFormat.Hex));
            Assert.AreEqual("I47GbDrg8N9/N2AbrTVFp7UJu+0=", _file2.GetSHAString(StringFormat.Base64));
            Assert.AreEqual("238ec66c3ae0f0df7f37601bad3545a7b509bbed", _file2.GetSHAString(StringFormat.Hex));
        }

        [TestMethod]
        public void CustomLinqMethods()
        {
            IEnumerable<int> inputs1 = new[] { 1, 2, 3, 4, 5, 6, 7 };
            IEnumerable<int> inputs2 = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            float median = inputs1.Median(); // median will be implemented as extension method
            Assert.AreEqual(4, median);
            median = inputs2.Median();
            Assert.AreEqual(4.5, median);
        }


    }
}