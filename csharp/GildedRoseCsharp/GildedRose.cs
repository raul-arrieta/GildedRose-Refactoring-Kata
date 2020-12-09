using System.Collections.Generic;
namespace GildedRoseCsharp
{
    public class GildedRose
    {
        private IList<Item> Items;
        private const string Backstage = "Backstage passes to a TAFKAL80ETC concert";
        private const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        private const string AgredBrie = "Aged Brie";
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }
        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                UpdateItem(Items[i]);
            }
        }
        private bool UpdateItem(Item item)
        {
            return UpdateSulfuras(item)
            || UpdateBackstage(item)
            || UpdateOthers(item);
        }
        private bool UpdateSulfuras(Item item)
        {
            if (item.Name != Sulfuras)
            {
                return false;
            }
            return true;
        }

        private bool UpdateBackstage(Item item)
        {
            if (item.Name != Backstage)
            {
                return false;
            }
            IncrementItemQuality(item);
            if (item.SellIn < 11)
            {
                IncrementItemQuality(item);
            }
            if (item.SellIn < 6)
            {
                IncrementItemQuality(item);
            }

            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - item.Quality;
                IncrementItemQuality(item);
            }
            
            return true;
        }

        private bool UpdateOthers(Item item)
        {
            if (item.Name != AgredBrie && item.Name != Backstage)
            {
                DecrementItemQuality(item);
            }
            else
            {
                IncrementItemQuality(item);
                if (item.Name == Backstage)
                {
                    if (item.SellIn < 11)
                    {
                        IncrementItemQuality(item);
                    }
                    if (item.SellIn < 6)
                    {
                        IncrementItemQuality(item);
                    }
                }
            }
            item.SellIn = item.SellIn - 1;
            if (item.SellIn < 0)
            {
                if (item.Name != AgredBrie)
                {
                    if (item.Name != Backstage)
                    {
                        DecrementItemQuality(item);
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    IncrementItemQuality(item);
                }
            }
            return true;
        }

        private void IncrementItemQuality(Item item)
        {
            if (item.Quality == 50)
            {
                return;
            }
            item.Quality += 1;
        }
        private void DecrementItemQuality(Item item)
        {
            if (item.Quality == 0)
            {
                return;
            }
            item.Quality -= 1;
        }
    }
}