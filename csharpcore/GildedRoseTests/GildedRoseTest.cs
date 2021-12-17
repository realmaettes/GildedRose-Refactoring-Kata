using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void ItemNameStaysTheSame()
        {
            var initialName = "Chocolate Cake";
            var initialSellIn = 7;
            var initialQuality = 11;
            IList<Item> Items = new List<Item> { new Item { Name = initialName, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            var expectedName = initialName;
            Assert.Equal(expectedName, Items[0].Name);
        }
        
        [Fact]
        public void SellInValueIsLowered()
        {
            var initialName = "Chocolate Cake";
            var initialSellIn = 7;
            var initialQuality = 11;
            IList<Item> Items = new List<Item> { new Item { Name = initialName, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            var expectedSellIn = initialSellIn-1;
            Assert.Equal(expectedSellIn, Items[0].SellIn);
        }
        
        [Fact]
        public void QualityValueIsLowered()
        {
            var initialName = "Chocolate Cake";
            var initialSellIn = 7;
            var initialQuality = 11;
            IList<Item> Items = new List<Item> { new Item { Name = initialName, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            var expectedQuality = initialQuality-1;
            Assert.Equal(expectedQuality, Items[0].Quality);
        }
        
        [Fact]
        public void QualityDegradesTwiceAsFastAfterSellByDateHasPassed()
        {
            var initialName = "Chocolate Cake";
            var initialSellIn = 0;
            var initialQuality = 11;
            IList<Item> Items = new List<Item> { new Item { Name = initialName, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            var expectedQuality = initialQuality-2;
            Assert.Equal(expectedQuality, Items[0].Quality);
        }
        
        [Fact]
        public void QualityIsNeverNegative()
        {
            var initialName = "Chocolate Cake";
            var initialSellIn = 0;
            var initialQuality = 0;
            IList<Item> Items = new List<Item> { new Item { Name = initialName, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            var expectedQuality = initialQuality;
            Assert.Equal(expectedQuality, Items[0].Quality);
        }
        
        [Fact]
        public void AgedBrieIncreasesInQuality()
        {
            var initialName = "Aged Brie";
            var initialSellIn = 2;
            var initialQuality = 10;
            IList<Item> Items = new List<Item> { new Item { Name = initialName, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            var expectedQuality = initialQuality+1;
            Assert.Equal(expectedQuality, Items[0].Quality);
        }
        
        [Fact]
        public void QualityIsNeverMoreThan50()
        {
            var initialName = "Aged Brie";
            var initialSellIn = 5;
            var initialQuality = 50;
            IList<Item> Items = new List<Item> { new Item { Name = initialName, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            var expectedQuality = initialQuality;
            Assert.Equal(expectedQuality, Items[0].Quality);
        }
        
        [Fact]
        public void QualityOfSulfurasStaysTheSame()
        {
            var initialName = "Sulfuras";
            var initialSellIn = 5;
            var initialQuality = 80;
            IList<Item> Items = new List<Item> { new Item { Name = initialName, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            var expectedQuality = initialQuality;
            Assert.Equal(expectedQuality, Items[0].Quality);
        }
        
        [Fact]
        public void SulfurasNeverHasToBeSold()
        {
            var initialName = "Sulfuras";
            var initialSellIn = 5;
            var initialQuality = 80;
            IList<Item> Items = new List<Item> { new Item { Name = initialName, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            var expectedSellIn = initialSellIn;
            Assert.Equal(expectedSellIn, Items[0].SellIn);
        }
        
        [Fact]
        public void BackStagePassesIncreaseInQuality()
        {
            var initialName = "Backstage passes to a Nightwish concert";
            var initialSellIn = 333;
            var initialQuality = 42;
            IList<Item> Items = new List<Item> { new Item { Name = initialName, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            var expectedQuality = initialQuality+1;
            Assert.Equal(expectedQuality, Items[0].Quality);
        }
        
        [Fact]
        public void QualityOfBackstagePassesIncreasesBy2WhenThereAre10DaysOrLess()
        {
            var initialName = "Backstage passes to a Nightwish concert";
            var initialSellIn = 10;
            var initialQuality = 42;
            IList<Item> Items = new List<Item> { new Item { Name = initialName, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            var expectedQuality = initialQuality+2;
            Assert.Equal(expectedQuality, Items[0].Quality);
        }
        
        [Fact]
        public void QualityOfBackstagePassesIncreasesBy3WhenThereAre5DaysOrLess()
        {
            var initialName = "Backstage passes to a Nightwish concert";
            var initialSellIn = 5;
            var initialQuality = 42;
            IList<Item> Items = new List<Item> { new Item { Name = initialName, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            var expectedQuality = initialQuality+3;
            Assert.Equal(expectedQuality, Items[0].Quality);
        }
        
        [Fact]
        public void QualityOfBackstagePassesDropsTo0AfterConcert()
        {
            var initialName = "Backstage passes to a Nightwish concert";
            var initialSellIn = 0;
            var initialQuality = 42;
            IList<Item> Items = new List<Item> { new Item { Name = initialName, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            var expectedQuality = 0;
            Assert.Equal(expectedQuality, Items[0].Quality);
        }
        
        [Fact]
        public void ConjuredItemsDegradeTwiceAsFast()
        {
            var initialName = "Conjured Chocolate Cake";
            var initialSellIn = 7;
            var initialQuality = 11;
            IList<Item> Items = new List<Item> { new Item { Name = initialName, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            var expectedQuality = initialQuality-2;
            Assert.Equal(expectedQuality, Items[0].Quality);
        }
        
        [Fact]
        public void BackstagePassesToASulfurasConcertShouldBeTreatedAsBackstagePasses()
        {
            var initialName = "Backstage passes to a Sulfuras concert";
            var initialSellIn = 333;
            var initialQuality = 42;
            IList<Item> Items = new List<Item> { new Item { Name = initialName, SellIn = initialSellIn, Quality = initialQuality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            var expectedQuality = initialQuality+1;
            Assert.Equal(expectedQuality, Items[0].Quality);
        }
    }
}
