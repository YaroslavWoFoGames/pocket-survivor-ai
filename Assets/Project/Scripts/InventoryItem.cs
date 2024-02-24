using System.Collections.Generic;
using System;
using UnityEngine;
public class InventoryItem : IComparer<InventoryItem>, IComparable<InventoryItem>
{
    public readonly ItemId ItemId;
    public readonly int DefaultCapacityPerSlot;
    public readonly Sprite Icon;

    public GameValue CurrentAmount = 0;

    public InventoryItem(ItemId itemId, int defaultCapacityPerSlot, Sprite icon)
    {
        ItemId = itemId;
        DefaultCapacityPerSlot = defaultCapacityPerSlot;
        Icon = icon;
    }

    public int Compare(InventoryItem x, InventoryItem y)
    {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;

        return string.Compare(x.ItemId, y.ItemId, StringComparison.InvariantCultureIgnoreCase);
    }

    public int CompareTo(InventoryItem other)
    {
        if (other == null) return 1;

        return string.Compare(ItemId, other.ItemId, StringComparison.InvariantCultureIgnoreCase);
    }
}
