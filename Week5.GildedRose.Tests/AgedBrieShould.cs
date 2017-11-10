namespace Week5.GildedRose.Tests
{
    using Inventory;
    using NUnit.Framework;

    [TestFixture]
    public class AgedBrieShould
    {
        [Test]
        public void IncreaseInQualityWhenProcessIsCalled()
        {
            var quality = 10;
            var sellIn = 10;

            var agedBrie = new AgedBrie(quality, sellIn);

            agedBrie.Process();

            Assert.That(agedBrie.Quality, Is.EqualTo(quality + 1));
        }

        [Test]
        public void NeverHaveQualityGreaterThan50WhenProcessIsCalled()
        {
            var quality = 50;
            var sellIn = 10;

            var agedBrie = new AgedBrie(quality, sellIn);

            agedBrie.Process();

            Assert.That(agedBrie.Quality, Is.EqualTo(quality));
        }
    }
}
