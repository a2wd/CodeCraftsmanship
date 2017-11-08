using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";

        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != AgedBrie && IsBackstagePasses(i) == false)
                {
                    DecreaseQualityIfAbove0AndNotHandOfRagnaros(i);
                }
                else if (Items[i].Quality < 50)
                {
                    IncreaseQuality(i);

                    IncreaseQualityForBackstagePassesWhenSellInIsAt11And6Days(i);
                }

                DecreaseSellInIfNotHandOfRagnaros(i);

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name == AgedBrie)
                    {
                        IncreaseQualityIfQualityLessThan50(i);
                    }
                    else
                    {
                        if (IsBackstagePasses(i))
                        {
                            Items[i].Quality = 0;
                        }
                        else
                        {
                            DecreaseQualityIfAbove0AndNotHandOfRagnaros(i);
                        }
                    }
                }
            }
        }

        private void IncreaseQualityForBackstagePassesWhenSellInIsAt11And6Days(int i)
        {
            if (Items[i].Name == BackstagePasses)
            {
                if (Items[i].SellIn < 11)
                {
                    IncreaseQualityIfQualityLessThan50(i);
                }

                if (Items[i].SellIn < 6)
                {
                    IncreaseQualityIfQualityLessThan50(i);
                }
            }
        }

        private bool IsBackstagePasses(int i)
        {
            return Items[i].Name == BackstagePasses;
        }

        private void DecreaseQualityIfAbove0AndNotHandOfRagnaros(int i)
        {
            if (Items[i].Quality > 0)
            {
                if (Items[i].Name != SulfurasHandOfRagnaros)
                {
                    DecreaseQuality(i);
                }
            }
        }

        private void IncreaseQualityIfQualityLessThan50(int i)
        {
            if (Items[i].Quality < 50)
            {
                IncreaseQuality(i);
            }
        }

        private void DecreaseSellInIfNotHandOfRagnaros(int i)
        {
            if (Items[i].Name != SulfurasHandOfRagnaros)
            {
                Items[i].SellIn = Items[i].SellIn - 1;
            }
        }

        private int IncreaseQuality(int i)
        {
            return Items[i].Quality = Items[i].Quality + 1;
        }

        private void DecreaseQuality(int i)
        {
            Items[i].Quality = Items[i].Quality - 1;
        }
    }
}
