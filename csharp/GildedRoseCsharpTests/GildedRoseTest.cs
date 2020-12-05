using FluentAssertions;
using GildedRoseCsharp;
using Xunit;

namespace GildedRoseCsharpTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void Test_regular_quality()
        {
            var items = new[] {new Item()
            {
                Name = "bread",
                SellIn = 20,
                Quality = 40
            }};

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            items[0].Quality.Should().Be(39);
        }

        [Fact]
        public void Test_regular_sell_in()
        {
            var items = new[]
            {
                new Item()
                {
                    Name = "bread",
                    SellIn = 20,
                    Quality = 40
                }
            };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            items[0].SellIn.Should().Be(19);
        }

        [Fact]
        public void Test_regular_sell_in_passed()
        {
            var items = new[]
            {
                new Item()
                {
                    Name = "bread",
                    SellIn = 0,
                    Quality = 40
                }
            };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            items[0].Quality.Should().Be(38);
        }

        [Fact]
        public void Test_regular_sell_in_negative()
        {
            var items = new[]
            {
                new Item()
                {
                    Name = "bread",
                    SellIn = 0,
                    Quality = 40
                }
            };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            items[0].SellIn.Should().Be(-1);
        }

        [Fact]
        public void Test_regular_quality_negative()
        {
            var items = new[]
            {
                    new Item()
                    {
                        Name = "bread",
                        SellIn = 0,
                        Quality = 0
                    }
                };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            items[0].Quality.Should().Be(0);
        }

        [Fact]
        public void Test_aged_brie_quality()
        {
            var items = new[]
            {
                new Item()
                {
                    Name = "Aged Brie",
                    SellIn = 10,
                    Quality = 2
                }
            };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            items[0].Quality.Should().Be(3);
        }

        [Fact]
        public void Test_aged_brie_sell_in()
        {
            var items = new[]
            {
                new Item()
                {
                    Name = "Aged Brie",
                    SellIn = 10,
                    Quality = 2
                }
            };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            items[0].SellIn.Should().Be(9);
        }

        [Fact]
        public void Test_aged_brie_quality_exceeded()
        {
            var items = new[]
            {
                new Item()
                {
                    Name = "Aged Brie",
                    SellIn = 10,
                    Quality = 50
                }
            };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            items[0].Quality.Should().Be(50);
        }

        [Fact]
        public void Test_sulfuras_quality_unvariated()
        {
            var items = new[]
            {
                new Item()
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = 10,
                    Quality = 40
                }
            };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            items[0].Quality.Should().Be(40);
        }

        [Fact]
        public void Test_sulfuras_sell_in_unvariated()
        {
            var items = new[]
            {
                new Item()
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = 10,
                    Quality = 40
                }
            };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            items[0].SellIn.Should().Be(10);
        }

        [Fact]
        public void Test_backstage_quality()
        {
            var items = new[]
            {
                new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 40
                }
            };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            items[0].Quality.Should().Be(41);
        }

        [Fact]
        public void Test_backstage_quality_double_increase()
        {
            var items = new[]
            {
                new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 40
                }
            };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            items[0].Quality.Should().Be(42);
        }

        [Fact]
        public void Test_backstage_quality_triple_increase()
        {
            var items = new[]
            {
                new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 2,
                    Quality = 40
                }
            };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            items[0].Quality.Should().Be(43);
        }

        [Fact]
        public void Test_backstage_quality_expires()
        {
            var items = new[]
            {
                new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = -6,
                    Quality = 40
                }
            };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            items[0].Quality.Should().Be(0);
        }

        [Fact]
        public void Test_backstage_quality_exceeded()
        {
            var items = new[]
            {
                new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                }
            };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            items[0].Quality.Should().Be(50);
        }

        [Fact]
        public void Test_backstage_sell_in()
        {
            var items = new[]
            {
                new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 6,
                    Quality = 40
                }
            };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            items[0].SellIn.Should().Be(5);
        }

        [Fact]
        public void Test_conjured_quality()
        {
            var items = new[]
            {
                new Item()
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 6,
                    Quality = 2
                }
            };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            items[0].SellIn.Should().Be(0);
        }

        [Fact]
        public void Test_conjured_sell_in()
        {
            var items = new[]
            {
                new Item()
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 6,
                    Quality = 40
                }
            };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();
            items[0].SellIn.Should().Be(5);
        }
    }
}