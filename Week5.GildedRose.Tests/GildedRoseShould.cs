namespace Week5.GildedRose
{
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class GildedRoseShould
    {
        [Test]
        public void PersistItemAfterUpdateQualityOperation()
        {
            IList<Item.Item> Items = new List<Item.Item> { new Item.Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }
    }
}
