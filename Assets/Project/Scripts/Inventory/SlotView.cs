using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotView : MonoBehaviour,
        IDropHandler
{
    [SerializeField] private Image _image;

    public InventorySlot Model;

    [SerializeField] private ItemView _prefab;

    private ItemView _currentItemInSlot;

    public void Setup(InventorySlot model)
    {
        Model = model;
        Model.Added = OnAdded;
        Model.Removed = OnRemoved;
        if(!Model.IsEmpty)
            OnAdded(Model.CurrentItem.CurrentAmount);
    }

    public void OnAdded(int currentAmount) 
    {
        if (currentAmount>0)
        {
            _currentItemInSlot = Instantiate(_prefab, transform);
            _currentItemInSlot.Setup(Model.CurrentItem);
        }
    }
    public void OnRemoved(int currentAmount)
    {
        if (currentAmount == 0)
        {
            Destroy(_currentItemInSlot.gameObject);
        }
        else
        {
            _currentItemInSlot.UpdateValue(currentAmount);
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
       if(eventData.pointerDrag.TryGetComponent(out ItemView itemView) && Model.CurrentItem == null)
       {
            //if(Model.CurrentItem == null)
            //{
            //    itemView.SetupNewParent(transform);
            //    Model.Add(itemView.Model, itemView.Model.CurrentAmount);
            //    itemView.Model.CurrentAmount.TakeNeed(itemView.Model.CurrentAmount);
               
            //}
            //else if(Model.CurrentItem != null && !Model.IsFull
            //    && Model.CurrentItem == itemView.Model
            //    && Model.CurrentItem.CurrentAmount + itemView.Model.CurrentAmount <= itemView.Model.DefaultCapacityPerSlot) 
            //{
            //    itemView.SetupNewParent(transform);
            //    Model.Add(itemView.Model, itemView.Model.CurrentAmount);
            //    itemView.Model.CurrentAmount.TakeNeed(itemView.Model.CurrentAmount);
                
            //}
          
       }

    }
}
