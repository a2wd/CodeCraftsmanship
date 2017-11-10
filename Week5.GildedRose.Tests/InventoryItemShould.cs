namespace Week5.GildedRose.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class InventoryItemShould
    {
        [Test]
        public void DecreaseQualityWhenProcessIsCalled()
        {
            var quality = 2;
            var sellIn = 10;

            var inventoryItem = new InventoryItem(quality, sellIn);

            inventoryItem.Process();

            Assert.That(inventoryItem.Quality, Is.EqualTo(quality - 1));
        }

        [Test]
        public void DecreaseSellInWhenProcessIsCalled()
        {
            var quality = 0;
            var sellIn = 3;

            var inventoryItem = new InventoryItem(quality, sellIn);

            inventoryItem.Process();
            
            Assert.That(inventoryItem.SellIn, Is.EqualTo(sellIn - 1));
        }

        [Test]
        public void DegradeQualityTwiceAsFastWhenProcessIsCalledAndSellInIs0()
        {
            var quality = 10;
            var sellIn = 0;

            var inventoryItem = new InventoryItem(quality, sellIn);

            inventoryItem.Process();

            Assert.That(inventoryItem.Quality, Is.EqualTo(quality - 2));
        }

        [Test]
        public void NeverDecreaseQualityBelowZeroWhenProcessIsCalled()
        {
            var quality = 0;
            var sellIn = 2;

            var inventoryItem = new InventoryItem(quality, sellIn);

            inventoryItem.Process();

            Assert.That(inventoryItem.Quality, Is.EqualTo(0));
        }
    }
}
