using System;

[Serializable]
public class InventorySlot 
{
    public readonly int IdSlot;

    public InventoryItem CurrentItem;
    public Action<int> Added;
    public Action<int> Removed;
    public InventorySlot(int numberSlot)
    {
        IdSlot = numberSlot;
    }
    public bool IsEmpty => CurrentItem == null;
    public bool IsFull => !IsEmpty && CurrentItem.CurrentAmount == CurrentItem.DefaultCapacityPerSlot;

    public virtual void Add(InventoryItem item, int amount) 
    {
        CurrentItem = item;
        CurrentItem.CurrentAmount += amount;
        Added?.Invoke(CurrentItem.CurrentAmount);
    }
    public virtual void Remove(int amount)
    {
        CurrentItem.CurrentAmount -= amount;
        Removed?.Invoke(CurrentItem.CurrentAmount);
        if (CurrentItem.CurrentAmount == 0)
        {
            CurrentItem = null;
        }
    }
}
