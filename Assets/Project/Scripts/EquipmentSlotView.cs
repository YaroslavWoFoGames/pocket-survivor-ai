using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class EquipmentSlotView : MonoBehaviour,
  IDropHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private ItemView _prefab;
    [SerializeField] private TextMeshProUGUI _armorValue;
    [SerializeField] private TextMeshProUGUI _namePart;
    [SerializeField] private Image _partIcon;

   public EquipmentSlot Model;


    private ItemView _currentItemInSlot;

    public void Setup(EquipmentSlot model, Sprite icon)
    {
        Model = model;
        _partIcon.sprite = icon;
        UpdateView();
    }

    private void UpdateView()
    {
        if (!Model.IsEmpty)
        {
            _currentItemInSlot.Setup(Model.CurrentItem);
        }

        _namePart.text = LocalizationService.GetTextTranslation(Model.AcceptableId);
    }

 
    public void OnDrop(PointerEventData eventData)
    {
       
    }
}
