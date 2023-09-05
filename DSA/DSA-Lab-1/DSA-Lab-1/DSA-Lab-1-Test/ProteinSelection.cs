using System.ComponentModel.Design;

namespace DSA_Lab_1_Test
{
    [TestClass]
    public class ProteinSelection
    {
        ChoiceSample menu;
        [TestInitialize]
        public void TestSetup()
        {
            menu = new ChoiceSample();
        }
        [TestMethod]
        [DataRow("Beef", "Hamburger")]
        [DataRow("Pepperoni", "Pizza")]
        [DataRow("Tofu", "Tofu Fried Rice")]
        public void TestWithExpectedProteinType(string proteinChoices, string menuItem)
        {
            string dish = menu.GetDishRecommendation(proteinChoices);
            Assert.AreEqual(menuItem, dish, true);
        }
        [TestMethod]
        public void TestWith_Unexpected_ProteinType(string proteinChoices, string menuItem)
        {
            string dish = menu.GetDishRecommendation(proteinChoices);
            Assert.AreNotEqual(menuItem, dish, true);
        }
    }
}