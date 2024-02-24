using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BackpackView : MonoBehaviour
{
    [SerializeField] private Transform _slotsContent;
    [SerializeField] private SlotView _prefabSlotView;

    [SerializeField] private GridLayoutGroup  _gridLayoutGroup;

    [SerializeField] private InventoryRepository _inventoryRepository;
    [SerializeField] private ItemRepository _itemRepository;
    [SerializeField] private InventoryId _inventoryId;

    private List<SlotView> _createdSlotsView = new List<SlotView>();

    private void Start()
    {
        CreateInventory();
    }

    private void CreateInventory()
    {
        var model = _inventoryRepository.GetById(_inventoryId);
        var remote = model.RemoteConfigDto;
        var startItemData = model.Configuration.InventoryStartData;
        model.CreateSlots(remote.InventoryAmountOfSlots);
        _gridLayoutGroup.constraintCount = remote.NumberOfColumnsInventory;

        foreach (var data in startItemData)
        {
            var slot = model.Slots.FirstOrDefault(x => x.IdSlot == data.NumberSlot);
            if(slot != null)
            {
                var item = _itemRepository.GetById(data.ItemId);
                slot.Add(new InventoryItem(item.Configuration.Id, item.RemoteConfigDto.DefaultCapacityPerSlot, item.Configuration.Icon), data.AmountItems);
            }
        }
      
        for (int i = 0; i < remote.InventoryAmountOfSlots; i++)
        {
            var slot = Instantiate(_prefabSlotView, _slotsContent);
            slot.Setup(model.Slots.First(x => x.IdSlot == i));
            _createdSlotsView.Add(slot);
        }

    }
}
