namespace Week5.GildedRose.Inventory
{
    using Week5.GildedRose.Interfaces;

    public class InventoryItem: Item.Item, IItemOperations
    {

        public InventoryItem(int quality, int sellIn)
        {
            Quality = quality;
            SellIn = sellIn;
        }

        public void Process()
        {
            UpdateSellIn();
            UpdateQuality();
        }

        protected virtual void UpdateQuality()
        {
            if (SellIn == 0)
            {
                Quality = Quality - 2;
            }
            else
            {
                Quality--;
            }

            if (Quality < 0)
            {
                Quality = 0;
            }
        }

        private void UpdateSellIn()
        {
            if (SellIn > 0)
            {
                SellIn--;
            }
        }
    }
}