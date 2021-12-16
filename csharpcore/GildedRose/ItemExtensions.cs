using System;

namespace GildedRoseKata;

public static class ItemExtensions
{
    private const int MaxQuality = 50;

    private enum ItemType { Default, AgedBrie, Sulfuras, BackstagePasses, Conjured };
    
    private static ItemType GetItemType(this Item item)
    {
        if (item.Name.Contains("Sulfuras"))
        {
            return ItemType.Sulfuras;
        }
        
        if (item.Name.Contains("Backstage passes"))
        {
            return ItemType.BackstagePasses;
        }
        
        if (item.Name.Equals("Aged Brie"))
        {
            return ItemType.AgedBrie;
        }

        return item.Name.Contains("Conjured") ? ItemType.Conjured : ItemType.Default;
    }
    
    private static int GetQualityChange(this Item item)
    {
        switch (item.GetItemType())
        {
            case ItemType.Sulfuras:
            {
                return 0;
            }
            case ItemType.BackstagePasses:
            case ItemType.AgedBrie:
            {
                return 1;
            }
            case ItemType.Conjured:
            {
                return -2;
            }
            case ItemType.Default:
            default:
            {
                return -1;   
            }
        }
    }

    public static void UpdateQuality(this Item item)
    {
        switch (item.GetItemType())
        {
            case ItemType.Sulfuras:
            {
                return;
            }
            case ItemType.BackstagePasses:
            {
                switch (item.SellIn)
                {
                    case > 10:
                        item.ChangeQualityBy(1);
                        break;
                    case <= 10 and > 5:
                        item.ChangeQualityBy(2);
                        break;
                    case <= 5 and > 0:
                        item.ChangeQualityBy(3);
                        break;
                    default:
                        item.Quality = 0;
                        break;
                }
                item.SellIn--;

                return;
            }
            case ItemType.AgedBrie:
            case ItemType.Conjured:
            case ItemType.Default:
            default:
            {
                if (item.SellIn > 0)
                {
                    item.ChangeQualityBy(item.GetQualityChange());    
                }
                else
                {
                    item.ChangeQualityBy(2*item.GetQualityChange());
                }
                item.SellIn--;
                return;
            }
        }
    }
    
    private static void ChangeQualityBy(this Item item, int numberToAdd)
    {
        item.Quality = Math.Max(0, Math.Min(MaxQuality, item.Quality + numberToAdd));
    }
}