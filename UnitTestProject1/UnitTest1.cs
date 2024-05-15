using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class PrefixTreeTests
    {
        [TestMethod]
        public void Insert_ThenSearch_ReturnsInsertedPrice()
        {
            PrefixTree tree = new PrefixTree();
            Price expectedPrice = new Price("TestProduct", "TestShop", 10.99);

            tree.Insert("TestProduct", expectedPrice);
            Price actualPrice = tree.Search("TestProduct");

            Assert.AreEqual(expectedPrice.ProductName, actualPrice.ProductName);
            Assert.AreEqual(expectedPrice.ShopName, actualPrice.ShopName);
            Assert.AreEqual(expectedPrice.PriceValue, actualPrice.PriceValue);
        }

        [TestMethod]
        public void Search_NotFound_ReturnsNull()
        {
            PrefixTree tree = new PrefixTree();

            Price actualPrice = tree.Search("NonExistentProduct");

            Assert.IsNull(actualPrice);
        }
    }
}
