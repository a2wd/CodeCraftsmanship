namespace Week5.GildedRose.Inventory
{
    public class AgedBrie : InventoryItem
    {
        public AgedBrie(int quality, int sellIn) : base(quality, sellIn)
        {
        }

        protected override void UpdateQuality()
        {
            if (Quality < 50)
            {
                Quality++;
            }
        }
    }
}
